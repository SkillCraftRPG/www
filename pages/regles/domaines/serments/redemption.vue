<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <RulesBreadcrumb active="Rédemption" :parent="parent" />
    <p>
      Le Serment de Rédemption exige du paladin la violence en dernier recours. Les rédempteurs croient que quiconque peut être racheté. Ils affrontent le mal
      pour le ramener à la lumière, et ne tuent que pour sauver d’autres vies. Sans naïveté, ils savent que morts-vivants, démons, diables et menaces
      surnaturelles peuvent être intrinsèquement maléfiques ; contre eux, armes et sorts s’abattent. Ils prient pourtant qu’un jour même la méchanceté aspire à
      se racheter. Ce serment exige paix et justice.
    </p>
    <ul>
      <li><strong>Paix.</strong> La violence n’est qu’un dernier recours ; diplomatie et compréhension mènent à une paix durable.</li>
      <li>
        <strong>Innocence.</strong> Tous naissent innocents, et c’est l’environnement ou les forces obscures qui les poussent au mal ; par l’exemple et en
        guérissant un monde imparfait, il peut ramener quiconque sur une voie juste.
      </li>
      <li>
        <strong>Patience.</strong> Le changement prend du temps : ceux qui ont marché dans l’impiété ont besoin de rappels, et une fois la graine de droiture
        plantée, il doit l’entretenir jour après jour pour qu’elle survive et fleurisse.
      </li>
      <li>
        <strong>Sagesse.</strong> Cœur et esprit clairs, il sait qu’il devra parfois admettre l’échec : certaines créatures, trop avancées dans le mal, doivent
        mourir pour le bien commun ; il pèse l’acte et ses suites, puis l’accomplit, certain que sa voie est juste.
      </li>
    </ul>
    <h2 class="h3">Émissaire de la paix</h2>
    <p>
      Par une <NuxtLink to="/regles/combat/deroulement/tour">action</NuxtLink>, le personnage invoque son
      <NuxtLink to="/regles/specialisations/champion">pouvoir divin</NuxtLink> afin de se conférer un bonus (+5) à ses
      <NuxtLink to="/regles/competences/tests">tests</NuxtLink> de <NuxtLink to="/regles/competences/diplomatie">Diplomatie</NuxtLink>, de
      <NuxtLink to="/regles/competences/representation">Représentation</NuxtLink> et de
      <NuxtLink to="/regles/competences/tromperie">Tromperie</NuxtLink> pendant <NuxtLink to="/regles/aventure/temps">10 minutes</NuxtLink>.
    </p>
    <h2 class="h3">Esprit protecteur</h2>
    <p>
      En situation de <NuxtLink to="/regles/combat">combat</NuxtLink>, lorsque le personnage termine son
      <NuxtLink to="/regles/combat/deroulement/tour">tour</NuxtLink> alors que sa <NuxtLink to="/regles/statistiques/vitalite">Vitalité</NuxtLink> courante est
      inférieure à la moitié de sa Vitalité maximale et qu’il n’est pas <NuxtLink to="/regles/combat/conditions/incapable">incapable</NuxtLink>, il peut se
      <NuxtLink to="/regles/combat/degats/soins">soigner</NuxtLink> en utilisant sa <NuxtLink to="/regles/specialisations/paladin">Santé divine</NuxtLink> en
      <NuxtLink to="/regles/combat/deroulement/tour">action libre</NuxtLink>.
    </p>
    <h2 class="h3">Réprimande des violents</h2>
    <p>
      Immédiatement après qu’une créature située à 9 mètres ou moins du personnage <NuxtLink to="/regles/combat/degats">blesse</NuxtLink> celui-ci ou une autre
      créature par une <NuxtLink to="/regles/combat/attaque">attaque</NuxtLink>, le personnage peut invoquer son
      <NuxtLink to="/regles/specialisations/champion">pouvoir divin</NuxtLink> en <NuxtLink to="/regles/combat/deroulement/tour">réaction</NuxtLink>. Il
      effectue un <NuxtLink to="/regles/competences/tests">test</NuxtLink> d’<NuxtLink to="/regles/competences/occultisme">Occultisme</NuxtLink> et la cible
      effectue un <NuxtLink to="/regles/competences/tests/sauvegarde">jet de sauvegarde</NuxtLink> de
      <NuxtLink to="/regles/competences/discipline">Discipline</NuxtLink> de <NuxtLink to="/regles/competences/tests/difficulte">difficulté</NuxtLink> égale au
      résultat du test. En cas d’échec, la cible reçoit un nombre de points de dégâts égal au nombre de points de dégâts reçus par sa propre cible. En cas de
      réussite, elle ne reçoit que la moitié des points de dégâts. Le <NuxtLink to="/regles/combat/degats/types">type</NuxtLink> des dégâts varie en fonction du
      <NuxtLink to="/regles/domaines/divins">domaine divin</NuxtLink> du personnage.
    </p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/tar/breadcrumb";

const parent: Breadcrumb[] = [
  { text: "Annexes", to: "/regles/annexes" },
  { text: "Serments sacrés", to: "/regles/domaines/serments" },
];
const title: string = "Serment de Rédemption";

useSeo({
  title,
  description:
    "Découvrez le Serment de Rédemption de SkillCraft, ses préceptes de paix et de justice, ainsi que ses pouvoirs de guérison et de réprimande des violents.",
});
</script>
