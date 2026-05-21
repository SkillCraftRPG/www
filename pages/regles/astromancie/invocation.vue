<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <RulesBreadcrumb active="Invocation" :parent="parent" />
    <p>
      Le cercle d’invocation rassemble les pouvoirs manipulant l’énergie autour du magicien. Cette magie peut prendre plusieurs formes : l’espace, le temps, ou
      encore les éléments, les caractéristiques d’animaux ou de plantes, les astres, la lumière ou les ténèbres.
    </p>
    <!-- Invocation contrôlée (Allégeance) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Invocation contrôlée</h2>
      <div class="h5">
        <TarBadge variant="secondary">Allégeance</TarBadge>
      </div>
    </div>
    <p>
      Lorsque le personnage <NuxtLink to="/regles/magie/pouvoirs/canalisation">canalise</NuxtLink> un
      <NuxtLink to="/regles/magie/pouvoirs">pouvoir</NuxtLink> associé au cercle d’Invocation, il peut sélectionner un nombre de créatures qu’il peut
      <NuxtLink to="/regles/aventure/environnement/vision">voir</NuxtLink> inférieur ou égal au
      <NuxtLink to="/regles/magie/pouvoirs/niveau">niveau</NuxtLink> du pouvoir. Ces créatures réussissent automatiquement le
      <NuxtLink to="/regles/competences/tests/sauvegarde">jet de sauvegarde</NuxtLink> contre le pouvoir, et elles ne reçoivent aucun
      <NuxtLink to="/regles/combat/degats">point de dégât</NuxtLink> si la réussite du jet de sauvegarde réduirait normalement de moitié les points de dégâts
      reçus.
    </p>
    <p>
      Également, lorsqu’une créature réussit le jet de sauvegarde contre un pouvoir de niveau 1 canalisé par le personnage, elle reçoit la moitié des points de
      dégâts plutôt qu’aucun, sauf si elle a été désignée tel que décrit précédemment.
    </p>
    <!-- Canalisation exagérée (Élévation) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Canalisation exagérée</h2>
      <div class="h5">
        <TarBadge variant="secondary">Élévation</TarBadge>
      </div>
    </div>
    <p>
      Lorsque le personnage <NuxtLink to="/regles/magie/pouvoirs/canalisation">canalise</NuxtLink> un
      <NuxtLink to="/regles/magie/pouvoirs">pouvoir</NuxtLink> de <NuxtLink to="/regles/personnages/progression/tiers">tiers</NuxtLink> 2 et moins infligeant
      des <NuxtLink to="/regles/combat/degats">points de dégâts</NuxtLink>, il peut remplacer les <NuxtLink to="/regles/combat/degats/jet">dés</NuxtLink> par
      leur valeur maximale.
    </p>
    <p>
      S’il réutilise cette capacité avant d’avoir complété une <NuxtLink to="/regles/aventure/repos/sommeil">nuit de sommeil</NuxtLink>, il reçoit 2d12 points
      de dégâts <NuxtLink to="/regles/combat/degats/types">nécrotiques</NuxtLink> pour chaque
      <NuxtLink to="/regles/magie/pouvoirs/niveau">niveau</NuxtLink> canalisé du pouvoir. Ce nombre de dés incrémente d’un chaque fois qu’il réutilise cette
      capacité avant d’avoir complété une nuit de sommeil. Ces dégâts ignorent la <NuxtLink to="/regles/combat/degats/efficacite">résistance</NuxtLink> et
      l’<NuxtLink to="/regles/combat/degats/efficacite">immunité</NuxtLink>.
    </p>
    <!-- Invocation supérieure (Élévation) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Invocation supérieure</h2>
      <div class="h5">
        <TarBadge variant="secondary">Élévation</TarBadge>
      </div>
    </div>
    <p>
      Lorsque le personnage <NuxtLink to="/regles/magie/pouvoirs/canalisation">canalise</NuxtLink> un
      <NuxtLink to="/regles/magie/pouvoirs">pouvoir</NuxtLink> associé au cercle d’Invocation, il peut infliger un nombre de
      <NuxtLink to="/regles/combat/degats">points de dégâts</NuxtLink> supplémentaires égal à la moitié de sa
      <NuxtLink to="/regles/statistiques/puissance">Puissance</NuxtLink> (minimum&nbsp;1).
    </p>
    <!-- TODO(fpion): Spell List -->
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/tar/breadcrumb";

const parent: Breadcrumb[] = [
  { text: "Annexes", to: "/regles/annexes" },
  { text: "Astromancie", to: "/regles/astromancie" },
];
const title: string = "Cercle d’Invocation";

useSeo({
  title,
  description: "Découvrez le cercle d’Invocation : des pouvoirs d’Astromancie pour manipuler l’énergie, les éléments, les astres, la lumière et les ténèbres.",
});
</script>
