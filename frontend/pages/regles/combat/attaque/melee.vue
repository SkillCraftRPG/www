<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb active="Mêlée" :parent="parent" />
    <p>
      Les créatures sont dotées pour le plupart d’une portée de mêlée de 1,5 mètres. Les attaques de certaines créatures sont dotées d’une portée supérieure.
    </p>
    <p>
      Cette portée correspond à la portée des attaques effectuées avec un membre de son corps ou avec une
      <NuxtLink to="/regles/equipement/armes">arme</NuxtLink> de mêlée. Les armes dotées de la propriété
      <NuxtLink to="/regles/equipement/armes/proprietes">Allonge</NuxtLink> augmentent cette portée.
    </p>
    <p>
      Les attaques de mêlée sont généralement effectuées par l’<NuxtLink to="/regles/combat/activites">activité</NuxtLink> <i>Attaquer</i>, par un
      <NuxtLink to="/regles/competences/tests">test</NuxtLink> de <NuxtLink to="/regles/competences/melee">Mêlée</NuxtLink>. La
      <NuxtLink to="/regles/statistiques/force">Force</NuxtLink> de l’attaquant est ajoutée aux
      <NuxtLink to="/regles/combat/degats">points de dégâts</NuxtLink> infligés. Ces attaques ne déclenchent pas d’<NuxtLink
        to="/regles/combat/attaque/opportunite"
        >attaque d’opportunité</NuxtLink
      >.
    </p>
    <p>
      Une créature peut attaquer avec un membre de son corps, par exemple donner un coup de poing ou un coup de pied. Elle inflige 1 +
      <NuxtLink to="/regles/statistiques/force">Force</NuxtLink> points de dégâts contondants non létaux en cas de réussite. Le
      <NuxtLink to="/regles/talents">talent</NuxtLink> <NuxtLink to="/regles/talents/arts-martiaux">Arts martiaux</NuxtLink> forme une créature au combat avec
      un membre de son corps.
    </p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Combat", to: "/regles/combat" },
  { text: "Attaque", to: "/regles/combat/attaque" },
];
const title: string = "Attaque de mêlée";

useSeo({
  title,
  description:
    "Découvrez les règles des attaques de mêlée : coups portés avec le corps ou une arme, portée de 1,5 m, modificateurs de Force et talents associés.",
});

// TODO(fpion): TODO(fpion): talents pour le corps-à-corps
// TODO(fpion): extraire le corps-à-corps, comme on a fait avec le combat à deux armes
</script>
