<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" />
    <p>Les statistiques sont d’autres nombres qui déterminent et influencent les capacités, forces et faiblesses des personnages et créatures.</p>
    <p>
      Les statistiques sont le résultat d’un calcul mathématique. Chaque statistique est gouvernée par un <NuxtLink to="/regles/attributs">attribut</NuxtLink>,
      et certaines statistiques progressent avec le niveau.
    </p>
    <p>Le système SkillCraft utilise <strong>10 statistiques</strong>.</p>
    <div class="row">
      <div v-for="statistic in statistics" :key="statistic.id" class="col-xs-12 col-sm-6 col-md-4 col-lg-3 col-fifth mb-4">
        <StatisticCard class="d-flex flex-column h-100" :statistic="statistic" />
      </div>
    </div>
  </main>
</template>

<script setup lang="ts">
import type { SearchResults, Statistic } from "~/types/game";

const config = useRuntimeConfig();
const title: string = "Statistiques";

const { data } = await useFetch("/api/statistics", {
  baseURL: config.public.apiBaseUrl,
  cache: "no-cache",
  server: false,
});
const statistics = computed<Statistic[]>(() => (data.value as SearchResults<Statistic>)?.items ?? []);

useSeoMeta({
  title,
  description: "Découvrez les statistiques : des valeurs essentielles qui traduisent la vitalité, l’énergie et d’autres aspects clés des personnages en jeu.",
});
useLinks();
</script>
