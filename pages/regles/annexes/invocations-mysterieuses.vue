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
    <div class="text-danger">
      <p>Il serait intéressant de :</p>
      <ul>
        <li>Ne pas dupliquer l’information à propos des composantes, de la dépense d’Énergie et de la réussite automatique des pouvoirs.</li>
        <li>Ce sont les composantes Focus et Matériel qui sont retirées, pas les Somatique ni les Verbal.</li>
      </ul>
    </div>
    <InvocationA />
    <InvocationBC />
    <InvocationDEG />
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
