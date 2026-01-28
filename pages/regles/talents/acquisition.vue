<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb active="Acquisition" :parent="parent" />
    <p>Afin d’acquérir un talent, un personnage doit satisfaire les conditions suivantes.</p>
    <ul>
      <li>Son <NuxtLink to="/regles/personnages/progression/tiers">tiers</NuxtLink> de personnage doit être supérieur ou égal au tiers du talent.</li>
      <li>Si le talent requiert un autre talent, alors le personnage doit préalablement avoir acquis le talent requis.</li>
      <li>Il doit dépenser les <NuxtLink to="/regles/talents/points">points de talent</NuxtLink> nécessaires.</li>
      <li>Le personnage doit satisfaire toute condition additionnelle spécifiée par le talent.</li>
    </ul>
    <h2 class="h3">Achats multiples</h2>
    <p>Sauf indication contraire, un talent ne peut être acquis qu’une seule fois.</p>
    <p>Seuls les talents portant la mention <i>Achats multiples</i> peuvent être acquis plusieurs fois.</p>
    <p>Chaque acquisition doit satisfaire les conditions indiquées ci-dessus.</p>
    <p>Si le personnage possède un ou plusieurs rabais sur un talent, alors chaque acquisition du talent bénéficie du rabais.</p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [{ text: "Talents", to: "/regles/talents" }];
const title: string = "Acquisition de talent";

useSeo({
  title,
  description: "Découvrez les règles d’acquisition de talents : conditions, prérequis, points nécessaires et possibilités d’achats multiples avec rabais.",
});
</script>
