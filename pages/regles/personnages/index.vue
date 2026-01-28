<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" />
    <p>Au cinéma comme dans la littérature, l’attention du public est centrée sur un ou plusieurs héros ou héroïnes.</p>
    <p>Dans le jeu de rôle, ce sont les personnages des joueurs qui sont les protagonistes de l’histoire.</p>
    <p>Leurs paroles et leurs actions donnent vie à l’intrigue racontée par le maître de jeu.</p>
    <div class="row">
      <div v-for="(item, index) in items" :key="index" class="col-xs-12 col-sm-6 mb-4">
        <LinkCard class="d-flex flex-column h-100" :text="item.description" :title="item.title" :to="item.path" />
      </div>
    </div>
  </main>
</template>

<script setup lang="ts">
const title: string = "Personnages";

type MenuItem = {
  path: string;
  title: string;
  description: string;
};
const items: MenuItem[] = [
  {
    path: "/regles/personnages/creation",
    title: "Création",
    description:
      "Créez un personnage unique grâce à des étapes guidées, en définissant son apparence, sa personnalité, son histoire et ses caractéristiques initiales.",
  },
  {
    path: "/regles/personnages/progression",
    title: "Progression",
    description:
      "Découvrez la progression des personnages, guidée par l’expérience, le niveau et le tiers, qui permettent d’améliorer et d’acquérir des capacités.",
  },
];

useSeo({
  title,
  description: "Découvrez le fonctionnement des personnages dans le jeu, véritables héros de l’histoire, et explorez les règles de création et de progression.",
});
</script>
