<template>
  <LinkCard :text="customization.summary" :title="customization.name" :to="`/regles/dons-handicaps/${customization.slug}`">
    <template #subtitle-override>
      <h3 class="card-subtitle h6 mb-2 text-body-secondary">
        <CustomizationKind :customization="customization" />
      </h3>
    </template>
  </LinkCard>
</template>

<script setup lang="ts">
import type { Customization } from "~/types/game";

defineProps<{
  customization: Customization;
}>();
</script>
