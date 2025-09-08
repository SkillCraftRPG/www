<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>Une créature étourdie ne peut utiliser sa <NuxtLink to="/regles/combat/deroulement/tour">réaction</NuxtLink>.</p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Combat", to: "/regles/combat" },
  { text: "Conditions", to: "/regles/combat/conditions" },
];
const title: string = "Étourdi";

useSeo({
  title,
  description: "Découvrez la condition Étourdi : une créature étourdie est incapable d’utiliser sa réaction en combat.",
});
</script>
