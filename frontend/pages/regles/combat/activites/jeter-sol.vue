<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>Vous vous jetez au sol, en position <NuxtLink to="/regles/combat/conditions/renverse">renversée</NuxtLink>.</p>
    <p>Vous ne subissez pas de <NuxtLink to="/regles/aventure/environnement/chute">chute</NuxtLink>, sauf si le sol se brise sous vos pieds.</p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Combat", to: "/regles/combat" },
  { text: "Activités", to: "/regles/combat/activites" },
];
const title: string = "Se jeter au sol";

useSeo({
  title,
  description: "Découvrez la règle pour se jeter au sol : adoptez la position renversée sans subir de chute, sauf si le sol s’effondre sous vos pieds.",
});
</script>
