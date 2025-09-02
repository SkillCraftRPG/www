<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb active="Martiales" :parent="parent" />
    <p>Des armes puissantes et spécialisées pour guerriers aguerris et combattants d’élite.</p>
    <!--
      TODO(fpion): liens vers les sections utiles
      * Attaque
      * Dégâts
      * Formation
      * Propriétés
    -->
    <ItemWeaponList :items="weapons" />
    <button class="btn btn-lg btn-primary position-fixed bottom-0 end-0 m-3 rounded-circle" @click="scrollToTop">
      <font-awesome-icon icon="fas fa-arrow-up" />
    </button>
  </main>
</template>

<script setup lang="ts">
import { arrayUtils } from "logitar-js";

import type { Breadcrumb } from "~/types/components";
import type { Weapon } from "~/types/items";
import { getWeapons } from "~/services/items";

const parent: Breadcrumb[] = [
  { text: "Équipement", to: "/regles/equipement" },
  { text: "Armes", to: "/regles/equipement/armes" },
];
const title: string = "Armes martiales";
const { orderBy } = arrayUtils;

const weapons = ref<Weapon[]>(
  orderBy(
    getWeapons().filter(({ category }) => category === "Martial"),
    "slug",
  ),
);

useSeo({
  title,
  description:
    "Découvrez les armes martiales : épées longues, hallebardes, arbalètes lourdes et autres équipements avancés réservés aux combattants entraînés.",
});
</script>
