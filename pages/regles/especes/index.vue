<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" />
    <p>
      Une espèce représente un regroupement d’individus présentant des caractéristiques communes, comme la forme du corps, la couleur de peau, de yeux et de
      cheveux, les comportements sociaux et l’espérance de vie. Certaines espèces se décomposent en plusieurs ethnies, associés à un territoire, une
      organisation géopolitique et un ensemble de mœurs et coutumes.
    </p>
    <p>
      Les personnages appartiennent tous à une espèce, et lorsqu’une espèce se décline en plusieurs ethnies, ils appartiennent à une de ces ethnies. L’espèce et
      le peuple sont choisis à la <NuxtLink to="/regles/personnages/creation">création du personnage</NuxtLink>, et ne changent jamais par la suite.
    </p>
    <p>Les espèces et ethnies définissent les caractéristiques de personnage suivantes :</p>
    <ul>
      <li><strong>Traits.</strong> Des capacités spécifiques aux individus de cette espèce ou ethnie.</li>
      <li>
        <strong>Langues.</strong> Les individus d’une même espèce ou ethnie parlent généralement les mêmes <NuxtLink to="/regles/langues">langues</NuxtLink>,
        mais vous pouvez choisir de parler des langues différentes, avec l’accord de votre maître de jeu et une histoire crédible.
      </li>
      <li><strong>Nom.</strong> Chaque espèce ou ethnie présente des exemples de noms pour votre personnage. Vous pouvez choisir un nom différent.</li>
      <li>
        <strong>Vitesse.</strong> Les espèces et ethnies définissent vos <NuxtLink to="/regles/aventure/mouvement/vitesse">vitesses de déplacement</NuxtLink>.
      </li>
      <li>
        <strong>Apparence.</strong> Les membres d’une même ethnie ou espèce partagent une similarité d’apparence. Votre ethnie ou espèce définit votre
        <NuxtLink to="/regles/especes/taille">taille</NuxtLink>, poids et vieillissement.
      </li>
    </ul>
    <h2 class="h3">Table des matières</h2>
    <ul>
      <li v-for="category in categories" :key="category.id">
        <a :href="`#${category.key}`">{{ category.name }}</a>
      </li>
    </ul>
    <div v-for="category in categories" :key="category.id">
      <h2 :id="category.key" class="h3">{{ category.name }}</h2>
      <MarkdownContent v-if="category.htmlContent" :text="category.htmlContent" />
      <SpeciesList :cols="category.columns" :items="category.species" />
    </div>
  </main>
</template>

<script setup lang="ts">
import { arrayUtils } from "logitar-js";

import type { SearchResults } from "~/types/game";
import type { Species, SpeciesCategory } from "~/types/lineages";

const config = useRuntimeConfig();
const title: string = "Espèces";
const { orderBy } = arrayUtils;

const { data } = await useLazyAsyncData<SearchResults<Species>>(
  "species",
  () =>
    $fetch("/api/species", {
      baseURL: config.public.apiBaseUrl,
    }),
  {
    server: false,
  },
);
const categories = computed<SpeciesCategory[]>(() => {
  const species: Species[] = data.value?.items ?? [];
  const categories: Map<string, SpeciesCategory> = new Map();
  species.forEach((species) => {
    const category: SpeciesCategory | undefined = categories.get(species.category.id) ?? species.category;
    category.species.push(species);
    categories.set(category.id, category);
  });
  [...categories.values()].forEach((category) => (category.species = orderBy(category.species, "slug")));
  return orderBy([...categories.values()], "order");
});

useSeo({
  title,
  description: "Découvrez les espèces et leurs ethnies : un regroupement d’individus aux traits physiques, sociaux et culturels communs dans le jeu.",
});
</script>
