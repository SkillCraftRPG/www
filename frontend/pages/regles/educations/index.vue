<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" />
    <p>Les éducations représentent différents modes de vie adoptés par les personnages pendant leurs premières années d’existence.</p>
    <p>Le joueur assigne une éducation à son personnage au moment de sa <NuxtLink to="/regles/personnages/creation">création</NuxtLink>.</p>
    <p>
      Chaque éducation définit une <NuxtLink to="/regles/competences">compétence</NuxtLink> pour laquelle le personnage est
      <NuxtLink to="/regles/competences/formation">formé</NuxtLink>, un multiplicateur permettant de déterminer sa
      <NuxtLink to="/regles/equipement/depart">richesse de départ</NuxtLink>, ainsi qu’une particularité qui lui est propre.
    </p>
    <EducationList v-if="educations.length" :items="educations" />
  </main>
</template>

<script setup lang="ts">
import { arrayUtils } from "logitar-js";

import type { Education } from "~/types/game";
import { getEducations } from "~/services/educations";

const title: string = "Éducations";
const { orderBy } = arrayUtils;

const educations = ref<Education[]>(orderBy(getEducations({ skill: true }), "slug"));

useSeo({
  title,
  description: "Choisissez l’éducation du personnage selon son enfance : elle détermine une compétence, sa richesse de départ et une particularité unique.",
});
</script>
