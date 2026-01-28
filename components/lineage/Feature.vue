<template>
  <div>
    <h3 class="h5">{{ feature.name }}</h3>
    <MarkdownContent v-if="feature.htmlContent" :text="feature.htmlContent" />
  </div>
</template>

<script setup lang="ts">
import type { Feature } from "~/types/game";

defineProps<{
  feature: Feature;
}>();
</script>
