<template>
  <TarBadge><font-awesome-icon icon="fas fa-shield" />&nbsp;{{ formattedText }}</TarBadge>
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
