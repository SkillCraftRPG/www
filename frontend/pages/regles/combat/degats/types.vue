<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb active="Types" :parent="parent" />
    <p>Chaque source de dégâts est associée à un ou plusieurs types.</p>
    <p>
      Les différents types de dégâts n’ont pas de règles spécifiques s’appliquant à chacun. Cependant, certains types de dégâts n’ont pas la même
      <NuxtLink to="/regles/combat/degats/efficacite">efficacité</NuxtLink> contre différents
      <NuxtLink to="/regles/aventure/interaction-objets">objets</NuxtLink> ou créatures.
    </p>
    <p>Voici les différents types de dégâts et des exemples pour chaque type.</p>
    <h6>Dégâts physiques</h6>
    <ul>
      <li><strong>Contondant.</strong> Coups et chocs de masse, chutes, débris ou effondrements provoquant des traumatismes par impact.</li>
      <li><strong>Perforant.</strong> Pénétration par pointes ou projectiles comme les flèches, carreaux, lances, aiguillons ou épieux.</li>
      <li><strong>Tranchant.</strong> Entailles causées par lames et outils coupants tels que sabres, haches, faucilles ou scies.</li>
    </ul>
    <h6>Dégâts spéciaux</h6>
    <ul>
      <li><strong>Acide.</strong> Brûlures corrosives dues à des substances chimiques comme la chaux vive, le vitriol ou d’autres agents caustiques.</li>
      <li><strong>Feu.</strong> Brûlures et carbonisation par flammes ouvertes, incendies, naphta, pétrole ou explosifs incendiaires.</li>
      <li><strong>Force.</strong> Pression ou énergie concentrée produisant une onde de choc ou un impact de type « champ de force ».</li>
      <li><strong>Foudre.</strong> Électrocution par décharge électrique naturelle ou artificielle, comme la foudre ou un circuit sous tension.</li>
      <li><strong>Froid.</strong> Gelures et engelures provoquées par le gel intense, le blizzard ou une exposition prolongée au froid.</li>
      <li><strong>Nécrotique.</strong> Dégradation des tissus et perte vitale liées à la nécrose, aux infections graves ou à des toxines destructrices.</li>
      <li><strong>Poison.</strong> Intoxication par substances venimeuses, gaz nocifs, plantes toxiques ou venins animaux.</li>
      <li><strong>Psychique.</strong> Atteintes mentales par terreur, suggestion, traumatisme psychologique ou chocs sensoriels extrêmes.</li>
      <li><strong>Radiant.</strong> Brûlures et lésions causées par une lumière intense, un rayonnement énergétique ou des UV puissants.</li>
      <li><strong>Tonnerre.</strong> Dommages dus à une explosion sonore ou à une onde de choc acoustique déstabilisante.</li>
    </ul>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Combat", to: "/regles/combat" },
  { text: "Dégâts", to: "/regles/combat/degats" },
];
const title: string = "Types de dégâts";

useSeo({
  title,
  description: "Découvrez les différents types de dégâts physiques et spéciaux, avec exemples d’impacts, pour enrichir vos combats et varier les menaces.",
});

// TODO(fpion): parler des dégâts magiques
</script>
