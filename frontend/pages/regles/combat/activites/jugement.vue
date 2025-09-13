<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>Vous tentez d’évaluer la situation ou de déceler un comportement anormal.</p>
    <p>
      Sélectionnez une créature située à 9 mètres ou moins de votre position et que vous pouvez voir et effectuez un
      <NuxtLink to="/regles/competences/tests">test</NuxtLink> d’<NuxtLink to="/regles/competences/intuition">Intuition</NuxtLink>.
    </p>
    <p>Les <NuxtLink to="/regles/talents">talents</NuxtLink> suivants améliorent votre capacité à poser un jugement :</p>
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
  { text: "Activités", to: "/regles/combat/activites" },
];
const slugs: Set<string> = new Set(["perception-extrasensorielle"]);
const title: string = "Jugement";
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
  description: "Découvrez l’action Jugement : évaluez une situation ou décelez un comportement suspect grâce à un test d’Intuition sur une créature proche.",
});
</script>
