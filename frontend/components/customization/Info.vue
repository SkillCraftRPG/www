<template>
  <h2 class="h3 mb-3">
    <TarBadge variant="secondary"><CustomizationKind :customization="customization" /></TarBadge>
  </h2>
</template>

<script setup lang="ts">
import type { Customization } from "~/types/game";

defineProps<{
  customization: Customization;
}>();
</script>
