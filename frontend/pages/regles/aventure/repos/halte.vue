<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>Lorsqu’un personnage effectue une activité légère pendant une <NuxtLink to="/regles/aventure/temps">heure</NuxtLink> ininterrompue, il fait halte.</p>
    <p>
      Une activité légère implique qu’aucune énergie n’est nécessaire à l’accomplissement de cette activité, par exemple faire tranquillement la conversation,
      lire ou écrire, monter la garde, s’étendre en restant immobile, ou encore méditer. L’action de manger n’est pas considérée comme une activité légère.
    </p>
    <p>
      Il récupère 10 % de son <NuxtLink to="/regles/statistiques/energie">Énergie</NuxtLink> totale (minimum 1) ainsi que 1 % de sa
      <NuxtLink to="/regles/statistiques/vitalite">Vitalité</NuxtLink> totale (minimum 0) par heure passée à la halte. S’il fait halte pendant plusieurs heures
      d’affilée, on effectue le calcul à la fin de la période, ce qui permet d’arrondir les points récupérés.
    </p>
    <p>Après avoir fait halte pendant 8 heures, le personnage peut continuer à faire halte, mais ses régénérations sont réduites de moitié.</p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Aventure", to: "/regles/aventure" },
  { text: "Repos", to: "/regles/aventure/repos" },
];
const title: string = "Halte";

useSeo({
  title,
  description: "Découvrez comment la halte permet de régénérer énergie et vitalité grâce aux activités légères.",
});
</script>
