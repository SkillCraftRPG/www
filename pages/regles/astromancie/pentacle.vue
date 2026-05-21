<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <RulesBreadcrumb :active="title" :parent="parent" />
    <p>
      Le pentacle est un symbole très important de l’astromancie, et sera omniprésent dans les
      <NuxtLink to="/regles/astromancie/ecole">écoles de magie</NuxtLink>. Il illustre la relation des composantes essentielles de l’astromancie, soit les
      <NuxtLink to="/regles/elementarisme">éléments</NuxtLink>, les cercles de magie ainsi que les
      <NuxtLink to="/regles/astromancie/signes">signes astrologiques</NuxtLink>.
    </p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/tar/breadcrumb";

const parent: Breadcrumb[] = [
  { text: "Annexes", to: "/regles/annexes" },
  { text: "Astromancie", to: "/regles/astromancie" },
];
const title: string = "Pentacle";

useSeo({
  title,
  description: "🚧",
});

// TODO(fpion): picture, explanation, and meta description
</script>
