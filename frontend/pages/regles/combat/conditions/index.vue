<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Les conditions sont des états affectant les capacités d’une créature. La majorité des conditions sont négatives, mais certaines conditions confèrent un
      effet bénéfique.
    </p>
    <p>Une condition dure jusqu’à ce qu’elle soit contrée ou jusqu’à la fin de l’effet l’ayant causée.</p>
    <p>
      Une créature peut être affectée simultanément par toutes les conditions. Si elle est affectée plusieurs fois par la même condition, les effets ne sont pas
      cumulés, mais chaque effet possède sa propre durée.
    </p>
    <div class="row">
      <div v-for="(condition, index) in conditions" :key="index" class="col-xs-12 col-sm-6 col-md-4 col-lg-3 mb-4">
        <LinkCard class="d-flex flex-column h-100" :text="condition.description" :title="condition.title" :to="condition.path" />
      </div>
    </div>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [{ text: "Combat", to: "/regles/combat" }];
const title: string = "Conditions";

type Condition = {
  path: string;
  title: string;
  description: string;
};
const conditions: Condition[] = [
  {
    path: "/regles/combat/conditions/agrippe",
    title: "Agrippé",
    description: "Cible immobilisée jusqu’à son évasion ou sa libération.",
  },
  {
    path: "/regles/combat/conditions/apeure",
    title: "Apeuré",
    description: "Désavantage aux tests et restrictions de mouvement.",
  },
  {
    path: "/regles/combat/conditions/assomme",
    title: "Assommé",
    description: "Incapable, échecs automatiques et faiblesse.",
  },
  {
    path: "/regles/combat/conditions/assourdi",
    title: "Assourdi",
    description: "Échec des tests auditifs.",
  },
  {
    path: "/regles/combat/conditions/aveugle",
    title: "Aveuglé",
    description: "Échec des tests visuels et impacts sur les attaques.",
  },
  {
    path: "/regles/combat/conditions/charme",
    title: "Charmé",
    description: "Contrainte du charmé et avantages du charmeur.",
  },
  {
    path: "/regles/combat/conditions/empoisonne",
    title: "Empoisonné",
    description: "Désavantage aux tests actifs.",
  },
  {
    path: "/regles/combat/conditions/etourdi",
    title: "Étourdi",
    description: "Ne peut utiliser sa réaction.",
  },
  {
    path: "/regles/combat/conditions/incapable",
    title: "Incapable",
    description: "Ne peut effectuer aucune action, ni action libre ou réaction.",
  },
  {
    path: "/regles/combat/conditions/invisible",
    title: "Invisible",
    description: "Être dissimulé magiquement et impacts sur les attaques.",
  },
  {
    path: "/regles/combat/conditions/renverse",
    title: "Renversé",
    description: "Déplacements limités et impacts sur les attaques.",
  },
];

useSeo({
  title,
  description: "🚧",
});
</script>
