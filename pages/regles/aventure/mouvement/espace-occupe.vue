<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Une créature occupe un espace déterminé en fonction de sa <NuxtLink to="/regles/especes/taille">taille</NuxtLink>, tel qu’illustré dans le tableau
      ci-dessous.
    </p>
    <p>Une créature de grande taille occupera plusieurs cases, tandis que plusieurs créatures de petite taille peuvent partager la même case.</p>
    <p>
      Une case occupée par une créature de taille moyenne ou supérieure est considérée comme du
      <NuxtLink to="/regles/aventure/mouvement/terrain-difficile">terrain difficile</NuxtLink>.
    </p>
    <p>
      Une créature ne peut arrêter son <NuxtLink to="/regles/combat/activites/deplacement">déplacement</NuxtLink> dans une case occupée par une autre créature,
      sauf si la taille des créatures le permet.
    </p>
    <p>
      Une créature ne peut également pas traverser une case occupée par une créature hostile, sauf si la différence entre leur taille est d’au moins deux
      catégories. Le <NuxtLink to="/regles/talents">talent</NuxtLink> <NuxtLink to="/regles/talents/culbutes">Culbutes</NuxtLink> permet d’outrepasser cette
      restriction.
    </p>
    <LineageSizeCategoryTable display="space" />
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Aventure", to: "/regles/aventure" },
  { text: "Mouvement", to: "/regles/aventure/mouvement" },
];
const title: string = "Espace occupé";

useSeo({
  title,
  description:
    "Découvrez comment chaque catégorie de taille influence l’espace occupé sur la grille, en carrés ou hexagones, avec règles de mouvement associées.",
});
</script>
