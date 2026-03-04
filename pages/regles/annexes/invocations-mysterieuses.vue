<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Les invocations mystérieuses sont des capacités magiques ésotériques et secrètes réservées au
      <NuxtLink to="/regles/specialisations/conjurateur">Conjurateur</NuxtLink>.
    </p>
    <h2 class="h3">Liste des invocations</h2>
    <h3 class="h5">Acuité surnaturelle</h3>
    <p>
      Le personnage peut <NuxtLink to="/regles/magie/pouvoirs/canalisation">canaliser</NuxtLink> le
      <NuxtLink to="/regles/magie/pouvoirs/niveau">niveau 2</NuxtLink> du pouvoir
      <NuxtLink to="/regles/magie/pouvoirs/protection-contre-la-magie">Protection contre la magie</NuxtLink> sans
      <NuxtLink to="/regles/magie/pouvoirs/energie">dépenser de point d’Énergie</NuxtLink>, sans
      <NuxtLink to="/regles/magie/parametres/composantes">composante</NuxtLink>, et en réussissant automatiquement le
      <NuxtLink to="/regles/competences/tests">test</NuxtLink> d’<NuxtLink to="/regles/competences/occultisme">Occultisme</NuxtLink>. Il n’a pas besoin d’avoir
      acquis le pouvoir afin d’utiliser cette capacité.
    </p>
    <h3 class="h5">Contemplation</h3>
    <p>
      Le personnage se voit conférer l’<NuxtLink to="/regles/competences/tests/avantage-desavantage">avantage</NuxtLink> à ses
      <NuxtLink to="/regles/competences/tests/sauvegarde">jets de sauvegarde</NuxtLink> de
      <NuxtLink to="/regles/competences/discipline">Discipline</NuxtLink> afin de maintenir sa
      <NuxtLink to="/regles/magie/parametres/duree">concentration</NuxtLink> sur un <NuxtLink to="/regles/magie/pouvoirs">pouvoir</NuxtLink>.
    </p>
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
