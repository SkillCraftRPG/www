<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>Une créature morte n’a plus d’emprise sur son corps, ni son esprit.</p>
    <p>
      Elle ne peut être <NuxtLink to="/regles/combat/activites/stabiliser">stabilisée</NuxtLink>, ni
      <NuxtLink to="/regles/combat/degats/soins">soignée</NuxtLink>.
    </p>
    <p>Elle peut être <NuxtLink to="/regles/combat/mort-agonie">ressuscitée</NuxtLink>, mais cet acte est très éprouvant et difficile à accomplir.</p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Combat", to: "/regles/combat" },
  { text: "Conditions", to: "/regles/combat/conditions" },
];
const title: string = "Mort";

useSeo({
  title,
  description: "Découvrez la condition de mort : perte totale de contrôle du corps et de l’esprit, seule une résurrection peut y remédier.",
});
</script>
