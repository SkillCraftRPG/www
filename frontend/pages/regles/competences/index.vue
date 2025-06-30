<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" />
    <p>
      Les compétences sont des aptitudes et savoir-faire des personnages et créatures. Elles régissent leurs actions en jeu, influençant leur probabilité de
      réussite.
    </p>
    <p>
      La plupart des compétences sont associées à un <NuxtLink to="/regles/attributs">attribut</NuxtLink>. L’attribut d’autres compétences varie en fonction de
      la situation. Cet attribut intervient en ajoutant un bonus ou une pénalité au <strong>test</strong> d’une compétence.
    </p>
    <div class="row">
      <div v-for="skill in skills" :key="skill.id" class="col-xs-12 col-sm-6 col-md-4 col-lg-3 mb-4">
        <SkillCard class="d-flex flex-column h-100" :skill="skill" />
      </div>
    </div>
  </main>
</template>

<script setup lang="ts">
import type { SearchResults, Skill } from "~/types/game";

const config = useRuntimeConfig();
const title: string = "Compétences";

const { data } = await useFetch("/api/skills", {
  baseURL: config.public.apiBaseUrl,
  cache: "no-cache",
  server: false,
});
const skills = computed<Skill[]>(() => (data.value as SearchResults<Skill>)?.items ?? []);

useSeo({
  title,
  description: "Découvrez comment les compétences traduisent les savoir-faire, aptitudes et expertises de vos héros.",
});

/* TODO(fpion):

 * Compétences
 * - Formation
 * - Rang

 * Tests
 * - Système 2d10
 * - Faire 20
 * - Faire 10
 * - Degré de difficulté
 * - Bonus de circonstance ?
 * - Test opposé
 * - Avantage et désavantage
 * - Jets de sauvegarde
 * - Test passif
 * - Test de groupe

 * Espérance et Damnation
 * - Momentum
 * - Dépense d’Espérance et de Momentum
 */
</script>
