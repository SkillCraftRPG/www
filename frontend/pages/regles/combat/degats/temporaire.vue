<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Certaines capacités confèrent à une créature des points de <NuxtLink to="/regles/statistiques/vitalite">Vitalité</NuxtLink> <strong>temporaires</strong>.
    </p>
    <p>
      Ceux-ci s’ajoutent à votre Vitalité courante, mais ils n’augmentent pas votre Vitalité maximale. Ils ne peuvent donc être
      <NuxtLink to="/regles/aventure/repos">récupérés</NuxtLink>, ni <NuxtLink to="/regles/combat/degats/soins">soignés</NuxtLink>.
    </p>
    <p>La Vitalité actuelle d’une créature peut dépasser sa Vitalité maximale grâce à des points temporaires.</p>
    <p>
      Lorsqu’une créature est <NuxtLink to="/regles/combat/degats/letalite">blessée</NuxtLink>, ses points de Vitalité temporaires sont perdus avant ses points
      de Vitalité normaux.
    </p>
    <p>Les effets conférant ces points temporaires spécifient généralement une durée. Ils sont réinitialisés à 0 à la fin de cette période.</p>
    <p>
      Lorsqu’une créature complète une <NuxtLink to="/regles/aventure/repos/sommeil">nuit de sommeil</NuxtLink>, ses points temporaires sont réinitialisés à 0.
    </p>
    <p>
      Les points temporaires ne sont pas cumulables. Lorsqu’une créature reçoit des points temporaires de plusieurs effets, elle choisit l’effet s’appliquant.
    </p>
    <h2 class="h3">Exemple</h2>
    <ol>
      <li>Une créature possède 7 points de Vitalité actuelle, sur un maximum de 10.</li>
      <li>Elle reçoit 5 points temporaires : sa Vitalité actuelle augmente à 12.</li>
      <li>
        Elle est blessée de 3 points de dégâts : sa Vitalité actuelle chute à 9, et il lui reste 2 points temporaires.
        <ul>
          <li>
            Si elle complète une nuit de sommeil, ses points temporaires restants retombent à 0. Sa Vitalité actuelle chute à 7, mais elle est ensuite regénérée
            par la nuit de sommeil.
          </li>
          <li>Si elle est encore blessée de 3 points de dégâts, sa Vitalité chute à 6, et il ne lui reste aucun point temporaire.</li>
        </ul>
      </li>
    </ol>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Combat", to: "/regles/combat" },
  { text: "Dégâts", to: "/regles/combat/degats" },
];
const title: string = "Points temporaires";

useSeo({
  title,
  description: "Découvrez comment les points temporaires augmentent votre Vitalité au-delà du maximum, absorbant les dégâts avant vos points normaux.",
});
</script>
