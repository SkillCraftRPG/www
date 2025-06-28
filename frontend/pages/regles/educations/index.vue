<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" />
    <p>Les éducations représentent différents modes de vie adoptés par les personnages pendant leurs premières années d’existence.</p>
    <p>Le joueur assigne une éducation à son personnage au moment de sa <NuxtLink to="/regles/personnages/creation">création</NuxtLink>.</p>
    <p>
      Chaque éducation définit une <NuxtLink to="/regles/competences">compétence</NuxtLink> pour laquelle le personnage est formé, un multiplicateur permettant
      de déterminer sa richesse de départ, ainsi qu'une particularité qui lui est propre.
    </p>
    <div class="row">
      <div v-for="education in educations" :key="education.id" class="col-xs-12 col-sm-6 col-md-4 col-lg-3 mb-4">
        <EducationCard class="d-flex flex-column h-100" :education="education" />
      </div>
    </div>
  </main>
</template>

<script setup lang="ts">
import type { Education, SearchResults } from "~/types/game";

const config = useRuntimeConfig();
const title: string = "Éducations";

const { data } = await useFetch("/api/educations", {
  baseURL: config.public.apiBaseUrl,
  cache: "no-cache",
  server: false,
});
const educations = computed<Education[]>(() => (data.value as SearchResults<Education>)?.items ?? []);

useSeo({
  title,
  description: "Choisissez l’éducation du personnage selon son enfance : elle détermine une compétence, sa richesse de départ et une particularité unique.",
});
</script>
