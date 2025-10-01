<template>
  <LinkCard :text="education.summary" :title="education.name" :to="`/regles/educations/${education.slug}`">
    <template v-if="education.skill" #subtitle-override>
      <h3 class="card-subtitle h6 mb-2 text-body-secondary"><SkillIcon /> {{ education.skill.name }}</h3>
    </template>
  </LinkCard>
</template>

<script lang="ts" setup>
import type { Education } from "~/types/game";

defineProps<{
  education: Education;
}>();
</script>
