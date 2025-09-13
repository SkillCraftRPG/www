<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      La gueule de bois est une condition causée par l’<NuxtLink to="/regles/aventure/environnement/alcoolemie">ébriété</NuxtLink> avancée. Elle débute quand
      une créature retombe sous la phase 1 d’ébriété.
    </p>
    <p>
      Cette condition dure un nombre d’heures égal au nombre maximal de points d’alcoolémie atteint depuis que ces points sont retombés à 0, divisé par deux.
      Elle peut aussi être retirée par une capacité naturelle ou surnaturelle réduisant le
      <NuxtLink to="/regles/combat/conditions/fatigue">niveau de Fatigue</NuxtLink>.
    </p>
    <p>Une créature affligée par la gueule de bois voit sa <NuxtLink to="/regles/aventure/repos">régénération</NuxtLink> réduite de moitié.</p>
    <p>
      Ses
      <NuxtLink to="/regles/competences/tests">tests</NuxtLink> sont également affligés du
      <NuxtLink to="/regles/competences/tests/avantage-desavantage">désavantage</NuxtLink>, incluant le test de ses
      <NuxtLink to="/regles/combat/attaque">attaques</NuxtLink>, mais excluant ses
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
const title: string = "Gueule de bois";

useSeo({
  title,
  description: "Découvrez la condition Gueule de bois : effets après ébriété avancée, désavantage aux tests et régénération réduite de moitié.",
});
</script>
