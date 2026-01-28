<template>
  <div>
    <h3 class="h5">{{ feature.name }}</h3>
    <MarkdownContent v-if="feature.description" :text="feature.description" />
  </div>
</template>

<script setup lang="ts">
import type { Feature } from "~/types/game";

defineProps<{
  feature: Feature;
}>();
</script>
