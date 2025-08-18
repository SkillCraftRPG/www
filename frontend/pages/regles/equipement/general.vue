<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>🚧</p>
    <h2 class="h3">Table des matières</h2>
    <ul>
      <li>
        <a href="#articles">Articles</a>
      </li>
      <li>
        <a href="#conteneurs">Conteneurs</a>
      </li>
      <li>
        <a href="#vetements">Vêtements</a>
      </li>
    </ul>
    <h2 id="articles" class="h3">Articles</h2>
    <p>🚧</p>
    <ItemList :items="items" />
    <h2 id="conteneurs" class="h3">Conteneurs</h2>
    <p>🚧</p>
    <p>
      La colonne <i>Capacité</i> correspond à la masse maximale qu’un contenant peu supporter, en kilogrammes. Si son contenu excède cette capacité, le
      contenant brise.
    </p>
    <ItemContainerList :items="containers" />
    <h2 id="vetements" class="h3">Vêtements</h2>
    <p>🚧</p>
    <ItemList :items="clothing" />
    <button class="btn btn-lg btn-primary position-fixed bottom-0 end-0 m-3 rounded-circle" @click="scrollToTop">
      <font-awesome-icon icon="fas fa-arrow-up" />
    </button>
  </main>
</template>

<script setup lang="ts">
import { arrayUtils } from "logitar-js";

import type { Breadcrumb } from "~/types/components";
import type { Item } from "~/types/items";
import { getClothingItems, getContainers, getGeneralItems } from "~/services/items";

const parent: Breadcrumb[] = [{ text: "Équipement", to: "/regles/equipement" }];
const title: string = "Équipement général";
const { orderBy } = arrayUtils;

const clothing = ref<Item[]>(orderBy(getClothingItems(), "slug"));
const containers = ref<Item[]>(orderBy(getContainers(), "slug"));
const items = ref<Item[]>(orderBy(getGeneralItems(), "slug"));

useSeo({
  title,
  description: "🚧",
});
</script>
