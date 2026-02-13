<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Les esprits appartenant à ce domaine sont associés à la Lune, à la nuit et à l’obscurité. Les animistes s’identifiant à ce domaine se rencontrent lors de
      la pleine lune. Ils sont souvent des ermites vivant en profonde nature.
    </p>
    <!-- Forme bestiale (Tiers 0) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Forme bestiale</h2>
      <div class="h5">
        <TarBadge variant="secondary">Tiers&nbsp;0</TarBadge>
      </div>
    </div>
    <p>
      Le personnage acquiert gratuitement le talent <NuxtLink to="/regles/talents/arts-martiaux">Arts martiaux</NuxtLink>. Lorsqu’il
      <NuxtLink to="/regles/combat/attaque/mains-nues">combat à mains nues</NuxtLink>, il peut donner momentanément des propriétés animales à son corps. Ces
      propriétés peuvent être des serres ou des griffes (<NuxtLink to="/regles/combat/degats/types">tranchant</NuxtLink>), des cornes ou des crocs (<NuxtLink
        to="/regles/combat/degats/types"
        >perforant</NuxtLink
      >), une carapace ou des écailles dures (<NuxtLink to="/regles/combat/degats/types">contondant</NuxtLink>), ou tout autre propriété similaire. Ces
      propriétés lui permettent d’infliger des <NuxtLink to="/regles/combat/degats/letalite">dégâts létaux</NuxtLink>. Une fois par
      <NuxtLink to="/regles/combat/deroulement/tour">tour</NuxtLink>, il peut dépenser 5 points d’<NuxtLink to="/regles/statistiques/energie">Énergie</NuxtLink>
      en <NuxtLink to="/regles/combat/deroulement/tour">action libre</NuxtLink> avant d’effectuer cette attaque afin d’infliger des
      <NuxtLink to="/regles/combat/degats">points de dégâts</NuxtLink> d’<NuxtLink to="/regles/combat/degats/types">acide</NuxtLink> et de remplacer sa
      <NuxtLink to="/regles/statistiques/force">Force</NuxtLink> par sa <NuxtLink to="/regles/statistiques/puissance">Puissance</NuxtLink>.
    </p>
    <!-- Forme sauvage supérieure (Tiers 1) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Forme sauvage supérieure</h2>
      <div class="h5">
        <TarBadge variant="secondary">Tiers&nbsp;1</TarBadge>
      </div>
    </div>
    <p>
      Le personnage peut <NuxtLink to="/regles/specialisations/animiste">assumer la forme</NuxtLink> d’une bête de niveau maximal égal à son
      <NuxtLink to="/regles/personnages/progression/niveau">niveau</NuxtLink> divisé par 15, tronqué (minimum&nbsp;1). Lorsqu’il assume une forme sauvage, une
      fois par <NuxtLink to="/regles/combat/deroulement/tour">tour</NuxtLink>, par une <NuxtLink to="/regles/combat/deroulement/tour">action</NuxtLink>, il peut
      se <NuxtLink to="/regles/combat/degats/soins">soigner</NuxtLink> d’un nombre de d10 égal à un
      <NuxtLink to="/regles/magie/pouvoirs/niveau">niveau</NuxtLink> de <NuxtLink to="/regles/magie/pouvoirs">pouvoir</NuxtLink> qu’il peut
      <NuxtLink to="/regles/magie/pouvoirs/canalisation">canaliser</NuxtLink>. Il dépense un nombre de points d’<NuxtLink to="/regles/statistiques/energie"
        >Énergie</NuxtLink
      >
      égal au nombre de points de <NuxtLink to="/regles/statistiques/vitalite">Vitalité</NuxtLink> récupérés.
    </p>
    <!-- Frappe sauvage (Tiers 2) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Frappe sauvage</h2>
      <div class="h5">
        <TarBadge variant="secondary">Tiers&nbsp;2</TarBadge>
      </div>
    </div>
    <p>
      Lorsque le personnage assume une <NuxtLink to="/regles/specialisations/animiste">forme sauvage</NuxtLink>, ses
      <NuxtLink to="/regles/combat/attaque">attaques physiques</NuxtLink> infligent des
      <NuxtLink to="/regles/combat/degats/types">points de dégâts magiques</NuxtLink>.
    </p>
    <!-- Forme élémentaire (Tiers 3) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Forme élémentaire</h2>
      <div class="h5">
        <TarBadge variant="secondary">Tiers&nbsp;3</TarBadge>
      </div>
    </div>
    <p>
      Le personnage peut utiliser deux utilisations de sa <NuxtLink to="/regles/specialisations/animiste">forme sauvage</NuxtLink> afin de prendre la forme d’un
      <NuxtLink to="/regles/elementarisme/capacites">élémentaire</NuxtLink> d’air, d’eau, de feu ou de terre.
    </p>
    <!-- Mille-formes (Tiers 3) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Mille-formes</h2>
      <div class="h5">
        <TarBadge variant="secondary">Tiers&nbsp;3</TarBadge>
      </div>
    </div>
    <p>
      Le personnage acquiert gratuitement le pouvoir <NuxtLink to="/regles/magie/pouvoirs/polymorphisme">Polymorphisme</NuxtLink>. Il peut
      <NuxtLink to="/regles/magie/pouvoirs/canalisation">canaliser</NuxtLink> le <NuxtLink to="/regles/magie/pouvoirs/niveau">niveau 2</NuxtLink> de ce
      <NuxtLink to="/regles/magie/pouvoirs">pouvoir</NuxtLink> sans dépenser de point d’<NuxtLink to="/regles/statistiques/energie">Énergie</NuxtLink>, et
      <NuxtLink to="/regles/competences/tests/faire-20">fait 20</NuxtLink> au <NuxtLink to="/regles/competences/tests">test</NuxtLink> d’<NuxtLink
        to="/regles/competences/occultisme"
        >Occultisme</NuxtLink
      >.
    </p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Annexes", to: "/regles/annexes" },
  { text: "Domaines d’animisme", to: "/regles/domaines/animisme" },
];
const title: string = "Lune";

useSeo({
  title,
  description: "Découvrez le domaine d’animisme de la Lune, où formes sauvages, bestialité et pouvoirs nocturnes lient l’ermite à la nuit et à l’obscurité.",
});
</script>
