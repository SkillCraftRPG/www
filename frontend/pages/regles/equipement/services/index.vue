<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>🚧</p>
    <div class="row">
      <div v-for="(item, index) in items" :key="index" class="col-xs-12 col-sm-6 col-md-4 mb-4">
        <LinkCard class="d-flex flex-column h-100" :text="item.description" :title="item.title" :to="item.path" />
      </div>
    </div>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [{ text: "Équipement", to: "/regles/equipement" }];
const title: string = "Services";

type MenuItem = {
  path: string;
  title: string;
  description: string;
};
const items: MenuItem[] = [
  {
    path: "/regles/equipement/services/gite-couvert",
    title: "Gîte et couvert",
    description: "🚧",
  },
  {
    path: "/regles/equipement/services/professionnels",
    title: "Services professionnels",
    description: "🚧",
  },
  {
    path: "/regles/equipement/services/occultes",
    title: "Services occultes",
    description: "🚧",
  },
  {
    path: "/regles/equipement/services/peuplements",
    title: "Peuplements",
    description: "🚧",
  },
  {
    path: "/regles/equipement/services/passage-navire",
    title: "Passage en navire",
    description: "🚧",
  },
];

useSeo({
  title,
  description: "🚧",
});
</script>
