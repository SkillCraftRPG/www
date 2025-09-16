<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>Certaines situations vous permettent de réussir un test automatiquement sans <NuxtLink to="/regles/competences/tests/2d10">jeter de dé</NuxtLink>.</p>
    <p>Lorsque les conditions suivantes sont respectées, vous pouvez <i>Faire 10</i>, et l’action entreprise est réussie.</p>
    <p><i>Faire 10</i> signifie que votre personnage fait de son mieux afin d’atteindre rapidement un résultat satisfaisant.</p>
    <ul>
      <li>
        <strong>Vous n’êtes pas menacé.</strong> Vous n’êtes pas considéré menacé si aucune créature ennemie ne peut vous atteindre pas une
        <NuxtLink to="/regles/combat/attaque">attaque</NuxtLink> quelconque (<NuxtLink to="/regles/combat/attaque/melee">mêlée</NuxtLink>,
        <NuxtLink to="/regles/combat/attaque/distance">à distance</NuxtLink> ou même <NuxtLink to="/regles/magie/effets/attaque">surnaturelle</NuxtLink>).
      </li>
      <li>
        <strong>Vous n’êtes pas distrait.</strong> Certaines situations peuvent causer la distraction, par exemple un fort bruit ambiant, des mouvements
        brusques (en véhicule, en navire, sur une monture, etc.), une météo violente, vous devez retenir votre souffle, etc.
      </li>
      <li>
        <strong>Le résultat de votre test passif est suffisant.</strong> Le résultat de votre
        <NuxtLink to="/regles/competences/tests/passif">test passif</NuxtLink> doit être supérieur ou égal au
        <NuxtLink to="/regles/competences/tests/difficulte">degré de difficulté</NuxtLink>.
      </li>
    </ul>
    <p>
      Lorsque vous <i>faites 10</i>, vous ne bénéficiez d’aucune conséquence positive ou négative. Vous ne générez pas non plus de
      <NuxtLink to="/regles/competences/esperance-damnation">point d’Espérance ni de Damnation</NuxtLink>.
    </p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Compétences", to: "/regles/competences" },
  { text: "Tests", to: "/regles/competences/tests" },
];
const title: string = "Faire 10";

useSeo({
  title,
  description:
    "Découvrez les situations permettant de réussir un test automatiquement lorsque les conditions de sécurité, concentration et seuil passif sont respectés.",
});
</script>
