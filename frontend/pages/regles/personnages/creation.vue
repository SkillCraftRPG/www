<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb active="Création" :parent="parent" />
    <p>Avant de commencer à jouer, le joueur doit créer son personnage.</p>
    <p>Il utilise les étapes ci-dessous ainsi que son imagination afin de créer le personnage qu’il désire incarner.</p>
    <p>Il conçoit les différentes facettes de son personnage, notamment son apparence, sa personnalité et son historique.</p>
    <p>Il peut justifier ses choix par des calculs d’optimisation mathématique, mais aura bien plus de plaisir s’il utilise sa créativité.</p>
    <p>
      De manière générale, un personnage débute avec <NuxtLink to="/regles/personnages/progression/experience">0 point d’expérience</NuxtLink>, il est de
      <NuxtLink to="/regles/personnages/progression/niveau">niveau 0</NuxtLink> et de <NuxtLink to="/regles/personnages/progression/tiers">tiers 0</NuxtLink>.
    </p>
    <CharacterCreationContents />
    <CharacterCreationStep1Info />
    <CharacterCreationStep2Info />
    <CharacterCreationStep3Info />
    <CharacterCreationStep4Info />
    <CharacterCreationStep5Info />
    <CharacterCreationStep6Info />
    <CharacterCreationStep7Info />
    <button class="btn btn-lg btn-primary position-fixed bottom-0 end-0 m-3 rounded-circle" @click="scrollToTop">
      <font-awesome-icon icon="fas fa-arrow-up" />
    </button>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const title: string = "Création de personnage";

const parent = computed<Breadcrumb[]>(() => [{ text: "Personnages", to: "/regles/personnages" }]);

function scrollToTop(): void {
  window.history.replaceState(window.history.state, "", window.location.pathname + window.location.search);
  window.scrollTo({ top: 0, left: 0, behavior: "smooth" });
}

useSeoMeta({
  title,
  description:
    "Créez un personnage unique grâce à des étapes guidées, en définissant son apparence, sa personnalité, son histoire et ses caractéristiques initiales.",
});
useLinks();
</script>
