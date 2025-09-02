<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb active="Général" :parent="parent" />
    <p>Des articles pratiques et variés pour faciliter la vie quotidienne des aventuriers.</p>
    <div class="row">
      <div v-for="(item, index) in list" :key="index" class="col-xs-12 col-sm-6 mb-4">
        <LinkCard class="d-flex flex-column h-100" :text="item.description" :title="item.title" :to="item.path" />
      </div>
    </div>
    <h2 class="h3">Articles divers</h2>
    <ItemList :items="items" />
    <button class="btn btn-lg btn-primary position-fixed bottom-0 end-0 m-3 rounded-circle" @click="scrollToTop">
      <font-awesome-icon icon="fas fa-arrow-up" />
    </button>
  </main>
</template>

<script setup lang="ts">
import { arrayUtils } from "logitar-js";

import type { Breadcrumb } from "~/types/components";
import type { Item } from "~/types/items";
import { getGeneralItems } from "~/services/items";

const parent: Breadcrumb[] = [{ text: "Équipement", to: "/regles/equipement" }];
const title: string = "Équipement général";
const { orderBy } = arrayUtils;

type MenuItem = {
  path: string;
  title: string;
  description: string;
};
const list: MenuItem[] = [
  {
    path: "/regles/equipement/general/contenants",
    title: "Contenants",
    description: "Bourses, sacs, fioles et tonneaux : contenants pour stocker et transporter.",
  },
  {
    path: "/regles/equipement/general/vetements",
    title: "Vêtements",
    description: "Vêtements pour roturiers, voyageurs, religieux ou nobles des grandes occasions",
  },
];

const items = ref<Item[]>(orderBy(getGeneralItems(), "slug"));

useSeo({
  title,
  description: "Découvrez l’équipement général : outils, lampes, cordes, rations et objets utiles pour le voyage, la survie et les situations imprévues.",
});
</script>
