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

import type { Skill } from "~/types/game";

const { orderBy } = arrayUtils;

const props = withDefaults(
  defineProps<{
    floating?: boolean | string;
    id?: string;
    label?: string;
    modelValue?: string;
    placeholder?: string;
    skills?: Skill[];
  }>(),
  {
    floating: true,
    id: "skill",
    label: "Compétence",
    placeholder: "Sélectionnez une compétence",
    skills: () => [],
  },
);

const options = computed<SelectOption[]>(() =>
  orderBy(
    props.skills.map(({ id, name }) => ({ text: name, value: id })),
    "text",
  ),
);

const emit = defineEmits<{
  (e: "selected", value?: Skill): void;
  (e: "update:model-value", value?: string): void;
}>();

function onModelValueUpdate(value?: string): void {
  emit("update:model-value", value);

  const skill: Skill | undefined = props.skills.find(({ id }) => id === value);
  emit("selected", skill);
}
</script>
