<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>Une créature assourdie n’entend rien. Elle échoue automatiquement les <NuxtLink to="/regles/competences/tests">tests</NuxtLink> requérant l’ouïe.</p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Combat", to: "/regles/combat" },
  { text: "Conditions", to: "/regles/combat/conditions" },
];
const title: string = "Assourdi";

useSeo({
  title,
  description: "Découvrez la condition Assourdi : une créature n’entend rien et échoue automatiquement aux tests nécessitant l’ouïe.",
});
</script>
