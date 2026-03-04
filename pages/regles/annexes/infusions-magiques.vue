<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Les infusions magiques sont des procédés extraordinaires qui confèrent des propriétés magiques à des objets banals. Le talent
      <NuxtLink to="/regles/talents/infusions-magiques">Infusions magiques</NuxtLink> permet à un personnage d’apprendre des infusions magiques parmi la liste
      ci-dessous.
    </p>
    <p>
      À la fin d’une <NuxtLink to="/regles/aventure/repos/sommeil">nuit de sommeil</NuxtLink>, le personnage peut toucher un ou plusieurs
      <NuxtLink to="/regles/equipement">objets</NuxtLink> non magiques et dépenser 15 points d’<NuxtLink to="/regles/statistiques/energie">Énergie</NuxtLink>
      par objet afin de les imprégner d’une infusion magique. Les objets ainsi infusés deviennent <NuxtLink to="/regles/magie/artefacts">magiques</NuxtLink>.
      Certaines infusions ne sont compatibles qu’avec des objets d’un certain type, un objet ne peut être imprégné que d’une seule infusion à la fois, et une
      infusion ne peut être appliquée qu’à un seul objet à la fois. Si l’infusion requiert l’<NuxtLink to="/regles/magie/artefacts/harmonisation"
        >harmonisation</NuxtLink
      >, le personnage peut s’y harmoniser immédiatement au moment où il l’applique. Sinon, il doit respecter les règles d’harmonisation conventionnelles.
    </p>
    <p>
      Le personnage peut maintenir un nombre d’infusions égal à son <NuxtLink to="/regles/attributs/intellect">Intellect</NuxtLink> (minimum&nbsp;1). S’il
      dépasse cette limite, alors les infusions les plus anciennes prennent fin et sont remplacées par la ou les nouvelles. Les infusions durent indéfiniment,
      mais si le personnage <NuxtLink to="/regles/combat/conditions/mort">meurt</NuxtLink>, alors elles prennent fin un nombre de jours suivant sa
      <NuxtLink to="/regles/combat/mort-agonie">mort</NuxtLink> égal à son <NuxtLink to="/regles/attributs/intellect">Intellect</NuxtLink> (minimum&nbsp;1).
      Lorsqu’une infusion prend fin sur un <NuxtLink to="/regles/equipement/general/contenants">contenant</NuxtLink>, alors celui-ci déverse son contenu au sol,
      sans danger.
    </p>
    <InfusionContents />
    <InfusionTier1 />
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [{ text: "Annexes", to: "/regles/annexes" }];
const title: string = "Infusions magiques";

useSeo({
  title,
  description: "🚧",
});
</script>
