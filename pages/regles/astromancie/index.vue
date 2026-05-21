<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <RulesBreadcrumb :active="title" :parent="parent" />
    <p>
      L’astromancie est l’art mystique faisant appel à l’énergie des astres lointains afin d’altérer la réalité. Ces astres forment des constellations
      organisées en signes astrologiques qui régissent certains aspects du monde physique. Les mages étudiant dans une école de magie apprennent à reconnaître
      et à utiliser ces signes afin de canaliser les pouvoirs associés.
    </p>
    <div class="row">
      <div v-for="(item, index) in items" :key="index" class="col-xs-12 col-sm-6 col-md-4 col-lg-3 mb-4">
        <LinkCard class="d-flex flex-column h-100" :text="item.description" :title="item.title" :to="item.path" />
      </div>
    </div>
    <h2 class="h3">Cercles de magie</h2>
    <p>
      Les pouvoirs d’astromancie sont catégorisés en cercles de magie. Il existe cinq cercles de magie, décrits ci-dessous. Les pouvoirs n’appartenant à aucun
      cercle de magie sont dits universels.
    </p>
    <div class="row">
      <div v-for="(circle, index) in circles" :key="index" class="col-xs-12 col-sm-6 col-md-4 col-lg-3 col-fifth mb-4">
        <LinkCard class="d-flex flex-column h-100" :text="circle.description" :title="circle.title" :to="circle.path" />
      </div>
    </div>
    <!-- TODO(fpion):
     * Rites initiatiques: Initiation, Allégeance, Élévation
    -->
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
const title: string = "Astromancie";

type MenuItem = {
  path: string;
  title: string;
  description: string;
};
const items: MenuItem[] = [
  {
    path: "/regles/astromancie/signes",
    title: "Signes astrologiques",
    description: "Astres et constellations guidant les pouvoirs des Astromanciens.",
  },
  {
    path: "/regles/astromancie/pentacle",
    title: "Pentacle",
    description: "🚧",
  },
  {
    path: "/regles/astromancie/ecole",
    title: "École de magie",
    description: "Maisons et tours de magie structurant l’étude des astres.",
  },
  {
    path: "/regles/astromancie/ceremonies",
    title: "Rites initiatiques",
    description: "Rites, serments et rangs guidant la progression des mages.",
  },
];
const circles: MenuItem[] = [
  {
    path: "/regles/astromancie/abjuration",
    title: "Abjuration",
    description: "Pouvoirs protecteurs et de défense contre la magie.",
  },
  {
    path: "/regles/astromancie/divination",
    title: "Divination",
    description: "Pouvoirs pour voir le passé, le présent et l’avenir.",
  },
  {
    path: "/regles/astromancie/envoutement",
    title: "Envoûtement",
    description: "Pouvoirs pour charmer, tromper et contrôler l’esprit.",
  },
  {
    path: "/regles/astromancie/invocation",
    title: "Invocation",
    description: "Pouvoirs pour manipuler l’énergie et la matière.",
  },
  {
    path: "/regles/astromancie/transmutation",
    title: "Transmutation",
    description: "Pouvoirs pour transformer la réalité et la matière.",
  },
];

const category: string = SpellCategories.Astromancy;
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
  description: "Découvrez l’astromancie : l’art mystique d’altérer la réalité grâce à l’énergie des astres, des constellations et des signes astrologiques.",
});
</script>
