<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>Vous vous déplacez de 1,5 mètres dans n’importe quelle direction, sans déclencher d’<strong>attaque d’opportunité</strong>.</p>
    <p>
      Vous ne pouvez effectuer un pas prudent que si votre <NuxtLink to="/regles/aventure/mouvement/vitesse">vitesse</NuxtLink> n’est réduite d’aucune manière,
      par exemple par le <NuxtLink to="/regles/aventure/mouvement/terrain-difficile">terrain difficile</NuxtLink>.
    </p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Combat", to: "/regles/combat" },
  { text: "Activités", to: "/regles/combat/activites" },
];
const title: string = "Pas prudent";

useSeo({
  title,
  description: "Découvrez l’action Pas prudent : déplacez-vous de 1,5 mètre sans déclencher d’attaque d’opportunité, sauf en terrain difficile.",
});
</script>
