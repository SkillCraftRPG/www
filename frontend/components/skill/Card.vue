<template>
  <LinkCard :subtitle="subtitle" :text="skill.summary" :title="skill.name" :to="`/regles/competences/${skill.slug}`" />
</template>

<script lang="ts" setup>
import { parsingUtils } from "logitar-js";

import type { Skill } from "~/types/game";

const { parseBoolean } = parsingUtils;

const props = defineProps<{
  noAttribute?: boolean | string;
  skill: Skill;
}>();

const subtitle = computed<string | undefined>(() => (parseBoolean(props.noAttribute) ? undefined : (props.skill.attribute?.name ?? "Variable")));
</script>
