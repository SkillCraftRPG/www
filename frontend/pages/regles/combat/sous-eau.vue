<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb active="Sous l’eau" :parent="parent" />
    <p>
      Combattre sous l’eau inflige des pénalités pour les créatures terrestres ou aériennes. Les créatures aquatiques (dotées d’une
      <NuxtLink to="/regles/aventure/mouvement/vitesse">vitesse</NuxtLink> de <NuxtLink to="/regles/aventure/mouvement/vitesse">nage</NuxtLink>) en sont
      exemptes.
    </p>
    <p>
      Le <NuxtLink to="/regles/competences/tests">test</NuxtLink> des <NuxtLink to="/regles/combat/attaque">attaques</NuxtLink> effectuées sous l’eau est
      affligé du <NuxtLink to="/regles/competences/tests/avantage-desavantage">désavantage</NuxtLink>, sauf lorsqu’il s’agit d’une des armes suivantes :
    </p>
    <ul>
      <li>Dague (<NuxtLink to="/regles/combat/attaque/melee">attaque de mêlée</NuxtLink> seulement)</li>
      <li>Dard</li>
      <li>Épée courte</li>
      <li>Filet</li>
      <li>Javelot</li>
      <li>Lance</li>
      <li>Trident</li>
      <li>Les armes dotées de la propriété <NuxtLink to="/regles/equipement/armes/proprietes">Chargement</NuxtLink>.</li>
    </ul>
    <p>
      Le test des <NuxtLink to="/regles/combat/attaque/distance">attaques à distance</NuxtLink> effectuées au-delà de la
      <NuxtLink to="/regles/equipement/armes/proprietes">courte portée</NuxtLink> de l’arme échoue automatiquement.
    </p>
    <p>Les créatures entièrement submergées sont résistantes aux dégâts de feu.</p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [{ text: "Combat", to: "/regles/combat" }];
const title: string = "Combat sous l’eau";

useSeo({
  title,
  description:
    "Découvrez les règles du combat sous l’eau : pénalités, armes efficaces, limites des attaques à distance et résistances des créatures immergées.",
});
</script>
