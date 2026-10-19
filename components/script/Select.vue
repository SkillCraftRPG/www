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

import type { Script } from "~/types/game";
import type { SelectOption } from "~/types/tar/select";

const { orderBy } = arrayUtils;

const props = withDefaults(
  defineProps<{
    floating?: boolean | string;
    id?: string;
    label?: string;
    modelValue?: string;
    placeholder?: string;
    scripts?: Script[];
  }>(),
  {
    floating: true,
    id: "script",
    label: "Alphabet",
    placeholder: "Sélectionnez un alphabet",
    scripts: () => [],
  },
);

const options = computed<SelectOption[]>(() =>
  orderBy(
    props.scripts.map(({ name, slug }) => ({ text: name, value: slug, sort: unaccent(name) })),
    "sort",
  ),
);

const emit = defineEmits<{
  (e: "selected", value?: Script): void;
  (e: "update:model-value", value?: string): void;
}>();

function onModelValueUpdate(value?: string): void {
  emit("update:model-value", value);

  let script: Script | undefined = undefined;
  if (value) {
    script = props.scripts.find(({ slug }) => slug === value);
  }
  emit("selected", script);
}
</script>
