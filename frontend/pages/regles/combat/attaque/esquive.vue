<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Toute créature est dotée d’une valeur d’<NuxtLink to="/regles/statistiques/esquive">Esquive</NuxtLink>. Lorsqu’une créature est la cible d’une attaque,
      l’attaque échoue si le résultat du <NuxtLink to="/regles/competences/tests">test</NuxtLink> est inférieur à l’Esquive de la cible.
    </p>
    <p>Les <NuxtLink to="/regles/talents">talents</NuxtLink> suivants améliorent votre capacité à esquiver :</p>
    <div class="row">
      <div v-for="talent in talents" :key="talent.id" class="col-xs-12 col-sm-6 mb-4">
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
  { text: "Attaque", to: "/regles/combat/attaque" },
];
const title: string = "Esquive";
const { orderBy } = arrayUtils;

const query: string = ["ambidextre", "desarconnement", "parade", "prediction"].map((slug) => `slug=${slug}`).join("&");
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
  description: "Découvrez les règles d’Esquive : comparez vos tests aux attaques ennemies et explorez les talents qui renforcent vos chances d’éviter un coup.",
});
</script>
