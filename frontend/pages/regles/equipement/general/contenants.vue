<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>Des contenants variés pour transporter monnaie, vivres, outils et ressources.</p>
    <p>
      La colonne <i>Capacité</i> correspond à la masse maximale qu’un contenant peut supporter, en kilogrammes. Si son contenu excède cette capacité, le
      contenant brise.
    </p>
    <ItemContainerList :items="containers" />
  </main>
</template>

<script setup lang="ts">
import { arrayUtils } from "logitar-js";

import type { Breadcrumb } from "~/types/components";
import type { Item } from "~/types/items";
import { getContainers } from "~/services/items";

const parent: Breadcrumb[] = [
  { text: "Équipement", to: "/regles/equipement" },
  { text: "Général", to: "/regles/equipement/general" },
];
const title: string = "Contenants";
const { orderBy } = arrayUtils;

const containers = ref<Item[]>(orderBy(getContainers(), "slug"));

useSeo({
  title,
  description: "Découvrez les contenants : bourses, sacs, tonneaux, fioles et coffres, essentiels pour stocker et transporter vos biens durant l’aventure.",
});
</script>
