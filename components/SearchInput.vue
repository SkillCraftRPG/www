<template>
  <TarInput
    :floating="floating"
    :id="id"
    :label="label"
    :model-value="modelValue"
    :placeholder="placeholder"
    :type="type"
    @update:model-value="$emit('update:model-value', $event)"
  />
</template>

<script setup lang="ts">
import type { InputType } from "~/types/tar/input";

withDefaults(
  defineProps<{
    floating?: boolean | string;
    id?: string;
    label?: string;
    modelValue?: string;
    placeholder?: string;
    type?: InputType;
  }>(),
  {
    floating: true,
    id: "search",
    label: "Recherche",
    placeholder: "Recherche",
    type: "search",
  },
);

defineEmits<{
  (e: "update:model-value", value?: string): void;
}>();
</script>
