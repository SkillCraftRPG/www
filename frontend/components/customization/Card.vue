<template>
  <LinkCard :subtitle="kind" :text="customization.summary" :title="customization.name" :to="`/regles/dons-handicaps/${customization.slug}`" />
</template>

<script setup lang="ts">
import type { Customization } from "~/types/game";

const props = defineProps<{
  customization: Customization;
}>();

const kind = computed<string>(() => {
  switch (props.customization.kind) {
    case "Disability":
      return "Handicap";
  }
  return "Don";
});
</script>
