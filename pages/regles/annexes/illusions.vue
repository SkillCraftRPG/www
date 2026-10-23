<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <RulesBreadcrumb :active="title" :parent="parent" />
    <p>
      Les illusions sont des pouvoirs manipulant la fabrique de la réalité afin d’y introduire des éléments imaginés de toute pièce. Certains de ces pouvoirs
      manipulent la psyché plutôt que la réalité. Les talents <NuxtLink to="/regles/talents/illusions-mineures">Illusions mineures</NuxtLink> et
      <NuxtLink to="/regles/talents/pareidolie">Paréidolie</NuxtLink> permettent d’<NuxtLink to="/regles/magie/pouvoirs/acquisition">acquérir</NuxtLink> les
      pouvoirs ci-dessous.
    </p>
    <SpellList v-if="spells.length" :items="spells" :scope="category" />
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/tar/breadcrumb";
import type { SearchResults } from "~/types/game";
import type { Spell } from "~/types/magic";
import { SpellCategories } from "~/types/constants";

const config = useRuntimeConfig();
const parent: Breadcrumb[] = [{ text: "Annexes", to: "/regles/annexes" }];
const title: string = "Illusions";

const category: string = SpellCategories.Illusion;
const { data } = await useLazyAsyncData<SearchResults<Spell>>(
  `spells:${category}`,
  () =>
    $fetch(`/api/spells?category=${category}`, {
      baseURL: config.public.apiBaseUrl,
    }),
  {
    server: false,
  },
);
const spells = computed<Spell[]>(() => data.value?.items ?? []);

useSeo({
  title,
  description:
    "Découvrez les illusions de SkillCraft, des pouvoirs capables de tromper les sens, de manipuler la psyché et d’altérer la réalité, ainsi que leurs effets.",
});
</script>
