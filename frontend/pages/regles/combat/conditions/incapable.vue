<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>Une créature incapable ne peut effectuer aucune <NuxtLink to="/regles/combat/deroulement/tour">action, ni action libre ou réaction</NuxtLink>.</p>
    <p>
      Lorsqu’elle devient incapable, elle perd sa <NuxtLink to="/regles/magie/parametres/duree">Concentration</NuxtLink> si elle maintenait un
      <NuxtLink to="/regles/magie/pouvoirs">pouvoir</NuxtLink> actif.
    </p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Combat", to: "/regles/combat" },
  { text: "Conditions", to: "/regles/combat/conditions" },
];
const title: string = "Incapable";

useSeo({
  title,
  description: "Découvrez l’état Incapable, une condition qui prive totalement une créature de ses actions, actions libres et réactions en combat.",
});
</script>
