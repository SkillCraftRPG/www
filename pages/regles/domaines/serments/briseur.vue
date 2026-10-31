<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <RulesBreadcrumb :active="title" :parent="parent" />
    <p>
      Un briseur de serment est un <NuxtLink to="/regles/specialisations/inquisiteur">inquisiteur</NuxtLink> ou un
      <NuxtLink to="/regles/specialisations/paladin">paladin</NuxtLink> qui a rompu ses serments sacrés pour poursuivre quelque sombre ambition ou servir une
      puissance maléfique. Quelle que fût la lumière qui brûlait dans le cœur du paladin, elle s’est éteinte ; seules les ténèbres demeurent.
    </p>
    <h2 class="h3"><font-awesome-icon icon="fas fa-skull" />&nbsp;Aura de haine</h2>
    <p>
      Lorsqu’une créature se trouve à 3 mètres ou moins de la position du personnage, elle se voit conférer un bonus aux
      <NuxtLink to="/regles/combat/degats">dégâts</NuxtLink> qu’elle inflige égal à la <NuxtLink to="/regles/attributs/sante">Santé</NuxtLink> (minimum&nbsp;1)
      du personnage, peu importe qu’elle soit <NuxtLink to="/regles/aventure/interaction-sociale">amicale</NuxtLink> ou
      <NuxtLink to="/regles/aventure/interaction-sociale">hostile</NuxtLink> envers lui. Afin de bénéficier de cette capacité, elle doit appartenir à un des
      types de créature suivants : aberration, célestiel, élémentaire, fée, infernal ou mort-vivant. Une créature ne peut bénéficier simultanément plusieurs
      fois de cette capacité.
    </p>
    <h2 class="h3">Aspect terrifiant</h2>
    <p>
      Par une <NuxtLink to="/regles/combat/deroulement/tour">action</NuxtLink>, le personnage invoque son pouvoir divin afin de canaliser les émotions les plus
      sombres et les concentrer en une explosion de menace magique. Chaque créature de son choix située à 9 mètres ou moins de sa position doit réussir un
      <NuxtLink to="/regles/competences/tests/sauvegarde">jet de sauvegarde</NuxtLink> de <NuxtLink to="/regles/competences/discipline">Discipline</NuxtLink> si
      elle peut le <NuxtLink to="/regles/aventure/environnement/vision">voir</NuxtLink> ou être
      <NuxtLink to="/regles/combat/conditions/apeure">apeurée</NuxtLink> par celui-ci pendant <NuxtLink to="/regles/aventure/temps">une minute</NuxtLink>. Si
      une créature apeurée termine son <NuxtLink to="/regles/combat/deroulement/tour">tour</NuxtLink> à plus de 9 mètres du personnage, alors elle peut tenter à
      nouveau le jet de sauvegarde. En cas de réussite, l’effet prend fin pour cette créature.
    </p>
    <h2 class="h3">Contrôle des morts-vivants</h2>
    <p>
      Par une <NuxtLink to="/regles/combat/deroulement/tour">action</NuxtLink>, le personnage invoque son pouvoir divin afin de tenter de prendre contrôle d’un
      mort-vivant qu’il peut <NuxtLink to="/regles/aventure/environnement/vision">voir</NuxtLink> et situé à 18 mètres ou moins de sa position. Il effectue un
      <NuxtLink to="/regles/competences/tests">test</NuxtLink> d’<NuxtLink to="/regles/competences/occultisme">Occultisme</NuxtLink>, et la cible effectue un
      <NuxtLink to="/regles/competences/tests/sauvegarde">jet de sauvegarde</NuxtLink> de <NuxtLink to="/regles/competences/discipline">Discipline</NuxtLink> ou
      d’<NuxtLink to="/regles/competences/intuition">Intuition</NuxtLink> de <NuxtLink to="/regles/competences/tests/difficulte">difficulté</NuxtLink> égale au
      résultat du test. En cas de réussite, la cible est immunisée à cette capacité. En cas d’échec, la cible devient
      <NuxtLink to="/regles/aventure/interaction-sociale">amicale</NuxtLink> envers le personnage et obéit à ses commandes jusqu’à ce que celui-ci réutilise
      cette capacité.
    </p>
    <ul>
      <li>
        Si l’<NuxtLink to="/regles/attributs/intellect">Intellect</NuxtLink> de la cible est supérieur à –2, son jet de sauvegarde se voit conférer l’<NuxtLink
          to="/regles/competences/tests/avantage-desavantage"
          >avantage</NuxtLink
        >.
      </li>
      <li>
        Si l’<NuxtLink to="/regles/attributs/intellect">Intellect</NuxtLink> de la cible est supérieur à 0, elle peut répéter le jet de sauvegarde à la fin de
        chaque <NuxtLink to="/regles/aventure/temps">heure</NuxtLink> jusqu’à ce qu’elle le réussisse.
      </li>
    </ul>
    <h2 class="h3">Résistance surnaturelle</h2>
    <p>
      Le personnage devient <NuxtLink to="/regles/combat/degats/efficacite">résistant</NuxtLink> aux dégâts
      <NuxtLink to="/regles/combat/degats/types">contondants</NuxtLink>, <NuxtLink to="/regles/combat/degats/types">perforants</NuxtLink> et
      <NuxtLink to="/regles/combat/degats/types">tranchants</NuxtLink>.
    </p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/tar/breadcrumb";

const parent: Breadcrumb[] = [
  { text: "Annexes", to: "/regles/annexes" },
  { text: "Serments sacrés", to: "/regles/domaines/serments" },
];
const title: string = "Briseur de serment";

useSeo({
  title,
  description:
    "Découvrez le Briseur de serment de SkillCraft, un paladin ou inquisiteur déchu qui manie les ténèbres, inspire la terreur et contrôle les morts-vivants.",
});
</script>
