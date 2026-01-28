<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Vous maintenez actif un <NuxtLink to="/regles/magie/pouvoirs">pouvoir</NuxtLink> nécessitant la
      <NuxtLink to="/regles/magie/parametres/duree">concentration</NuxtLink>.
    </p>
    <p>
      Maintenir votre concentration est une <NuxtLink to="/regles/combat/deroulement/tour">action libre</NuxtLink>, mais vous ne pouvez vous concentrer que sur
      un seul pouvoir à la fois.
    </p>
    <p>
      Le <NuxtLink to="/regles/talents">talent</NuxtLink> <NuxtLink to="/regles/talents/magie-guerriere">Magie guerrière</NuxtLink> améliore votre capacité à
      maintenir votre concentration.
    </p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Combat", to: "/regles/combat" },
  { text: "Activités", to: "/regles/combat/activites" },
];
const title: string = "Concentration";

useSeo({
  title,
  description: "Découvrez comment maintenir un pouvoir actif grâce à la concentration : une action libre, mais limitée à un seul pouvoir à la fois.",
});
</script>
