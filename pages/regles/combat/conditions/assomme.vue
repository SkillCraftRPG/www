<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Une créature assommée est <NuxtLink to="/regles/combat/conditions/incapable">incapable</NuxtLink> : elle ne peut pas bouger, et elle ne peut balbutier que
      quelques mots hésitants.
    </p>
    <p>
      Également, elle échoue automatique ses <NuxtLink to="/regles/competences/tests/sauvegarde">jets de sauvegarde</NuxtLink> d’<NuxtLink
        to="/regles/competences/athletisme"
        >Athlétisme</NuxtLink
      >
      et d’<NuxtLink to="/regles/competences/acrobaties">Acrobaties</NuxtLink>.
    </p>
    <p>
      Enfin, le <NuxtLink to="/regles/competences/tests">test</NuxtLink> des <NuxtLink to="/regles/combat/attaque">attaques</NuxtLink> dirigées contre cette
      créature se voit conférer l’<NuxtLink to="/regles/competences/tests/avantage-desavantage">avantage</NuxtLink>.
    </p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Combat", to: "/regles/combat" },
  { text: "Conditions", to: "/regles/combat/conditions" },
];
const title: string = "Assommé";

useSeo({
  title,
  description: "Découvrez la condition Assommé : une créature incapable échoue à ses sauvegardes physiques et subit l’avantage aux attaques ennemies.",
});
</script>
