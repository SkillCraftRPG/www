<template>
  <LinkCard :subtitle="subtitle" :text="education.summary" :title="education.name" :to="`/regles/educations/${education.slug}`" />
</template>

<script lang="ts" setup>
import type { Education } from "~/types/game";

const props = defineProps<{
  education: Education;
}>();

const subtitle = computed<string | undefined>(() => props.education.skill?.name ?? undefined);
</script>
