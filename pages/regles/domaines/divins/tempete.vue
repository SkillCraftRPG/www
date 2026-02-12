<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Les divinités appartenant à ce domaine s’intéressent aux cieux, aux mers, aux tempêtes et aux catastrophes naturelles tels les tremblements de terre. On
      leur attribue la responsabilité du climat et de la météo.
    </p>
    <p>
      Type de dégâts de l’<NuxtLink to="/regles/specialisations/pretre">Attaque divine</NuxtLink> : <NuxtLink to="/regles/combat/degats/types">foudre</NuxtLink>
    </p>
    <!-- Guerrier agité (Tiers 0) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Guerrier agité</h2>
      <div class="h5">
        <TarBadge variant="secondary">Tiers&nbsp;0</TarBadge>
      </div>
    </div>
    <p>
      Le personnage peut apprendre <NuxtLink to="/regles/talents/points">à rabais</NuxtLink> les talents
      <NuxtLink to="/regles/talents/elementarisme">Élémentarisme</NuxtLink> et
      <NuxtLink to="/regles/talents/combinaison-elementaire">Combinaison élémentaire</NuxtLink>.
    </p>
    <!-- Furie de la tempête (Tiers 1) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Furie de la tempête</h2>
      <div class="h5">
        <TarBadge variant="secondary">Tiers&nbsp;1</TarBadge>
      </div>
    </div>
    <p>
      Lorsque le personnage est victime d’une <NuxtLink to="/regles/combat/attaque/melee">attaque de mêlée</NuxtLink>, en
      <NuxtLink to="/regles/combat/deroulement/tour">réaction</NuxtLink>, il peut électrocuter l’attaquant ou émettre un son percutant en sa direction. Il
      effectue un <NuxtLink to="/regles/competences/tests">test</NuxtLink> d’<NuxtLink to="/regles/competences/occultisme">Occultisme</NuxtLink>, et la créature
      effectue un <NuxtLink to="/regles/competences/tests/sauvegarde">jet de sauvegarde</NuxtLink> d’<NuxtLink to="/regles/competences/acrobaties"
        >Acrobaties</NuxtLink
      >
      de <NuxtLink to="/regles/competences/tests/difficulte">difficulté</NuxtLink> égale au résultat du test. En cas d’échec, la cible reçoit
      <NuxtLink to="/regles/statistiques/puissance">Puissance</NuxtLink>&nbsp;+&nbsp;<NuxtLink to="/regles/combat/degats/jet">1d8 points de dégâts</NuxtLink> de
      <NuxtLink to="/regles/combat/degats/types">foudre</NuxtLink> ou de <NuxtLink to="/regles/combat/degats/types">tonnerre</NuxtLink>, au choix du personnage,
      ou seulement la moitié en cas de réussite. Le personnage peut utiliser cette capacité un nombre de fois égal à ses
      <NuxtLink to="/regles/attributs/sens">Sens</NuxtLink> (minimum&nbsp;1) et doit compléter une
      <NuxtLink to="/regles/aventure/repos/sommeil">nuit de sommeil</NuxtLink> afin de récupérer ces utilisations.
    </p>
    <!-- Courroux destructif (Pouvoir divin) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Courroux destructif</h2>
      <div class="h5">
        <TarBadge variant="secondary">Pouvoir&nbsp;divin</TarBadge>
      </div>
    </div>
    <p>
      Lorsque le personnage inflige des <NuxtLink to="/regles/combat/degats">points de dégâts</NuxtLink> de
      <NuxtLink to="/regles/combat/degats/types">foudre</NuxtLink> ou de <NuxtLink to="/regles/combat/degats/types">tonnerre</NuxtLink>, il peut utiliser son
      pouvoir divin en <NuxtLink to="/regles/combat/deroulement/tour">action libre</NuxtLink> s’il porte son
      <NuxtLink to="/regles/equipement/general">symbole divin</NuxtLink> afin de remplacer les
      <NuxtLink to="/regles/combat/degats/jet">dés de dégâts</NuxtLink> par leur valeur maximale.
    </p>
    <!-- Frappe tonitruante (Tiers 2) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Frappe tonitruante</h2>
      <div class="h5">
        <TarBadge variant="secondary">Tiers&nbsp;2</TarBadge>
      </div>
    </div>
    <p>
      Lorsque le personnage inflige des <NuxtLink to="/regles/combat/degats">points de dégâts</NuxtLink> de
      <NuxtLink to="/regles/combat/degats/types">foudre</NuxtLink> ou de <NuxtLink to="/regles/combat/degats/types">tonnerre</NuxtLink> à une créature de
      <NuxtLink to="/regles/especes/taille">taille</NuxtLink> inférieure à la sienne, ou supérieure d’une seule catégorie, il peut la repousser de
      3&nbsp;mètres.
    </p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Annexes", to: "/regles/annexes" },
  { text: "Domaines divins", to: "/regles/domaines/divins" },
];
const title: string = "Tempête";

useSeo({
  title,
  description: "Découvrez le domaine divin de la Tempête, dédié aux cieux et aux cataclysmes, offrant foudre, ripostes électriques et puissance destructrice.",
});

// TODO(fpion): Furie de la tempête, 2 hyperliens collés
</script>
