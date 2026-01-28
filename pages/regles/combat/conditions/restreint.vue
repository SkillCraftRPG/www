<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>Une créature restreinte est immobilisée, elle ne peut donc pas <NuxtLink to="/regles/combat/activites/deplacement">se déplacer</NuxtLink>.</p>
    <p>
      Également, le <NuxtLink to="/regles/competences/tests">test</NuxtLink> des <NuxtLink to="/regles/combat/attaque">attaques</NuxtLink> dirigées contre elle
      se voit conférer l’<NuxtLink to="/regles/competences/tests/avantage-desavantage">avantage</NuxtLink>.
    </p>
    <p>
      Enfin, le test des attaques de la créature et ses <NuxtLink to="/regles/competences/tests/sauvegarde">jets de sauvegarde</NuxtLink> d’<NuxtLink
        to="/regles/competences/acrobaties"
        >Acrobaties</NuxtLink
      >
      sont affligés du <NuxtLink to="/regles/competences/tests/avantage-desavantage">désavantage</NuxtLink>.
    </p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Combat", to: "/regles/combat" },
  { text: "Conditions", to: "/regles/combat/conditions" },
];
const title: string = "Restreint";

useSeo({
  title,
  description:
    "Découvrez la condition restreint : une créature immobilisée, vulnérable aux attaques, subissant désavantage à ses propres actions et jets d’Acrobaties.",
});
</script>
