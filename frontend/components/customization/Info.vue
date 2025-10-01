<template>
  <h2 class="h3 mb-3">
    <span class="badge text-bg-secondary"><CustomizationKind :customization="customization" /></span>
  </h2>
</template>

<script setup lang="ts">
import type { Customization } from "~/types/game";

defineProps<{
  customization: Customization;
}>();
</script>
