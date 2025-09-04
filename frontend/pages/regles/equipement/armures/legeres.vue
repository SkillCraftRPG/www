<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb active="Légères" :parent="parent" />
    <p>Des armures souples offrant protection et confort sans sacrifier la mobilité.</p>
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
const title: string = "Armures légères";
const { orderBy } = arrayUtils;

const armor = computed<Armor[]>(() =>
  orderBy(
    getArmor()
      .filter(({ category }) => category === "Light")
      .map((armor) => ({ ...armor, sort: [armor.defense, armor.slug].join("_") })),
    "sort",
  ),
);

useSeo({
  title,
  description: "Découvrez les armures légères comme la brigandine, le cuir et le cuir clouté, alliant protection basique, confort et liberté de mouvement.",
});
</script>
