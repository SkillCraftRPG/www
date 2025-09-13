<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>Vous effectuez un déplacement en respectant votre <NuxtLink to="/regles/aventure/mouvement/vitesse">vitesse</NuxtLink>.</p>
    <p>
      Votre déplacement peut appartenir à plusieurs <NuxtLink to="/regles/aventure/mouvement/types">types de mouvement</NuxtLink>. Par exemple, vous traversez à
      la nage un cours d’eau de 1,5 mètres ou moins de largeur, puis escaladez une corniche d’au plus 1,5 mètres de hauteur, puis vous marchez sur une distance
      de 3 mètres.
    </p>
    <p>
      Si vous quittez la <NuxtLink to="/regles/combat/attaque/melee">portée de mêlée</NuxtLink> d’une créature, alors votre déplacement déclenche une
      <NuxtLink to="/regles/combat/attaque/opportunite">attaque d’opportunité</NuxtLink>.
    </p>
    <p>
      Une fois par <NuxtLink to="/regles/combat/deroulement/tour">tour</NuxtLink>, pendant que vous vous déplacez, vous pouvez effectuer une interaction simple
      avec un objet en action libre, par exemple :
    </p>
    <ul>
      <li>Dégainer ou rengainer une arme.</li>
      <li>Ouvrir ou fermer une porte.</li>
      <li>Sortir ou ranger un objet dans votre sac.</li>
      <li>Boire d’un récipient que vous tenez.</li>
      <li>Éteindre votre torche.</li>
      <li>Ramasser ou déposer un objet sur une table à proximité.</li>
      <li>Lever ou baisser votre capuche.</li>
    </ul>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Combat", to: "/regles/combat" },
  { text: "Activités", to: "/regles/combat/activites" },
];
const title: string = "Déplacement";

useSeo({
  title,
  description: "🚧",
});
</script>
