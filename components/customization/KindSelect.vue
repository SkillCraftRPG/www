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
import type { SelectOption } from "~/types/tar/select";

const options: SelectOption[] = [
  {
    text: $t("customization.kind.options.Gift"),
    value: "Gift",
  },
  {
    text: $t("customization.kind.options.Disability"),
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
