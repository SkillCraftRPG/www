<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" />
    <p>Les attributs quantifient les forces et faiblesses des personnages et créatures. Ils influencent également les chances de réussite de leurs actions.</p>
    <p>La valeur d’un attribut varie généralement entre -5 et +5, mais certaines conditions peuvent amener cette valeur en-dehors de ces bornes.</p>
    <p>Le système SkillCraft utilise <strong>5 attributs</strong> :</p>
    <ul>
      <li>
        <font-awesome-icon :icon="categories[0].icon" />
        2 attributs physiques, qui bénéficieront davantage aux personnages actifs.
      </li>
      <li>
        <font-awesome-icon :icon="categories[1].icon" />
        2 attributs mentaux, qui bénéficieront davantage aux personnages intellectuels.
      </li>
      <li>
        <font-awesome-icon :icon="categories[2].icon" />
        Un attribut universel dont tous les personnages bénéficient.
      </li>
    </ul>
    <table v-if="attributes.length" class="table table-striped">
      <thead>
        <tr>
          <th scope="col">Attribut</th>
          <th scope="col">Résumé</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="categorized in attributes" :key="categorized.attribute.id">
          <td>
            <NuxtLink :to="`/regles/attributs/${categorized.attribute.slug}`">{{ categorized.attribute.name }}</NuxtLink>
            <br />
            <font-awesome-icon class="me-1" :icon="categorized.category.icon" />
            <i>{{ categorized.category.text }}</i>
          </td>
          <td>
            <span v-if="categorized.attribute.summary">{{ categorized.attribute.summary }}</span>
            <span v-else class="text-muted">{{ "—" }}</span>
          </td>
        </tr>
      </tbody>
    </table>
  </main>
</template>

<script setup lang="ts">
import { arrayUtils } from "logitar-js";

import type { Attribute, SearchResults } from "~/types/game";

type Category = {
  icon: string;
  text: string;
};
type CategorizedAttribute = {
  attribute: Attribute;
  category: Category;
  sort: string;
};

const categories = [
  { icon: "fas fa-dumbbell", text: "Physique" },
  { icon: "fas fa-brain", text: "Mental" },
  { icon: "fas fa-heart", text: "Universel" },
];
const config = useRuntimeConfig();
const title: string = "Attributs";
const { orderBy } = arrayUtils;

const { data } = await useFetch("/api/attributes", {
  baseURL: config.public.apiBaseUrl,
  server: false,
});

const attributes = computed<CategorizedAttribute[]>(() => {
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
        attribute,
        category: categories[index],
        sort: [index, attribute.name].join("_"),
      };
    }),
    "sort",
  );
});

useSeoMeta({
  title,
  description:
    "Découvrez le fonctionnement des attributs de personnage : des caractéristiques clés qui définissent les forces, faiblesses et compétences de vos héros.",
});
useLinks();
</script>
