<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Les esprits appartenant à ce domaine sont associés aux forêts, ainsi qu’à la faune et à la flore de ces milieux naturels. Les animistes de ce domaine sont
      des protecteurs des forêts, et ils se rencontrent loin de la civilisation, dans des bosquets et clairières naturels.
    </p>
    <!-- Parole des bois (Tiers 0) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Parole des bois</h2>
      <div class="h5">
        <TarBadge variant="secondary">Tiers&nbsp;0</TarBadge>
      </div>
    </div>
    <p>
      Le personnage apprend la langue <NuxtLink to="/regles/langues/sylvestre">Sylvestre</NuxtLink>. De plus, les bêtes peuvent comprendre sa parole, et il peut
      déchiffrer leurs bruits et mouvements. Il peut comprendre leurs émotions et tisser des liens avec des événements récents vécus par ces bêtes.
    </p>
    <!-- Totem (Tiers 1) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Totem</h2>
      <div class="h5">
        <TarBadge variant="secondary">Tiers&nbsp;1</TarBadge>
      </div>
    </div>
    <p>
      Par une <NuxtLink to="/regles/combat/deroulement/tour">action</NuxtLink>, le personnage invoque un esprit animal à un point qu’il peut
      <NuxtLink to="/regles/aventure/environnement/vision">voir</NuxtLink> et situé à 18 mètres ou moins de sa position. L’esprit prend l’apparence spectrale de
      l’animal sélectionné, mais il n’est pas une créature, ni un objet. Il est intangible, et il est impossible d’interagir avec.
    </p>
    <p>
      L’esprit disparaît après <NuxtLink to="/regles/aventure/temps">une minute</NuxtLink>. Le personnage doit faire
      <NuxtLink to="/regles/aventure/repos/halte">halte</NuxtLink> ou compléter une
      <NuxtLink to="/regles/aventure/repos/sommeil">nuit de sommeil</NuxtLink> afin de réutiliser cette capacité.
    </p>
    <p>
      Une fois par <NuxtLink to="/regles/combat/deroulement/tour">tour</NuxtLink>, par une action, le personnage peut déplacer l’esprit d’une distance maximale
      de 18 mètres. Une aura de 9 mètres de rayon émane centrée sur la position de l’esprit.
    </p>
    <ul>
      <li>
        <strong>Faucon.</strong> L’aura confère au personnage et à ses alliés l’<NuxtLink to="/regles/competences/tests/avantage-desavantage"
          >avantage</NuxtLink
        >
        à leurs <NuxtLink to="/regles/competences/tests">tests</NuxtLink> de <NuxtLink to="/regles/competences/perception">Perception</NuxtLink>. De plus,
        lorsque le personnage ou une créature alliée dans l’aura est ciblé par une <NuxtLink to="/regles/combat/attaque">attaque</NuxtLink>, le personnage peut
        utiliser sa <NuxtLink to="/regles/combat/deroulement/tour">réaction</NuxtLink> afin d’affliger du
        <NuxtLink to="/regles/competences/tests/avantage-desavantage">désavantage</NuxtLink> le test de cette attaque.
      </li>
      <li>
        <strong>Licorne.</strong> L’aura confère au personnage et à ses alliés l’avantage aux tests effectués afin de détecter la présence d’une créature se
        trouvant dans l’aura. De plus, lorsque le personnage <NuxtLink to="/regles/magie/pouvoirs/canalisation">canalise</NuxtLink> un
        <NuxtLink to="/regles/magie/pouvoirs">pouvoir</NuxtLink> et qu’une créature <NuxtLink to="/regles/combat/degats/soins">récupère</NuxtLink> des points de
        <NuxtLink to="/regles/statistiques/vitalite">Vitalité</NuxtLink> en raison de ce pouvoir, alors le personnage et toute créature alliée à l’intérieur de
        l’aura récupèrent un nombre de points de Vitalité égal à la <NuxtLink to="/regles/statistiques/puissance">Puissance</NuxtLink> du personnage.
      </li>
      <li>
        <strong>Ours.</strong> L’aura confère au personnage et à ses alliés l’avantage à leurs tests d’<NuxtLink to="/regles/competences/athletisme"
          >Athlétisme</NuxtLink
        >, de <NuxtLink to="/regles/competences/melee">Mêlée</NuxtLink> et de <NuxtLink to="/regles/competences/resistance">Résistance</NuxtLink>. De plus, le
        personnage et ses alliés se voient conférer un nombre de points de Vitalité <NuxtLink to="/regles/combat/degats/temporaire">temporaires</NuxtLink> égal
        à la Puissance du personnage.
      </li>
    </ul>
    <!-- Puissantes invocations (Tiers 2) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Puissantes invocations</h2>
      <div class="h5">
        <TarBadge variant="secondary">Tiers&nbsp;2</TarBadge>
      </div>
    </div>
    <p>
      Lorsque le personnage invoque une créature, celle-ci possède un nombre de points de
      <NuxtLink to="/regles/statistiques/vitalite">Vitalité</NuxtLink> supplémentaires égal à la
      <NuxtLink to="/regles/statistiques/puissance">Puissance</NuxtLink> du personnage. Également, les
      <NuxtLink to="/regles/combat/attaque">attaques</NuxtLink> de cette créature sont considérées
      <NuxtLink to="/regles/combat/degats/types">magiques</NuxtLink> lorsque la cible est
      <NuxtLink to="/regles/combat/degats/efficacite">résistante</NuxtLink> ou <NuxtLink to="/regles/combat/degats/efficacite">immunisée</NuxtLink> aux
      <NuxtLink to="/regles/combat/degats/types">dégâts physiques</NuxtLink>.
    </p>
    <!-- Esprit protecteur (Tiers 3) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Esprit protecteur</h2>
      <div class="h5">
        <TarBadge variant="secondary">Tiers&nbsp;3</TarBadge>
      </div>
    </div>
    <p>
      Lorsqu’une créature invoquée par le personnage termine son <NuxtLink to="/regles/combat/deroulement/tour">tour</NuxtLink> dans l’aura du
      <strong>Totem</strong>, celle-ci récupère un nombre de points de <NuxtLink to="/regles/statistiques/vitalite">Vitalité</NuxtLink> égal à la moitié de la
      <NuxtLink to="/regles/statistiques/puissante">Puissance</NuxtLink> du personnage.
    </p>
    <!-- Invocations fidèles (Tiers 3) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Invocations fidèles</h2>
      <div class="h5">
        <TarBadge variant="secondary">Tiers&nbsp;3</TarBadge>
      </div>
    </div>
    <p>
      Lorsque les points de <NuxtLink to="/regles/statistiques/vitalite">Vitalité</NuxtLink> du personnage chutent à 0 ou qu’il tombe
      <NuxtLink to="/regles/combat/conditions/incapable">incapable</NuxtLink> contre son gré, le
      <NuxtLink to="/regles/magie/pouvoirs/niveau">niveau 5</NuxtLink> du pouvoir
      <NuxtLink to="/regles/magie/pouvoirs/etres-des-bois">Êtres des bois</NuxtLink> est instantanément déclenché.
    </p>
    <p>
      Quatre bêtes de niveau 2 ou moins apparaissent à 6 mètres ou moins de la position du personnage. Si elles ne reçoivent pas d’ordre de celui-ci, les bêtes
      le protègent et <NuxtLink to="/regles/combat/attaque">attaquent</NuxtLink> ses ennemis.
    </p>
    <p>
      L’effet dure <NuxtLink to="/regles/aventure/temps">une heure</NuxtLink>, ne nécessite pas la
      <NuxtLink to="/regles/magie/parametres/duree">concentration</NuxtLink>, et peut être dissipé par le personnage en
      <NuxtLink to="/regles/combat/deroulement/tour">action libre</NuxtLink>.
    </p>
    <p>Le personnage doit compléter une <NuxtLink to="/regles/aventure/repos/sommeil">nuit de sommeil</NuxtLink> afin de réutiliser cette capacité.</p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Annexes", to: "/regles/annexes" },
  { text: "Domaines d’animisme", to: "/regles/domaines/animisme" },
];
const title: string = "Berger";

useSeo({
  title,
  description:
    "Découvrez le domaine du Berger, maître des esprits animaux et protecteur des forêts, invoquant totems, auras, créatures fidèles et puissantes bénédictions naturelles.",
});
</script>
