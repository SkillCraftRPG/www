<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Vous maintenez actif un <NuxtLink to="/regles/magie/pouvoirs">pouvoir</NuxtLink> nécessitant la
      <NuxtLink to="/regles/magie/parametres/duree">concentration</NuxtLink>.
    </p>
    <p>
      Maintenir votre concentration est une <NuxtLink to="/regles/combat/deroulement/tour">action libre</NuxtLink>, mais vous ne pouvez vous concentrer que sur
      un seul pouvoir à la fois.
    </p>
    <p>Les <NuxtLink to="/regles/talents">talents</NuxtLink> suivants améliorent votre capacité à maintenir votre concentration :</p>
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
const slugs: Set<string> = new Set(["magie-guerriere"]);
const title: string = "Concentration";
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
  description: "Découvrez comment maintenir un pouvoir actif grâce à la concentration : une action libre, mais limitée à un seul pouvoir à la fois.",
});
</script>
