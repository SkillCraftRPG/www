<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Vous indiquez aux créatures autour de vous l’emplacement d’une créature ou d’un objet <NuxtLink to="/regles/combat/activites/cacher">caché</NuxtLink> que
      vous avez découvert, par exemple un piège ou un passage secret.
    </p>
    <p>
      Toute créature située à 9 mètres ou moins de votre position peut utiliser sa <NuxtLink to="/regles/combat/deroulement/tour">réaction</NuxtLink> afin de
      <NuxtLink to="/regles/combat/activites/chercher">chercher</NuxtLink> la cible que vous indiquez.
    </p>
    <p>
      Une créature qui en fait ainsi se voit conférer l’<NuxtLink to="/regles/competences/tests/avantage-desavantage">avantage</NuxtLink> à son
      <NuxtLink to="/regles/competences/tests">test</NuxtLink> de <NuxtLink to="/regles/competences/perception">Perception</NuxtLink>.
    </p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Combat", to: "/regles/combat" },
  { text: "Activités", to: "/regles/combat/activites" },
];
const title: string = "Indiquer";

useSeo({
  title,
  description:
    "Découvrez l’action Indiquer : révélez un ennemi ou un objet caché et offrez à vos alliés un avantage à leur test de Perception pour le repérer.",
});
</script>
