<template>
  <span class="kind"
    ><template v-if="icon"><font-awesome-icon :icon="icon" />&nbsp;</template>{{ text }}</span
  >
</template>

<script setup lang="ts">
import type { Customization } from "~/types/game";

const props = defineProps<{
  customization: Customization;
}>();

const icon = computed<string | undefined>(() => {
  switch (props.customization.kind) {
    case "Disability":
      return "fas fa-wheelchair";
    case "Gift":
      return "fas fa-trophy";
  }
});
const text = computed<string>(() => $t(`customization.kind.options.${props.customization.kind}`));
</script>

<style scoped>
.kind {
  white-space: nowrap;
}
</style>
