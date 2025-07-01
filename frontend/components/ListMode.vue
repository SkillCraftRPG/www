<template>
  <div class="d-flex justify-content-end">
    <div class="btn-group" role="group" aria-label="Mode">
      <TarButton :disabled="modelValue === 'grid'" icon="fas fa-grip" :outline="modelValue !== 'grid'" @click="setMode('grid')" />
      <TarButton :disabled="modelValue === 'list'" icon="fas fa-list" :outline="modelValue !== 'list'" @click="setMode('list')" />
    </div>
  </div>
</template>

<script setup lang="ts">
import { TarButton } from "logitar-vue3-ui";

import type { ListMode } from "~/types/components";

defineProps<{
  modelValue?: ListMode;
}>();

const emit = defineEmits<{
  (e: "update:model-value", value: ListMode): void;
}>();

function setMode(mode: ListMode): void {
  emit("update:model-value", mode);
}
</script>
