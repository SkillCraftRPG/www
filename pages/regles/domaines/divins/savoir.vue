<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Les divinités appartenant à ce domaine s’intéressent à l’apprentissage et à la connaissance, et ses adeptes sont associés aux grandes universités et
      bibliothèques.
    </p>
    <p>
      Type de dégâts de l’<NuxtLink to="/regles/specialisations/pretre">Attaque divine</NuxtLink> : <NuxtLink to="/regles/combat/degats/types">acide</NuxtLink>
    </p>
    <!-- Grâce du savoir (Tiers 0) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Grâce du savoir</h2>
      <div class="h5">
        <TarBadge variant="secondary">Tiers&nbsp;0</TarBadge>
      </div>
    </div>
    <p>
      Le personnage peut acquérir <NuxtLink to="/regles/talents/points">à rabais</NuxtLink> les talents
      <NuxtLink to="/regles/talents/connaissance">Connaissance</NuxtLink> et <NuxtLink to="/regles/talents/linguistique">Linguistique</NuxtLink>.
    </p>
    <!-- Bénédiction de l’apprentissage (Tiers 1) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Bénédiction de l’apprentissage</h2>
      <div class="h5">
        <TarBadge variant="secondary">Tiers&nbsp;1</TarBadge>
      </div>
    </div>
    <p>
      Le personnage peut acquérir <NuxtLink to="/regles/talents/points">à rabais</NuxtLink> le talent
      <NuxtLink to="/regles/talents/expertise">Expertise</NuxtLink> pour la compétence <NuxtLink to="/regles/competences/connaissance">Connaissance</NuxtLink>.
      Il peut également acquérir à rabais le talent <NuxtLink to="/regles/talents/langue-supplementaire">Langue supplémentaire</NuxtLink> un nombre de fois égal
      à son <NuxtLink to="/regles/personnages/progression/tiers">tiers</NuxtLink>.
    </p>
    <!-- Savoir ancien (Pouvoir divin) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Savoir ancien</h2>
      <div class="h5">
        <TarBadge variant="secondary">Pouvoir&nbsp;divin</TarBadge>
      </div>
    </div>
    <p>
      Par une <NuxtLink to="/regles/combat/deroulement/tour">action</NuxtLink>, le personnage présente son
      <NuxtLink to="/regles/equipement/general">symbole divin</NuxtLink> et récite une prière à la mémoire collective. Il sélectionne une
      <NuxtLink to="/regles/competences/rang">compétence</NuxtLink>, des <NuxtLink to="/regles/equipement/outils">outils</NuxtLink> ou une
      <NuxtLink to="/regles/equipement/outils">trousse</NuxtLink>, un <NuxtLink to="/regles/equipement/outils/jeux">ensemble de jeu</NuxtLink> ou
      <NuxtLink to="/regles/equipement/outils/musique">instrument de musique</NuxtLink>, ou un
      <NuxtLink to="/regles/talents/connaissance">domaine de connaissance</NuxtLink>. Pendant les
      <NuxtLink to="/regles/aventure/temps">dix prochaines minutes</NuxtLink>, il est formé pour l’élément sélectionné. Si le
      <NuxtLink to="/regles/competences/rang">rang</NuxtLink> de la compétence associée est inférieur à 2&nbsp;+&nbsp;<NuxtLink
        to="/regles/personnages/progression/tiers"
        >tiers</NuxtLink
      >, alors il le remplace par ce nombre.
    </p>
    <!-- Lecture de la pensée (Tiers 2) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Lecture de la pensée</h2>
      <div class="h5">
        <TarBadge variant="secondary">Tiers&nbsp;2</TarBadge>
      </div>
    </div>
    <p>
      Par une <NuxtLink to="/regles/combat/deroulement/tour">action</NuxtLink>, le personnage désigne une créature qu’il peut
      <NuxtLink to="/regles/aventure/environnement/vision">voir</NuxtLink> située à 18 mètres ou moins de sa position et effectue un
      <NuxtLink to="/regles/competences/tests">test</NuxtLink> d’<NuxtLink to="/regles/competences/occultisme">Occultisme</NuxtLink>. La cible effectue un
      <NuxtLink to="/regles/competences/tests/sauvegarde">jet de sauvegarde</NuxtLink> de <NuxtLink to="/regles/competences/discipline">Discipline</NuxtLink>.
      En cas de réussite, le personnage ne peut réutiliser cette capacité contre la cible tant qu’il ne complète pas une
      <NuxtLink to="/regles/aventure/repos/sommeil">nuit de sommeil</NuxtLink>.
    </p>
    <p>
      En cas d’échec, le personnage peut lire les pensées de surface de la cible (ce qui occupe présentement son esprit, ses émotions actuelles et ce à quoi
      elle pense activement) pendant <NuxtLink to="/regles/aventure/temps">une minute</NuxtLink>, tant que la cible se trouve à 18 mètres ou moins de sa
      position.
    </p>
    <p>
      Pendant cette minute, si le personnage <NuxtLink to="/regles/magie/pouvoirs/canalisation">canalise</NuxtLink> le
      <NuxtLink to="/regles/magie/pouvoirs/niveau">niveau 3</NuxtLink> du pouvoir <NuxtLink to="/regles/magie/pouvoirs/coercition">Coercition</NuxtLink> contre
      la cible afin de lui suggérer un cours d’action, il <NuxtLink to="/regles/competences/tests/faire-20">fait 20</NuxtLink> au test d’Occultisme, la cible
      échoue automatiquement le jet de sauvegarde, et la <NuxtLink to="/regles/magie/pouvoirs/energie">dépense en points d’Énergie</NuxtLink> est réduite de
      moitié.
    </p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Annexes", to: "/regles/annexes" },
  { text: "Domaines divins", to: "/regles/domaines/divins" },
];
const title: string = "Savoir";

useSeo({
  title,
  description:
    "Découvrez le domaine divin du Savoir, dédié à la mémoire et à la connaissance, offrant bénédictions académiques, savoir ancien et lecture de la pensée.",
});
</script>
