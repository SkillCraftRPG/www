<template>
  <div class="h3 mb-3">
    <TarBadge v-if="caste.wealthRoll" variant="secondary">Richesse&nbsp;de&nbsp;départ&nbsp;:&nbsp;{{ caste.wealthRoll }}&nbsp;({{ average }})</TarBadge>
  </div>
</template>

<script setup lang="ts">
import type { Caste } from "~/types/game";

const props = defineProps<{
  caste: Caste;
}>();

const average = computed<number | undefined>(() => {
  const wealthRoll = props.caste.wealthRoll ?? "";
  const parts: string[] = wealthRoll.split("d");
  const dice: number = Number(parts[0]);
  const sides: number = Number(parts[1]);
  if (isNaN(dice) || isNaN(sides) || dice <= 0 || sides <= 0) {
    return undefined;
  }
  const average: number = (sides + 1) / 2;
  return Math.floor(dice * average);
});
</script>
