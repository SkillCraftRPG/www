<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb active="Martiales" :parent="parent" />
    <p>Des armes puissantes et spécialisées pour guerriers aguerris et combattants d’élite.</p>
    <ItemWeaponList :items="weapons" />
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
