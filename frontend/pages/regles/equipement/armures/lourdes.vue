<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb active="Lourdes" :parent="parent" />
    <p>Des armures imposantes offrant une protection maximale au prix de la mobilité.</p>
    <!--
      TODO(fpion): liens vers les sections utiles
      * Défense
      * Formation
      * Résistance
      * Propriétés
    -->
    <ItemArmorList :items="armor" />
  </main>
</template>

<script setup lang="ts">
import { arrayUtils } from "logitar-js";

import type { Armor } from "~/types/items";
import type { Breadcrumb } from "~/types/components";
import { getArmor } from "~/services/items";

const parent: Breadcrumb[] = [
  { text: "Équipement", to: "/regles/equipement" },
  { text: "Armures", to: "/regles/equipement/armures" },
];
const title: string = "Armures lourdes";
const { orderBy } = arrayUtils;

const armor = computed<Armor[]>(() =>
  orderBy(
    getArmor()
      .filter(({ category }) => category === "Heavy")
      .map((armor) => ({ ...armor, sort: [armor.defense, armor.slug].join("_") })),
    "sort",
  ),
);

useSeo({
  title,
  description: "Découvrez les armures lourdes : broigne, haubert, écailles et plate complète, conçues pour une défense optimale et une solidité inégalée.",
});
</script>
