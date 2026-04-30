<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Les invocations mystérieuses sont des capacités magiques ésotériques et secrètes réservées au
      <NuxtLink to="/regles/specialisations/conjurateur">Conjurateur</NuxtLink>.
    </p>
    <InvocationContents />
    <h2 class="h3">Liste des invocations</h2>
    <p>
      Lorsqu’une des capacités ci-dessous permet au personnage de <NuxtLink to="/regles/magie/pouvoirs/canalisation">canaliser</NuxtLink> un
      <NuxtLink to="/regles/magie/pouvoirs">pouvoir</NuxtLink>, celui-ci réussit automatiquement le
      <NuxtLink to="/regles/competences/tests">test</NuxtLink> d’<NuxtLink to="/regles/competences/occultisme">Occultisme</NuxtLink>, ne
      <NuxtLink to="/regles/magie/pouvoirs/energie">dépense</NuxtLink> aucun point d’<NuxtLink to="/regles/statistiques/energie">Énergie</NuxtLink>, et ne doit
      fournir aucune composante <NuxtLink to="/regles/magie/parametres/composantes">Focus</NuxtLink> ni
      <NuxtLink to="/regles/magie/parametres/composantes">Matériel</NuxtLink>. Il n’a pas besoin d’avoir acquis le pouvoir, et s’il est limité dans
      l’utilisation de la capacité, il récupère ces utilisations lorsqu’il complète une
      <NuxtLink to="/regles/aventure/repos/sommeil">nuit de sommeil</NuxtLink>.
    </p>
    <InvocationA />
    <InvocationBC />
    <InvocationDEFG />
    <InvocationLM />
    <InvocationOP />
    <InvocationSU />
    <InvocationV />
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [{ text: "Annexes", to: "/regles/annexes" }];
const title: string = "Invocations mystérieuses";

useSeo({
  title,
  description: "🚧",
});
</script>
