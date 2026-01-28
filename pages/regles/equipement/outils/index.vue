<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>Des outils et trousses variés pour l’artisanat, l’exploration, la survie et les interactions sociales.</p>
    <div class="row">
      <div v-for="(item, index) in items" :key="index" class="col-xs-12 col-sm-6 mb-4">
        <LinkCard class="d-flex flex-column h-100" :text="item.description" :title="item.title" :to="item.path" />
      </div>
    </div>
    <h2 class="h3">Outils d’artisanat et trousses</h2>
    <p>Le talent <NuxtLink to="/regles/talents/artisanat">Artisanat</NuxtLink> permet de se former pour les outils et trousses suivants.</p>
    <ItemList :items="artisan" />
    <h2 class="h3">Autres outils et trousses</h2>
    <p>La formation aux outils et trousses suivants nécessite un talent spécifique.</p>
    <ItemSpecialToolList :items="special" />
    <button class="btn btn-lg btn-primary position-fixed bottom-0 end-0 m-3 rounded-circle" @click="scrollToTop">
      <font-awesome-icon icon="fas fa-arrow-up" />
    </button>
  </main>
</template>

<script setup lang="ts">
import { arrayUtils } from "logitar-js";

import type { Breadcrumb } from "~/types/components";
import type { Tool } from "~/types/items";
import { getTools } from "~/services/items";

const parent: Breadcrumb[] = [{ text: "Équipement", to: "/regles/equipement" }];
const title: string = "Outils et trousses";
const { orderBy } = arrayUtils;

type MenuItem = {
  path: string;
  title: string;
  description: string;
};
const items: MenuItem[] = [
  {
    path: "/regles/equipement/outils/jeux",
    title: "Ensembles de jeu",
    description: "Jeux variés : dés, dominos, échecs, tarot et divertissements.",
  },
  {
    path: "/regles/equipement/outils/musique",
    title: "Instruments de musique",
    description: "Flûtes, luths, tambours et cornemuses : instruments pour rythmer l’aventure.",
  },
];

const tools = ref<Tool[]>(getTools());

const artisan = computed<Tool[]>(() =>
  orderBy(
    tools.value.filter(({ category, talents }) => category === "Crafting" && (!talents || !talents.length)),
    "slug",
  ),
);
const special = computed<Tool[]>(() =>
  orderBy(
    tools.value.filter(({ category, talents }) => category === "Crafting" && talents && talents.length),
    "slug",
  ),
);

useSeo({
  title,
  description: "Découvrez les outils et trousses essentiels : artisanat, métiers, soins, déguisement, empoisonnement et cuisine pour toutes vos aventures.",
});
</script>
