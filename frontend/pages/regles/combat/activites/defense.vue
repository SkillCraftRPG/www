<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>Vous vous placez en position défensive, vous appliquant à bloquer les coups dirigés vers vous.</p>
    <p>
      Pendant votre <NuxtLink to="/regles/combat/deroulement/tour">tour</NuxtLink>, vous vous préparez par une action. Vous utilisez ensuite votre réaction afin
      d’infliger le <NuxtLink to="/regles/competences/tests/avantage-desavantage">désavantage</NuxtLink> au
      <NuxtLink to="/regles/competences/tests">test</NuxtLink> des <NuxtLink to="/regles/combat/attaque">attaques</NuxtLink> dirigées contre vous jusqu’au début
      de votre prochain tour.
    </p>
    <p>
      Votre réaction n’est pas perdue si vous ne l’utilisez pas. Également, si vous l’utilisez pour autre chose, par exemple afin d’effectuer une
      <NuxtLink to="/regles/combat/attaque/opportunite">attaque d’opportunité</NuxtLink>, vous ne pouvez pas vous défendre.
    </p>
    <p>Les <NuxtLink to="/regles/talents">talents</NuxtLink> suivants améliorent votre capacité vous défendre :</p>
    <div class="row">
      <div v-for="talent in talents" :key="talent.id" class="col-xs-12 col-sm-6 col-md-4 mb-4">
        <TalentCard class="d-flex flex-column h-100" :talent="talent" />
      </div>
    </div>
  </main>
</template>

<script setup lang="ts">
import { arrayUtils } from "logitar-js";

import type { Breadcrumb } from "~/types/components";
import type { Talent } from "~/types/game";
import { getTalents } from "~/services/talents";

const parent: Breadcrumb[] = [
  { text: "Combat", to: "/regles/combat" },
  { text: "Activités", to: "/regles/combat/activites" },
];
const slugs: Set<string> = new Set(["repli-defensif"]);
const title: string = "Défense";
const { orderBy } = arrayUtils;

const allTalents = ref<Talent[]>(getTalents());

const talents = computed<Talent[]>(() =>
  orderBy(
    allTalents.value.filter(({ slug }) => slugs.has(slug)).map((talent) => ({ ...talent, sort: [talent.tier, talent.slug].join("_") })),
    "sort",
  ),
);

useSeo({
  title,
  description:
    "Découvrez l’action Défense : préparez-vous à bloquer les attaques ennemies, infligez un désavantage aux coups reçus et renforcez votre survie en combat.",
});
</script>
