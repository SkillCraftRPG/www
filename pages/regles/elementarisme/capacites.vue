<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>🚧</p>
    <ElementalismContents />
    <h2 id="tiers-1" class="h3">Capacités de tiers 1</h2>
    <ElementalismMinorForm />
    <ElementalismBlink />
    <h2 id="tiers-2" class="h3">Capacités de tiers 2</h2>
    <ElementalismExile />
    <ElementalismExpression />
    <ElementalismExpelling />
    <ElementalismMediumForm />
    <h2 id="tiers-3" class="h3">Capacités de tiers 3</h2>
    <ElementalismMajorForm />
    <button class="btn btn-lg btn-primary position-fixed bottom-0 end-0 m-3 rounded-circle" @click="scrollToTop">
      <font-awesome-icon icon="fas fa-arrow-up" />
    </button>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Annexes", to: "/regles/annexes" },
  { text: "Élémentarisme", to: "/regles/elementarisme" },
];
const title: string = "Capacités élémentaires";

useSeo({
  title,
  description: "🚧",
});
</script>
