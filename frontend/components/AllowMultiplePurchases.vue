<template>
  <span><font-awesome-icon :icon="icon" /> {{ text }}</span>
</template>

<script lang="ts" setup>
import type { Talent } from "~/types/game";

const props = defineProps<{
  talent: Talent;
}>();

const icon = computed<string>(() => (props.talent.allowMultiplePurchases ? "fas fa-check" : "fas fa-times"));
const text = computed<string>(() => (props.talent.allowMultiplePurchases ? "Oui" : "Non"));
</script>
