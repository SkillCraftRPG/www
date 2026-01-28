<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Vous canalisez un <NuxtLink to="/regles/magie/pouvoirs">pouvoir</NuxtLink>. Cette action déclenche une
      <NuxtLink to="/regles/combat/attaque/opportunite">attaque d’opportunité</NuxtLink>.
    </p>
    <p>
      Par une <NuxtLink to="/regles/combat/deroulement/tour">action</NuxtLink>, vous pouvez également commencer à canaliser un pouvoir. Lors de votre prochain
      <NuxtLink to="/regles/combat/deroulement/tour">tour</NuxtLink>, il vous coûtera une action en moins afin de compléter la canalisation. L’action est perdue
      si vous ne terminez pas la canalisation lors de votre prochain tour, ou si vous canalisez un autre pouvoir entre-temps. Vous n’avez pas besoin de vous
      <NuxtLink to="/regles/combat/activites/concentration">concentrer</NuxtLink> sur cette canalisation, et vous ne déclenchez une attaque d’opportunité qu’au
      moment où vous complétez la canalisation.
    </p>
    <p>Les <NuxtLink to="/regles/talents">talents</NuxtLink> suivants améliorent votre capacité à canaliser :</p>
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
const title: string = "Canaliser";
const { orderBy } = arrayUtils;

const query: string = ["magie-guerriere", "magie-precise", "magie-puissante", "maximisation-magique", "optimisation-magique"]
  .map((slug) => `slug=${slug}`)
  .join("&");
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
    "Découvrez comment canaliser un pouvoir : règles, actions requises et talents spéciaux pour améliorer puissance, précision, défense et optimisation magique.",
});
</script>
