<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Les divinités appartenant à ce domaine s’intéressent à la violence et au combat, aux conflits armés, parfois à la cruauté, souvent au courage. Ses
      disciples sont bien souvent de grands guerriers.
    </p>
    <p>
      Type de dégâts de l’<NuxtLink to="/regles/specialisations/pretre">Attaque divine</NuxtLink> :
      <NuxtLink to="/regles/combat/degats/types">tonnerre</NuxtLink>
    </p>
    <!-- Farouche guerrier (Tiers 0) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Farouche guerrier</h2>
      <div class="h5">
        <TarBadge variant="secondary">Tiers&nbsp;0</TarBadge>
      </div>
    </div>
    <p>
      Le personnage peut acquérir <NuxtLink to="/regles/talents/points">à rabais</NuxtLink> les talents <NuxtLink to="/regles/talents/melee">Mêlée</NuxtLink> et
      <NuxtLink to="/regles/talents/formation-martiale">Formation martiale</NuxtLink>.
    </p>
    <!-- Prêtre de guerre (Tiers 1) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Prêtre de guerre</h2>
      <div class="h5">
        <TarBadge variant="secondary">Tiers&nbsp;1</TarBadge>
      </div>
    </div>
    <p>
      Lorsque le personnage effectue l’activité <NuxtLink to="/regles/combat/attaque">Attaque</NuxtLink> à son
      <NuxtLink to="/regles/combat/deroulement/tour">tour</NuxtLink>, il peut annuler la pénalité infligée par les
      <NuxtLink to="/regles/combat/attaque/multiples">attaques multiples</NuxtLink>. Il peut utiliser cette capacité un nombre de fois égal à ses
      <NuxtLink to="/regles/attributs/sens">Sens</NuxtLink> (minimum&nbsp;1) et doit compléter une
      <NuxtLink to="/regles/aventure/repos/sommeil">nuit de sommeil</NuxtLink> afin de récupérer ces utilisations.
    </p>
    <!-- Frappe guidée (Pouvoir divin) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Frappe guidée</h2>
      <div class="h5">
        <TarBadge variant="secondary">Pouvoir&nbsp;divin</TarBadge>
      </div>
    </div>
    <p>
      Lorsqu’il effectue une <NuxtLink to="/regles/combat/attaque">attaque</NuxtLink>, le personnage peut utiliser son pouvoir divin en
      <NuxtLink to="/regles/combat/deroulement/tour">action libre</NuxtLink> et présenter son symbole divin en récitant une courte prière de
      <NuxtLink to="/regles/combat">combat</NuxtLink>. Il se alors voit conférer un bonus (+10) à son <NuxtLink to="/regles/competences/tests">test</NuxtLink>.
      Il peut utiliser cette capacité après avoir jeté les <NuxtLink to="/regles/competences/tests/2d10">dés</NuxtLink>, mais avant de savoir si le test est
      réussi ou échoué.
    </p>
    <!-- Frappe glorieuse (Tiers 2) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Frappe glorieuse</h2>
      <div class="h5">
        <TarBadge variant="secondary">Tiers&nbsp;2</TarBadge>
      </div>
    </div>
    <p>
      Lorsque le personnage <NuxtLink to="/regles/aventure/environnement/vision">voit</NuxtLink> une créature alliée effectuer une
      <NuxtLink to="/regles/combat/attaque">attaque</NuxtLink>, il peut utiliser son pouvoir divin en
      <NuxtLink to="/regles/combat/deroulement/tour">réaction</NuxtLink> et présenter son symbole divin en récitant une courte prière de
      <NuxtLink to="/regles/combat">combat</NuxtLink>. La créature se voit alors conférer un bonus (+10) à son
      <NuxtLink to="/regles/competences/tests">test</NuxtLink>. Il peut utiliser cette capacité après que la créature ait jeté les
      <NuxtLink to="/regles/competences/tests/2d10">dés</NuxtLink>, mais avant de savoir si le test est réussi ou échoué.
    </p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Annexes", to: "/regles/annexes" },
  { text: "Domaines divins", to: "/regles/domaines/divins" },
];
const title: string = "Guerre";

useSeo({
  title,
  description: "Découvrez le domaine divin de la Guerre, axé sur le combat, le courage et les frappes guidées qui renforcent les attaques alliées.",
});
</script>
