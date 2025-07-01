<template>
  <TarSelect
    :floating="floating"
    :id="id"
    :label="label"
    :model-value="modelValue"
    :options="options"
    :placeholder="placeholder"
    @update:model-value="$emit('update:model-value', $event)"
  />
</template>

<script setup lang="ts">
import { TarSelect, type SelectOption } from "logitar-vue3-ui";

const options: SelectOption[] = [
  {
    text: "Don",
    value: "Gift",
  },
  {
    text: "Handicap",
    value: "Disability",
  },
];

withDefaults(
  defineProps<{
    floating?: boolean | string;
    id?: string;
    label?: string;
    modelValue?: string;
    placeholder?: string;
  }>(),
  {
    floating: true,
    id: "kind",
    label: "Type",
    placeholder: "Sélectionnez un type de personnalisation",
  },
);

defineEmits<{
  (e: "update:model-value", value?: string): void;
}>();
</script>
