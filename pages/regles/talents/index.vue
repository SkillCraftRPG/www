<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" />
    <p>
      Une des facettes de la <NuxtLink to="/regles/personnages/progression">progression</NuxtLink> de personnage se matérialise par des talents, des capacités
      acquises au fil de ses aventures.
    </p>
    <p>
      Deux personnages suivant un parcours similaire peuvent totalement différer dans leurs choix de talents, ce qui permet au joueur de personnaliser son
      personnage en fonction de ses préférences.
    </p>
    <div class="row">
      <div v-for="(item, index) in items" :key="index" class="col-xs-12 col-sm-6 mb-4">
        <LinkCard class="d-flex flex-column h-100" :text="item.description" :title="item.title" :to="item.path" />
      </div>
    </div>
    <template v-if="talents.length">
      <h2 class="h3">Liste des talents</h2>
      <TalentList :items="talents" />
    </template>
    <button class="btn btn-lg btn-primary position-fixed bottom-0 end-0 m-3 rounded-circle" @click="scrollToTop">
      <font-awesome-icon icon="fas fa-arrow-up" />
    </button>
  </main>
</template>

<script setup lang="ts">
import type { SearchResults, Talent } from "~/types/game";

const config = useRuntimeConfig();
const title: string = "Talents";

type MenuItem = {
  path: string;
  title: string;
  description: string;
};
const items: MenuItem[] = [
  {
    path: "/regles/talents/points",
    title: "Points de talents",
    description: "Coûts, progression et rabais pour acquérir de nouveaux talents.",
  },
  {
    path: "/regles/talents/acquisition",
    title: "Acquisition de talent",
    description: "Conditions, prérequis, points requis et achats multiples avec rabais.",
  },
];

const { data } = await useLazyAsyncData<SearchResults<Talent>>(
  "talents",
  () =>
    $fetch("/api/talents", {
      baseURL: config.public.apiBaseUrl,
    }),
  {
    server: false,
  },
);

const talents = computed<Talent[]>(() => data.value?.items ?? []);

useSeo({
  title,
  description: "Découvrez les talents : des capacités uniques qui enrichissent les personnages et façonnent leur style de jeu.",
});
</script>
