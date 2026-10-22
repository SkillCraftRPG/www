<template>
  <div v-if="specializations.length > 1">
    <h2 class="h3">Arbre</h2>
    <div class="tree">
      <VueFlow
        :id="flowId"
        :delete-key-code="null"
        :edges-updatable="false"
        :elements-selectable="false"
        :nodes="nodes"
        :nodes-connectable="false"
        :nodes-draggable="false"
        @node-click="onNodeClick"
        @node-mouse-enter="onNodeMouseEnter"
        @node-mouse-leave="onNodeMouseLeave"
      >
        <SpecializationTreeFlow />
        <Controls :fit-view-params="{ padding: 0.2 }" />
      </VueFlow>
    </div>
  </div>
</template>

<script setup lang="ts">
import type { Edge, Node, NodeMouseEvent } from "@vue-flow/core";
import type { Ref, VNode } from "vue";
import { Controls } from "@vue-flow/controls";
import { NodeToolbar } from "@vue-flow/node-toolbar";
import { Position, useNode, useVueFlow } from "@vue-flow/core";

import DoctrineIcon from "~/components/doctrine/Icon.vue";
import type { Specialization, SpecializationNode, SpecializationTree } from "~/types/specializations";

const nodeWidth = 150;
const columnGap = 36;
const rowGap = 120;

const config = useRuntimeConfig();
const flowId = useId();

const props = defineProps<{
  specialization: Specialization;
}>();

type SpecializationTreeNodeData = {
  doctrine?: string | null;
  name: string;
  summary?: string | null;
  tier: number;
};

const hoveredNodeId = ref<string>();
provide("specializationTreeHoveredId", hoveredNodeId);

const SpecializationTreeLabel = markRaw(
  defineComponent({
    name: "SpecializationTreeLabel",
    setup() {
      const { node, nodeEl } = useNode<SpecializationTreeNodeData>();
      const hoveredId = inject<Ref<string | undefined>>("specializationTreeHoveredId");

      return () => {
        const lines: VNode[] = [];
        if (node.data.doctrine) {
          lines.push(h("div", { class: "fw-semibold" }, [h(DoctrineIcon), "\u00A0", node.data.doctrine]));
        }
        if (node.data.summary) {
          lines.push(h("div", node.data.summary));
        }

        const flow = nodeEl.value?.closest(".vue-flow");
        let position = Position.Top;
        if (flow && nodeEl.value) {
          const flowRect = flow.getBoundingClientRect();
          const nodeRect = nodeEl.value.getBoundingClientRect();
          const spaceAbove = nodeRect.top - flowRect.top;
          const spaceBelow = flowRect.bottom - nodeRect.bottom;
          if (spaceAbove < 72 && spaceBelow > spaceAbove) {
            position = Position.Bottom;
          }
        }

        return h("div", [
          h(NodeToolbar, { isVisible: hoveredId?.value === node.id && lines.length > 0, position }, () => h("div", lines)),
          h("div", node.data.name),
          h("div", { class: "mt-1 fst-italic fw-normal text-body-secondary" }, `Tiers ${node.data.tier}`),
        ]);
      };
    },
  }),
);

const SpecializationTreeFlow = defineComponent({
  name: "SpecializationTreeFlow",
  setup() {
    const { fitView, onNodesInitialized, setEdges } = useVueFlow();

    onNodesInitialized((initialized) => {
      if (initialized.length === 0) {
        return;
      }
      setEdges(edges.value);
      fitView({ padding: 0.2 });
    });

    return () => null;
  },
});

const { data } = await useLazyAsyncData<SpecializationTree>(
  `specialization:${props.specialization.slug}:tree`,
  () =>
    $fetch(`/api/specializations/${props.specialization.id}/tree`, {
      baseURL: config.public.apiBaseUrl,
    }),
  {
    server: false,
    watch: [() => props.specialization.id],
  },
);

const specializations = computed<SpecializationNode[]>(() => data.value?.nodes ?? []);
const graph = computed<{ edges: Edge[]; nodes: Node<SpecializationTreeNodeData>[] }>(() => layout(specializations.value, props.specialization.id));
const edges = computed<Edge[]>(() => graph.value.edges);
const nodes = computed<Node[]>(() => graph.value.nodes);

function onNodeClick({ node }: NodeMouseEvent): void {
  const specialization: SpecializationNode | undefined = specializations.value.find((item) => item.id === node.id);
  if (!specialization || specialization.slug === props.specialization.slug) {
    return;
  }
  navigateTo(`/regles/specialisations/${specialization.slug}`);
}

function onNodeMouseEnter({ node }: NodeMouseEvent): void {
  hoveredNodeId.value = node.id;
}

function onNodeMouseLeave(): void {
  hoveredNodeId.value = undefined;
}

