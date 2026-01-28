<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>Vous vous placez en posture défensive, vous appliquant à bloquer les coups dirigés vers vous.</p>
    <p>
      Pendant votre <NuxtLink to="/regles/combat/deroulement/tour">tour</NuxtLink>, vous vous préparez par une action. Vous utilisez ensuite votre réaction afin
      d’infliger le <NuxtLink to="/regles/competences/tests/avantage-desavantage">désavantage</NuxtLink> au
      <NuxtLink to="/regles/competences/tests">test</NuxtLink> des <NuxtLink to="/regles/combat/attaque">attaques</NuxtLink> dirigées contre vous jusqu’au début
      de votre prochain tour.
    </p>
    <p>
      Votre réaction n’est pas perdue si vous ne l’utilisez pas. Également, si vous l’utilisez pour autre chose, par exemple afin d’effectuer une
      <NuxtLink to="/regles/combat/attaque/opportunite">attaque d’opportunité</NuxtLink>, vous ne pouvez pas vous défendre.
    </p>
    <p>
      Le <NuxtLink to="/regles/talents">talent</NuxtLink> <NuxtLink to="/regles/talents/repli-defensif">Repli défensif</NuxtLink> améliore votre capacité à vous
      défendre.
    </p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Combat", to: "/regles/combat" },
  { text: "Activités", to: "/regles/combat/activites" },
];
const title: string = "Défense";

useSeo({
  title,
  description:
    "Découvrez l’action Défense : préparez-vous à bloquer les attaques ennemies, infligez un désavantage aux coups reçus et renforcez votre survie en combat.",
});
</script>
