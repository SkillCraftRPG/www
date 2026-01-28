<template>
  <ClientOnly>
    <div class="row">
      <div v-for="lineage in lineages" :key="lineage.id" :class="classes">
        <LineageCard class="d-flex flex-column h-100" :lineage="lineage" />
      </div>
    </div>
  </ClientOnly>
</template>

<script setup lang="ts">
import { parsingUtils } from "logitar-js";

import type { Lineage } from "~/types/lineages";

const { parseNumber } = parsingUtils;

const props = defineProps<{
  cols?: number | string | null;
  items: Lineage[];
}>();

const classes = computed<string[]>(() => {
  const classes: string[] = ["mb-4", "col-xs-12"];
  const cols: number | undefined = parseNumber(props.cols ?? undefined) ?? 0;
  if (cols >= 2) {
    classes.push("col-sm-6");
  }
  if (cols >= 3) {
    classes.push("col-md-4");
  }
  if (cols >= 4) {
    classes.push("col-lg-3");
  }
  return classes;
});
const lineages = computed<Lineage[]>(() => props.items);
</script>
