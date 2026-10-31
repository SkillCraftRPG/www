<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <RulesBreadcrumb active="Vengeance" :parent="parent" />
    <p>
      Le Serment de la Sentinelle lie les inquisiteurs à la protection des royaumes mortels contre les créatures extra-dimensionnelles, capables d’anéantir des
      soldats mortels. Ils aiguisent esprit, âme et corps contre de telles menaces, demeurent vigilants face aux forces d’outre-monde, et établissent souvent un
      réseau d’espions et d’informateurs pour surveiller les cultes suspects. Pour un inquisiteur, méfiance et conscience de son environnement sont aussi
      naturelles que de porter une armure.
    </p>
    <ul>
      <li>
        <strong>Vigilance.</strong> Les menaces auxquelles il fait face sont rusées, puissantes et subversives : il demeure toujours en alerte contre leur
        corruption.
      </li>
      <li>
        <strong>Loyauté.</strong> Il n’accepte jamais de dons ni de faveurs de la part de fiélons ou de ceux qui traitent avec eux, et reste fidèle à son ordre,
        à ses camarades et à son devoir.
      </li>
      <li>
        <strong>Discipline.</strong> Bouclier contre les terreurs sans fin qui gisent au-delà des étoiles, il tient lame et esprit toujours affûtés pour
        survivre à ce qui se trouve au-delà.
      </li>
    </ul>
    <h2 class="h3">Anathème</h2>
    <p>
      Lorsque le personnage utilise le talent <NuxtLink to="/regles/talents/exorcisme">Exorcisme</NuxtLink> et qu’il ne châtie pas les morts-vivants, alors il
      peut choisir un nombre de types de créature parmi la liste suivante inférieur ou égal à sa
      <NuxtLink to="/regles/attributs/sante">Santé</NuxtLink> (minimum&nbsp;2) : aberration, célestiel, élémentaire, fée ou infernal. Toute créature appartenant
      à au moins un des types désignés est châtiée.
    </p>
    <h2 class="h3">Réprimande vigilante</h2>
    <p>
      Lorsque le personnage ou une créature située à 9 mètres ou moins de sa position qu’il peut
      <NuxtLink to="/regles/aventure/environnement/vision">voir</NuxtLink> réussit un
      <NuxtLink to="/regles/competences/tests/sauvegarde">jet de sauvegarde</NuxtLink> de <NuxtLink to="/regles/competences/discipline">Discipline</NuxtLink>,
      d’<NuxtLink to="/regles/competences/intuition">Intuition</NuxtLink> ou d’<NuxtLink to="/regles/competences/investigation">Investigation</NuxtLink>, il
      peut utiliser sa <NuxtLink to="/regles/combat/deroulement/tour">réaction</NuxtLink> afin d’infliger
      <NuxtLink to="/regles/combat/degats/jet">2d10</NuxtLink>&nbsp;+&nbsp;<NuxtLink to="/regles/attributs/sante">Santé</NuxtLink>{{ " "
      }}<NuxtLink to="/regles/combat/degats">points de dégâts</NuxtLink> à la créature ayant forcé le jet de sauvegarde. Le
      <NuxtLink to="/regles/combat/degats/types">type</NuxtLink> des dégâts varie en fonction de son
      <NuxtLink to="/regles/domaines/divins">domaine divin</NuxtLink>.
    </p>
    <h2 class="h3">Volonté de la Sentinelle</h2>
    <p>
      Par une <NuxtLink to="/regles/combat/deroulement/tour">action</NuxtLink>, le personnage invoque son pouvoir divin et sélectionne un nombre de créatures
      inférieur ou égal à sa <NuxtLink to="/regles/attributs/sante">Santé</NuxtLink> (minimum&nbsp;1) situées à 9 mètres ou moins de sa position qu’il peut
      <NuxtLink to="/regles/aventure/environnement/vision">voir</NuxtLink>. Pendant la prochaine <NuxtLink to="/regles/aventure/temps">minute</NuxtLink>, le
      personnage et les créatures désignées se voient conférer l’<NuxtLink to="/regles/competences/tests/avantage-desavantage">avantage</NuxtLink> à leurs
      <NuxtLink to="/regles/competences/tests/sauvegarde">jets de sauvegarde</NuxtLink> de <NuxtLink to="/regles/competences/discipline">Discipline</NuxtLink>,
      d’<NuxtLink to="/regles/competences/intuition">Intuition</NuxtLink> et d’<NuxtLink to="/regles/competences/investigation">Investigation</NuxtLink>.
    </p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/tar/breadcrumb";

const parent: Breadcrumb[] = [
  { text: "Annexes", to: "/regles/annexes" },
  { text: "Serments sacrés", to: "/regles/domaines/serments" },
];
const title: string = "Serment de la Sentinelle";

useSeo({
  title,
  description:
    "Découvrez le Serment de la Sentinelle de SkillCraft, ses préceptes de vigilance et de loyauté, et ses pouvoirs contre les créatures extra-dimensionnelles.",
});
</script>
