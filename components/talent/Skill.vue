<template>
  <div>
    <h2 class="h3">Compétence</h2>
    <p v-if="isTraining">
      L’acquisition de ce talent <NuxtLink to="/regles/competences/formation">forme</NuxtLink> le personnage pour la
      <NuxtLink to="/regles/competences">compétence</NuxtLink> ci-dessous. Elle augmente (+1) également le
      <NuxtLink to="/regles/competences/rang">rang</NuxtLink> de cette compétence.
    </p>
    <p v-else>
      L’acquisition de ce talent augmente (+1) le <NuxtLink to="/regles/competences/rang">rang</NuxtLink> de la
      <NuxtLink to="/regles/competences">compétence</NuxtLink> ci-dessous.
    </p>
    <SkillCard class="mb-4" :skill="skill" />
  </div>
</template>

<script setup lang="ts">
import { parsingUtils } from "logitar-js";

import type { Skill } from "~/types/game";

const { parseBoolean } = parsingUtils;

const props = defineProps<{
  skill: Skill;
  training?: boolean | string;
}>();

const isTraining = computed<boolean>(() => parseBoolean(props.training) ?? false);
</script>
