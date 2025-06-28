<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" />
    <p>Les castes représentent les différentes classes sociales composant le tissu sociétaire.</p>
    <p>Le joueur assigne une caste à son personnage au moment de sa <NuxtLink to="/regles/personnages/creation">création</NuxtLink>.</p>
    <p>
      Chaque caste définit une <NuxtLink to="/regles/competences">compétence</NuxtLink> pour laquelle le personnage est formé, un jet de dés permettant de
      déterminer sa richesse de départ, ainsi qu'une particularité qui lui est propre.
    </p>
    <div class="row">
      <div v-for="caste in castes" :key="caste.id" class="col-xs-12 col-sm-6 col-md-4 col-lg-3 mb-4">
        <CasteCard class="d-flex flex-column h-100" :caste="caste" />
      </div>
    </div>
  </main>
</template>

<script setup lang="ts">
import type { Caste, SearchResults } from "~/types/game";

const config = useRuntimeConfig();
const title: string = "Castes";

const { data } = await useFetch("/api/castes", {
  baseURL: config.public.apiBaseUrl,
  cache: "no-cache",
  server: false,
});
const castes = computed<Caste[]>(() => (data.value as SearchResults<Caste>)?.items ?? []);

useSeo({
  title,
  description: "Les castes définissent la position sociale d’un personnage, sa compétence de départ, sa richesse initiale et une particularité unique.",
});
</script>
