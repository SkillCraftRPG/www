<template>
  <TarBadge><font-awesome-icon icon="fas fa-shield" />&nbsp;{{ text }}</TarBadge>
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
