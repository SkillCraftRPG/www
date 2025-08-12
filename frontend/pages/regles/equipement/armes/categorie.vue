<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb active="Catégories" :parent="parent" />
    <p>Les armes sont réparties en deux catégories :</p>
    <ul>
      <li><strong>Simples.</strong> Des armes rudimentaires et moins adaptées à la guerre, utilisées par les roturiers et soldats improvisés.</li>
      <li><strong>Martiales.</strong> Des armes complexes, puissantes et solides, dédiées aux hommes d’armes.</li>
    </ul>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Équipement", to: "/regles/equipement" },
  { text: "Armes", to: "/regles/equipement/armes" },
];
const title: string = "Catégories d’armes";

useSeo({
  title,
  description: "Découvrez les deux catégories d’arme : simples, martiales, et leurs caractéristiques.",
});
</script>
