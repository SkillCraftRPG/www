<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Les divinités appartenant à ce domaine s’intéressent au cycle de la vie et de la mort. Certaines protègent les cimetières et rites funéraires, tandis que
      d’autres sont fascinées par les morts-vivants.
    </p>
    <p>
      Type de dégâts de l’<NuxtLink to="/regles/specialisations/pretre">Attaque divine</NuxtLink> :
      <NuxtLink to="/regles/combat/degats/types">nécrotique</NuxtLink>
    </p>
    <!-- Cycle de la vie (Tiers 0) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Cycle de la vie</h2>
      <div class="h5">
        <TarBadge variant="secondary">Tiers&nbsp;0</TarBadge>
      </div>
    </div>
    <p>
      Le personnage acquiert gratuitement le pouvoir <NuxtLink to="/regles/magie/pouvoirs/preservation">Préservation</NuxtLink>. Il peut
      <NuxtLink to="/regles/magie/pouvoirs/canalisation">canaliser</NuxtLink> le <NuxtLink to="/regles/magie/pouvoirs/niveau">niveau 1</NuxtLink> de ce
      <NuxtLink to="/regles/magie/pouvoirs">pouvoir</NuxtLink> par une seule <NuxtLink to="/regles/combat/deroulement/tour">action</NuxtLink>, et la
      <NuxtLink to="/regles/magie/parametres/portee">portée</NuxtLink> augmente à 6 (9 mètres). Également, lorsqu’il
      <NuxtLink to="/regles/combat/degats/soins">soigne</NuxtLink> une créature
      <NuxtLink to="/regles/combat/conditions/agonisant">agonisante stable</NuxtLink> en canalisant un pouvoir, alors les dés de guérison sont remplacés par
      leur valeur maximale.
    </p>
    <!-- Yeux de la Mort (Tiers 1) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Yeux de la Mort</h2>
      <div class="h5">
        <TarBadge variant="secondary">Tiers&nbsp;1</TarBadge>
      </div>
    </div>
    <p>
      Par une <NuxtLink to="/regles/combat/deroulement/tour">action</NuxtLink>, le personnage peut détecter la présence et l’emplacement précis des
      morts-vivants situés à 18 mètres ou moins de sa position jusqu’à la fin de son prochain <NuxtLink to="/regles/combat/deroulement/tour">tour</NuxtLink>. La
      détection pénètre toute barrière, mais elle ne détecte pas les morts-vivants protégés contre la détection, ni en situation d’<NuxtLink
        to="/regles/combat/attaque/abri"
        >abri total</NuxtLink
      >. Cette capacité ne lui indique pas l’identité ni les capacités des créatures ainsi détectées. Il peut utiliser cette capacité un nombre de fois égal à
      ses <NuxtLink to="/regles/attributs/sens">Sens</NuxtLink> (minimum&nbsp;1) et doit compléter une
      <NuxtLink to="/regles/aventure/repos/sommeil">nuit de sommeil</NuxtLink> afin de récupérer ces utilisations.
    </p>
    <!-- Tombeau (Pouvoir divin) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Tombeau</h2>
      <div class="h5">
        <TarBadge variant="secondary">Pouvoir&nbsp;divin</TarBadge>
      </div>
    </div>
    <p>
      Lorsque le personnage réussit une <NuxtLink to="/regles/combat/attaque/melee">attaque de mêlée</NuxtLink>, il récite une prière funèbre en
      <NuxtLink to="/regles/combat/deroulement/tour">action libre</NuxtLink>. La cible reçoit un nombre de
      <NuxtLink to="/regles/combat/degats/types">points de dégâts nécrotiques</NuxtLink> supplémentaires égal à la
      <NuxtLink to="/regles/statistiques/puissance">Puissance</NuxtLink> du personnage, additionnés à la moitié de son
      <NuxtLink to="/regles/personnages/progression/niveau">niveau</NuxtLink>.
    </p>
    <p>
      Alternativement, il présente son <NuxtLink to="/regles/equipement/general">symbole divin</NuxtLink> par une
      <NuxtLink to="/regles/combat/deroulement/tour">action</NuxtLink> et récite une prière de malédiction en direction d’une créature qu’il peut
      <NuxtLink to="/regles/aventure/environnement/vision">voir</NuxtLink> et située à 9 mètres ou moins de sa position. La malédiction dure jusqu’à la fin du
      prochain <NuxtLink to="/regles/combat/deroulement/tour">tour</NuxtLink> du personnage et porte les effets suivants :
    </p>
    <ul>
      <li>
        La cible est <NuxtLink to="/regles/combat/degats/efficacite">vulnérable</NuxtLink> à tous les
        <NuxtLink to="/regles/combat/degats">dégâts</NuxtLink> infligés par la prochaine <NuxtLink to="/regles/combat/attaque">attaque</NuxtLink> qu’elle reçoit
        de la part du personnage ou d’une autre créature désignée par celui-ci.
      </li>
      <li>
        Lorsque le personnage <NuxtLink to="/regles/magie/pouvoirs/canalisation">canalise</NuxtLink> un
        <NuxtLink to="/regles/magie/pouvoirs">pouvoir</NuxtLink> associé à la <NuxtLink to="#">Nécromancie</NuxtLink> ciblant une seule créature, si la créature
        maudite se trouve à 1,5 mètres ou moins de la position de la cible, alors la créature maudite est également affectée par le pouvoir.
      </li>
    </ul>
    <!-- Cycle de la mort (Tiers 2) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Cycle de la mort</h2>
      <div class="h5">
        <TarBadge variant="secondary">Tiers&nbsp;2</TarBadge>
      </div>
    </div>
    <p>
      Lorsque le personnage inflige des <NuxtLink to="/regles/combat/degats/types">dégâts nécrotiques</NuxtLink> à une créature en utilisant
      <strong>Tombeau</strong> ou en <NuxtLink to="/regles/magie/pouvoirs/canalisation">canalisant</NuxtLink> un
      <NuxtLink to="/regles/magie/pouvoirs">pouvoir</NuxtLink>, alors ces <NuxtLink to="/regles/combat/degats">dégâts</NuxtLink> ignorent les
      <NuxtLink to="/regles/combat/degats/efficacite">résistances</NuxtLink> de la cible.
    </p>
    <p>
      Également, lorsqu’il est victime d’un <NuxtLink to="/regles/competences/tests/critique">coup critique</NuxtLink>, il peut utiliser sa
      <NuxtLink to="/regles/combat/deroulement/tour">réaction</NuxtLink> afin de transformer le résultat en réussite simple. Il peut utiliser cette capacité sur
      une créature alliée qu’il peut <NuxtLink to="/regles/aventure/environnement/vision">voir</NuxtLink> située à 9 mètres ou moins de sa position. Il peut
      utiliser cette capacité un nombre de fois égal à ses <NuxtLink to="/regles/attributs/sens">Sens</NuxtLink> (minimum&nbsp;1) et doit compléter une
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
const title: string = "Mort";

useSeo({
  title,
  description: "Découvrez le domaine divin de la Mort, centré sur le cycle de la vie, les rites funéraires et la maîtrise des énergies nécrotiques.",
});
</script>
