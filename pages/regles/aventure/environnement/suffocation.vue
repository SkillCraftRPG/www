<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Une créature peut retenir son souffle pendant un nombre de rounds (d’une durée de <NuxtLink to="/regles/aventure/temps">6 secondes</NuxtLink>) en fonction
      de sa <NuxtLink to="/regles/attributs/sante">Santé</NuxtLink> (minimum 2 rounds) :
    </p>
    <p>
      <code>Rounds = (Santé + 5) × 2</code>
    </p>
    <p>Ce nombre de rounds est doublé si la créature est submergée dans l’eau.</p>
    <p>
      Par exemple, une créature dotée de +3 en Santé peut retenir son souffle pendant 16 rounds (96 secondes) sur terre, ou 32 rounds (3 minutes et 12 secondes)
      sous l’eau.
    </p>
    <h2 class="h3">Suffocation</h2>
    <p>Par la suite, la créature suffoque et sa vie est en danger.</p>
    <p>
      Elle doit effectuer un <NuxtLink to="/regles/competences/tests/sauvegarde">jet de sauvegarde</NuxtLink> de
      <NuxtLink to="/regles/competences/resistance">Résistance</NuxtLink> au début de chaque tour pendant lequel elle suffoque. Le
      <NuxtLink to="/regles/competences/tests/difficulte">degré de difficulté</NuxtLink> est de 5 par round, additionné de 5 : 10 pour le premier round, 15 pour
      le second, et ainsi de suite.
    </p>
    <p>
      En cas d’échec, ses points de <NuxtLink to="/regles/statistiques/vitalite">Vitalité</NuxtLink> chutent à 0 et elle tombe à l’<NuxtLink
        to="/regles/combat/mort-agonie"
        >agonie</NuxtLink
      >.
    </p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Aventure", to: "/regles/aventure" },
  { text: "Environnement", to: "/regles/aventure/environnement" },
];
const title: string = "Retenir son souffle";

useSeo({
  title,
  description: "Découvrez les règles pour retenir son souffle, la durée selon la Santé, et les effets de la suffocation avec jets de sauvegarde croissants.",
});
</script>
