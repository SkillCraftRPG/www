<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" />
    <p>Cette section regroupe les annexes complétant les règles.</p>
    <div class="row">
      <div v-for="(item, index) in items" :key="index" class="col-xs-12 col-sm-6 col-md-4 mb-4">
        <LinkCard class="d-flex flex-column h-100" :text="item.description" :title="item.title" :to="item.path" />
      </div>
    </div>
  </main>
</template>

<script setup lang="ts">
const title: string = "Annexes";

type MenuItem = {
  path: string;
  title: string;
  description: string;
};
const items: MenuItem[] = [
  {
    path: "/regles/herboristerie",
    title: "Herboristerie",
    description: "Apprenez et créez remèdes et poisons selon votre rang et vos talents.",
  },
  {
    path: "/regles/domaines/divins",
    title: "Domaines divins",
    description: "Choisissez un domaine divin et ses pouvoirs sacrés associés.",
  },
  {
    path: "/regles/domaines/animisme",
    title: "Domaines d’animisme",
    description: "Choisissez un domaine animiste et sa catégorie associée.",
  },
  {
    path: "/regles/elementarisme",
    title: "Élémentarisme",
    description: "Maîtrisez l’essence des éléments et activez leurs pouvoirs.",
  },
  {
    path: "/regles/annexes/infusions-magiques",
    title: "Infusions magiques",
    description: "🚧",
  },
  {
    path: "/regles/annexes/invocations-mysterieuses",
    title: "Invocations mystérieuses",
    description: "🚧",
  },
];

useSeo({
  title,
  description: "🚧",
});
</script>
