<template>
  <NuxtLink :to="`/regles/dons-handicaps/${customization.slug}`" class="card clickable">
    <div class="card-body">
      <div class="card-title h5">{{ customization.name }}</div>
      <h3 class="card-subtitle h6 mb-2 text-body-secondary">{{ kind }}</h3>
      <div v-if="customization.summary" class="card-text">{{ customization.summary }}</div>
    </div>
  </NuxtLink>
</template>

<script setup lang="ts">
import type { Customization } from "~/types/game";

const props = defineProps<{
  customization: Customization;
}>();

const kind = computed<string>(() => {
  switch (props.customization.kind) {
    case "Disability":
      return "Handicap";
  }
  return "Don";
});
</script>
