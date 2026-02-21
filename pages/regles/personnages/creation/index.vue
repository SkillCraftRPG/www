<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb active="Création" :parent="parent" />
    <p>Avant de commencer à jouer, vous devez créer un personnage.</p>
    <p>Utilisez les étapes ci-dessous ainsi que votre imagination afin de créer le personnage que vous désirez incarner.</p>
    <p>Vous concevrez les différentes facettes de votre personnage, notamment son apparence, sa personnalité et son historique.</p>
    <p>Vous pouvez justifier vos choix par des calculs d’optimisation mathématique, mais vous aurez bien plus de plaisir si vous utilisez votre créativité.</p>
    <p>
      De manière générale, un personnage débute avec <NuxtLink to="/regles/personnages/progression/experience">0 point d’expérience</NuxtLink>, il est de
      <NuxtLink to="/regles/personnages/progression/niveau">niveau 0</NuxtLink> et de <NuxtLink to="/regles/personnages/progression/tiers">tiers 0</NuxtLink>.
    </p>
    <CharacterCreationContents />
    <CharacterCreationIntroduction />
    <CharacterCreationStep1 />
    <CharacterCreationStep2 />
    <CharacterCreationStep3 />
    <CharacterCreationStep4 />
    <CharacterCreationStep5 />
    <CharacterCreationStep6 />
    <CharacterCreationStep7 />
    <CharacterCreationStep8 />
    <CharacterCreationStep9 />
    <CharacterCreationStep10 />
    <CharacterCreationReview />
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [{ text: "Personnages", to: "/regles/personnages" }];
const title: string = "Création de personnage";

useSeo({
  title,
  description:
    "Créez un personnage unique grâce à des étapes guidées, en définissant son apparence, sa personnalité, son histoire et ses caractéristiques initiales.",
});
</script>
