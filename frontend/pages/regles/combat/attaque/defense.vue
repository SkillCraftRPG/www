<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Toute créature est dotée d’une valeur de Défense. Cette valeur est égale à la somme de l’<NuxtLink to="/regles/statistiques/esquive">Esquive</NuxtLink> de
      cette créature et des bonus de <NuxtLink to="/regles/equipement/defense">Défense</NuxtLink> conférés par son
      <NuxtLink to="/regles/equipement">équipement</NuxtLink>.
    </p>
    <p>
      Lorsqu’une créature est la cible d’une attaque, l’attaque réussit si le résultat du <NuxtLink to="/regles/competences/tests">test</NuxtLink> est supérieur
      ou égal à la Défense de la cible.
    </p>
    <p>
      Si le résultat du test est inférieur à la Défense de la cible, mais qu’il est supérieur ou égal à son
      <NuxtLink to="/regles/combat/attaque/esquive">Esquive</NuxtLink>, alors l’attaque est bloquée par le
      <NuxtLink to="/regles/equipement/boucliers">bouclier</NuxtLink> ou l’<NuxtLink to="/regles/equipement/armures">armure</NuxtLink> de la cible. L’équipement
      en question subit une perte de <NuxtLink to="/regles/equipement/resistance">Résistance</NuxtLink>.
    </p>
    <p>Les <NuxtLink to="/regles/talents">talents</NuxtLink> suivants améliorent votre capacité vous défendre ou à défendre vos alliés :</p>
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
import type { Talent } from "~/types/game";
import { getTalents } from "~/services/talents";

const parent: Breadcrumb[] = [
  { text: "Combat", to: "/regles/combat" },
  { text: "Attaque", to: "/regles/combat/attaque" },
];
const slugs: Set<string> = new Set(["ame-de-diamant", "barriere-mentale", "blinde", "coup-de-bouclier", "protection"]);
const title: string = "Défense";
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
    "Découvrez les règles de Défense : combinez esquive et équipements pour bloquer les attaques, et explorez les talents qui renforcent votre protection.",
});
</script>
