<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      La taille d’une créature représente son envergure physique, incluant sa hauteur, sa largeur et son volume global. Elle est divisée en huit catégories
      distinctes, allant des plus petites entités jusqu’aux créatures colossales.
    </p>
    <p>
      La taille influence directement plusieurs aspects du jeu : <NuxtLink to="/regles/equipement/encombrement">capacité de charge</NuxtLink> (plus la créature
      est grande, plus elle peut soulever, tirer ou porter de poids), <NuxtLink to="/regles/aventure/mouvement/espace-occupe">espace occupé</NuxtLink>, et
      certaines capacités spéciales, qui dépendent de la taille de la cible.
    </p>
    <LineageSizeCategoryTable />
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const title: string = "Taille";
const parent: Breadcrumb[] = [{ text: "Espèces", to: "/regles/especes" }];

useSeo({
  title,
  description: "Découvrez comment la taille d’une créature influence sa charge, l’espace occupé et ses capacités, des plus infimes aux colossales.",
});
</script>
