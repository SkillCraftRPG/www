<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      La vitesse d’une créature est la distance qu’elle peut parcourir pendant une période de <NuxtLink to="/regles/aventure/temps">temps</NuxtLink> donnée en
      situation de combat ou de tour-par-tour. Cette vitesse est déterminée par la <NuxtLink to="/regles/especes/taille">taille</NuxtLink> et parfois
      l’<NuxtLink to="/regles/especes">espèce</NuxtLink> de la créature.
    </p>
    <p>
      La vitesse s’exprime en <strong>mètres par seconde (m/s)</strong> et en <strong>points de mouvement</strong>. Chaque point de mouvement correspond à une
      case traversée. Par exemple, une créature dotée d’une vitesse de 1,5 m/s et de 6 points de mouvement pourra traverser 6 cases pour chaque action
      <strong>Déplacement</strong> effectuée.
    </p>
    <p>
      Cette vitesse ne considère ni le poids de l’équipement, ni le terrain accidenté. Les déplacements effectués à cette vitesse sont réalisables par courtes
      rafales et grâce à l’adrénaline du moment. Pour des déplacements sur de longues distances et de longues durées, on utilise plutôt une
      <NuxtLink to="/regles/aventure/mouvement/cadences">cadence</NuxtLink>.
    </p>
    <p>
      Une créature peut être dotée d’une vitesse par <NuxtLink to="/regles/aventure/mouvement/types">type de mouvement</NuxtLink>. Plusieurs situations peuvent
      influencer sa vitesse de déplacement, notamment le <NuxtLink to="/regles/aventure/mouvement/terrain-difficile">terrain difficile</NuxtLink> et le
      <NuxtLink to="/regles/aventure/mouvement/furtif">déplacement&nbsp;furtif</NuxtLink>.
    </p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Aventure", to: "/regles/aventure" },
  { text: "Mouvement", to: "/regles/aventure/mouvement" },
];
const title: string = "Vitesse";

useSeo({
  title,
  description: "🚧",
});
</script>
