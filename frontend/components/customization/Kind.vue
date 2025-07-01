<template>
  <span class="kind"><font-awesome-icon :icon="icon" />&nbsp;{{ text }}</span>
</template>

<script setup lang="ts">
import type { Customization } from "~/types/game";

const props = defineProps<{
  customization: Customization;
}>();

const icon = computed<string>(() => {
  switch (props.customization.kind) {
    case "Disability":
      return "fas fa-wheelchair";
  }
  return "fas fa-hand-fist";
});
const text = computed<string>(() => {
  switch (props.customization.kind) {
    case "Disability":
      return "Handicap";
  }
  return "Don";
});
</script>

<style scoped>
.kind {
  white-space: nowrap;
}
</style>
