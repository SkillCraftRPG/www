<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Vous achevez une créature <NuxtLink to="/regles/combat/mort-agonie">mourante</NuxtLink>. Celle-ci doit être
      <NuxtLink to="/regles/combat/conditions/agonisant">agonisante</NuxtLink> et instable.
    </p>
    <p>
      Si la créature est agonisante mais stable, vous devez d’abord la rendre instable en la <NuxtLink to="/regles/combat/degats">blessant</NuxtLink>, par
      exemple par une <NuxtLink to="/regles/combat/attaque">attaque</NuxtLink>.
    </p>
    <p>Une créature achevée meurt instantanément. Elle peut néanmoins être ressuscitée si les conditions sont respectées.</p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Combat", to: "/regles/combat" },
  { text: "Activités", to: "/regles/combat/activites" },
];
const title: string = "Coup de grâce";

useSeo({
  title,
  description:
    "Découvrez comment le coup de grâce permet d’achever une créature mourante et instable, entraînant sa mort instantanée sauf si elle est ressuscitée.",
});
</script>
