<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>Une créature paralysée est <NuxtLink to="/regles/combat/conditions/incapable">incapable</NuxtLink> : elle ne peut pas bouger ni parler.</p>
    <p>
      Également, elle échoue automatiquement ses <NuxtLink to="/regles/competences/tests/sauvegarde">jets de sauvegarde</NuxtLink> d’<NuxtLink
        to="/regles/competences/athletisme"
        >Athlétisme</NuxtLink
      >
      et d’<NuxtLink to="/regles/competences/acrobaties">Acrobaties</NuxtLink>.
    </p>
    <p>
      Enfin, le <NuxtLink to="/regles/competences/tests">test</NuxtLink> des <NuxtLink to="/regles/combat/attaque">attaques</NuxtLink> dirigées contre elle se
      voit conférer l’<NuxtLink to="/regles/competences/tests/avantage-desavantage">avantage</NuxtLink>, et les
      <NuxtLink to="/regles/combat/attaque/melee">attaques de mêlée</NuxtLink> la ciblant sont automatiquement une
      <NuxtLink to="/regles/competences/tests/critique">réussite critique</NuxtLink>.
    </p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Combat", to: "/regles/combat" },
  { text: "Conditions", to: "/regles/combat/conditions" },
];
const title: string = "Paralysé";

useSeo({
  title,
  description: "Découvrez la condition paralysé : créature immobile, échec aux jets physiques, attaques subies avec avantage et coups critiques en mêlée.",
});
</script>
