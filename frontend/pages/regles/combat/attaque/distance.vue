<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb active="Distance" :parent="parent" />
    <p>
      Une attaque à distance s’effectue en lançant une <NuxtLink to="/regles/equipement/armes">arme</NuxtLink> de
      <NuxtLink to="/regles/equipement/armes/proprietes">Jet</NuxtLink> ou en tirant d’une arme à
      <NuxtLink to="/regles/equipement/armes/proprietes">Munition</NuxtLink>.
    </p>
    <p>
      Ces armes définissent deux <NuxtLink to="/regles/equipement/armes/proprietes">portées</NuxtLink> : une courte et une longue. Le
      <NuxtLink to="/regles/competences/tests">test</NuxtLink> de l’attaque est affligé du
      <NuxtLink to="/regles/competences/tests/avantage-desavantage">désavantage</NuxtLink> si la distance entre l’attaquant et la cible est supérieure à la
      courte portée, et échoue automatiquement si cette distance est supérieure à la longue portée.
    </p>
    <p>
      Les attaques à distance sont effectuées par l’<NuxtLink to="/regles/combat/activites">activité</NuxtLink> <i>Attaquer</i> (arme de jet) ou
      <NuxtLink to="/regles/combat/activites/viser-tirer">Viser et tirer</NuxtLink> (arme à munition), par un
      <NuxtLink to="/regles/competences/tests">test</NuxtLink> d’<NuxtLink to="/regles/competences/orientation">Orientation</NuxtLink>. La
      <NuxtLink to="/regles/statistiques/precision">Précision</NuxtLink> de l’attaquant est ajoutée aux
      <NuxtLink to="/regles/combat/degats">points de dégâts</NuxtLink> infligés. Ces attaques déclenchent une
      <NuxtLink to="/regles/combat/attaque/opportunite">attaque d’opportunité</NuxtLink>. Également, le test est affligé du
      <NuxtLink to="/regles/competences/tests/avantage-desavantage">désavantage</NuxtLink> si une arme à munition est utilisée contre une cible située à 1,5
      mètres ou moins de l’attaquant.
    </p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Combat", to: "/regles/combat" },
  { text: "Attaque", to: "/regles/combat/attaque" },
];
const title: string = "Attaque à distance";

useSeo({
  title,
  description: "Découvrez les règles des attaques à distance : armes de jet ou à munition, portées, désavantages, précision et attaques d’opportunité.",
});
</script>
