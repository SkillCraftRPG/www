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
import { arrayUtils } from "logitar-js";

import type { SelectOption } from "~/types/tar/select";
import type { SpellCategory } from "~/types/magic";

const { orderBy } = arrayUtils;

const props = withDefaults(
  defineProps<{
    categories?: SpellCategory[];
    floating?: boolean | string;
    id?: string;
    label?: string;
    modelValue?: string;
    placeholder?: string;
  }>(),
  {
    categories: () => [],
    floating: true,
    id: "category",
    label: "Catégorie",
    placeholder: "Sélectionnez une catégorie",
  },
);

const options = computed<SelectOption[]>(() =>
  orderBy(
    props.categories.map(({ id, name }) => ({ text: name, value: id, sort: unaccent(name) })),
    "sort",
  ),
);

const emit = defineEmits<{
  (e: "selected", value?: SpellCategory): void;
  (e: "update:model-value", value?: string): void;
}>();

function onModelValueUpdate(value?: string): void {
  emit("update:model-value", value);

  let category: SpellCategory | undefined = undefined;
  if (value) {
    category = props.categories.find(({ id }) => id === value);
  }
  emit("selected", category);
}
</script>
