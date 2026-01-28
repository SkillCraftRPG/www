<template>
  <div>
    <h2 class="h3">
      Particularité&nbsp;:&nbsp;<i>{{ feature.name }}</i>
    </h2>
    <MarkdownContent v-if="feature.htmlContent" :text="feature.htmlContent" />
  </div>
</template>

<script setup lang="ts">
import type { Feature } from "~/types/game";

defineProps<{
  feature: Feature;
}>();
</script>
