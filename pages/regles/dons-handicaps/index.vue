<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" />
    <p>Les dons et handicaps sont une manière additionnelle de personnaliser son personnage.</p>
    <p>Ils sont complètement optionnels : un joueur peut très bien créer un personnage sans don ni handicap.</p>
    <p>
      Ces éléments sont également permanents, c’est-à-dire qu’ils ne peuvent être ajoutés à un personnage qu’au moment de sa
      <NuxtLink to="/regles/personnages/creation">création</NuxtLink>, et ils ne peuvent jamais être retirés.
    </p>
    <p>Au moment de la création du personnage, le joueur peut lui attribuer des dons. Il doit néanmoins lui attribuer un nombre égal de handicaps.</p>
    <p>Le maître de jeu peut restreindre le nombre de dons et handicaps qu’un joueur peut attribuer à son personnage. La recommandation est la suivante :</p>
    <ul>
      <li>Joueurs débutants : aucun don, au plus 1 don</li>
      <li>Joueurs intermédiaires : entre 1 et 2 dons</li>
      <li>Joueurs expérimentés : maximum 3 dons</li>
    </ul>
    <CustomizationList v-if="customizations.length" :items="customizations" />
  </main>
</template>

<script setup lang="ts">
import type { Customization, SearchResults } from "~/types/game";

const config = useRuntimeConfig();
const title: string = "Dons & Handicaps";

const { data } = await useLazyAsyncData<SearchResults<Customization>>(
  "customizations",
  () =>
    $fetch("/api/customizations?sort=Slug", {
      baseURL: config.public.apiBaseUrl,
    }),
  {
    server: false,
  },
);

const customizations = computed<Customization[]>(() => data.value?.items ?? []);

useSeo({
  title,
  description:
    "Ajoutez une touche unique à votre personnage grâce aux dons et handicaps, des options permanentes disponibles uniquement à la création du personnage.",
});
</script>
