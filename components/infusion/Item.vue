<template>
  <TarBadge>
    <template v-if="icon"><font-awesome-icon :icon="icon" />&nbsp;</template>{{ text }}
  </TarBadge>
</template>

<script setup lang="ts">
defineProps<{
  icon?: string;
  text: string;
}>();
</script>
