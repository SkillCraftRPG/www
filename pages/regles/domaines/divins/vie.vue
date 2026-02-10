<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Les divinités appartenant à ce domaine s’intéressent à la vie, la santé et la guérison. Leurs disciples protègent et viennent en aide à ceux dans le
      besoin et s’opposent aux forces de la mort et aux morts-vivants.
    </p>
    <p>
      Type de dégâts de l’<NuxtLink to="/regles/specialisations/pretre">Attaque divine</NuxtLink> :
      <NuxtLink to="/regles/combat/degats/types">radiant</NuxtLink>
    </p>
    <!-- Protecteur de la vie (Tiers 0) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Protecteur de la vie</h2>
      <div class="h5">
        <TarBadge variant="secondary">Tiers&nbsp;0</TarBadge>
      </div>
    </div>
    <p>
      Le personnage peut acquérir <NuxtLink>à rabais</NuxtLink> les talents <NuxtLink to="/regles/talents/medecine">Médecine</NuxtLink> et
      <NuxtLink to="/regles/talents/resistance">Résistance</NuxtLink>.
    </p>
    <!-- Disciple de la vie (Tiers 1) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Disciple de la vie</h2>
      <div class="h5">
        <TarBadge variant="secondary">Tiers&nbsp;1</TarBadge>
      </div>
    </div>
    <p>
      Lorsque le personnage <NuxtLink to="/regles/magie/pouvoirs/canalisation">canalise</NuxtLink> un pouvoir
      <NuxtLink to="/regles/combat/degats/soins">soignant</NuxtLink> une créature, celle-ci récupère un nombre de points de
      <NuxtLink to="/regles/statistiques/vitalite">Vitalité</NuxtLink> supplémentaires égal aux <NuxtLink to="/regles/attributs/sens">Sens</NuxtLink> du
      personnage (minimum&nbsp;1) additionnés au <NuxtLink to="/regles/magie/pouvoirs/niveau">niveau</NuxtLink> du
      <NuxtLink to="/regles/magie/pouvoirs">pouvoir</NuxtLink>.
    </p>
    <!-- Rétablissement (Pouvoir divin) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Rétablissement</h2>
      <div class="h5">
        <TarBadge variant="secondary">Pouvoir&nbsp;divin</TarBadge>
      </div>
    </div>
    <p>
      Par une <NuxtLink to="/regles/combat/deroulement/tour">action</NuxtLink>, le personnage présente son symbole divin et récite une prière de guérison. Il
      peut prodiguer des <NuxtLink to="/regles/combat/degats/soins">soins</NuxtLink> d’un nombre de points de
      <NuxtLink to="/regles/statistiques/vitalite">Vitalité</NuxtLink> égal à son <NuxtLink to="/regles/personnages/progression/niveau">niveau</NuxtLink>. Il
      désigne toute créature de son choix située à 9 mètres ou moins de sa position et répartit les soins entre celles-ci. Ces soins ne peuvent faire remonter
      la Vitalité actuelle d’une créature à une valeur supérieure à la moitié de sa Vitalité maximale. Les morts-vivants et constructions ne sont pas affectés
      par cette capacité.
    </p>
    <!-- Faveur du guérisseur (Tiers 2) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Faveur du guérisseur</h2>
      <div class="h5">
        <TarBadge variant="secondary">Tiers&nbsp;2</TarBadge>
      </div>
    </div>
    <p>
      Lorsqu’il <NuxtLink to="/regles/magie/pouvoirs/canalisation">canalise</NuxtLink> un pouvoir
      <NuxtLink to="/regles/combat/degats/soins">soignant</NuxtLink> une créature, le personnage récupère un nombre de points de
      <NuxtLink to="/regles/statistiques/vitalite">Vitalité</NuxtLink> supplémentaires égal à ses
      <NuxtLink to="/regles/attributs/sens">Sens</NuxtLink> (minimum&nbsp;1) additionnés au <NuxtLink to="/regles/magie/pouvoirs/niveau">niveau</NuxtLink> du
      <NuxtLink to="/regles/magie/pouvoirs">pouvoir</NuxtLink>.
    </p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Annexes", to: "/regles/annexes" },
  { text: "Domaines divins", to: "/regles/domaines/divins" },
];
const title: string = "Vie";

useSeo({
  title,
  description: "Découvrez le domaine de la Vie, dédié à la guérison, à la protection et à la vitalité, opposé aux morts-vivants et aux forces de la mort.",
});
</script>
