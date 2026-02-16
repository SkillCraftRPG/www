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
import { arrayUtils, parsingUtils } from "logitar-js";

import type { Actor, GameSkill, Skill } from "~/types/game";
import type { SelectOption } from "~/types/tar/select";

const { orderBy } = arrayUtils;
const { parseBoolean } = parsingUtils;

const actor: Actor = {
  type: "System",
  id: "system",
  isDeleted: false,
  displayName: "System",
};
const now: string = new Date().toISOString();
const anySkill: Skill = {
  id: "any",
  version: 0,
  createdBy: actor,
  createdOn: now,
  updatedBy: actor,
  updatedOn: now,
  slug: "",
  value: "" as GameSkill,
  name: "N’importe laquelle",
  talents: [],
};
const noneSkill: Skill = {
  id: "none",
  version: 0,
  createdBy: actor,
  createdOn: now,
  updatedBy: actor,
  updatedOn: now,
  slug: "",
  value: "" as GameSkill,
  name: "Aucune",
  talents: [],
};

const props = withDefaults(
  defineProps<{
    extended?: boolean | string;
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

const options = computed<SelectOption[]>(() => {
  const options: SelectOption[] = orderBy(
    props.skills.map(({ id, name }) => ({ text: name, value: id, sort: unaccent(name) })),
    "sort",
  );
  if (parseBoolean(props.extended)) {
    options.splice(0, 0, { text: noneSkill.name, value: noneSkill.id }, { text: anySkill.name, value: anySkill.id });
  }
  return options;
});

const emit = defineEmits<{
  (e: "selected", value?: Skill): void;
  (e: "update:model-value", value?: string): void;
}>();

function onModelValueUpdate(value?: string): void {
  emit("update:model-value", value);

  let skill: Skill | undefined = undefined;
  if (value === anySkill.id) {
    skill = anySkill;
  } else if (value === noneSkill.id) {
    skill = noneSkill;
  } else if (value) {
    skill = props.skills.find(({ id }) => id === value);
  }
  emit("selected", skill);
}
</script>
