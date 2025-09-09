<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>Les paramètres suivants définissent la manière dont un pouvoir est canalisé et la forme que son effet prend.</p>
    <div class="row">
      <div v-for="(item, index) in items" :key="index" class="col-xs-12 col-sm-6 mb-4">
        <LinkCard class="d-flex flex-column h-100" :text="item.description" :title="item.title" :to="item.path" />
      </div>
    </div>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [{ text: "Magie", to: "/regles/magie" }];
const title: string = "Paramètres";

type MenuItem = {
  path: string;
  title: string;
  description: string;
};
const items: MenuItem[] = [
  {
    path: "/regles/magie/parametres/incantation",
    title: "Incantation",
    description: "Durée d’incantation : actions, réactions ou incantation prolongée.",
  },
];

useSeo({
  title,
  description: "🚧",
});
</script>
