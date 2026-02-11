<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Les divinités appartenant à ce domaine s’intéressent à la discipline, à la philosophie, à la justice et à la paix. Leurs fervents sont associés aux
      institutions législatives, aux tribunaux et à la diplomatie.
    </p>
    <p>
      Type de dégâts de l’<NuxtLink to="/regles/specialisations/pretre">Attaque divine</NuxtLink> :
      <NuxtLink to="/regles/combat/degats/types">psychique</NuxtLink>
    </p>
    <!-- Héraut de la paix (Tiers 0) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Héraut de la paix</h2>
      <div class="h5">
        <TarBadge variant="secondary">Tiers&nbsp;0</TarBadge>
      </div>
    </div>
    <p>
      Le personnage peut acquérir <NuxtLink to="/regles/talents/points">à rabais</NuxtLink> deux <NuxtLink to="/regles/talents">talents</NuxtLink> parmi la
      liste suivante : <NuxtLink to="/regles/talents/diplomatie">Diplomatie</NuxtLink>, <NuxtLink to="/regles/talents/intuition">Intuition</NuxtLink>,
      <NuxtLink to="/regles/talents/representation">Représentation</NuxtLink> et <NuxtLink to="/regles/talents/tromperie">Tromperie</NuxtLink>.
    </p>
    <!-- L’union fait la force (Tiers 1) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">L’union fait la force</h2>
      <div class="h5">
        <TarBadge variant="secondary">Tiers&nbsp;1</TarBadge>
      </div>
    </div>
    <p>
      Par une <NuxtLink to="/regles/combat/deroulement/tour">action</NuxtLink>, le personnage crée un lien unissant un nombre de créatures consentantes
      inférieur ou égal à ses <NuxtLink to="/regles/attributs/sens">Sens</NuxtLink> (minimum&nbsp;1). Ces créatures doivent se trouver à 9 mètres ou moins de sa
      position, et il peut s’inclure dans ce nombre. Ce lien dure <NuxtLink to="/regles/aventure/temps">10 minutes</NuxtLink> ou jusqu’à ce que le personnage
      réutilise cette capacité. Il peut utiliser cette capacité un nombre de fois égal à ses
      <NuxtLink to="/regles/attributs/sens">Sens</NuxtLink> (minimum&nbsp;1) et doit compléter une
      <NuxtLink to="/regles/aventure/repos/sommeil">nuit de sommeil</NuxtLink> afin de récupérer ces utilisations.
    </p>
    <p>
      Une fois par <NuxtLink to="/regles/combat/deroulement/tour">tour</NuxtLink>, lorsqu’une créature de l’union se trouve à 9 mètres ou moins d’une autre
      créature de l’union, elle peut ajouter 1d6 à un <NuxtLink to="/regles/competences/tests">test</NuxtLink>. Également, lorsque le personnage
      <NuxtLink to="/regles/magie/pouvoirs/canalisation">canalise</NuxtLink> un <NuxtLink to="/regles/magie/pouvoirs">pouvoir</NuxtLink> ciblant une créature de
      l’union, celle-ci peut effectuer une <NuxtLink to="/regles/combat/attaque/melee">attaque de mêlée</NuxtLink> en
      <NuxtLink to="/regles/combat/deroulement/tour">réaction</NuxtLink> contre une créature qu’elle peut
      <NuxtLink to="/regles/aventure/environnement/vision">voir</NuxtLink>.
    </p>
    <!-- Exigence (Pouvoir divin) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Exigence</h2>
      <div class="h5">
        <TarBadge variant="secondary">Pouvoir&nbsp;divin</TarBadge>
      </div>
    </div>
    <p>
      Par une <NuxtLink to="/regles/combat/deroulement/tour">action</NuxtLink>, le personnage présente son
      <NuxtLink to="/regles/equipement/general">symbole divin</NuxtLink> en récitant une prière à la Loi. Jusqu’à la fin de son tour, il peut toucher en
      <NuxtLink to="/regles/combat/deroulement/tour">action libre</NuxtLink> chaque créature participant au lien d’union une fois afin de la
      <NuxtLink to="/regles/combat/degats/soins">soigner</NuxtLink> de 1d6 points de
      <NuxtLink to="/regles/statistiques/vitalite">Vitalité</NuxtLink> additionnés à la moitié de sa
      <NuxtLink to="/regles/statistiques/puissance">Puissance</NuxtLink>.
    </p>
    <p>
      Il peut également désigner toutes les créatures de son choix qui peuvent le <NuxtLink to="/regles/aventure/environnement/vision">voir</NuxtLink> ou
      l’entendre situées à 9 mètres ou moins de sa position et effectue un <NuxtLink to="/regles/competences/tests">test</NuxtLink> d’<NuxtLink
        to="/regles/competences/occultisme"
        >Occultisme</NuxtLink
      >. Chaque créature effectue un <NuxtLink to="/regles/competences/tests/sauvegarde">jet de sauvegarde</NuxtLink> de
      <NuxtLink to="/regles/competences/discipline">Discipline</NuxtLink> de <NuxtLink to="/regles/competences/tests/difficulte">difficulté</NuxtLink> égale au
      résultat du test. En cas d’échec, une créature est <NuxtLink to="/regles/combat/conditions/charme">charmée</NuxtLink> par le personnage jusqu’à la fin du
      prochain <NuxtLink to="/regles/combat/deroulement/tour">tour</NuxtLink> du personnage, ou jusqu’à ce qu’elle soit
      <NuxtLink to="/regles/combat/degats">blessée</NuxtLink>, et le personnage peut lui exiger en action libre de
      <NuxtLink to="/regles/combat/activites/lacher">lâcher</NuxtLink> immédiatement les objets qu’elle tient.
    </p>
    <!-- Figure d’autorité (Tiers 2) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Figure d’autorité</h2>
      <div class="h5">
        <TarBadge variant="secondary">Tiers&nbsp;2</TarBadge>
      </div>
    </div>
    <p>
      Le personnage peut utiliser son <NuxtLink to="/regles/specialisations/clerc">pouvoir divin</NuxtLink> afin de
      <NuxtLink to="/regles/magie/pouvoirs/canalisation">canaliser</NuxtLink> un <NuxtLink to="/regles/magie/pouvoirs">pouvoir</NuxtLink> contraignant une ou
      plusieurs créatures à agir d’une certaine manière et dont l’<NuxtLink to="/regles/magie/parametres/incantation">incantation</NuxtLink> est de
      deux&nbsp;<NuxtLink to="/regles/combat/deroulement/tour">actions</NuxtLink>. Lorsqu’il en fait ainsi, il peut
      <NuxtLink to="/regles/competences/tests/faire-10">Faire 10</NuxtLink> au <NuxtLink to="/regles/competences/tests">test</NuxtLink> d’<NuxtLink
        to="/regles/competences/occultisme"
        >Occultisme</NuxtLink
      >, ne dépense que la moitié des points d’<NuxtLink to="/regles/statistiques/energie">Énergie</NuxtLink>, et canalise le pouvoir par une seule
      <NuxtLink to="/regles/combat/deroulement/tour">action</NuxtLink>.
    </p>
    <p>
      Également, lorsqu’une créature participant au lien d’union est sur le point d’être <NuxtLink to="/regles/combat/degats">blessée</NuxtLink>, une autre
      créature participant au lien d’union et située à 9 mètres ou moins de sa position peut la protéger s’il y a un espace adjacent
      <NuxtLink to="/regles/aventure/mouvement/espace-occupe">inoccupé</NuxtLink>. La seconde créature se téléporte en
      <NuxtLink to="/regles/combat/deroulement/tour">réaction</NuxtLink> à la position de la première créature et reçoit tous les points de dégâts, tandis que
      la première créature est éjectée dans l’espace inoccupé en position <NuxtLink to="/regles/combat/conditions/renverse">renversée</NuxtLink>.
    </p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Annexes", to: "/regles/annexes" },
  { text: "Domaines divins", to: "/regles/domaines/divins" },
];
const title: string = "Ordre";

useSeo({
  title,
  description: "Découvrez le domaine divin de l’Ordre, axé sur la discipline, la justice, la paix et la force du collectif.",
});
</script>
