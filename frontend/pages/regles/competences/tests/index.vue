<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>Lorsqu’un personnage ou une créature effectue une action qui a un potentiel de réussite et d’échec, il doit se soumettre à un test.</p>
    <p>
      Les actions qui ne peuvent réussir échouement automatiquement, aucun test nécessaire. Inversement, les actions qui ne peuvent échouer réussissent
      automatiquement, aucun test nécessaire.
    </p>
    <p>
      Chaque test est associé à un <NuxtLink to="/regles/attributs">attribut</NuxtLink> et à une <NuxtLink to="/regles/competences">compétence</NuxtLink>. Vous
      pouvez suggérer un attribut et/ou une compétence au maître de jeu lorsque vous effectuez un test, mais la décision finale lui appartient.
    </p>
    <div class="row">
      <div v-for="(item, index) in items" :key="index" class="col-xs-12 col-sm-6 col-md-4 col-lg-3 mb-4">
        <LinkCard class="d-flex flex-column h-100" :text="item.description" :title="item.title" :to="item.path" />
      </div>
    </div>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [{ text: "Compétences", to: "/regles/competences" }];
const title: string = "Tests";

type MenuItem = {
  path: string;
  title: string;
  description: string;
};
const items: MenuItem[] = [
  {
    path: "/regles/competences/tests/2d10",
    title: "Système 2d10",
    description: "Le système de résolution d’actions utilisant jet de dés, attributs et compétences.",
  },
  {
    path: "/regles/competences/tests/avantage",
    title: "Avantage et Désavantage",
    description: "L’effet de l’avantage et du désavantage sur le jet de dés, résolution en cas de cumul.",
  },
  {
    path: "/regles/competences/tests/critique",
    title: "Critique",
    description: "Fonctionnement et conséquences de la réussite critique et de l’échec critique.",
  },
  {
    path: "/regles/competences/tests/difficulte",
    title: "Degré de difficulté",
    description: "Détermine si une action réussit ou échoue, proportionnel à la complexité.",
  },
  {
    path: "/regles/competences/tests/faire-10",
    title: "Faire 10",
    description: "Réussir automatiquement une action sans menace ni distraction.",
  },
  {
    path: "/regles/competences/tests/faire-20",
    title: "Faire 20",
    description: "Réussir automatiquement une action sans menace, distraction ni contrainte de temps ou matérielle.",
  },
  {
    path: "/regles/competences/tests/oppose",
    title: "Test opposé",
    description: "Deux créatures s’affrontent, entrent en compétition.",
  },
  {
    path: "/regles/competences/tests/passif",
    title: "Test passif",
    description: "Utilise une moyenne plutôt qu’un lancer de dé afin de ne pas éveiller les soupçons des joueurs.",
  },
  {
    path: "/regles/competences/tests/groupe",
    title: "Test de groupe",
    description: "Tous les membres d’un groupe effectuent le même test.",
  },
  {
    path: "/regles/competences/tests/sauvegarde",
    title: "Jet de sauvegarde",
    description: "Se soustraire ou minimiser les conséquences négatives d’un effet.",
  },
];

useSeo({
  title,
  description: "Un test détermine le succès ou l’échec d’une action. Il associe un attribut et une compétence choisis par le maître de jeu selon le contexte.",
});
</script>
