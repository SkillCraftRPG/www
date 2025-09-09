<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>Les pouvoirs représentent les facultés surnaturelles des personnages.</p>
    <p>Ils regroupent autant les sorts canalisés par les utilisateurs de magie que les capacités uniques de certaines espèces ou types de personnages.</p>
    <p>L’action d’utiliser un pouvoir est appelée <NuxtLink to="/regles/combat/activites/canaliser">Canaliser</NuxtLink>.</p>
    <div class="row">
      <div v-for="(item, index) in items" :key="index" class="col-xs-12 col-sm-6 col-lg-4 mb-4">
        <LinkCard class="d-flex flex-column h-100" :text="item.description" :title="item.title" :to="item.path" />
      </div>
    </div>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [{ text: "Magie", to: "/regles/magie" }];
const title: string = "Pouvoirs";

type MenuItem = {
  path: string;
  title: string;
  description: string;
};
const items: MenuItem[] = [
  {
    path: "/regles/magie/pouvoirs/apprentissage",
    title: "Apprentissage",
    description: "Apprendre de nouveaux pouvoirs avec les points de talent.",
  },
  {
    path: "/regles/magie/pouvoirs/niveau",
    title: "Niveau",
    description: "Déclinaison en niveaux selon le tier et restrictions de canalisation.",
  },
  {
    path: "/regles/magie/pouvoirs/canalisation",
    title: "Canalisation",
    description: "Requiert un test d’Occultisme, au risque de perdre l’Énergie.",
  },
  {
    path: "/regles/magie/pouvoirs/energie",
    title: "Dépense d’Énergie",
    description: "Effet du tiers, niveau et talents sur la dépense d’Énergie.",
  },
  {
    path: "/regles/magie/pouvoirs/rituel",
    title: "Rituel",
    description: "Canalisation en rituel, avec une dépense minime et réussite automatique.",
  },
];

useSeo({
  title,
  description:
    "Découvrez les pouvoirs, capacités surnaturelles regroupant sorts canalisés et aptitudes uniques, avec règles d’apprentissage, niveaux et dépenses d’Énergie.",
});
</script>
