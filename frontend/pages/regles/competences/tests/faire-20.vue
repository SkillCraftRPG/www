<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>Certaines situations vous permettent de réussir un test automatiquement sans <NuxtLink to="/regles/competences/tests/2d10">jeter de dé</NuxtLink>.</p>
    <p>Lorsque les conditions suivantes sont respectées, vous pouvez <i>Faire 20</i>, et l’action entreprise est réussie.</p>
    <p><i>Faire 20</i> signifie que votre personnage prend le temps d’obtenir le meilleur résultat possible.</p>
    <ul>
      <li>
        <strong>Vous n’êtes pas menacé.</strong> Vous n’êtes pas considéré menacé si aucune créature ennemie ne peut vous atteindre pas une attaque quelconque
        (mêlée, à distance ou même surnaturelle).
      </li>
      <li>
        <strong>Vous n’êtes pas distrait.</strong> Certaines situations peuvent causer la distraction, par exemple un fort bruit ambiant, des mouvements
        brusques (en véhicule, en navire, sur une monture, etc.), une météo violente, vous devez retenir votre souffle, etc.
      </li>
      <li>
        <strong>Sans contrainte de temps.</strong> Vous pouvez prendre environ 20 fois le temps nécessaire afin d’accomplir la tâche sans subir de pénalité ni
        de conséquence négative.
      </li>
      <li>
        <strong>Sans contrainte matérielle.</strong>
        Vous pouvez répéter 20 fois l’action sans subir de pénalité ou de conséquence matérielle, par exemple une perte de ressources, un bris d’équipement ou
        d’outils, une blessure ou la fatigue, etc.
      </li>
    </ul>
    <p>
      Lorsque vous <i>faites 20</i>, vous ne bénéficiez d’aucune conséquence positive ou négative. Vous ne générez pas non plus de
      <strong>points d’Espérance ni de Damnation</strong>.
    </p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Compétences", to: "/regles/competences" },
  { text: "Tests", to: "/regles/competences/tests" },
];
const title: string = "Faire 20";

useSeo({
  title,
  description:
    "Découvrez les situations permettant de réussir un test automatiquement lorsque les conditions de sécurité, concentration et contraintes sont respectées.",
});
</script>