function layout(specializations: SpecializationNode[], currentId: string): { edges: Edge[]; nodes: Node<SpecializationTreeNodeData>[] } {
  const byId = new Map<string, SpecializationNode>(specializations.map((specialization) => [specialization.id, specialization]));
  const tiers: number[] = [...new Set(specializations.map((specialization) => specialization.tier))].sort((left, right) => left - right);
  const minTier: number = tiers[0] ?? 0;
  const centers = new Map<string, number>();
  const stride = nodeWidth + columnGap;

  const placedParents = (specialization: SpecializationNode): SpecializationNode[] => {
    const parents: SpecializationNode[] = [];
    for (const id of specialization.parents) {
      const parent: SpecializationNode | undefined = byId.get(id);
      if (parent && centers.has(parent.id)) {
        parents.push(parent);
      }
    }
    return parents;
  };

  for (const tier of tiers) {
    const keyed: { center?: number; node: SpecializationNode }[] = specializations
      .filter((specialization) => specialization.tier === tier)
      .map((specialization) => {
        const parents: SpecializationNode[] = placedParents(specialization);
        if (parents.length === 0) {
          return { node: specialization };
        }
        const center: number = parents.reduce((sum, parent) => sum + (centers.get(parent.id) ?? 0), 0) / parents.length;
        return { center, node: specialization };
      });

    keyed.sort((left, right) => {
      if (left.center === undefined && right.center === undefined) {
        return compareName(left.node, right.node);
      }
      if (left.center === undefined) {
        return 1;
      }
      if (right.center === undefined) {
        return -1;
      }
      return left.center - right.center || compareName(left.node, right.node);
    });

    const preferred: number[] = keyed.every((item) => item.center === undefined)
      ? keyed.map((_, index) => (index - (keyed.length - 1) / 2) * stride)
      : keyed.map((item, index) => item.center ?? index * stride);
    const placed: number[] = pack(preferred, stride);
    keyed.forEach((item, index) => centers.set(item.node.id, placed[index] ?? 0));
  }

  const nodes: Node<SpecializationTreeNodeData>[] = [];
  const edges: Edge[] = [];

  for (const specialization of specializations) {
    const center: number | undefined = centers.get(specialization.id);
    if (center === undefined) {
      continue;
    }

    nodes.push({
      id: specialization.id,
      position: { x: center - nodeWidth / 2, y: (specialization.tier - minTier) * rowGap },
      type: nodeType(specialization, byId),
      data: {
        doctrine: specialization.doctrine,
        name: specialization.name,
        summary: specialization.summary,
        tier: specialization.tier,
      },
      label: SpecializationTreeLabel,
      width: nodeWidth,
      class: specialization.id === currentId ? "is-current" : undefined,
      deletable: false,
    });

    for (const childId of specialization.children) {
      if (!byId.has(childId)) {
        continue;
      }
      edges.push({
        id: `${specialization.id}:${childId}`,
        source: specialization.id,
        target: childId,
        type: "smoothstep",
      });
    }
  }

  return { edges, nodes };
}

function compareName(left: SpecializationNode, right: SpecializationNode): number {
  return left.name.localeCompare(right.name, "fr") || left.slug.localeCompare(right.slug, "fr");
}

function pack(preferred: number[], stride: number): number[] {
  const count: number = preferred.length;
  if (count === 0) {
    return [];
  }

  const xs: number[] = preferred.slice();
  for (let index = 1; index < count; index++) {
    const min: number = (xs[index - 1] ?? 0) + stride;
    if ((xs[index] ?? 0) < min) {
      xs[index] = min;
    }
  }

  const preferredMean: number = preferred.reduce((sum, value) => sum + value, 0) / count;
  const actualMean: number = xs.reduce((sum, value) => sum + value, 0) / count;
  const shift: number = preferredMean - actualMean;
  return xs.map((value) => value + shift);
}

function nodeType(specialization: SpecializationNode, byId: Map<string, SpecializationNode>): "default" | "input" | "output" {
  const hasParent: boolean = specialization.parents.some((id) => byId.has(id));
  if (!hasParent) {
    return "input";
  }
  const hasChild: boolean = specialization.children.some((id) => byId.has(id));
  return hasChild ? "default" : "output";
}
</script>

<style scoped>
.tree {
  width: 100%;
  height: 32rem;
  --vf-node-bg: var(--bs-body-bg);
  --vf-node-text: var(--bs-body-color);
}

[data-bs-theme="dark"] .tree :deep(.vue-flow__node-default) {
  --vf-node-color: var(--bs-border-color);
}

.tree :deep(.vue-flow__node) {
  cursor: pointer;
}

.tree :deep(.vue-flow__node.is-current) {
  font-weight: 700;
  cursor: default;
}

.tree :deep(.vue-flow__controls-button) {
  background: var(--bs-body-bg);
  border-bottom-color: var(--bs-border-color);
  color: var(--bs-body-color);
}

.tree :deep(.vue-flow__controls-button svg) {
  fill: currentColor;
}

.tree :deep(.vue-flow__controls-button:hover) {
  background: var(--bs-tertiary-bg);
}

.tree :deep(.vue-flow__node-toolbar) {
  max-width: 24rem;
  padding: 0.4rem 0.55rem;
  border: 1px solid var(--bs-border-color);
  border-radius: 0.375rem;
  background: rgba(var(--bs-body-bg-rgb), 0.875);
  color: var(--bs-body-color);
  font-size: 1rem;
  font-weight: 400;
  font-style: normal;
  line-height: 1.4;
  text-align: start;
  white-space: normal;
  pointer-events: none;
}
</style>
