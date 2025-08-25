<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>Les personnages et créatures doivent se nourrir et s’hydrater suffisamment afin d’éviter de mettre leur survie en jeu.</p>
    <h2 class="h3">Eau</h2>
    <p>
      Une créature de <NuxtLink to="/regles/especes/taille">taille moyenne</NuxtLink> doit boire au moins 2 litres d’eau par jour. Ce volume est doublé
      lorsqu’elle se trouve dans un climat très chaud ou sec.
    </p>
    <p>
      Si elle ne réussit pas à boire cette quantité, mais qu’elle en boit au moins la moitié, elle est affligée de la <strong>Soif</strong>. Sa
      <strong>Fatigue</strong> ne descend pas d’un niveau lorsqu’elle complète une <strong>nuit de sommeil</strong>. À la fin de la journée, elle est affligée
      d’un niveau de Fatigue si elle échoue un <NuxtLink to="/regles/competences/tests/sauvegarde">jet de sauvegarde</NuxtLink> de
      <NuxtLink to="/regles/competences/resistance">Résistance</NuxtLink> de <NuxtLink to="/regles/competences/tests/difficulte">difficulté élevée</NuxtLink>.
    </p>
    <p>
      Si elle ne réussit pas à boire la moitié du volume minimal d’eau, alors elle est affligée de la <strong>Sécheresse</strong> et échoue automatiquement le
      jet de sauvegarde décrit plus haut.
    </p>
    <h2 class="h3">Nourriture</h2>
    <p>Une créature de <NuxtLink to="/regles/especes/taille">taille moyenne</NuxtLink> doit manger au moins 1 kilogramme de nourriture par jour.</p>
    <p>
      Si elle ne réussit pas à manger cette quantité, mais qu’elle en consomme au moins la moitié, elle est affligée de la <strong>Faim</strong>. Sa
      <strong>Fatigue</strong> ne descend pas d’un niveau lorsqu’elle complète une <strong>nuit de sommeil</strong>. À la fin de la journée, elle doit effectuer
      un <NuxtLink to="/regles/competences/tests/sauvegarde">jet de sauvegarde</NuxtLink> de
      <NuxtLink to="/regles/competences/resistance">Résistance</NuxtLink> de <NuxtLink to="/regles/competences/tests/difficulte">difficulté élevée</NuxtLink>.
      Elle est affligée des pénalités suivantes en cas d’échec :
    </p>
    <ul>
      <li>Sa <strong>régénération</strong> de <NuxtLink to="/regles/statistiques/vitalite">Vitalité</NuxtLink> devient nulle.</li>
      <li>Sa <strong>régénération</strong> d’<NuxtLink to="/regles/statistiques/energie">Énergie</NuxtLink> est réduite de moitié.</li>
      <li>
        Ses points de <NuxtLink to="/regles/statistiques/vitalite">Vitalité</NuxtLink> maximum sont réduits de 2+1d4. Les points de Vitalité maximum perdus de
        cette façon sont récupérés après une nuit complète de sommeil, si la créature n’est plus affligée par la Soif, la Sécheresse, la Faim ou la Famine.
      </li>
    </ul>
    <p>
      Si elle ne réussit pas à manger la moitié de la quantité minimale de nourriture, alors elle est affligée de la <strong>Famine</strong> et échoue
      automatiquement le jet de sauvegarde décrit plus haut.
    </p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Aventure", to: "/regles/aventure" },
  { text: "Environnement", to: "/regles/aventure/environnement" },
];
const title: string = "Alimentation";

useSeo({
  title,
  description:
    "Découvrez les règles de survie liées à l’eau et la nourriture : soif, sécheresse, faim, famine et leurs conséquences sur la vitalité et la fatigue.",
});
</script>
