<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Vous visez une cible avec une arme possédant la propriété <NuxtLink to="/regles/equipement/armes/proprietes">Munition</NuxtLink>, puis vous tirez
      (<NuxtLink to="/regles/combat/attaque/distance">attaque à distance</NuxtLink>).
    </p>
    <p>Cette action déclenche une <NuxtLink to="/regles/combat/attaque/opportunite">attaque d’opportunité</NuxtLink>.</p>
    <p>
      Également, votre <NuxtLink to="/regles/competences/tests">test</NuxtLink> est affligé du
      <NuxtLink to="/regles/competences/tests/avantage-desavantage">désavantage</NuxtLink> si votre cible se trouve à 1,5 mètres ou moins de vous.
    </p>
    <p>Les <NuxtLink to="/regles/talents">talents</NuxtLink> suivants améliorent votre capacité à viser et tirer :</p>
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
import type { SearchResults, Talent } from "~/types/game";

const config = useRuntimeConfig();
const parent: Breadcrumb[] = [
  { text: "Combat", to: "/regles/combat" },
  { text: "Activités", to: "/regles/combat/activites" },
];
const title: string = "Viser et tirer";
const { orderBy } = arrayUtils;

const query: string = ["armes de tir", "orientation", "tir-precis", "tir-rapide"].map((slug) => `slug=${slug}`).join("&");
const { data } = await useAsyncData<SearchResults<Talent>>("talents", () =>
  $fetch(`/api/talents?${query}`, {
    baseURL: config.public.apiBaseUrl,
  }),
);
const talents = computed<Talent[]>(() =>
  orderBy(
    (data.value?.items ?? []).map((talent) => ({ ...talent, sort: [talent.tier, talent.slug].join("_") })),
    "sort",
  ),
);

useSeo({
  title,
  description:
    "Découvrez les règles pour viser et tirer avec une arme à munitions, incluant attaques d’opportunité, désavantages en mêlée et talents améliorant la vitesse de tir.",
});
</script>
