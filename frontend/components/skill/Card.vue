<template>
  <LinkCard :text="skill.summary" :title="skill.name" :to="`/regles/competences/${skill.slug}`">
    <template v-if="!hideAttribute" #subtitle-override>
      <h3 class="card-subtitle h6 mb-2 text-body-secondary">
        <AttributeIcon />
        {{ " " }}
        <template v-if="skill.attribute">{{ skill.attribute.name }}</template>
        <i v-else>Variable</i>
      </h3>
    </template>
  </LinkCard>
</template>

<script lang="ts" setup>
import { parsingUtils } from "logitar-js";

import type { Skill } from "~/types/game";

const { parseBoolean } = parsingUtils;

const props = defineProps<{
  noAttribute?: boolean | string;
  skill: Skill;
}>();

const hideAttribute = computed<boolean>(() => parseBoolean(props.noAttribute) ?? false);
</script>
