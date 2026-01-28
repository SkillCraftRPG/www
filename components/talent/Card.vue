<template>
  <LinkCard :title="talent.name" :to="`/regles/talents/${talent.slug}`">
    <template v-if="talent.requiredTalent" #subtitle-override>
      <h3 class="card-subtitle h6 mb-2 text-body-secondary"><TalentIcon /> {{ talent.requiredTalent.name }}</h3>
    </template>
    <div v-if="hasText" class="card-text">
      <div v-if="talent.summary">{{ talent.summary }}</div>
      <div v-if="!hideSkill && talent.skill"><SkillIcon />&nbsp;{{ talent.skill.name }}</div>
      <div v-if="talent.allowMultiplePurchases"><i>Achats&nbsp;multiples</i></div>
    </div>
  </LinkCard>
</template>

<script lang="ts" setup>
import { parsingUtils } from "logitar-js";

import type { Talent } from "~/types/game";

const { parseBoolean } = parsingUtils;

const props = defineProps<{
  noSkill?: boolean | string;
  talent: Talent;
}>();

const hasText = computed<boolean>(
  () => Boolean(props.talent.summary) || (!hideSkill.value && Boolean(props.talent.skill)) || props.talent.allowMultiplePurchases,
);
const hideSkill = computed<boolean>(() => parseBoolean(props.noSkill) ?? false);
</script>
