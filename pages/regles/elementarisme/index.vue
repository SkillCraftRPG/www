<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>L’élémentarisme est la faculté de faire appel à la puissance des éléments : l’Air, l’Eau, le Feu, la Terre et l’Esprit.</p>
    <p>Le talent <NuxtLink to="/regles/competences/elementarisme">Élémentarisme</NuxtLink> permet au personnage de s’initier à la manipulation d’un élément.</p>
    <p>
      La spécialisation <NuxtLink to="/regles/specialisations/elementariste">Élémentariste</NuxtLink> permet à un personnage de convertir de l’<NuxtLink
        to="/regles/statistiques/energie"
        >Énergie</NuxtLink
      >
      en essence élémentaire, qu’il peut ensuite consommer afin d’activer de puissantes capacités élémentaires.
    </p>
    <div class="row">
      <div v-for="(item, index) in items" :key="index" class="col-xs-12 col-sm-6 mb-4">
        <LinkCard class="d-flex flex-column h-100" :text="item.description" :title="item.title" :to="item.path" />
      </div>
    </div>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [{ text: "Annexes", to: "/regles/annexes" }];
const title: string = "Élémentarisme";

type MenuItem = {
  path: string;
  title: string;
  description: string;
};
const items: MenuItem[] = [
  {
    path: "/regles/elementarisme/essence",
    title: "Essence élémentaire",
    description: "Essence élémentaire, création d’orbes et effets magiques.",
  },
  {
    path: "/regles/elementarisme/capacites",
    title: "Capacités élémentaires",
    description: "Capacités élémentaires de tiers 1 à 3 et effets planaires.",
  },
];

useSeo({
  title,
  description: "Découvrez l’Élémentarisme et maîtrisez l’essence de l’Air, de l’Eau, du Feu, de la Terre ou de l’Esprit pour déployer de puissantes capacités.",
});
</script>
