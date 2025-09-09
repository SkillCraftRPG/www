<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" />
    <p>La magie est l’art de produire des phénomènes surnaturels par des procédés occultes.</p>
    <p>
      Elle peut avoir une fonction importante dans le jeu de rôle puisque plusieurs types de personnages peuvent utiliser la magie, par exemple les sorciers ou
      enchanteurs, les membres d’un clergé ou encore un mystique possédant des pouvoirs psychiques.
    </p>
    <p>La magie concerne donc les capacités surnaturelles mystérieuses ou étranges des personnages.</p>
    <div class="row">
      <div v-for="(item, index) in items" :key="index" class="col-xs-12 col-sm-6 col-md-4 mb-4">
        <LinkCard class="d-flex flex-column h-100" :text="item.description" :title="item.title" :to="item.path" />
      </div>
    </div>
  </main>
</template>

<script setup lang="ts">
const title: string = "Magie";

type MenuItem = {
  path: string;
  title: string;
  description: string;
};
const items: MenuItem[] = [
  {
    path: "/regles/magie/pouvoirs",
    title: "Pouvoirs",
    description: "Regroupent sorts et capacités uniques, règles d’apprentissage et d’usage.",
  },
  {
    path: "/regles/magie/parametres",
    title: "Paramètres",
    description: "🚧",
  },
];

useSeo({
  title,
  description: "🚧",
});
</script>
