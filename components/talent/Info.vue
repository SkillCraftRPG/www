<template>
  <div class="h3 mb-3">
    <TarBadge class="me-1" variant="secondary">Tiers&nbsp;:&nbsp;{{ $n(talent.tier, "integer") }}</TarBadge>
    <TarBadge class="ms-1" variant="secondary">Achats&nbsp;multiples&nbsp;:&nbsp;<font-awesome-icon :icon="icon" />&nbsp;{{ text }}</TarBadge>
  </div>
</template>

<script setup lang="ts">
import type { Talent } from "~/types/game";

const props = defineProps<{
  talent: Talent;
}>();

const icon = computed<string>(() => (props.talent.allowMultiplePurchases ? "fas fa-check" : "fas fa-times"));
const text = computed<string>(() => $t(props.talent.allowMultiplePurchases ? "yes" : "no"));
</script>
