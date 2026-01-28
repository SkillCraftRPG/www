<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb active="Jet" :parent="parent" />
    <p>
      Les <NuxtLink to="/regles/equipement/armes">armes</NuxtLink>, <NuxtLink to="/regles/magie/pouvoirs">pouvoirs</NuxtLink> et capacités offensives spécifient
      les dégâts infligés.
    </p>
    <p>
      Roulez les dés indiqués et ajoutez la <NuxtLink to="/regles/statistiques">statistique</NuxtLink> appropriée. Celle-ci est généralement spécifiée par la
      capacité utilisée.
    </p>
    <p>Une pénalité peut réduire les points de dégâts infligés à 0, mais jamais en deçà de 0.</p>
    <p>Lorsqu’une capacité cible plusieurs créatures, roulez une fois les dégâts, et toutes les cibles reçoivent la même quantité de points de dégâts.</p>
    <table class="table table-striped text-center">
      <thead>
        <tr>
          <th scope="col" class="w-50">Statistique</th>
          <th scope="col" class="w-50">Cas d’utilisation</th>
        </tr>
      </thead>
      <tbody>
        <tr>
          <td>
            <NuxtLink to="/regles/statistiques/force">Force</NuxtLink>
          </td>
          <td>
            <NuxtLink to="/regles/combat/attaque/melee">Attaques de mêlée</NuxtLink>
          </td>
        </tr>
        <tr>
          <td>
            <NuxtLink to="/regles/statistiques/precision">Précision</NuxtLink>
          </td>
          <td>
            <NuxtLink to="/regles/combat/attaque/distance">Attaques à distance</NuxtLink>
          </td>
        </tr>
        <tr>
          <td>
            <NuxtLink to="/regles/statistiques/puissance">Puissance</NuxtLink>
          </td>
          <td>Capacités surnaturelles, par exemple les <NuxtLink to="/regles/magie/pouvoirs">pouvoirs</NuxtLink></td>
        </tr>
        <tr>
          <td>
            <NuxtLink to="/regles/statistiques/stratageme">Stratagème</NuxtLink>
          </td>
          <td>Pièges et autres astuces</td>
        </tr>
      </tbody>
    </table>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Combat", to: "/regles/combat" },
  { text: "Dégâts", to: "/regles/combat/degats" },
];
const title: string = "Jet de dégâts";

useSeo({
  title,
  description:
    "Découvrez comment exécuter un jet de dégâts : lancez les dés, ajoutez la statistique adaptée et appliquez les règles pour vos attaques et pouvoirs.",
});
</script>
