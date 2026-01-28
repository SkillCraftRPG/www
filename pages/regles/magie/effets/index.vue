<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>Les sections suivantes décrivent comment les effets des pouvoirs s’appliquent.</p>
    <div class="row">
      <div v-for="(item, index) in items" :key="index" class="col-xs-12 col-sm-6 col-md-4 mb-4">
        <LinkCard class="d-flex flex-column h-100" :text="item.description" :title="item.title" :to="item.path" />
      </div>
    </div>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [{ text: "Magie", to: "/regles/magie" }];
const title: string = "Effets";

type MenuItem = {
  path: string;
  title: string;
  description: string;
};
const items: MenuItem[] = [
  {
    path: "/regles/magie/effets/cible",
    title: "Cible",
    description: "Les pouvoirs nécessitent une ou plusieurs cibles visibles, sauf cas spéciaux.",
  },
  {
    path: "/regles/magie/effets/zones",
    title: "Zones",
    description: "Les zones d’effet définissent l’aire touchée par les pouvoirs : cône, cube, etc.",
  },
  {
    path: "/regles/magie/effets/sauvegarde",
    title: "Jets de sauvegarde",
    description: "Les jets de sauvegarde permettent de résister aux effets néfastes des pouvoirs.",
  },
  {
    path: "/regles/magie/effets/attaque",
    title: "Attaque",
    description: "Certains pouvoirs agissent comme des attaques, comparant test et Défense.",
  },
  {
    path: "/regles/magie/effets/combinaison",
    title: "Combinaison",
    description: "Les effets de pouvoirs se cumulent, le plus puissant prime sur les autres.",
  },
];

useSeo({
  title,
  description: "Découvrez comment les effets des pouvoirs s’appliquent : cibles, zones d’effet, jets de sauvegarde, attaques et combinaisons possibles.",
});
</script>
