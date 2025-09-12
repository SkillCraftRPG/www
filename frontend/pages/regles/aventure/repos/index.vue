<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Le repos consiste en un moyen naturel pour les aventuriers de récupérer leur <NuxtLink to="/regles/statistiques/vitalite">Vitalité</NuxtLink> ainsi que
      leur <NuxtLink to="/regles/statistiques/energie">Énergie</NuxtLink>.
    </p>
    <p>Il est évidemment impossible pour un aventurier de récupérer plus de points qu’il lui en manque.</p>
    <p>
      Sa régénération peut être augmentée par certains effets, par exemple un <strong>remède</strong>, un
      <NuxtLink to="/regles/magie/pouvoirs">pouvoir</NuxtLink>, ou encore le <NuxtLink to="/regles/talents">talent</NuxtLink>
      <NuxtLink to="/regles/talents/meditation">Méditation</NuxtLink>.
    </p>
    <p>
      Au contraire, certaines conditions peuvent réduire sa régénération, par exemple un niveau de stress élevé, un environnement particulièrement bruyant, le
      fait de dormir en portant son <NuxtLink to="/regles/equipement/armures">armure</NuxtLink>, ou encore la
      <NuxtLink to="/regles/aventure/environnement/alimentation">faim</NuxtLink>.
    </p>
    <div class="row">
      <div v-for="(item, index) in items" :key="index" class="col-xs-12 col-sm-6 mb-4">
        <LinkCard class="d-flex flex-column h-100" :text="item.description" :title="item.title" :to="item.path" />
      </div>
    </div>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [{ text: "Aventure", to: "/regles/aventure" }];
const title: string = "Repos";

type MenuItem = {
  path: string;
  title: string;
  description: string;
};
const items: MenuItem[] = [
  {
    path: "/regles/aventure/repos/sommeil",
    title: "Sommeil",
    description: "Règles du sommeil et effets d’une nuit complète.",
  },
  {
    path: "/regles/aventure/repos/halte",
    title: "Halte",
    description: "Récupération par halte et activités légères.",
  },
];

useSeo({
  title,
  description: "Découvrez les règles de sommeil et de halte, essentielles pour récupérer énergie, vitalité et réduire la fatigue des personnages.",
});
</script>
