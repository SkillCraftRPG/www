<template>
  <h2 class="h3 mb-3">
    <span v-if="education.wealthMultiplier" class="badge text-bg-secondary"
      >Richesse de départ&nbsp;:&nbsp;×{{ $n(education.wealthMultiplier, "integer") }}</span
    >
  </h2>
</template>

<script setup lang="ts">
import type { Education } from "~/types/game";

defineProps<{
  education: Education;
}>();
</script>
