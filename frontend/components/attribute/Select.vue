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
import { arrayUtils, parsingUtils } from "logitar-js";

import type { Attribute, GameAttribute } from "~/types/game";

const { orderBy } = arrayUtils;
const { parseBoolean } = parsingUtils;

const variableAttribute: Attribute = {
  id: "variable",
  slug: "",
  value: "" as GameAttribute,
  name: "Variable",
  skills: [],
  statistics: [],
};

const props = withDefaults(
  defineProps<{
    attributes?: Attribute[];
    floating?: boolean | string;
    id?: string;
    label?: string;
    modelValue?: string;
    placeholder?: string;
    variable?: boolean | string;
  }>(),
  {
    attributes: () => [],
    floating: true,
    id: "attribute",
    label: "Attribut",
    placeholder: "Sélectionnez un attribut",
  },
);

const options = computed<SelectOption[]>(() => {
  const options: SelectOption[] = orderBy(
    props.attributes.map(({ id, name }) => ({ text: name, value: id })),
    "text",
  );
  if (parseBoolean(props.variable)) {
    options.push({ text: variableAttribute.name, value: variableAttribute.id });
  }
  return options;
});

const emit = defineEmits<{
  (e: "selected", value?: Attribute): void;
  (e: "update:model-value", value?: string): void;
}>();

function onModelValueUpdate(value?: string): void {
  emit("update:model-value", value);

  let attribute: Attribute | undefined = undefined;
  if (value === variableAttribute.id) {
    attribute = variableAttribute;
  } else if (value) {
    attribute = props.attributes.find(({ id }) => id === value);
  }
  emit("selected", attribute);
}
</script>
