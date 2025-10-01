<template>
  <h2 class="h3 mb-3">
    <span class="badge text-bg-secondary">Tiers&nbsp;:&nbsp;{{ $n(specialization.tier, "integer") }}</span>
  </h2>
</template>

<script setup lang="ts">
import type { Specialization } from "~/types/specializations";

defineProps<{
  specialization: Specialization;
}>();
</script>
