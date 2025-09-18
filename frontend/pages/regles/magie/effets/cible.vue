<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>La plupart des pouvoirs nécessitent la sélection d’une ou plusieurs cibles.</p>
    <p>
      Une cible peut ne pas se rendre compte qu’elle est affectée par un pouvoir, ce qui est le cas des
      <NuxtLink to="/regles/combat/conditions/charme">charmes</NuxtLink>.
    </p>
    <p>
      Une créature peut se désigner elle-même comme cible lorsqu’elle <NuxtLink to="/regles/magie/pouvoirs/canalisation">canalise</NuxtLink> un pouvoir, sauf si
      contre-indiqué.
    </p>
    <p>
      Lorsqu’elle désigne une autre créature comme cible, elle doit pouvoir <NuxtLink to="/regles/aventure/environnement/vision">voir</NuxtLink> cette cible,
      sauf lorsque contre-indiqué. Il est donc impossible de cibler une créature bénéficiant d’un
      <NuxtLink to="/regles/combat/attaque/abri">abri&nbsp;total</NuxtLink>.
    </p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Magie", to: "/regles/magie" },
  { text: "Effets", to: "/regles/magie/effets" },
];
const title: string = "Cible";

useSeo({
  title,
  description:
    "Découvrez comment fonctionne la sélection des cibles pour les pouvoirs, leurs restrictions, et les cas particuliers comme l’abri total ou les charmes.",
});
</script>
