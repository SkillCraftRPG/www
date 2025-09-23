<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" />
    <p>Les statistiques sont d’autres nombres qui déterminent et influencent les capacités, forces et faiblesses des personnages et créatures.</p>
    <p>
      Les statistiques sont le résultat d’un calcul mathématique. Chaque statistique est gouvernée par un <NuxtLink to="/regles/attributs">attribut</NuxtLink>,
      et certaines statistiques progressent avec le <NuxtLink to="/regles/personnages/progression/niveau">niveau</NuxtLink>.
    </p>
    <p>Le système SkillCraft utilise <strong>10 statistiques</strong>.</p>
    <StatisticList v-if="statistics.length" :items="statistics" />
  </main>
</template>

<script setup lang="ts">
import type { SearchResults, Statistic } from "~/types/game";

const config = useRuntimeConfig();
const title: string = "Statistiques";

const { data } = await useLazyAsyncData<SearchResults<Statistic>>(
  "statistics",
  () =>
    $fetch("/api/statistics", {
      baseURL: config.public.apiBaseUrl,
    }),
  {
    server: false,
  },
);

const statistics = computed<Statistic[]>(() => data.value?.items ?? []);

useSeo({
  title,
  description: "Découvrez les statistiques : des valeurs essentielles qui traduisent la vitalité, l’énergie et d’autres aspects clés des personnages en jeu.",
});
</script>
