<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>L’armure est une protection physique, et parfois magique, portée par les aventuriers, les hommes d’armes ainsi que certaines créatures.</p>
    <div class="row">
      <div v-for="(item, index) in items" :key="index" class="col-xs-12 col-sm-6 col-md-4 mb-4">
        <LinkCard class="d-flex flex-column h-100" :text="item.description" :title="item.title" :to="item.path" />
      </div>
    </div>
    <h2 class="h3">Catégories</h2>
    <p>Les armures sont réparties en trois catégories :</p>
    <div class="row">
      <div v-for="(item, index) in list" :key="index" class="col-xs-12 col-sm-6 col-md-4 mb-4">
        <LinkCard class="d-flex flex-column h-100" :text="item.description" :title="item.title" :to="item.path" />
      </div>
    </div>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [{ text: "Équipement", to: "/regles/equipement" }];
const title: string = "Armure";

type MenuItem = {
  path: string;
  title: string;
  description: string;
};
const items: MenuItem[] = [
  {
    path: "/regles/equipement/armure/formation",
    title: "Formation",
    description: "La formation nécessaire pour porter une armure et les pénalités sans.",
  },
  {
    path: "/regles/equipement/armure/proprietes",
    title: "Propriétés",
    description: "Propriétés des armures et effets sur le porteur.",
  },
  {
    path: "/regles/equipement/armure/enfiler-retirer",
    title: "Enfiler ou retirer son armure",
    description: "Temps pour enfiler ou retirer une armure selon sa catégorie.",
  },
  {
    path: "/regles/equipement/armure/partielle",
    title: "Armure partielle",
    description: "Assembler, combiner et calculer la Défense des armures partielles.",
  },
  {
    path: "/regles/equipement/armure/multiple",
    title: "Armures multiples",
    description: "Porter deux couches d’armure et combiner leurs effets.",
  },
  // TODO(fpion): Armures renforcées
];
const list: MenuItem[] = [
  {
    path: "/regles/equipement/armure/legeres",
    title: "Armures légères",
    description: "Des protections minces au poids léger qui ne restreignent pratiquement pas.",
  },
  {
    path: "/regles/equipement/armure/moyennes",
    title: "Armures moyennes",
    description: "Ces armures offrent le meilleur compromis entre protection et mobilité.",
  },
  {
    path: "/regles/equipement/armure/lourdes",
    title: "Armures lourdes",
    description: "Ces armures offrent une protection maximale, au prix d’un poids élevé ou d’une mobilité réduite.",
  },
];

useSeo({
  title,
  description:
    "Découvrez le fonctionnement des armures, ces protections physiques et parfois magiques, portées par les aventuriers, les hommes d’armes et certaines créatures.",
});
</script>
