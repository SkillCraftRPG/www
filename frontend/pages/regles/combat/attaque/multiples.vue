<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb active="Multiples" :parent="parent" />
    <p>
      Pendant son <NuxtLink to="/regles/combat/deroulement/tour">tour</NuxtLink>, une créature peut effectuer une
      <NuxtLink to="/regles/combat/activites">activité</NuxtLink> <i>Attaquer</i> par membre de son corps.
    </p>
    <p>Par exemple, un personnage doté de deux bras et de deux jambes peut effectuer un attaque avec chacun de ses bras, ainsi qu’avec une de ses jambes.</p>
    <p>
      Lorsqu’une créature effectue plusieurs attaques pendant le même tour, un pénalité cumulable (-5, -10, etc.) est infligée au
      <NuxtLink to="/regles/competences/tests">test</NuxtLink>
      de chaque attaque à partir de la seconde.
    </p>
    <p>Les <NuxtLink to="/regles/talents">talents</NuxtLink> suivants améliorent votre capacité à effectuer de multiples attaques :</p>
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
import type { Talent } from "~/types/game";
import { getTalents } from "~/services/talents";

const parent: Breadcrumb[] = [
  { text: "Combat", to: "/regles/combat" },
  { text: "Attaque", to: "/regles/combat/attaque" },
];
const slugs: Set<string> = new Set(["attaques-multiples", "frenesie"]);
const title: string = "Attaques multiples";
const { orderBy } = arrayUtils;

const allTalents = ref<Talent[]>(getTalents());

const talents = computed<Talent[]>(() =>
  orderBy(
    allTalents.value.filter(({ slug }) => slugs.has(slug)).map((talent) => ({ ...talent, sort: [talent.tier, talent.slug].join("_") })),
    "sort",
  ),
);

useSeo({
  title,
  description:
    "Découvrez les règles des attaques multiples : frappez avec plusieurs membres par tour, subissez pénalités cumulatives et apprenez les talents pour les réduire.",
});
</script>
