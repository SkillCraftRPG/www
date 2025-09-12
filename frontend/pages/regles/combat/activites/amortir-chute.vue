<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      En <NuxtLink to="/regles/aventure/environnement/chute">chute libre</NuxtLink>, vous tentez de vous positionner dans les airs afin de minimiser l’impact de
      votre écrasement au sol.
    </p>
    <p>
      Effectuez un <NuxtLink to="/regles/competences/tests/sauvegarde">jet de sauvegarde</NuxtLink> d’<NuxtLink to="/regles/competences/acrobaties"
        >Acrobaties</NuxtLink
      >
      de <NuxtLink to="/regles/competences/tests/difficulte">difficulté moyenne</NuxtLink>. En cas de réussite, vous
      <NuxtLink to="/regles/aventure/environnement/chute">amortissez votre chute</NuxtLink>.
    </p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Combat", to: "/regles/combat" },
  { text: "Activités", to: "/regles/combat/activites" },
];
const title: string = "Amortir sa chute";

useSeo({
  title,
  description: "Découvrez comment amortir une chute : réussissez un jet d’Acrobaties de difficulté moyenne pour réduire l’impact d’un écrasement au sol.",
});
</script>
