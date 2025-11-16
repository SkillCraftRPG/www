<template>
  <div class="h3 mb-3">
    <TarBadge variant="secondary"><CustomizationKind :customization="customization" /></TarBadge>
  </div>
</template>

<script setup lang="ts">
import type { Customization } from "~/types/game";

defineProps<{
  customization: Customization;
}>();
</script>
