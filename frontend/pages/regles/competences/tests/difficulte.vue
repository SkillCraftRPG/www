<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Le degré de difficulté est une valeur à laquelle le résultat d’un <NuxtLink to="/regles/competences/tests">test</NuxtLink> est comparé. Plus il est élevé,
      moins il est probable que l’action réussisse. Inversement, plus il est faible, plus grandes sont les chances de réussite.
    </p>
    <p>Si cette valeur est inférieure au résultat du test, l’action entreprise est réussie, sinon le test est soldé par un échec.</p>
    <p>
      Le maître de jeu détermine le degré de difficulté avant que le test ne soit effectué, ou pendant, mais avant d’en connaître le résultat, favorisant la
      neutralité et l’impartialité.
    </p>
    <p>
      Lorsque la situation est favorable au personnage entreprenant l’action, le maître de jeu peut réduire le degré de difficulté ou conférer un bonus
      situationnel à celui-ci. Inversement, il peut augmenter le degré de difficulté ou infliger une pénalité situationnelle au personnage lorsque la situation
      est défavorable à ce personnage.
    </p>
    <p>Voici une table stipulant les degrés de difficulté correspondant à la difficulté qualitative estimée par le maître de jeu :</p>
    <table class="table table-striped">
      <thead>
        <tr>
          <th scope="col">Difficulté qualitative</th>
          <th scope="col">Degré de difficulté</th>
        </tr>
      </thead>
      <tbody>
        <tr>
          <td>Très facile</td>
          <td>5</td>
        </tr>
        <tr>
          <td>Facile</td>
          <td>10</td>
        </tr>
        <tr>
          <td>Moyenne</td>
          <td>15</td>
        </tr>
        <tr>
          <td>Difficile</td>
          <td>20</td>
        </tr>
        <tr>
          <td>Très difficile</td>
          <td>25</td>
        </tr>
        <tr>
          <td>Extraordinaire</td>
          <td>30</td>
        </tr>
      </tbody>
    </table>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Compétences", to: "/regles/competences" },
  { text: "Tests", to: "/regles/competences/tests" },
];
const title: string = "Degré de difficulté";

useSeo({
  title,
  description: "Découvrez les degrés de difficulté, ces valeurs déterminant la réussite ou l’échec des actions en fonction de la complexité.",
});
</script>
