<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Les divinités appartenant à ce domaine s’intéressent à la nature, aux terres sauvages, à la faune et à la flore de ces environnements, et sont des
      protecteurs de ces éléments naturels.
    </p>
    <p>
      Type de dégâts de l’<NuxtLink to="/regles/specialisations/pretre">Attaque divine</NuxtLink> : <NuxtLink to="/regles/combat/degats/types">poison</NuxtLink>
    </p>
    <!-- Acolyte de la nature (Tiers 0) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Acolyte de la nature</h2>
      <div class="h5">
        <TarBadge variant="secondary">Tiers&nbsp;0</TarBadge>
      </div>
    </div>
    <p>
      Le personnage acquiert également gratuitement un <NuxtLink to="/regles/magie/pouvoirs">pouvoir</NuxtLink> de tiers 0 associé à un
      <NuxtLink to="/regles/domaines/animisme">domaine d’animisme naturel</NuxtLink>.
    </p>
    <!-- Arpenteur sauvage (Tiers 1) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Arpenteur sauvage</h2>
      <div class="h5">
        <TarBadge variant="secondary">Tiers&nbsp;1</TarBadge>
      </div>
    </div>
    <p>
      Le personnage peut acquérir <NuxtLink to="/regles/talents/points">à rabais</NuxtLink> les talents suivants :
      <NuxtLink to="/regles/talents/medecine-animale">Médecine animale</NuxtLink>, <NuxtLink to="/regles/talents/naturalisme">Naturalisme</NuxtLink> et
      <NuxtLink to="/regles/talents/survivalisme">Survivalisme</NuxtLink>.
    </p>
    <!-- Allié de la nature (Pouvoir divin) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Allié de la nature</h2>
      <div class="h5">
        <TarBadge variant="secondary">Pouvoir&nbsp;divin</TarBadge>
      </div>
    </div>
    <p>
      Le personnage présente son <NuxtLink to="/regles/equipement/general">symbole divin</NuxtLink> par une
      <NuxtLink to="/regles/combat/deroulement/tour">action</NuxtLink>, récite une prière à la nature et effectue un
      <NuxtLink to="/regles/competences/tests">test</NuxtLink> d’<NuxtLink to="/regles/competences/occultisme">Occultisme</NuxtLink>. Toute créature naturelle
      (bêtes et plantes) situées à 9 mètres ou moins du personnage doit effectuer un
      <NuxtLink to="/regles/competences/tests/sauvegarde">jet de sauvegarde</NuxtLink> de <NuxtLink to="/regles/competences/discipline">Discipline</NuxtLink> de
      <NuxtLink to="/regles/competences/tests/difficulte">difficulté</NuxtLink> égale au résultat du test. En cas d’échec, une créature est
      <NuxtLink to="/regles/combat/conditions/charme">charmée</NuxtLink> par le personnage pendant <NuxtLink to="/regles/aventure/temps">une minute</NuxtLink>,
      ou jusqu’à ce qu’elle reçoive des <NuxtLink to="/regles/combat/degats">points de dégâts</NuxtLink>. Pendant qu’elle est charmée, elle est
      <NuxtLink to="/regles/aventure/interaction-sociale">amicale</NuxtLink> envers le personnage et les créatures qu’il désigne.
    </p>
    <!-- Protection élémentaire (Tiers 2) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Protection élémentaire</h2>
      <div class="h5">
        <TarBadge variant="secondary">Tiers&nbsp;2</TarBadge>
      </div>
    </div>
    <p>
      Lorsque le personnage reçoit des <NuxtLink to="/regles/combat/degats">points de dégâts</NuxtLink> élémentaires
      <NuxtLink to="/regles/combat/degats/types">(acide, feu, foudre, froid ou tonnerre)</NuxtLink>, il peut utiliser sa
      <NuxtLink to="/regles/combat/deroulement/tour">réaction</NuxtLink> afin de se conférer la
      <NuxtLink to="/regles/combat/degats/efficacite">résistance</NuxtLink> aux <NuxtLink to="/regles/combat/degats">dégâts</NuxtLink> de ce type jusqu’au début
      de son prochain <NuxtLink to="/regles/combat/deroulement/tour">tour</NuxtLink>. Il peut également utiliser cette capacité en ciblant une autre créature
      située à 9 mètres ou moins de sa position.
    </p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Annexes", to: "/regles/annexes" },
  { text: "Domaines divins", to: "/regles/domaines/divins" },
];
const title: string = "Nature";

useSeo({
  title,
  description: "Découvrez le domaine divin de la Nature, axé sur la faune, la flore, l’animisme et la protection des forces naturelles.",
});
</script>
