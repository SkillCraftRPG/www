<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Afin de canaliser un pouvoir, une créature doit réussir un <NuxtLink to="/regles/competences/tests">test</NuxtLink> d’<NuxtLink
        to="/regles/competences/occultisme"
        >Occultisme</NuxtLink
      >.
    </p>
    <p>
      Le <NuxtLink to="/regles/competences/tests/difficulte">degré de difficulté</NuxtLink> du test est égal au nombre de
      <NuxtLink to="/regles/magie/pouvoirs/energie">points d’Énergie dépensés</NuxtLink>.
    </p>
    <ul>
      <li>En cas de réussite, le pouvoir prend effet et les points d’Énergie sont dépensés.</li>
      <li>En cas d’échec, le pouvoir n’est pas canalisé, et les points d’Énergie sont perdus.</li>
    </ul>
    <p>
      Une créature peut canaliser plusieurs pouvoirs dans un même <NuxtLink to="/regles/combat/deroulement/tour">tour</NuxtLink>. Chaque test d’Occultisme est
      effectué indépendamment, et chaque canalisation engendre une dépense en points d’Énergie. Par exemple, une créature pourrait :
    </p>
    <ul>
      <li>Canaliser jusqu’à trois fois un pouvoir dont l’<NuxtLink to="/regles/magie/parametres/incantation">incantation</NuxtLink> est d’une seule action.</li>
      <li>Canaliser un pouvoir dont l’incantation est d’une seule action ainsi qu’un pouvoir dont l’incantation est de deux actions.</li>
    </ul>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Magie", to: "/regles/magie" },
  { text: "Pouvoirs", to: "/regles/magie/pouvoirs" },
];
const title: string = "Canalisation";

useSeo({
  title,
  description: "Découvrez comment canaliser un pouvoir via un test d’Occultisme, réussissez ou perdez vos points d’Énergie.",
});

// TODO(fpion): réussite avec Damnation
// TODO(fpion): échec avec Damnation
// TODO(fpion): échec critique
</script>
