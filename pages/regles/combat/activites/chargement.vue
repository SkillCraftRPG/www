<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Vous chargez une <NuxtLink to="/regles/equipement/armes/munitions">munition</NuxtLink> dans une
      <NuxtLink to="/regles/equipement/armes">arme</NuxtLink> dotée de la propriété <NuxtLink to="/regles/equipement/armes/proprietes">Chargement</NuxtLink>.
    </p>
    <p>Cette action déclenche une <NuxtLink to="/regles/combat/attaque/opportunite">attaque d’opportunité</NuxtLink>.</p>
    <p>
      Le <NuxtLink to="/regles/talents">talent</NuxtLink> <NuxtLink to="/regles/talents/chargement-rapide">Chargement rapide</NuxtLink> améliore votre capacité
      à charger une arme.
    </p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Combat", to: "/regles/combat" },
  { text: "Activités", to: "/regles/combat/activites" },
];
const title: string = "Chargement";

useSeo({
  title,
  description: "Découvrez la règle du chargement : insérez une munition dans une arme et améliorez cette action grâce au talent Chargement rapide.",
});
</script>
