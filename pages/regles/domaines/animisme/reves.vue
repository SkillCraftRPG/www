<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Les esprits appartenant à ce domaine sont apparentés aux fées et à leur dimension obscure, mystérieuse et magie. Les animistes s’identifiant à ce domaine
      peuvent canaliser l’énergie de cette dimension, ce qui leur confère des pouvoirs similaires à ceux des fées.
    </p>
    <!-- Aptitudes féériques (Tiers 0) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Aptitudes féériques</h2>
      <div class="h5">
        <TarBadge variant="secondary">Tiers&nbsp;0</TarBadge>
      </div>
    </div>
    <p>
      Le personnage acquiert gratuitement le pouvoir <NuxtLink to="/regles/magie/pouvoirs/habiletes-feeriques">Habiletés féériques</NuxtLink>. Lorsqu’il
      <NuxtLink to="/regles/magie/pouvoirs/canalisation">canalise</NuxtLink> ce <NuxtLink to="/regles/magie/pouvoirs">pouvoir</NuxtLink>, il peut
      <NuxtLink to="/regles/competences/tests/faire-20">faire 20</NuxtLink> au <NuxtLink to="/regles/competences/tests">test</NuxtLink> d’<NuxtLink
        to="/regles/competences/occultisme"
        >Occultisme</NuxtLink
      >
      et ne <NuxtLink to="/regles/magie/pouvoirs/energie">dépense</NuxtLink> que la moitié des points d’<NuxtLink to="/regles/statistiques/energie"
        >Énergie</NuxtLink
      >.
    </p>
    <!-- Baume féérique (Tiers 1) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Baume féérique</h2>
      <div class="h5">
        <TarBadge variant="secondary">Tiers&nbsp;1</TarBadge>
      </div>
    </div>
    <p>
      Une fois par <NuxtLink to="/regles/combat/deroulement/tour">tour</NuxtLink>, par une <NuxtLink to="/regles/combat/deroulement/tour">action</NuxtLink>, le
      personnage peut <NuxtLink to="/regles/combat/degats/soins">soigner</NuxtLink> une créature qu’il peut
      <NuxtLink to="/regles/aventure/environnement/vision">voir</NuxtLink> et située à 36 mètres ou moins de sa position. Il dépense un nombre de points
      d’<NuxtLink to="/regles/statistiques/energie">Énergie</NuxtLink> inférieur ou égal à la moitié de son
      <NuxtLink to="/regles/personnages/progression/niveau">niveau</NuxtLink> (arrondi à la hausse), et la cible récupère un nombre égal de points de
      <NuxtLink to="/regles/statistiques/vitalite">Vitalité</NuxtLink>. La cible se voit également conférer un nombre de points de Vitalité
      <NuxtLink to="/regles/combat/degats/temporaire">temporaires</NuxtLink> égal à la <NuxtLink to="/regles/statistiques/puissance">Puissance</NuxtLink> du
      personnage.
    </p>
    <!-- Foyer des ombres (Tiers 2) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Foyer des ombres</h2>
      <div class="h5">
        <TarBadge variant="secondary">Tiers&nbsp;2</TarBadge>
      </div>
    </div>
    <p>
      Au début d’un <NuxtLink to="/regles/aventure/repos">repos</NuxtLink>, le personnage peut toucher un point dans l’<NuxtLink
        to="/regles/aventure/mouvement/espace-occupe"
        >espace</NuxtLink
      >
      et faire apparaître une sphère de magie <NuxtLink to="/regles/combat/conditions/invisible">invisible</NuxtLink> de 9 mètres de rayon centrée sur ce point.
      La sphère procure un <NuxtLink to="/regles/combat/attaque/abri">abri total</NuxtLink>, ne laisse pas sortir la
      <NuxtLink to="/regles/aventure/environnement/vision">lueur</NuxtLink> des flammes à l’intérieur, et confère un bonus (+5) aux
      <NuxtLink to="/regles/competences/tests">tests</NuxtLink> de <NuxtLink to="/regles/competences/furtivite">Furtivité</NuxtLink> et de
      <NuxtLink to="/regles/competences/perception">Perception</NuxtLink> des créatures se trouvant à l’intérieur. La sphère disparaît si le personnage quitte
      la zone, ou s’il la fait disparaître en <NuxtLink to="/regles/combat/deroulement/tour">action libre</NuxtLink>.
    </p>
    <!-- Chemins dissimulés (Tiers 3) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Chemins dissimulés</h2>
      <div class="h5">
        <TarBadge variant="secondary">Tiers&nbsp;3</TarBadge>
      </div>
    </div>
    <p>
      Une fois par <NuxtLink to="/regles/combat/deroulement/tour">tour</NuxtLink>, par une <NuxtLink to="/regles/combat/deroulement/tour">action</NuxtLink>, le
      personnage peut se téléporter dans un <NuxtLink to="/regles/aventure/mouvement/espace-occupe">espace inoccupé</NuxtLink> qu’il peut
      <NuxtLink to="/regles/aventure/environnement/vision">voir</NuxtLink> et situé à 18 mètres ou moins de sa position. Alternativement, il peut toucher une
      créature consentante et la téléporter dans un espace inoccupé qu’il peut voir et situé à 9 mètres ou moins de sa position. Il peut utiliser ces capacités
      un nombre de fois égal à ses <NuxtLink to="/regles/attributs/sens">Sens</NuxtLink> (minimum&nbsp;1) et doit compléter une
      <NuxtLink to="/regles/aventure/repos/sommeil">nuit de sommeil</NuxtLink> afin de récupérer ces utilisations.
    </p>
    <!-- Marcheur de rêves (Tiers 3) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Marcheur de rêves</h2>
      <div class="h5">
        <TarBadge variant="secondary">Tiers&nbsp;3</TarBadge>
      </div>
    </div>
    <p>
      Lorsque le personnage complète une <NuxtLink to="/regles/aventure/repos/halte">halte</NuxtLink>, il peut utiliser une des capacités suivantes équivalent à
      un <NuxtLink to="/regles/magie/pouvoirs">pouvoir</NuxtLink> en <NuxtLink to="/regles/competences/tests/faire-20">faisant 20</NuxtLink> au
      <NuxtLink to="/regles/competences/tests">test</NuxtLink> d’<NuxtLink to="/regles/competences/occultisme">Occultisme</NuxtLink>, sans
      <NuxtLink to="/regles/magie/pouvoirs/energie">dépense</NuxtLink> de point d’<NuxtLink to="/regles/statistiques/energie">Énergie</NuxtLink>, et sans
      nécessiter de composante <NuxtLink to="/regles/magie/parametres/composantes">Focus</NuxtLink> ni
      <NuxtLink to="/regles/magie/parametres/composantes">Matériel</NuxtLink>. Il doit compléter une
      <NuxtLink to="/regles/aventure/repos/sommeil">nuit de sommeil</NuxtLink> afin de réutiliser cette capacité.
    </p>
    <ul>
      <li><i>Espionnage.</i> <NuxtLink to="/regles/magie/pouvoirs/clairvoyance">Clairvoyance</NuxtLink> au niveau 5.</li>
      <li><i>Rêve.</i> <NuxtLink to="/regles/magie/pouvoirs/songe">Songe</NuxtLink> au niveau 5, le personnage est obligatoirement le messager.</li>
      <li>
        <i>Voyage.</i> <NuxtLink to="/regles/magie/pouvoirs/porte-dimensionnelle">Porte dimensionnelle</NuxtLink> au niveau 5. Plutôt que d’ouvrir un portail
        vers un cercle de téléportation, cette capacité ouvre un portail vers un emplacement dans la dimension actuelle où le personnage a déjà complété une
        nuit de sommeil. Le personnage doit avoir complété une nuit de sommeil dans la dimension où il se trouve actuellement afin d’utiliser cette capacité.
      </li>
    </ul>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Annexes", to: "/regles/annexes" },
  { text: "Domaines d’animisme", to: "/regles/domaines/animisme" },
];
const title: string = "Rêves";

useSeo({
  title,
  description:
    "Découvrez le domaine d’animisme des Rêves, où magie féérique, ombres protectrices et voyages oniriques ouvrent l’accès à une dimension mystérieuse.",
});
</script>
