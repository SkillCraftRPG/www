<template>
  <div>
    <h2 class="h3">
      Particularité&nbsp;:&nbsp;<i>{{ feature.name }}</i>
    </h2>
    <MarkdownContent v-if="feature.description" :text="feature.description" />
  </div>
</template>

<script setup lang="ts">
import type { Feature } from "~/types/game";

defineProps<{
  feature: Feature;
}>();
</script>
