<template>
  <h2 class="h3 mb-3">
    <TarBadge v-if="education.wealthMultiplier" variant="secondary"
      >Richesse&nbsp;de&nbsp;départ&nbsp;:&nbsp;×{{ $n(education.wealthMultiplier, "integer") }}</TarBadge
    >
  </h2>
</template>

<script setup lang="ts">
import type { Education } from "~/types/game";

defineProps<{
  education: Education;
}>();

// TODO(fpion): should not contain a H2!
</script>
