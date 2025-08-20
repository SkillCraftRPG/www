<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>Les mouvements en jeu peuvent être représentés par une grille carrée ou hexagonale.</p>
    <ul>
      <li>L’arête de chaque case de la grille carrée mesure <strong>1,5 mètres</strong>.</li>
      <li>La distance entre le centre de deux cases adjacentes de la grille hexagonale mesure <strong>1,5 mètres</strong>.</li>
    </ul>
    <div class="row">
      <div v-for="(item, index) in items" :key="index" class="col-xs-12 col-sm-6 col-md-4 mb-4">
        <LinkCard class="d-flex flex-column h-100" :text="item.description" :title="item.title" :to="item.path" />
      </div>
    </div>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [{ text: "Aventure", to: "/regles/aventure" }];
const title: string = "Mouvement";

type MenuItem = {
  path: string;
  title: string;
  description: string;
};
const items: MenuItem[] = [
  {
    path: "/regles/aventure/mouvement/vitesse",
    title: "Vitesse",
    description: "🚧",
  },
  {
    path: "/regles/aventure/mouvement/cadences",
    title: "Cadences",
    description: "🚧",
  },
  {
    path: "/regles/aventure/mouvement/types",
    title: "Types de mouvement",
    description: "🚧",
  },
  {
    path: "/regles/aventure/mouvement/terrain-difficile",
    title: "Terrain difficile",
    description: "🚧",
  },
  {
    path: "/regles/aventure/mouvement/furtif",
    title: "Mouvement furtif",
    description: "🚧",
  },
];

useSeo({
  title,
  description: "🚧",
});

// TODO(fpion): fusionner voyage et cadences ?
// TODO(fpion): se déplacer en étant vigilant
</script>
