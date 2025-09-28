<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Lorsqu’une créature <NuxtLink to="/regles/equipement/encombrement">porte un poids</NuxtLink> supérieure à sa
      <NuxtLink to="/regles/statistiques/charge">Charge</NuxtLink>, elle est encombrée.
    </p>
    <p>Sa <NuxtLink to="/regles/aventure/mouvement/vitesse">vitesse de déplacement</NuxtLink> subit une pénalité variant en fonction de l’excès de poids.</p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Combat", to: "/regles/combat" },
  { text: "Conditions", to: "/regles/combat/conditions" },
];
const title: string = "Encombré";

useSeo({
  title,
  description: "Découvrez l’état d’encombrement : une créature portant trop de poids subit une réduction de sa vitesse de déplacement.",
});
</script>
