<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Une créature apeurée ne peut <NuxtLink to="/regles/combat/activites/deplacement">se déplacer</NuxtLink> volontairement en direction de la source de sa
      peur.
    </p>
    <p>
      Également, ses <NuxtLink to="/regles/competences/tests">tests</NuxtLink> (à l’exception des
      <NuxtLink to="/regles/competences/tests/sauvegarde">jets de sauvegarde</NuxtLink>) sont affligés du
      <NuxtLink to="/regles/competences/tests/avantage-desavantage">désavantage</NuxtLink> si elle voit la source de sa peur.
    </p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Combat", to: "/regles/combat" },
  { text: "Conditions", to: "/regles/combat/conditions" },
];
const title: string = "Apeuré";

useSeo({
  title,
  description:
    "Découvrez la condition Apeuré : une créature ne peut avancer vers la source de sa peur et subit un désavantage à ses tests lorsqu’elle la voit.",
});
</script>
