<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>Vous utilisez ou activer un objet. Cette activité peut nécessiter 2 <NuxtLink to="/regles/combat/deroulement/tour">actions</NuxtLink> ou plus.</p>
    <p>
      Vous pouvez également rengainer une <NuxtLink to="/regles/equipement/armes">arme</NuxtLink> ou un
      <NuxtLink to="/regles/equipement/boucliers">bouclier</NuxtLink> que vous tenez, puis dégainer une arme ou prendre votre bouclier par la même action.
    </p>
    <p>
      Cette action déclenche une <NuxtLink to="/regles/combat/attaque/opportunite">attaque d’opportunité</NuxtLink> si l’objet vous
      <NuxtLink to="/regles/combat/degats/soins">soigne</NuxtLink>, ou si son utilisation requiert vos deux mains, par exemple enclencher un lourd levier ou
      appliquer un <NuxtLink to="/regles/herboristerie/poisons">poison</NuxtLink> sur votre arme.
    </p>
    <p>
      Le <NuxtLink to="/regles/talents">talent</NuxtLink> <NuxtLink to="/regles/talents/astuce">Astuce</NuxtLink> améliore votre capacité à utiliser un objet.
    </p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Combat", to: "/regles/combat" },
  { text: "Activités", to: "/regles/combat/activites" },
];
const title: string = "Objet";

useSeo({
  title,
  description: "Découvrez l’action Objet : activez, utilisez ou manipulez un objet en combat, parfois au prix de plusieurs actions.",
});
</script>
