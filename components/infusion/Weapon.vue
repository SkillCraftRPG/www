<template>
  <InfusionItem icon="fas fa-shield" :text="formattedText" />
</template>

<script setup lang="ts">
const props = withDefaults(
  defineProps<{
    property?: string;
    text?: string;
  }>(),
  {
    text: "Arme",
  },
);

const formattedText = computed<string>(() => {
  return props.property ? `${props.text} (${props.property})` : props.text;
});
</script>
