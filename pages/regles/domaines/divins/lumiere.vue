<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Les divinités appartenant à ce domaine s’intéressent à la pureté et à la lumière purificatrice, à la beauté et à la perfection. Elles sont de véritables
      icônes de la vigilance, des sentinelles célestes perçant les ombres et châtiant les trompeurs. Elles sont souvent associés à l’astre solaire, et on les
      associe parfois au talent artistique, véritable véhicule de l’élévation de l’âme.
    </p>
    <p>
      Type de dégâts de l’<NuxtLink to="/regles/specialisations/pretre">Attaque divine</NuxtLink> :
      <NuxtLink to="/regles/combat/degats/types">radiant</NuxtLink>
    </p>
    <!-- Incarnation de la Lumière (Tiers 0) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Incarnation de la Lumière</h2>
      <div class="h5">
        <TarBadge variant="secondary">Tiers&nbsp;0</TarBadge>
      </div>
    </div>
    <p>Le personnage acquiert gratuitement le pouvoir <NuxtLink to="/regles/magie/pouvoirs/lumiere">Lumière</NuxtLink>.</p>
    <!-- Garde lumineuse (Tiers 1) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Garde lumineuse</h2>
      <div class="h5">
        <TarBadge variant="secondary">Tiers&nbsp;1</TarBadge>
      </div>
    </div>
    <p>
      Lorsque le personnage <NuxtLink to="/regles/aventure/environnement/vision">voit</NuxtLink> une créature située à 9 mètres ou moins diriger une
      <NuxtLink to="/regles/combat/attaque">attaque</NuxtLink> envers lui, il peut dégager un éclair de lumière vive en
      <NuxtLink to="/regles/combat/deroulement/tour">réaction</NuxtLink>. L’éclair afflige du
      <NuxtLink to="/regles/competences/tests/avantage-desavantage">désavantage</NuxtLink> le <NuxtLink to="/regles/competences/tests">test</NuxtLink> de
      l’attaque. Une créature immunisée à l’<NuxtLink to="/regles/combat/conditions/aveugle">aveuglement</NuxtLink> n’est pas affectée par cette capacité. Le
      personnage peut utiliser cette capacité un nombre de fois égal à ses <NuxtLink to="/regles/attributs/sens">Sens</NuxtLink> (minimum&nbsp;1) et doit
      compléter une <NuxtLink to="/regles/aventure/repos/sommeil">nuit de sommeil</NuxtLink> afin de récupérer ces utilisations.
    </p>
    <!-- Abjuration arcane (Pouvoir divin) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Aube</h2>
      <div class="h5">
        <TarBadge variant="secondary">Aube</TarBadge>
      </div>
    </div>
    <p>
      Le personnage présente son <NuxtLink to="/regles/equipement/general">symbole divin</NuxtLink> par une
      <NuxtLink to="/regles/combat/deroulement/tour">action</NuxtLink> et récite une prière lumineuse. Il dissipe les
      <NuxtLink to="/regles/aventure/environnement/vision">ténèbres</NuxtLink> dans un rayon de 9 mètres centré sur sa position. Il effectue également un
      <NuxtLink to="/regles/competences/tests">test</NuxtLink> d’<NuxtLink to="/regles/competences/occultisme">Occultisme</NuxtLink> et désigne toutes les
      créatures de son choix situées dans cette zone. Chaque cible doit effectuer un
      <NuxtLink to="/regles/competences/tests/sauvegarde">jet de sauvegarde</NuxtLink> de <NuxtLink to="/regles/competences/resistance">Résistance</NuxtLink> de
      <NuxtLink to="/regles/competences/tests/difficulte">difficulté</NuxtLink> égale au résultat du test du personnage. En cas d’échec, une créature reçoit un
      nombre de <NuxtLink to="/regles/combat/degats/types">points de dégâts radiants</NuxtLink> égal à
      <NuxtLink to="/regles/combat/degats/jet">1d10</NuxtLink> par <NuxtLink to="/regles/personnages/progression/tiers">tiers</NuxtLink> du personnage,
      additionnés à la <NuxtLink to="/regles/statistiques/puissance">Puissance</NuxtLink> de celui-ci. Une créature ne reçoit que la moitié des
      <NuxtLink to="/regles/combat/degats">points de dégâts</NuxtLink> en cas de réussite. Une créature en situation d’<NuxtLink
        to="/regles/combat/attaque/abri"
        >abri total</NuxtLink
      >
      n’est pas affectée par cette capacité.
    </p>
    <!-- Lumière supérieure (Tiers 2) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Lumière supérieure</h2>
      <div class="h5">
        <TarBadge variant="secondary">Tiers&nbsp;2</TarBadge>
      </div>
    </div>
    <p>
      Le personnage peut désormais utiliser sa <strong>Garde lumineuse</strong> afin de protéger une autre créature qu’il peut
      <NuxtLink to="/regles/aventure/environnement/vision">voir</NuxtLink> située à 9 mètres ou moins de sa position.
    </p>
    <p>
      Également, lorsqu’il utilise <strong>Aube</strong>, il ajoute une seconde fois sa <NuxtLink to="/regles/statistiques/puissance">Puissance</NuxtLink> aux
      <NuxtLink to="/regles/combat/degats">points de dégâts</NuxtLink> infligés.
    </p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Annexes", to: "/regles/annexes" },
  { text: "Domaines divins", to: "/regles/domaines/divins" },
];
const title: string = "Lumière";

useSeo({
  title,
  description: "Découvrez le domaine divin de la Lumière, axé sur la purification, la vigilance et des pouvoirs radiants protecteurs et offensifs.",
});
</script>
