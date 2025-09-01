<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>Les règles décrites dans cette section s’appliquent à l’environnement dans lequel l’aventure se déroule.</p>
    <div class="row">
      <div v-for="(item, index) in items" :key="index" class="col-xs-12 col-sm-6 col-md-4 mb-4">
        <LinkCard class="d-flex flex-column h-100" :text="item.description" :title="item.title" :to="item.path" />
      </div>
    </div>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [{ text: "Aventure", to: "/regles/aventure" }];
const title: string = "Environnement";

type MenuItem = {
  path: string;
  title: string;
  description: string;
};
const items: MenuItem[] = [
  {
    path: "/regles/aventure/environnement/chute",
    title: "Chute",
    description: "Règles de chute : dégâts, sauvegardes et surfaces d’impact.",
  },
  {
    path: "/regles/aventure/environnement/suffocation",
    title: "Retenir son souffle",
    description: "Durée d’apnée et règles de suffocation en jeu.",
  },
  {
    path: "/regles/aventure/environnement/vision",
    title: "Vision",
    description: "Lumière, obscurité et visions spéciales en jeu.",
  },
  {
    path: "/regles/aventure/environnement/alimentation",
    title: "Alimentation",
    description: "Soif, faim et survie des personnages en jeu.",
  },
  {
    path: "/regles/aventure/environnement/alcoolemie",
    title: "Alcoolémie",
    description: "Alcoolémie, ébriété et gueule de bois en jeu.",
  },
  {
    path: "/regles/aventure/environnement/objets",
    title: "Interaction avec les objets",
    description: "Règles pour cibler, briser et gérer la solidité des objets.",
  },
];

useSeo({
  title,
  description: "Découvrez les règles d’environnement : chutes, suffocation, vision, alimentation et interactions avec les objets durant l’aventure.",
});
</script>
