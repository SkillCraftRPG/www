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
    id: "actions",
    label: "Actions",
    placeholder: "Tous",
  },
);

const options = ref<SelectOption[]>(
  orderBy(
    [
      { text: "1 action", value: "1" },
      { text: "2 actions", value: "2" },
      { text: "3 actions", value: "3" },
      { text: "Action libre", value: "free" },
      { text: "Réaction", value: "reaction" },
    ],
    "text",
  ),
);

defineEmits<{
  (e: "update:model-value", value?: string): void;
}>();
</script>
