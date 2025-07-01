<template>
  <TarSelect
    :floating="floating"
    :id="id"
    :label="label"
    :model-value="modelValue"
    :options="options"
    :placeholder="placeholder"
    @update:model-value="onModelValueUpdate"
  />
</template>

<script setup lang="ts">
import { TarSelect, type SelectOption } from "logitar-vue3-ui";
import { arrayUtils } from "logitar-js";

import type { Attribute } from "~/types/game";

const { orderBy } = arrayUtils;

const props = withDefaults(
  defineProps<{
    attributes?: Attribute[];
    floating?: boolean | string;
    id?: string;
    label?: string;
    modelValue?: string;
    placeholder?: string;
  }>(),
  {
    floating: true,
    id: "attribute",
    label: "Attribut",
    placeholder: "Sélectionnez un attribut",
  },
);

const options = computed<SelectOption[]>(() =>
  orderBy(
    (props.attributes ?? []).map(({ id, name }) => ({ text: name, value: id })),
    "text",
  ),
);

const emit = defineEmits<{
  (e: "selected", value?: Attribute): void;
  (e: "update:model-value", value?: string): void;
}>();

function onModelValueUpdate(value?: string): void {
  emit("update:model-value", value);

  const attribute: Attribute | undefined = (props.attributes ?? []).find(({ id }) => id === value);
  emit("selected", attribute);
}
</script>
