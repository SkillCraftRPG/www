<template>
  <TarSelect
    :floating="floating"
    :id="id"
    :label="label"
    :model-value="modelValue?.toString()"
    :options="options"
    :placeholder="placeholder"
    @update:model-value="$emit('update:model-value', parseBoolean($event))"
  />
</template>

<script setup lang="ts">
import { TarSelect, type SelectOption } from "logitar-vue3-ui";
import { parsingUtils } from "logitar-js";

const options: SelectOption[] = [
  {
    text: $t("no"),
    value: false.toString(),
  },
  {
    text: $t("yes"),
    value: true.toString(),
  },
];
const { parseBoolean } = parsingUtils;

withDefaults(
  defineProps<{
    floating?: boolean | string;
    id?: string;
    label?: string;
    modelValue?: boolean | string;
    placeholder?: string;
  }>(),
  {
    floating: true,
  },
);

defineEmits<{
  (e: "update:model-value", value?: boolean): void;
}>();
</script>
