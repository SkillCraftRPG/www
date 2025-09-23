<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>Vous tentez d’évaluer la situation ou de déceler un comportement anormal.</p>
    <p>
      Sélectionnez une créature située à 9 mètres ou moins de votre position et que vous pouvez voir et effectuez un
      <NuxtLink to="/regles/competences/tests">test</NuxtLink> d’<NuxtLink to="/regles/competences/intuition">Intuition</NuxtLink>.
    </p>
    <p>
      Le <NuxtLink to="/regles/talents">talent</NuxtLink>
      <NuxtLink to="/regles/talents/perception-extrasensorielle">Perception extrasensorielle</NuxtLink> améliore votre capacité à poser un jugement.
    </p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Combat", to: "/regles/combat" },
  { text: "Activités", to: "/regles/combat/activites" },
];
const title: string = "Jugement";

useSeo({
  title,
  description: "Découvrez l’action Jugement : évaluez une situation ou décelez un comportement suspect grâce à un test d’Intuition sur une créature proche.",
});
</script>
