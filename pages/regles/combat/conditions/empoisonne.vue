<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Les <NuxtLink to="/regles/competences/tests">tests</NuxtLink> d’une créature empoisonnée sont affligés du
      <NuxtLink to="/regles/competences/tests/avantage-desavantage">désavantage</NuxtLink>, à l’exception des
      <NuxtLink to="/regles/competences/tests/sauvegarde">jets de sauvegarde</NuxtLink>.
    </p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Combat", to: "/regles/combat" },
  { text: "Conditions", to: "/regles/combat/conditions" },
];
const title: string = "Empoisonné";

useSeo({
  title,
  description: "Découvrez la condition Empoisonné : les tests d’une créature affectée subissent un désavantage, sauf ses jets de sauvegarde.",
});
</script>
