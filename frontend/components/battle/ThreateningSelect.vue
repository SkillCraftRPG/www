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
import { arrayUtils } from "logitar-js";

const { orderBy } = arrayUtils;

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
    id: "threatening",
    label: "Attaque d’opportunité",
    placeholder: "Tous",
  },
);

const options = ref<SelectOption[]>(
  orderBy(
    [
      { text: "Non / Peut-être", value: "no-maybe" },
      { text: "Non", value: "no" },
      { text: "Oui / Peut-être", value: "yes-maybe" },
      { text: "Oui", value: "yes" },
      { text: "Peut-être", value: "maybe" },
    ],
    "text",
  ),
);

defineEmits<{
  (e: "update:model-value", value?: string): void;
}>();
</script>
