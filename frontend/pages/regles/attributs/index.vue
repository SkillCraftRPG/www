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
    <AttributeList v-if="attributes.length" :items="attributes" />
  </main>
</template>

<script setup lang="ts">
import { arrayUtils } from "logitar-js";

import type { Attribute } from "~/types/game";
import { getAttributes } from "~/services/attributes";

const title: string = "Attributs";
const { orderBy } = arrayUtils;

const attributes = computed<Attribute[]>(() =>
  orderBy(
    getAttributes({ statistics: true, skills: true }).map((attribute) => {
      let sort: string = "2";
      switch (attribute.category) {
        case "Physical":
          sort = "0";
          break;
        case "Mental":
          sort = "1";
          break;
      }
      sort = `${sort}_${attribute.slug}`;
      return { ...attribute, sort };
    }),
    "sort",
  ),
);

useSeo({
  title,
  description:
    "Découvrez le fonctionnement des attributs de personnage : des caractéristiques clés qui définissent les forces, faiblesses et compétences de vos héros.",
});
</script>
