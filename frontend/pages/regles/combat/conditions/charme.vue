<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Une créature charmée ne peut <NuxtLink to="/regles/combat/attaque">attaquer</NuxtLink> la source du charme, ni utiliser quelconque habileté naturelle ou
      surnaturelle mettant en péril la source du charme.
    </p>
    <p>
      Également, la source du charme se voit conférer l’<NuxtLink to="/regles/competences/tests/avantage-desavantage">avantage</NuxtLink> à ses
      <NuxtLink to="/regles/competences/tests">tests</NuxtLink> lorsqu’elle
      <NuxtLink to="/regles/aventure/interaction-sociale">interagit socialement</NuxtLink> avec la créature charmée.
    </p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Combat", to: "/regles/combat" },
  { text: "Conditions", to: "/regles/combat/conditions" },
];
const title: string = "Charmé";

useSeo({
  title,
  description: "Découvrez la condition Charmé : une créature ne peut attaquer la source du charme et lui accorde un avantage lors des interactions sociales.",
});
</script>
