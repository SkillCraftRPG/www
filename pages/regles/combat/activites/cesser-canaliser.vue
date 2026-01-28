<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Vous cessez de vous <NuxtLink to="/regles/combat/activites/concentration">concentrer</NuxtLink> sur un
      <NuxtLink to="/regles/magie/pouvoirs">pouvoir</NuxtLink> que vous maintenez actif. Les effets du pouvoir prennent instantanément fin.
    </p>
    <p>Vous pouvez effectuer cette <NuxtLink to="/regles/combat/deroulement/tour">action libre</NuxtLink> à tout moment.</p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Combat", to: "/regles/combat" },
  { text: "Activités", to: "/regles/combat/activites" },
];
const title: string = "Cesser de canaliser";

useSeo({
  title,
  description: "Découvrez comment cesser de canaliser un pouvoir : arrêtez la concentration à tout moment et mettez instantanément fin à ses effets.",
});
</script>
