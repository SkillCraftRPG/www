<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <RulesBreadcrumb :active="title" :parent="parent" />
    <p>🚧</p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/tar/breadcrumb";

const parent: Breadcrumb[] = [
  { text: "Annexes", to: "/regles/annexes" },
  { text: "Astromancie", to: "/regles/astromancie" },
];
const title: string = "Tour de la Magie";

useSeo({
  title,
  description: "🚧",
});
</script>
