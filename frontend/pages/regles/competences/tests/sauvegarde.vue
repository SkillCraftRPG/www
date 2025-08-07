<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Les jets de sauvegarde sont similaires aux <NuxtLink to="/regles/competences/tests/oppose">tests opposés</NuxtLink> : ils sont effectués en réaction à une
      situation.
    </p>
    <p>Les jets de sauvegarde sont généralement plus avantageux que les tests opposés, puisqu’ils ne sont pas affectés par les mêmes contraintes.</p>
    <p>
      Les jets de sauvegarde n’octroient jamais de conséquence négative ou positive, ni de
      <NuxtLink to="/regles/competences/esperance-damnation">point d’Espérance ni de Damnation</NuxtLink>.
    </p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Compétences", to: "/regles/competences" },
  { text: "Tests", to: "/regles/competences/tests" },
];
const title: string = "Jet de sauvegarde";

useSeo({
  title,
  description: "Découvrez les jets de sauvegarde, ces tests effectués en réaction à une situation et servant à s’y soustraire ou minimiser les désagréments.",
});
</script>
