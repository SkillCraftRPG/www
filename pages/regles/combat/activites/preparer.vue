<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>Sélectionnez une autre activité, et indiquez un déclencheur. Soyez spécifiques quant au déclencheur et à l’action que vous accomplirez.</p>
    <p>
      Jusqu’au début de votre prochain <NuxtLink to="/regles/combat/deroulement/tour">tour</NuxtLink>, si le déclencheur se produit, vous pouvez utiliser votre
      réaction afin d’accomplir l’action décrite.
    </p>
    <p>
      Si l’action déclenche normalement une <NuxtLink to="/regles/combat/attaque/opportunite">attaque d’opportunité</NuxtLink>, alors préparer cette action ne
      l’en exempt pas.
    </p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Combat", to: "/regles/combat" },
  { text: "Activités", to: "/regles/combat/activites" },
];
const title: string = "Préparer";

useSeo({
  title,
  description: "Découvrez comment préparer une action avec un déclencheur défini pour agir en réaction avant votre prochain tour de jeu.",
});
</script>
