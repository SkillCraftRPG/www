<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Les <NuxtLink to="/regles/combat/activites">activités</NuxtLink> <i>Attaquer</i> et
      <NuxtLink to="/regles/combat/activites/viser-tirer">Viser et tirer</NuxtLink> permettent à une créature d’effectuer une attaque.
    </p>
    <p>
      L’attaquant effectue un <NuxtLink to="/regles/competences/tests">test</NuxtLink> de <NuxtLink to="/regles/competences/melee">Mêlée</NuxtLink> ou
      d’<NuxtLink to="/regles/competences/orientation">Orientation</NuxtLink>, selon la situation. Le résultat du test est comparé à l’<NuxtLink
        to="/regles/combat/attaque/esquive"
        >Esquive</NuxtLink
      >
      et à la <NuxtLink to="/regles/combat/attaque/defense">Défense</NuxtLink> de la cible.
    </p>
    <p>
      Comme tout test de <NuxtLink to="/regles/competences">compétence</NuxtLink>, l’attaque peut engendrer un
      <NuxtLink to="/regles/competences/tests/critique">coup critique</NuxtLink>.
    </p>
    <p>
      Lorsqu’une créature n’est pas <NuxtLink to="/regles/equipement/armes/formation">formée</NuxtLink> avec l’<NuxtLink to="/regles/equipement/armes"
        >arme</NuxtLink
      >
      qu’elle manie pour effectuer l’attaque, alors son <NuxtLink to="/regles/competences/rang">rang</NuxtLink> de compétence n’est pas ajouté au test.
    </p>
    <p>Les armes improvisées et attaques avec les membres de son corps nécessitent également une formation afin d’éviter cette pénalité.</p>
    <div class="row">
      <div v-for="(item, index) in items" :key="index" class="col-xs-12 col-sm-6 col-md-4 mb-4">
        <LinkCard class="d-flex flex-column h-100" :text="item.description" :title="item.title" :to="item.path" />
      </div>
    </div>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [{ text: "Combat", to: "/regles/combat" }];
const title: string = "Attaque";

type MenuItem = {
  path: string;
  title: string;
  description: string;
};
const items: MenuItem[] = [
  {
    path: "/regles/combat/attaque/multiples",
    title: "Attaques multiples",
    description: "Pénalités et restrictions d’effectuer un enchaînement d’attaques dans le même tour.",
  },
  {
    path: "/regles/combat/attaque/esquive",
    title: "Esquive",
    description: "Règles de l’Esquive, comparaisons aux attaques ennemies et talents pour mieux éviter les coups.",
  },
  {
    path: "/regles/combat/attaque/defense",
    title: "Défense",
    description: "Défense : esquive, boucliers et armures pour bloquer les attaques, avec talents de protection.",
  },
  {
    path: "/regles/combat/attaque/dissimulee",
    title: "Attaque dissimulée",
    description: "Pénalités aux cibles non voyantes et avantages pour les assaillants dissimulés.",
  },
  {
    path: "/regles/combat/attaque/melee",
    title: "Attaque de mêlée",
    description: "Coups au corps-à-corps avec armes ou membres, portée de 1,5 mètres.",
  },
  {
    path: "/regles/combat/attaque/distance",
    title: "Attaque à distance",
    description: "Combat avec armes de jet ou à munition, portée et précision.",
  },
  {
    path: "/regles/combat/attaque/opportunite",
    title: "Attaque d’opportunité",
    description: "🚧",
  },
  {
    path: "/regles/combat/attaque/deux-armes",
    title: "Combat à deux armes",
    description: "Règles, désavantages et talents pour le combat à plusieurs armes.",
  },
  {
    path: "/regles/combat/attaque/abri",
    title: "Abri",
    description: "Règles d’abri en combat : bonus de défense selon l’espace bloqué.",
  },
];

useSeo({
  title,
  description: "🚧",
});

// TODO(fpion): attaquer directement une arme, un bouclier ou un objet tenu
</script>
