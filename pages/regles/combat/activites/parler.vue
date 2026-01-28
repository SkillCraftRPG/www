<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>Vous prononcez, criez ou chuchotez quelques mots.</p>
    <p>
      Vous parlez en <NuxtLink to="/regles/combat/deroulement/tour">action libre</NuxtLink>, mais votre discours ne doit pas durer plus de
      <NuxtLink to="/regles/aventure/temps">6 secondes</NuxtLink>.
    </p>
    <p>En langue française, on peut exprimer approximativement 25 mots par round.</p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Combat", to: "/regles/combat" },
  { text: "Activités", to: "/regles/combat/activites" },
];
const title: string = "Parler";

useSeo({
  title,
  description: "Découvrez comment parler en combat : exprimez jusqu’à 25 mots par round en action libre, sans dépasser 6 secondes de discours.",
});
</script>
