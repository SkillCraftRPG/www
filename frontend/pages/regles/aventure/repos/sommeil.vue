<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Un personnage requiert généralement un minimum de 6 heures de sommeil par jour. S’il ne dort pas suffisamment au cours d’une journée, il est affligé d’un
      <strong>niveau de Fatigue</strong>.
    </p>
    <p>
      Une nuit complète est une période d’une durée minimale de 8 heures consécutives, composée de sommeil et de
      <NuxtLink to="/regles/aventure/repos/halte">halte</NuxtLink>. La majorité des personnages peuvent dormir pendant 6 heures et faire halte pendant 2 heures.
      Un personnage est <strong>inconscient</strong> pendant qu’il dort.
    </p>
    <p>
      Lorsqu’un personnage complète une nuit de sommeil, il récupère tous ses points d’<NuxtLink to="/regles/statistiques/energie">Énergie</NuxtLink> ainsi que
      ⅐ (14,3 %) de sa <NuxtLink to="/regles/statistiques/vitalite">Vitalité</NuxtLink> totale (minimum 1). Cette régénération n’est pas affectée si le sommeil
      est interrompu temporairement. Cette régénération inclut les 6 heures de sommeil et les 2 heures de halte.
    </p>
    <p>
      Lorsqu’un personnage complète une nuit de sommeil sans interruption, il bénéficie des effets suivants. Une nuit de sommeil peut être interrompu par un
      combat, de fortes intempéries l’obligeant à déplacer son campement, ou d’autres événements similaires.
    </p>
    <ul>
      <li>Il peut retirer une pénalité (-1) à un <NuxtLink to="/regles/attributs">attribut</NuxtLink>.</li>
      <li>Sa <strong>Fatigue</strong> descend d’un niveau.</li>
      <li>Il récupère les utilisations de certaines capacités.</li>
    </ul>
    <p>Un personnage ne peut bénéficier que d’une seule nuit complète par <NuxtLink to="/regles/aventure/temps">période de 24 heures</NuxtLink>.</p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Aventure", to: "/regles/aventure" },
  { text: "Repos", to: "/regles/aventure/repos" },
];
const title: string = "Sommeil";

useSeo({
  title,
  description: "Découvrez comment le sommeil complet régénère Énergie, Vitalité et réduit la Fatigue des personnages.",
});
</script>
