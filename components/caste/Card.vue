<template>
  <LinkCard :text="caste.summary" :title="caste.name" :to="`/regles/castes/${caste.slug}`">
    <template v-if="caste.skill" #subtitle-override>
      <h3 class="card-subtitle h6 mb-2 text-body-secondary"><SkillIcon /> {{ caste.skill.name }}</h3>
    </template>
  </LinkCard>
</template>

<script lang="ts" setup>
import type { Caste } from "~/types/game";

defineProps<{
  caste: Caste;
}>();
</script>
