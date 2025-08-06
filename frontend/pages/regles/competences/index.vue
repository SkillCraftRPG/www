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
      la situation. Cet attribut intervient en ajoutant un bonus ou une pénalité au test d’une compétence.
    </p>
    <!-- TODO(fpion): Tests -->
    <!-- TODO(fpion): Espérance et Damnation -->
    <h2 class="h3">Formation</h2>
    <p>Le personnage est formé pour une compétence lorsqu’il acquiert le <NuxtLink to="/regles/talents">talent</NuxtLink> portant le même nom que celle-ci.</p>
    <p>Un personnage formé pour une compétence maîtrise les aptitudes et savoir-faire, contrairement à une créature qui n’est pas formée.</p>
    <p>Lorsqu’il est formé pour une compétence, il ne subit pas de pénalité au rang de celle-ci.</p>
    <h2 class="h3">Rang</h2>
    <p>
      Le rang d’une compétence est similaire au <NuxtLink to="/regles/personnages/progression/niveau">niveau</NuxtLink> d’un personnage. Il est ajouté aux tests
      de cette compétence. Seulement la moitié du rang est ajoutée si le personnage n’est pas formé pour cette compétence.
    </p>
    <p>
      Un personnage possède un nombre de points de compétence égal à son <NuxtLink to="/regles/statistiques/apprentissage">Apprentissage</NuxtLink>. Il peut
      dépenser un point afin d’augmenter de 1 le rang d’une compétence.
    </p>
    <p>Le rang maximal des compétences d’un personnage est défini par son <NuxtLink to="/regles/personnages/progression/tiers">tiers</NuxtLink>.</p>
    <!-- TODO(fpion): +1 au rang lorsque achat talent de compétence -->
    <table class="table table-striped">
      <thead>
        <tr>
          <th scope="col">Tiers du personnage</th>
          <th scope="col">Rang maximal</th>
        </tr>
      </thead>
      <tbody>
        <tr>
          <td>0</td>
          <td>2</td>
        </tr>
        <tr>
          <td>1</td>
          <td>5</td>
        </tr>
        <tr>
          <td>2</td>
          <td>9</td>
        </tr>
        <tr>
          <td>3</td>
          <td>14</td>
        </tr>
      </tbody>
    </table>
    <template v-if="skills.length">
      <h2 class="h3">Liste des compétences</h2>
      <SkillList :items="skills" />
    </template>
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

 * Espérance et Damnation
 * - Momentum
 * - Dépense d’Espérance et de Momentum
 */
</script>
