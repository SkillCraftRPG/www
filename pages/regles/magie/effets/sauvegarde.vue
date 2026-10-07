<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <RulesBreadcrumb :active="title" :parent="parent" />
    <p>Plusieurs pouvoirs nécessitent un <NuxtLink to="/regles/competences/tests/sauvegarde">jet de sauvegarde</NuxtLink> afin de résister à leurs effets.</p>
    <p>Les effets du pouvoir peuvent être altérés ou annulés en cas de réussite de ce jet de sauvegarde.</p>
    <p>
      Au cours du <NuxtLink to="/regles/combat/deroulement/tour">tour</NuxtLink> pendant lequel le pouvoir a été canalisé, la
      <NuxtLink to="/regles/competences/tests/difficulte">difficulté</NuxtLink> du jet de sauvegarde est égale au résultat du
      <NuxtLink to="/regles/competences/tests">test</NuxtLink> d’<NuxtLink to="/regles/competences/occultisme">Occultisme</NuxtLink> de la créature ayant
      canalisé le pouvoir.
    </p>
    <p>
      Au cours des tours subséquents, la difficulté est égale au résultat du <NuxtLink to="/regles/competences/tests/passif">test passif</NuxtLink> d’Occultisme
      de la créature ayant canalisé le pouvoir.
    </p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/tar/breadcrumb";

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
