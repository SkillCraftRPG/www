<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" />
    <p>
      Les spécialisations représentent les possibilités d’avancement d’un personnage au travers des
      <NuxtLink to="/regles/personnages/progression/tiers">tiers</NuxtLink>. Chaque spécialisation ne peut être acquise qu’une seule fois.
    </p>
    <p>
      Lorsqu’un personnage acquiert une spécialisation, son tiers augmente pour refléter celui de la spécialisation. Par exemple, lorsqu’un personnage de tiers
      0 acquiert une spécialisation de tiers 1, alors son tiers de personnage augmente à 1.
    </p>
    <div class="row">
      <div v-for="(item, index) in items" :key="index" class="col-xs-12 col-sm-6 mb-4">
        <LinkCard class="d-flex flex-column h-100" :text="item.description" :title="item.title" :to="item.path" />
      </div>
    </div>
    <template v-if="specializations.length">
      <h2 class="h3">Liste des spécialisations</h2>
      <SpecializationList :items="specializations" />
    </template>
  </main>
</template>

<script setup lang="ts">
import type { SearchResults } from "~/types/game";
import type { Specialization } from "~/types/specializations";

const config = useRuntimeConfig();
const title: string = "Spécialisations";

type MenuItem = {
  path: string;
  title: string;
  description: string;
};
const items: MenuItem[] = [
  {
    path: "/regles/specialisations/acquisition",
    title: "Acquisition",
    description: "Conditions, talents requis et pouvoirs associés selon le tiers.",
  },
  {
    path: "/regles/specialisations/talent-reserve",
    title: "Talent réservé",
    description: "Capacités uniques aux spécialisations, coût variable selon le tiers.",
  },
];

const { data } = await useLazyAsyncData<SearchResults<Specialization>>(
  "specializations",
  () =>
    $fetch("/api/specializations", {
      baseURL: config.public.apiBaseUrl,
    }),
  {
    server: false,
  },
);

const specializations = computed<Specialization[]>(() => data.value?.items ?? []);

useSeo({
  title,
  description:
    "Découvrez les spécialisations : progression des personnages à travers les tiers, acquisition unique, conditions, talents requis et pouvoirs associés.",
});
</script>
