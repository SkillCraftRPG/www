<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      La table ci-dessous spécifie les munitions nécessaires pour les armes dotées de la propriété
      <NuxtLink to="/regles/equipement/armes/proprietes">Munition</NuxtLink>, ainsi que le contenant pour ces munitions.
    </p>
    <p>Un personnage doit posséder le bon contenant pour chaque type de munition. Chaque contenant peut contenir un nombre maximal de munitions.</p>
    <p>Lorsqu’il perd toutes ses munitions, le personnage n’a besoin que de racheter celles-ci, il conserve le contenant qu’il possède déjà.</p>
    <ItemAmmunitionList :items="ammunition" />
  </main>
</template>

<script setup lang="ts">
import { arrayUtils } from "logitar-js";

import type { Ammunition } from "~/types/items";
import type { Breadcrumb } from "~/types/components";
import { getAmmunition } from "~/services/items";

const parent: Breadcrumb[] = [
  { text: "Équipement", to: "/regles/equipement" },
  { text: "Armes", to: "/regles/equipement/armes" },
];
const title: string = "Munitions";
const { orderBy } = arrayUtils;

const ammunition = ref<Ammunition[]>(orderBy(getAmmunition(), "slug"));

useSeo({
  title,
  description:
    "Découvrez les munitions pour arcs, arbalètes, sarbacanes, frondes et armes à feu, ainsi que leurs contenants indispensables pour vos aventures.",
});
</script>
