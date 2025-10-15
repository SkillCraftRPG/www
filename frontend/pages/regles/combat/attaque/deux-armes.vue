<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Une créature peut tenir une <NuxtLink to="/regles/equipement/armes">arme</NuxtLink> à une main dans chacune de ses mains. Si une de ces armes n’est pas
      dotée de la propriété <NuxtLink to="/regles/equipement/armes/proprietes">Légère</NuxtLink>, alors tous les
      <NuxtLink to="/regles/competences/tests">tests</NuxtLink> d’attaque de cette créature sont affligés du
      <NuxtLink to="/regles/competences/tests/avantage-desavantage">désavantage</NuxtLink>.
    </p>
    <p>
      Toute créature est dotée d’une main principale, déterminée à sa création, qui ne peut être changée par la suite. Lorsqu’elle effectue une attaque en
      maniant une arme avec une autre de ses mains, alors son test est affligé du désavantage et elle n’ajoute que la moitié de sa
      <NuxtLink to="/regles/statistiques/force">Force</NuxtLink> ou de sa <NuxtLink to="/regles/statistiques/precision">Précision</NuxtLink> aux points de
      dégâts infligés.
    </p>
    <p>Les <NuxtLink to="/regles/talents">talents</NuxtLink> suivants améliorent votre capacité à combattre en maniant plusieurs armes :</p>
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
  { text: "Attaque", to: "/regles/combat/attaque" },
];
const title: string = "Combat à deux armes";
const { orderBy } = arrayUtils;

const query: string = ["ambidextre", "desarconnement", "double-attaque"].map((slug) => `slug=${slug}`).join("&");
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
  description: "Découvrez les règles du combat à deux armes : attaques avec main principale et secondaire, désavantages, bonus et talents associés.",
});
</script>
