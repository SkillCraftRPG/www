<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>Un test de groupe survient lorsque l’ensemble des créatures ou personnages d’un groupe doit effectuer simultanément un même test.</p>
    <p>
      De manière générale, les tests de groupe n’octroient pas de <strong>points d’Espérance ni de Damnation</strong>. Le maître de jeu peut toutefois octroyer
      des conséquences positives ou négatives. La décision finale lui appartient.
    </p>
    <p>Le test de groupe peut être utilisé de différentes manières par un maître de jeu :</p>
    <ul>
      <li>Réussite si la majorité (50% + 1) des membres du groupe réussit le test.</li>
      <li>Calcul de la moyenne des résultats (faire la somme des résultats et diviser par le nombre de membres) et utiliser cette moyenne.</li>
      <li>Réussite ou échec individuelle des membres du groupe.</li>
    </ul>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Compétences", to: "/regles/competences" },
  { text: "Tests", to: "/regles/competences/tests" },
];
const title: string = "Test de groupe";

useSeo({
  title,
  description: "Découvrez le fonctionnement des tests de groupe, qui impliquent tous les membres d’un même groupe.",
});
</script>
