<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>Un personnage requiert généralement un minimum de 6 heures de sommeil par jour.</p>
    <p>S’il ne dort pas suffisamment au cours d’une journée, il est affligé d’un <strong>niveau de Fatigue</strong>.</p>
    <p>Un personnage ne peut bénéficier que d’une seule nuit complète par <NuxtLink to="/regles/aventure/temps">période de 24 heures</NuxtLink>.</p>
    <h2 class="h3">Durée</h2>
    <p>
      Une nuit complète est une période d’une durée minimale de 8 heures consécutives, composée de sommeil et de
      <NuxtLink to="/regles/aventure/repos/halte">halte</NuxtLink>.
    </p>
    <p>La majorité des personnages peuvent dormir pendant 6 heures et faire halte pendant 2 heures.</p>
    <p>Un personnage est <NuxtLink to="/regles/combat/conditions/inconscient">inconscient</NuxtLink> pendant qu’il dort.</p>
    <h2 class="h3">Régénération</h2>
    <p>
      Lorsqu’un personnage complète une nuit de sommeil, il récupère tous ses points d’<NuxtLink to="/regles/statistiques/energie">Énergie</NuxtLink> ainsi que
      ⅐ ({{ $n(1 / 7, "percentage") }}) de sa <NuxtLink to="/regles/statistiques/vitalite">Vitalité</NuxtLink> totale (minimum 1).
    </p>
    <p>Cette régénération n’est pas affectée si le sommeil est interrompu temporairement, en autant que les 8 heures de repos sont complétées.</p>
    <p>Cette régénération inclut toute heure de sommeil et de halte pendant la nuit.</p>
    <p>
      S’il fait halte pendant le reste de la journée, il récupère une seconde fois ⅐ ({{ $n(1 / 7, "percentage") }}) de sa
      <NuxtLink to="/regles/statistiques/vitalite">Vitalité</NuxtLink> totale (minimum 1).
    </p>
    <h2 class="h3">Bénéfices</h2>
    <p>Lorsqu’un personnage complète une nuit de sommeil sans interruption, il bénéficie des effets suivants :</p>
    <ul>
      <li>Il peut retirer une pénalité (-1) à un <NuxtLink to="/regles/attributs">attribut</NuxtLink>.</li>
      <li>Sa <strong>Fatigue</strong> descend d’un niveau.</li>
      <li>
        Ses <NuxtLink to="/regles/magie/alchimie">points d’intoxication</NuxtLink> descendent d’une valeur égale à son
        <NuxtLink to="/regles/personnages/progression/tiers">tiers</NuxtLink> (minimum 1).
      </li>
      <li>Il récupère les utilisations de certaines capacités.</li>
    </ul>
    <p>Voici quelques situations pouvant interrompre une nuit de sommeil :</p>
    <ul>
      <li>Un combat.</li>
      <li>De fortes intempéries obligeant à déplacer son campement.</li>
      <li>L’<NuxtLink to="/regles/aventure/environnement/alcoolemie">ébriété</NuxtLink>.</li>
      <li>
        Porter une <NuxtLink to="/regles/equipement/armures/partielles">pièce</NuxtLink> d’<NuxtLink to="/regles/equipement/armures">armure</NuxtLink> n’étant
        pas dotée de la propriété <NuxtLink to="/regles/equipement/armures/proprietes">Confortable</NuxtLink>.
      </li>
    </ul>
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
