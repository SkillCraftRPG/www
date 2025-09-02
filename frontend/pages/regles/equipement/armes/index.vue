<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>Les armes permettent aux aventuriers de se défendre contre une agression ou de tourner une situation à leur avantage.</p>
    <div class="row">
      <div v-for="(item, index) in items" :key="index" class="col-xs-12 col-sm-6 col-md-4 mb-4">
        <LinkCard class="d-flex flex-column h-100" :text="item.description" :title="item.title" :to="item.path" />
      </div>
    </div>
    <h2 class="h3">Catégories</h2>
    <p>Les armes sont réparties en deux catégories :</p>
    <div class="row">
      <div v-for="(item, index) in list" :key="index" class="col-xs-12 col-sm-6 mb-4">
        <LinkCard class="d-flex flex-column h-100" :text="item.description" :title="item.title" :to="item.path" />
      </div>
    </div>
    <h3 class="h5">🚧</h3>
    <p>🚧</p>
    <div class="row">
      <div v-for="(item, index) in other" :key="index" class="col-xs-12 col-sm-6 mb-4">
        <LinkCard class="d-flex flex-column h-100" :text="item.description" :title="item.title" :to="item.path" />
      </div>
    </div>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [{ text: "Équipement", to: "/regles/equipement" }];
const title: string = "Armes";

type MenuItem = {
  path: string;
  title: string;
  description: string;
};
const items: MenuItem[] = [
  {
    path: "/regles/equipement/armes/formation",
    title: "Formation",
    description: "La formation nécessaire pour manier une arme et les pénalités sans.",
  },
  {
    path: "/regles/equipement/armes/attaque",
    title: "Attaque",
    description: "Bonus au test d’attaque selon la taille de l’arme.",
  },
  {
    path: "/regles/equipement/armes/proprietes",
    title: "Propriétés",
    description: "Propriétés des armes et effets sur le maniement.",
  },
  {
    path: "/regles/equipement/armes/improvisees",
    title: "Armes improvisées",
    description: "Règles pour l’usage et les dégâts des armes improvisées.",
  },
  {
    path: "/regles/equipement/armes/argent",
    title: "Plaquage d’argent",
    description: "Plaquage en argent pour armes contre créatures résistantes.",
  },
  // TODO(fpion): Armes affûtées
  // TODO(fpion): Armes brisées
];
const list: MenuItem[] = [
  {
    path: "/regles/equipement/armes/simples",
    title: "Armes simples",
    description: "Des armes rudimentaires et moins adaptées à la guerre, utilisées par les roturiers et soldats improvisés.",
  },
  {
    path: "/regles/equipement/armes/martiales",
    title: "Armes martiales",
    description: "Des armes complexes, puissantes et solides, dédiées aux hommes d’armes.",
  },
];
const other: MenuItem[] = [
  {
    path: "/regles/equipement/armes/munitions",
    title: "Munitions",
    description: "Munitions et contenants pour arcs, arbalètes, sarbacanes et frondes.",
  },
  // TODO(fpion): Armes à feu et explosifs
];

useSeo({
  title,
  description: "Découvrez le fonctionnement des armes, qui permettent aux aventuriers de se défendre et à leurs adversaires de les assaillir.",
});
</script>
