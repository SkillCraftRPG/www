<template>
  <div>
    <h2 class="h3">Arbre de talents</h2>
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
        <TalentTreeFlow />
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

import SkillIcon from "~/components/skill/Icon.vue";
import type { Talent, TalentNode, TalentTree } from "~/types/talents";

const nodeWidth = 150;
const columnGap = 36;
const rowGap = 120;

const config = useRuntimeConfig();
const flowId = useId();

const props = defineProps<{
  talent: Talent;
}>();

type TalentTreeNodeData = {
  allowMultiplePurchases: boolean;
  name: string;
  skill?: string | null;
  summary?: string | null;
  tier: number;
};

const hoveredNodeId = ref<string>();
provide("talentTreeHoveredId", hoveredNodeId);

const TalentTreeLabel = markRaw(
  defineComponent({
    name: "TalentTreeLabel",
    setup() {
      const { node, nodeEl } = useNode<TalentTreeNodeData>();
      const hoveredId = inject<Ref<string | undefined>>("talentTreeHoveredId");

      return () => {
        const lines: VNode[] = [];
        if (node.data.summary) {
          lines.push(h("div", node.data.summary));
        }
        if (node.data.skill) {
          lines.push(h("div", [h(SkillIcon), "\u00A0", node.data.skill]));
        }
        if (node.data.allowMultiplePurchases) {
          lines.push(h("div", { class: "fst-italic" }, "Achats\u00A0multiples"));
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

const TalentTreeFlow = defineComponent({
  name: "TalentTreeFlow",
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

const { data } = await useLazyAsyncData<TalentTree>(
  `talent:${props.talent.slug}:tree`,
  () =>
    $fetch(`/api/talents/${props.talent.id}/tree`, {
      baseURL: config.public.apiBaseUrl,
    }),
  {
    server: false,
    watch: [() => props.talent.id],
  },
);

const talents = computed<TalentNode[]>(() => data.value?.nodes ?? []);
const graph = computed<{ edges: Edge[]; nodes: Node<TalentTreeNodeData>[] }>(() => layout(talents.value, props.talent.id));
const edges = computed<Edge[]>(() => graph.value.edges);
const nodes = computed<Node[]>(() => graph.value.nodes);

function onNodeClick({ node }: NodeMouseEvent): void {
  const talent: TalentNode | undefined = talents.value.find((item) => item.id === node.id);
  if (!talent || talent.slug === props.talent.slug) {
    return;
  }
  navigateTo(`/regles/talents/${talent.slug}`);
}

function onNodeMouseEnter({ node }: NodeMouseEvent): void {
  hoveredNodeId.value = node.id;
}

function onNodeMouseLeave(): void {
  hoveredNodeId.value = undefined;
}

function layout(talents: TalentNode[], currentId: string): { edges: Edge[]; nodes: Node<TalentTreeNodeData>[] } {
  const byId = new Map<string, TalentNode>(talents.map((talent) => [talent.id, talent]));
  const root: TalentNode | undefined = talents.find((talent) => !talent.parent || !byId.has(talent.parent));
  if (!root) {
    return { edges: [], nodes: [] };
  }

  const centers = new Map<string, { x: number; y: number }>();
  let cursor = 0;
  const stride = nodeWidth + columnGap;

  const place = (talent: TalentNode, depth: number): { left: number; right: number } => {
    const children: TalentNode[] = [];
    for (const id of talent.children) {
      const child: TalentNode | undefined = byId.get(id);
      if (child) {
        children.push(child);
      }
    }
    children.sort((left, right) => left.name.localeCompare(right.name, "fr") || left.slug.localeCompare(right.slug, "fr"));

    const y = depth * rowGap;
    if (children.length === 0) {
      const x = cursor;
      cursor += stride;
      centers.set(talent.id, { x, y });
      return { left: x, right: x };
    }

    const spans: { left: number; right: number }[] = children.map((child) => place(child, depth + 1));
    const left = spans[0]?.left ?? 0;
    const right = spans[spans.length - 1]?.right ?? left;
    const x = (left + right) / 2;
    centers.set(talent.id, { x, y });
    return { left, right };
  };

  place(root, 0);
  const rootCenter: number = centers.get(root.id)?.x ?? 0;
  const nodes: Node<TalentTreeNodeData>[] = [];
  const edges: Edge[] = [];

  for (const talent of talents) {
    const center = centers.get(talent.id);
    if (!center) {
      continue;
    }

    nodes.push({
      id: talent.id,
      position: { x: center.x - rootCenter - nodeWidth / 2, y: center.y },
      type: nodeType(talent),
      data: {
        allowMultiplePurchases: talent.allowMultiplePurchases,
        name: talent.name,
        skill: talent.skill,
        summary: talent.summary,
        tier: talent.tier,
      },
      label: TalentTreeLabel,
      width: nodeWidth,
      class: talent.id === currentId ? "is-current" : undefined,
      deletable: false,
    });

    for (const childId of talent.children) {
      if (!byId.has(childId)) {
        continue;
      }
      edges.push({
        id: `${talent.id}:${childId}`,
        source: talent.id,
        target: childId,
        type: "smoothstep",
      });
    }
  }

  return { edges, nodes };
}

function nodeType(talent: TalentNode): "default" | "input" | "output" {
  if (!talent.parent) {
    return "input";
  }
  return talent.children.length > 0 ? "default" : "output";
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
