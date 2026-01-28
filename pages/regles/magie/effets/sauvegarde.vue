<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>Plusieurs pouvoirs nécessitent un <NuxtLink to="/regles/competences/tests/sauvegarde">jet de sauvegarde</NuxtLink> afin de résister à leurs effets.</p>
    <p>Les effets du pouvoir peuvent être altérés ou annulés en cas de réussite de ce jet de sauvegarde.</p>
    <p>
      Le <NuxtLink to="/regles/competences/tests/difficulte">degré de difficulté</NuxtLink> du jet de sauvegarde est toujours égal au résultat du
      <NuxtLink to="/regles/competences/tests">test</NuxtLink> d’<NuxtLink to="/regles/competences/occultisme">Occultisme</NuxtLink> de la créature ayant
      canalisé le pouvoir.
    </p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Magie", to: "/regles/magie" },
  { text: "Effets", to: "/regles/magie/effets" },
];
const title: string = "Jets de sauvegarde";

useSeo({
  title,
  description: "Découvrez comment les jets de sauvegarde permettent de résister aux pouvoirs, réduisant ou annulant leurs effets selon le degré de difficulté.",
});
</script>
