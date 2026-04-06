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
    <InvocationA />
    <InvocationBC />
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
