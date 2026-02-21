<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Les capacités élémentaires permettent à l’<NuxtLink to="/regles/specialisations/elementariste">Élémentariste</NuxtLink> d’incarner, invoquer, altérer et
      manipuler les forces de sa dimension à travers des capacités progressives de <NuxtLink to="/regles/personnages/progression/tiers">tiers 1 à 3</NuxtLink>.
    </p>
    <ElementalismContents />
    <h2 id="tiers-1" class="h3">Capacités de tiers 1</h2>
    <ElementalismMinorForm />
    <ElementalismBlink />
    <h2 id="tiers-2" class="h3">Capacités de tiers 2</h2>
    <ElementalismExile />
    <ElementalismExpression />
    <ElementalismExpelling />
    <ElementalismMediumForm />
    <h2 id="tiers-3" class="h3">Capacités de tiers 3</h2>
    <ElementalismAltering />
    <ElementalismConvoy />
    <ElementalismMajorForm />
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Annexes", to: "/regles/annexes" },
  { text: "Élémentarisme", to: "/regles/elementarisme" },
];
const title: string = "Capacités élémentaires";

useSeo({
  title,
  description: "Découvrez les capacités élémentaires : incarnations, invocations, exils planaires et altérations liées aux dimensions élémentaires.",
});
</script>
