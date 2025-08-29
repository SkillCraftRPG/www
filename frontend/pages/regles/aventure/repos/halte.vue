<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>Lorsqu’un personnage effectue une activité légère pendant une <NuxtLink to="/regles/aventure/temps">heure</NuxtLink> ininterrompue, il fait halte.</p>
    <h2 class="h3">Activité légère</h2>
    <p>
      Une activité légère implique qu’aucune énergie n’est nécessaire à l’accomplissement de cette activité, par exemple faire tranquillement la conversation,
      lire ou écrire, monter la garde, s’étendre en restant immobile, ou encore méditer.
    </p>
    <p>L’action de <NuxtLink to="/regles/aventure/environnement/alimentation">manger</NuxtLink> n’est pas considérée comme une activité légère.</p>
    <h2 class="h3">Régénération</h2>
    <p>
      Un personnage récupère ⅒ ({{ $n(1 / 10, "percentage") }}) de son <NuxtLink to="/regles/statistiques/energie">Énergie</NuxtLink> totale (minimum 1) par
      heure passée à la halte.
    </p>
    <p>S’il fait halte pendant plusieurs heures d’affilée, le calcul est effectué à la fin de la période, ce qui permet d’arrondir les points récupérés.</p>
    <p>Après avoir fait halte pendant 8 heures, cette régénération est réduite de moitié pour chaque heure additionnelle.</p>
    <p>
      S’il complète une <NuxtLink to="/regles/aventure/repos/sommeil">nuit de sommeil</NuxtLink> et fait halte pendant une période de 24 heures consécutives, il
      récupère le double de points de <NuxtLink to="/regles/statistiques/vitalite">Vitalité</NuxtLink>.
    </p>
    <h2 class="h3">Bénéfices</h2>
    <p>Les utilisations de certaines capacités sont récupérées après une halte.</p>
    <p>Certaines conditions et pénalités prennent également fin après une halte.</p>
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
