<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Lorsque votre <NuxtLink to="/regles/combat/monte">monture</NuxtLink> est <NuxtLink to="/regles/">renversée</NuxtLink>, que vous êtes renversés alors que
      vous la montez, ou que votre monture est déplacée contre son gré, vous la démontez et retombez sur vos jambes.
    </p>
    <p>
      Si vous tombez d’une hauteur supérieure ou égale à 1,5 mètres, vous subissez une <NuxtLink to="/regles/aventure/environnement/chute">chute</NuxtLink>.
      Vous pouvez tenter d’<NuxtLink to="/regles/combat/activites/amortir-chute">amortir votre chute</NuxtLink> dans la même
      <NuxtLink to="/regles/combat">réaction</NuxtLink>.
    </p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Combat", to: "/regles/combat" },
  { text: "Activités", to: "/regles/combat/activites" },
];
const title: string = "Démonter";

useSeo({
  title,
  description: "Découvrez la règle pour démonter d’une monture renversée et gérer la chute éventuelle, avec possibilité d’amortir l’impact par une réaction.",
});
</script>
