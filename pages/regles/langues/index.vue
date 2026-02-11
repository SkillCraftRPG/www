<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" />
    <p>
      Les langues qu’un personnage maîtrise proviennent surtout de son <NuxtLink to="/regles/especes">espèce</NuxtLink> et de son origine, mais peuvent évoluer
      au fil de son parcours. Certaines sont courantes, d’autres plus rares ou réservées à des cercles précis, et il existe des langues regroupant plusieurs
      dialectes généralement intercompréhensibles. Cette page présente les langues des espèces et ethnies, ainsi que l’<NuxtLink to="/regles/langues/scripts"
        >alphabet</NuxtLink
      >
      utilisé lorsqu’une forme écrite existe. En l’absence d’alphabet, la langue est uniquement orale.
    </p>
    <p>Les talents suivants permettent au personnage d’apprendre de nouvelles langues :</p>
    <div class="row">
      <div v-for="talent in talents" :key="talent.id" class="col-xs-12 col-sm-6 col-md-4 mb-4">
        <TalentCard class="d-flex flex-column h-100" :talent="talent" />
      </div>
    </div>
    <template v-if="languages.length">
      <h2 class="h3">Liste des langues</h2>
      <LanguageList v-if="languages.length" :items="languages" />
    </template>
    <button class="btn btn-lg btn-primary position-fixed bottom-0 end-0 m-3 rounded-circle" @click="scrollToTop">
      <font-awesome-icon icon="fas fa-arrow-up" />
    </button>
  </main>
</template>

<script setup lang="ts">
import { arrayUtils } from "logitar-js";

import type { Language, SearchResults, Talent } from "~/types/game";

const config = useRuntimeConfig();
const title: string = "Langues";
const { orderBy } = arrayUtils;

type Data = {
  languages: SearchResults<Language>;
  talents: SearchResults<Talent>;
};
const query: string = ["interprete", "langue-supplementaire", "linguistique", "philologie", "synergie-alphabetique"].map((slug) => `slug=${slug}`).join("&");
const { data } = await useLazyAsyncData<Data>(
  "languages",
  async () => {
    const [languages, talents] = await Promise.all([
      $fetch("/api/rules/languages?sort=Slug", {
        baseURL: config.public.apiBaseUrl,
      }),
      $fetch(`/api/talents?${query}`, {
        baseURL: config.public.apiBaseUrl,
      }),
    ]);
    return {
      languages: languages as SearchResults<Language>,
      talents: talents as SearchResults<Talent>,
    };
  },
  {
    server: false,
  },
);

const languages = computed<Language[]>(() => data.value?.languages.items ?? []);
const talents = computed<Talent[]>(() =>
  orderBy(
    (data.value?.talents.items ?? []).map((talent) => ({ ...talent, sort: [talent.tier, talent.slug].join("_") })),
    "sort",
  ),
);

useSeo({
  title,
  description:
    "Découvrez les langues de l’univers, leurs usages, dialectes et alphabets, ainsi que les talents permettant d’en apprendre et de les interpréter.",
});
</script>
