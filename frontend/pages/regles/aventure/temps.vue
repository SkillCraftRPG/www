<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>Une aventure se déroule suivant un cycle perpétuel pendant lequel :</p>
    <ol>
      <li>Le maître de jeu décrit l’environnement aux joueurs ;</li>
      <li>Les joueurs décrivent les actions que leur personnage désire effectuer ;</li>
      <li>Le maître de jeu décrit le résultat de ces actions aux joueurs.</li>
    </ol>
    <p>L’enchaînement de ces actions est mesuré par une échelle de temps établie en fonction du contexte :</p>
    <ul>
      <li>En situation de combat, l’échelle des <strong>secondes</strong> est utilisée ;</li>
      <li>Sur des distances rapprochées, par exemple dans un centre de ville ou un bâtiment, l’échelle des <strong>minutes</strong> est utilisée ;</li>
      <li>L’échelle des <strong>heures</strong> est utilisée sur de plus longues distances, par exemple sur une route séparant deux villages ;</li>
      <li>
        L’échelle des <strong>jours</strong> peut être utilisée à la discrétion du maître de jeu afin d’exprimer les déplacements sur de longues distances
        lorsqu’aucun événement significatif à l’histoire ne survient.
      </li>
    </ul>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [{ text: "Aventure", to: "/regles/aventure" }];
const title: string = "Temps";

useSeo({
  title,
  description: "Découvrez le cycle de jeu et les différentes échelles de temps : secondes, minutes, heures et jours selon le contexte d’aventure.",
});
</script>
