<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" />
    <p>Les attributs quantifient les forces et faiblesses des personnages et créatures. Ils influencent également les chances de réussite de leurs actions.</p>
    <p>La valeur d’un attribut varie généralement entre -5 et +5, mais certaines conditions peuvent amener cette valeur en-dehors de ces bornes.</p>
    <p>
      Les attributs influencent les <NuxtLink to="/regles/statistiques">statistiques</NuxtLink> ainsi que les
      <NuxtLink to="/regles/competences">compétences</NuxtLink>.
    </p>
    <p>Le système SkillCraft utilise <strong>5 attributs</strong> :</p>
    <ul>
      <li>
        <font-awesome-icon icon="fas fa-dumbbell" />
        2 attributs physiques, qui bénéficieront davantage aux personnages actifs.
      </li>
      <li>
        <font-awesome-icon icon="fas fa-brain" />
        2 attributs mentaux, qui bénéficieront davantage aux personnages intellectuels.
      </li>
      <li>
        <font-awesome-icon icon="fas fa-heart" />
        Un attribut universel dont tous les personnages bénéficient.
      </li>
    </ul>
    <div class="row">
      <div v-for="attribute in attributes" :key="attribute.id" class="col-xs-12 col-sm-6 col-md-4 col-lg-3 col-fifth mb-4">
        <AttributeDetailCard :attribute="attribute" class="d-flex flex-column h-100" />
      </div>
    </div>
  </main>
</template>

<script setup lang="ts">
import { arrayUtils } from "logitar-js";

import type { Attribute, SearchResults } from "~/types/game";

type SortableAttribute = Attribute & {
  order: string;
};

const config = useRuntimeConfig();
const title: string = "Attributs";
const { orderBy } = arrayUtils;

const { data } = await useFetch("/api/attributes", {
  baseURL: config.public.apiBaseUrl,
  cache: "no-cache",
  server: false,
});

const attributes = computed<SortableAttribute[]>(() => {
  const results = data.value as SearchResults<Attribute>;
  if (!results) {
    return [];
  }
  return orderBy(
    results.items.map((attribute) => {
      let index: number = 2;
      switch (attribute.value) {
        case "Dexterity":
        case "Vigor":
          index = 0;
          break;
        case "Intellect":
        case "Senses":
          index = 1;
      }
      return {
        ...attribute,
        skills: orderBy(attribute.skills, "name"),
        order: [index, attribute.name].join("_"),
      };
    }),
    "order",
  );
});

useSeo({
  title,
  description:
    "Découvrez le fonctionnement des attributs de personnage : des caractéristiques clés qui définissent les forces, faiblesses et compétences de vos héros.",
});
</script>
