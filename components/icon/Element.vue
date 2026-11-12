<template>
  <span>{{ icon }}</span>
</template>

<script setup lang="ts">
const props = defineProps<{
  element: string;
}>();

const icons = new Map<string, string>([
  ["air", "🜁"],
  ["eau", "🜄"],
  ["esprit", "Ω"],
  ["feu", "🜂"],
  ["terre", "🜃"],
]);
const icon = computed<string>(() => icons.get(props.element.trim().toLocaleLowerCase("fr")) ?? "");
</script>
