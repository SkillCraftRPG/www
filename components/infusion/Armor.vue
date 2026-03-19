<template>
  <InfusionItem icon="fas fa-shield" :text="text" />
</template>

<script setup lang="ts">
withDefaults(
  defineProps<{
    text?: string;
  }>(),
  {
    text: "Armure",
  },
);
</script>
