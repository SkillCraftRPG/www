<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Un personnage peut dépenser les <NuxtLink to="/regles/talents/points">points de talent</NuxtLink> obtenus à chaque
      <NuxtLink to="/regles/personnages/progression/niveau">gain de niveau</NuxtLink> afin d’acquérir de nouveaux pouvoirs.
    </p>
    <p>
      Les pouvoirs sont regroupés par famille, et un <NuxtLink to="/regles/talents">talent</NuxtLink> est nécessaire afin d’acquérir les pouvoirs de cette
      famille.
    </p>
    <p>
      Les <NuxtLink to="/regles/talents/acquisition">conditions</NuxtLink>, tiers et l’effet des <NuxtLink to="/regles/talents/points">rabais</NuxtLink> sont
      les mêmes que pour les talents.
    </p>
    <p>Le nombre de points de talent à dépenser afin d’acquérir un pouvoir varie en fonction de son tiers.</p>
    <TalentCostTable />
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Magie", to: "/regles/magie" },
  { text: "Pouvoirs", to: "/regles/magie/pouvoirs" },
];
const title: string = "Apprentissage";

useSeo({
  title,
  description: "Découvrez comment dépenser vos points de talent pour acquérir de nouveaux pouvoirs selon leur famille et leur tier.",
});
</script>
