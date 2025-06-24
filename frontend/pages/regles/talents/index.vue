<template>
  <div>
    <main class="container">
      <h1>{{ title }}</h1>
      <AppBreadcrumb :active="title" />
      <!-- TODO(fpion): explanation text -->
      <p>{{ "[…]" }}</p>
    </main>
    <section class="container-fluid">
      <table v-if="talents.length" class="table table-striped">
        <thead>
          <tr>
            <th scope="col">Tiers</th>
            <th scope="col">Nom</th>
            <th scope="col">Talent requis</th>
            <th scope="col">Compétence</th>
            <th scope="col">Achats multiples</th>
            <th scope="col">Résumé</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="talent in talents" :key="talent.id">
            <td>{{ talent.tier }}</td>
            <td>
              <NuxtLink :to="`/regles/talents/${talent.slug}`">{{ talent.name }}</NuxtLink>
            </td>
            <td>
              <NuxtLink v-if="talent.requiredTalent" :to="`/regles/talents/${talent.requiredTalent.slug}`">{{ talent.requiredTalent.name }}</NuxtLink>
              <span v-else class="text-muted">{{ "—" }}</span>
            </td>
            <td>
              <NuxtLink v-if="talent.skill" :to="`/regles/competences/${talent.skill.slug}`">{{ talent.skill.name }}</NuxtLink>
              <span v-else class="text-muted">{{ "—" }}</span>
            </td>
            <td>
              <TalentAllowMultiplePurchases :talent="talent" />
            </td>
            <td>
              <template v-if="talent.summary">{{ talent.summary }}</template>
              <span v-else class="text-muted">{{ "—" }}</span>
            </td>
          </tr>
        </tbody>
      </table>
    </section>
  </div>
</template>

<script setup lang="ts">
import { arrayUtils } from "logitar-js";

import type { SearchResults, Talent } from "~/types/game";

type SortableTablent = Talent & {
  order: string;
};

const config = useRuntimeConfig();
const title: string = "Talents";
const { orderBy } = arrayUtils;

const { data } = await useFetch("/api/talents", {
  baseURL: config.public.apiBaseUrl,
  cache: "no-cache",
  server: false,
});
const talents = computed<SortableTablent[]>(() => {
  const results = data.value as SearchResults<Talent>;
  if (!results) {
    return [];
  }
  return orderBy(
    results.items.map((talent) => ({
      ...talent,
      order: [talent.tier, talent.name].join("_"),
    })),
    "order",
  );
});

useSeoMeta({
  title,
  description: "Découvrez les talents : des capacités uniques qui enrichissent les personnages et façonnent leur style de jeu.",
});
useLinks();
</script>
