<script setup lang="ts">
import { TarAvatar, TarProgress, parsingUtils, type ProgressVariant } from "logitar-vue3-ui";
import { computed } from "vue";

import DownloadList from "./DownloadList.vue";
import type { ProgressItem } from "@/types";

const dateFormatter = new Intl.DateTimeFormat("fr-CA", { dateStyle: "full", timeStyle: "short" });
const maximumLevel: number = parsingUtils.parseNumber(import.meta.env.VITE_APP_MAXIMUM_LEVEL) ?? 0;

const props = withDefaults(
  defineProps<{
    item: ProgressItem;
    level?: string | number;
  }>(),
  {
    level: 0,
  },
);

function calculateProgress(item: ProgressItem, weight?: number): number {
  let value: number = 0;
  if (item.children && item.children.length > 0) {
    for (let child of item.children) {
      value += calculateProgress(child, item.children.length);
    }
  } else if (item.value) {
    value = item.value;
  }
  return value * (item.weight ?? weight ?? 1);
}

const classes = computed<string[]>(() => {
  const classes = ["mb-3"];
  if (parsedLevel.value === 1) {
    classes.push("root-progress");
  }
  return classes;
});
const parsedLevel = computed<number>(() => parsingUtils.parseNumber(props.level) ?? 0);
const updatedOn = computed<string | undefined>(() => {
  if (props.level === 0 && props.item.updatedOn) {
    return dateFormatter.format(new Date(props.item.updatedOn));
  }
  return undefined;
});
const value = computed<number>(() => (calculateProgress(props.item) * 100) / (props.item.weight ?? 1));
const variant = computed<ProgressVariant>(() => {
  const step: number = Math.floor(value.value / 20);
  switch (step) {
    case 0:
      return "danger";
    case 1:
      return "warning";
    case 2:
      return "info";
    case 3:
      return "primary";
    default:
      return "success";
  }
});
</script>

<template>
  <div>
    <h1 v-if="parsedLevel === 0" class="text-center">{{ item.name ?? item.key }}</h1>
    <h2 v-else-if="parsedLevel === 1">{{ item.name ?? item.key }}</h2>
    <h3 v-else-if="parsedLevel === 2">{{ item.name ?? item.key }}</h3>
    <h4 v-else-if="parsedLevel === 3">{{ item.name ?? item.key }}</h4>
    <h5 v-else-if="parsedLevel === 4">{{ item.name ?? item.key }}</h5>
    <h6 v-else>{{ item.name ?? item.key }}</h6>
    <DownloadList v-if="parsedLevel <= 0" />
    <TarProgress v-else :class="classes" :animated="value > 0" :label="`${value.toFixed(2)} %`" min="0" max="100" striped :value="value" :variant="variant" />
    <template v-if="parsedLevel < maximumLevel">
      <ProgressItem v-for="child in item.children" :key="child.key" :item="child" :level="parsedLevel + 1" />
    </template>
    <div v-if="parsedLevel === 0 && updatedOn">
      Dernière modification le {{ updatedOn }} par
      <a href="https://www.francispion.ca/" target="_blank">Francis Pion</a>
      {{ " " }}
      <a href="https://www.francispion.ca/" target="_blank">
        <TarAvatar display-name="Francis Pion" url="https://www.francispion.ca/assets/img/profile-img.jpg" />
      </a>
    </div>
  </div>
</template>

<style scoped>
.root-progress {
  height: 3rem;
}
</style>
