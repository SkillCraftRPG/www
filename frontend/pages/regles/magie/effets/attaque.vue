<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>Certains pouvoirs agissent comme une <NuxtLink to="/regles/combat/attaque">attaque</NuxtLink>.</p>
    <p>
      Dans le cas échéant, le résultat du
      <NuxtLink to="/regles/competences/tests">test</NuxtLink> d’ <NuxtLink to="/regles/competences/occultisme">Occultisme</NuxtLink> est comparé à la
      <NuxtLink to="/regles/combat/attaque/defense">Défense</NuxtLink> des cibles.
    </p>
    <p>Une cible est affectée par le pouvoir si le résultat du test est supérieur ou égal à sa Défense.</p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Magie", to: "/regles/magie" },
  { text: "Effets", to: "/regles/magie/effets" },
];
const title: string = "Attaque";

useSeo({
  title,
  description:
    "Découvrez comment certains pouvoirs fonctionnent comme des attaques, opposant un test d’Occultisme à la Défense des cibles pour déterminer leur effet.",
});
</script>
