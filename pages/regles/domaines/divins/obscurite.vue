<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Les divinités appartenant à ce domaine s’intéressent à l’obscurité, aux pâles lueurs nocturnes ainsi qu’au clair de lune, au silence et à la quiétude
      apportés par la nuit et nécessaires au repos et au sommeil. Elles sont souvent associés à l’astre lunaire, et se présentent comme des protectrices contre
      les horreurs de la nuit et des ténèbres.
    </p>
    <p>
      Type de dégâts de l’<NuxtLink to="/regles/specialisations/pretre">Attaque divine</NuxtLink> : <NuxtLink to="/regles/combat/degats/types">froid</NuxtLink>
    </p>
    <!-- Grâce du vigile (Tiers 0) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Grâce du vigile</h2>
      <div class="h5">
        <TarBadge variant="secondary">Tiers&nbsp;0</TarBadge>
      </div>
    </div>
    <p>
      Le personnage peut apprendre <NuxtLink to="/regles/talents/points">à rabais</NuxtLink> les talents
      <NuxtLink to="/regles/talents/orientation">Orientation</NuxtLink> et <NuxtLink to="/regles/talents/vigilance">Vigilance</NuxtLink>. Également, il peut
      toucher une créature consentante (l’incluant) afin de lui permettre de rejouer son prochain
      <NuxtLink to="/regles/combat/deroulement/initiative">test d’Initiative</NuxtLink> et de conserver le résultat de son choix. Cette capacité prend
      immédiatement s’il la réutilise en ciblant une autre créature.
    </p>
    <!-- Yeux de la Nuit (Tiers 1) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Yeux de la Nuit</h2>
      <div class="h5">
        <TarBadge variant="secondary">Tiers&nbsp;1</TarBadge>
      </div>
    </div>
    <p>
      Le personnage acquiert une <NuxtLink to="/regles/aventure/environnement/vision">vision dans le noir</NuxtLink> à une distance de 90 mètres. Il peut
      partager cette vision pendant une <NuxtLink to="/regles/aventure/temps">heure</NuxtLink> aux créatures de son choix qu’il peut voir et situées à 3 mètres
      ou moins de sa position. Le nombre maximal de créatures qu’il peut cibler est égal à ses <NuxtLink to="/regles/attributs/sens">Sens</NuxtLink> (minimum
      1). Il doit compléter une <NuxtLink to="/regles/aventure/repos/sommeil">nuit de sommeil</NuxtLink> afin de réutiliser cette capacité.
    </p>
    <!-- Sanctuaire du crépuscule (Pouvoir divin) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Sanctuaire du crépuscule</h2>
      <div class="h5">
        <TarBadge variant="secondary">Pouvoir&nbsp;divin</TarBadge>
      </div>
    </div>
    <p>
      Le personnage présente son <NuxtLink to="/regles/equipement/general">symbole divin</NuxtLink> par une
      <NuxtLink to="/regles/combat/deroulement/tour">action</NuxtLink> et récite une prière au crépuscule. Pendant la prochaine
      <NuxtLink to="/regles/aventure/temps">minute</NuxtLink> ou jusqu’à ce qu’il devienne
      <NuxtLink to="/regles/combat/conditions/incapable">incapable</NuxtLink>, une aura de
      <NuxtLink to="/regles/aventure/environnement/vision">pénombre</NuxtLink> émane de lui dans un rayon de 9 mètres. Lorsqu’une créature termine son tour
      <NuxtLink to="/regles/combat/deroulement/tour">tour</NuxtLink> dans la zone (l’incluant), le personnage peut utiliser sa
      <NuxtLink to="/regles/combat/deroulement/tour">réaction</NuxtLink> afin de lui conférer un des effets suivants :
    </p>
    <ul>
      <li>
        Un nombre de points de <NuxtLink to="/regles/statistiques/vitalite">Vitalité</NuxtLink>{{ " "
        }}<NuxtLink to="/regles/combat/degats/temporaire">temporaires</NuxtLink> égal à 1d10 additionné au double de sa
        <NuxtLink to="/regles/statistiques/puissance">Puissance</NuxtLink>.
      </li>
      <li>
        Il met fin à un <NuxtLink to="/regles/combat/conditions/charme">charme</NuxtLink> ou à un effet de
        <NuxtLink to="/regles/combat/conditions/apeure">peur</NuxtLink> affligeant cette créature.
      </li>
    </ul>
    <!-- Ailes de la nuit (Tiers 2) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Ailes de la nuit</h2>
      <div class="h5">
        <TarBadge variant="secondary">Tiers&nbsp;2</TarBadge>
      </div>
    </div>
    <p>
      Lorsque le personnage se trouve dans la <NuxtLink to="/regles/aventure/environnement/vision">pénombre</NuxtLink> ou dans l’<NuxtLink
        to="/regles/aventure/environnement/vision"
        >obscurité</NuxtLink
      >, il peut se conférer par une <NuxtLink to="/regles/combat/deroulement/tour">action</NuxtLink> une
      <NuxtLink to="/regles/aventure/mouvement/vitesse">vitesse</NuxtLink> de <NuxtLink to="/regles/aventure/mouvement/types">vol</NuxtLink> égale à sa vitesse
      de <NuxtLink to="/regles/aventure/mouvement/types">marche</NuxtLink> pendant <NuxtLink to="/regles/aventure/temps">une minute</NuxtLink>. Il peut utiliser
      cette capacité un nombre de fois égal à ses <NuxtLink to="/regles/attributs/sens">Sens</NuxtLink> et doit compléter une
      <NuxtLink to="/regles/aventure/repos/sommeil">nuit de sommeil</NuxtLink> afin de récupérer ces utilisations.
    </p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Annexes", to: "/regles/annexes" },
  { text: "Domaines divins", to: "/regles/domaines/divins" },
];
const title: string = "Obscurité";

useSeo({
  title,
  description: "Découvrez le domaine divin de l’Obscurité, lié au silence, au crépuscule, au repos nocturne et à une pénombre protectrice.",
});
</script>
