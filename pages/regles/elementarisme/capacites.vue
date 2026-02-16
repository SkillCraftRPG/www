<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>🚧</p>
    <h2 class="h3">Tiers 1</h2>
    <h3 class="h5">Incarnation élémentaire mineure</h3>
    <p>
      Une fois par <NuxtLink to="/regles/combat/deroulement/tour">tour</NuxtLink>, par une <NuxtLink to="/regles/combat/deroulement/tour">action</NuxtLink>, le
      personnage peut dépenser 3 points d’<NuxtLink to="/regles/elementarisme/essence">essence élémentaire</NuxtLink> afin d’assumer la forme d’un élémentaire
      mineur (niveau 2 et moins). Il peut reprendre sa forme normale par une action. Ses caractéristiques sont remplacées par celle de l’élémentaire.
    </p>
    <ul>
      <li>
        Les <NuxtLink to="/regles/combat/activites">activités</NuxtLink> qu’il peut accomplir et les <NuxtLink to="/regles/langues">langues</NuxtLink> qu’il
        peut parler sont limitées à celles de l’élémentaire.
      </li>
      <li>
        Il décide si son <NuxtLink to="/regles/equipement">équipement</NuxtLink> fusionne avec sa forme élémentaire ou s’il tombe au sol à ses pieds. Dans tous
        les cas, il ne peut utiliser son équipement lorsqu’il assume cette forme.
      </li>
      <li>
        S’il se <NuxtLink to="/regles/magie/parametres/duree">concentrait</NuxtLink> sur un <NuxtLink to="/regles/magie/pouvoirs">pouvoir</NuxtLink> au moment
        où il se transforme, il perd la concentration et le pouvoir prend fin.
      </li>
      <li>Il ne peut utiliser de capacité élémentaire lorsqu’il assume cette forme.</li>
      <li>
        S’il <NuxtLink to="/regles/combat/mort-agonie">meurt</NuxtLink>, ou si les points de <NuxtLink to="/regles/statistiques/vitalite">Vitalité</NuxtLink> de
        l’élémentaire chutent à 0, il reprend sa forme normale, et les <NuxtLink to="/regles/combat/degats">points de dégâts</NuxtLink> excédentaires sont
        transféré à sa forme normale.
      </li>
      <li>
        Il peut rester dans cette forme pendant un nombre d’<NuxtLink to="/regles/aventure/temps">heures</NuxtLink> égal à ses
        <NuxtLink to="/regles/attributs/sens">Sens</NuxtLink> (minimum&nbsp;1). Après ce délai, il reprend sa forme normale.
      </li>
    </ul>
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
  description: "🚧",
});
</script>
