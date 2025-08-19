<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb active="Types" :parent="parent" />
    <p>🚧</p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Aventure", to: "/regles/aventure" },
  { text: "Mouvement", to: "/regles/aventure/mouvement" },
];
const title: string = "Types de mouvement";

useSeo({
  title,
  description: "🚧",
});
</script>
