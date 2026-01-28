<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>La cible d’un pouvoir est généralement un point dans l’espace, ou une ou plusieurs autres créatures.</p>
    <p>Chaque cible doit se trouver dans une distance inférieure ou égale à la portée indiquée par le pouvoir.</p>
    <p>Il existe certaines portées spéciales :</p>
    <ul>
      <li><strong>Soi.</strong> Le pouvoir n’affecte que la créature qui le canalise.</li>
      <li><strong>Toucher.</strong> La cible doit être touchée afin d’être affectée par le pouvoir.</li>
    </ul>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Magie", to: "/regles/magie" },
  { text: "Paramètres", to: "/regles/magie/parametres" },
];
const title: string = "Portée";

useSeo({
  title,
  description: "Découvrez comment la portée d’un pouvoir détermine les cibles affectées, incluant les portées spéciales comme Toucher et Soi.",
});
</script>
