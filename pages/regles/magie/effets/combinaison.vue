<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>Les effets différents de plusieurs pouvoirs peuvent être cumulatifs.</p>
    <p>
      En revanche, lorsque plusieurs pouvoirs ayant des effets similaires ou identiques sont canalisés, l’effet le plus puissant est prioritaire aux effets les
      moins puissants.
    </p>
    <p>
      Si cet effet est d’une durée moindre que celle d’un autre effet moins prioritaire, alors l’effet moins prioritaire agit aussitôt que le premier effet se
      termine.
    </p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Magie", to: "/regles/magie" },
  { text: "Effets", to: "/regles/magie/effets" },
];
const title: string = "Combinaison";

useSeo({
  title,
  description:
    "Découvrez comment les effets de plusieurs pouvoirs peuvent se cumuler, avec priorité donnée aux plus puissants et enchaînement selon leur durée.",
});
</script>
