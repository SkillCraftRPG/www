<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>Une créature blessée par une <NuxtLink to="/regles/combat/attaque">attaque</NuxtLink> ou une situation périlleuse reçoit des points de dégâts.</p>
    <div class="row">
      <div v-for="(item, index) in items" :key="index" class="col-xs-12 col-sm-6 col-lg-4 mb-4">
        <LinkCard class="d-flex flex-column h-100" :text="item.description" :title="item.title" :to="item.path" />
      </div>
    </div>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [{ text: "Combat", to: "/regles/combat" }];
const title: string = "Dégâts";

type MenuItem = {
  path: string;
  title: string;
  description: string;
};
const items: MenuItem[] = [
  {
    path: "/regles/combat/degats/letalite",
    title: "Létalité",
    description: "🚧",
  },
  {
    path: "/regles/combat/degats/jet",
    title: "Jet de dégâts",
    description: "Jet de dégâts : lancez les dés et ajoutez la statistique associée.",
  },
  {
    path: "/regles/combat/degats/types",
    title: "Types de dégâts",
    description: "🚧",
  },
  {
    path: "/regles/combat/degats/efficacite",
    title: "Efficacité",
    description: "Efficacité : résistances, vulnérabilités et immunités aux dégâts.",
  },
  {
    path: "/regles/combat/degats/soins",
    title: "Soins",
    description: "🚧",
  },
  {
    path: "/regles/combat/degats/temporaire",
    title: "Points temporaires",
    description: "Points temporaires : Vitalité bonus absorbant les dégâts en premier.",
  },
];

useSeo({
  title,
  description: "🚧",
});
</script>
