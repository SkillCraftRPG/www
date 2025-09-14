<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" />
    <p>Les dons et handicaps sont une manière additionnelle de personnaliser son personnage.</p>
    <p>Ils sont complètement optionnels : un joueur peut très bien créer un personnage sans don ni handicap.</p>
    <p>
      Ces éléments sont également permanents, c’est-à-dire qu’ils ne peuvent être ajoutés à un personnage qu’au moment de sa création, et ils ne peuvent jamais
      être retirés.
    </p>
    <p>Au moment de la création du personnage, le joueur peut lui attribuer des dons. Il doit néanmoins lui attribuer un nombre égal de handicaps.</p>
    <p>Le maître de jeu peut restreindre le nombre de dons et handicaps qu’un joueur peut attribuer à son personnage. La recommandation est la suivante :</p>
    <ul>
      <li>Joueurs débutants : aucun don, au plus 1 don</li>
      <li>Joueurs intermédiaires : entre 1 et 2 dons</li>
      <li>Joueurs expérimentés : maximum 3 dons</li>
    </ul>
    <CustomizationList v-if="customizations.length" :items="customizations" />
    <button class="btn btn-lg btn-primary position-fixed bottom-0 end-0 m-3 rounded-circle" @click="scrollToTop">
      <font-awesome-icon icon="fas fa-arrow-up" />
    </button>
  </main>
</template>

<script setup lang="ts">
import { arrayUtils } from "logitar-js";

import type { Customization } from "~/types/game";
import { getCustomizations } from "~/services/customizations";

const title: string = "Dons & Handicaps";
const { orderBy } = arrayUtils;

const customizations = ref<Customization[]>(orderBy(getCustomizations(), "slug"));

useSeo({
  title,
  description:
    "Ajoutez une touche unique à votre personnage grâce aux dons et handicaps, des options permanentes disponibles uniquement à la création du personnage.",
});
</script>
