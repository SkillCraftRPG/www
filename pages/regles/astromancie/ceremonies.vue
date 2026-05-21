<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <RulesBreadcrumb :active="title" :parent="parent" />
    <p>
      Les rites initiatiques, ou <strong>cérémonies</strong>, jouent un rôle important pour les érudits des
      <NuxtLink to="/regles/astromancie/ecole">écoles occultes</NuxtLink>. C’est par ces rites qu’ils se démarquent de leurs comparses et qu’ils gravissent les
      échelons. Tout individu étudiant dans une école de magie est assigné le rang d’<NuxtLink to="/regles/talents/astrologie">Adepte</NuxtLink>. Lorsqu’un
      individu réside à une école dans la poursuite d’un rang supérieur, il est assigné le rang d’<NuxtLink to="/regles/specialisations/astromancien"
        >Aspirant</NuxtLink
      >.
    </p>
    <h2 class="h3">Cérémonie d’Initiation</h2>
    <p>
      Ce premier rite est le plus important et le premier rite accomplit par les Aspirants. Pendant cette cérémonie, les Aspirants doivent entres autres prêter
      les <strong>Trois-Serments</strong> suivants. Ils doivent également joindre une des <NuxtLink to="/regles/astromancie/ecole">sept maisons</NuxtLink>. À la
      fin de cette cérémonie, ils sont assignés le rang d’<i>Initié</i> et reçoivent une toge de la couleur de leur maison.
    </p>
    <p>
      En brisant les Trois-Serments ou en agissant délibérément contre son école de magie, le mage s’expose à la <strong>Désactivation</strong>, un processus
      douloureux consistant à rompre son lien temporairement ou de manière permanente avec sa magie et ses pouvoirs. Ce châtiment est réservé aux pires
      criminels ou aux récalcitrants à outrance.
    </p>
    <ul>
      <li>
        <strong>Vérité.</strong> Les mages ont droit au silence et peuvent omettre des détails lorsqu’ils sont interrogés, mais il leur est interdit de mentir.
      </li>
      <li>
        <strong>Pacifisme.</strong> Les mages doivent se servir de leur magie avec parcimonie et doivent régler leurs conflits d’une manière non violente. Il
        leur est défendu d’utiliser leur magie afin de blesser volontairement une créature n’étant pas de nature fondamentalement mauvaise.
      </li>
      <li>
        <strong>Prudence.</strong> Les mages ne doivent pas se servir de la magie afin de fabriquer une arme permettant de tuer une autre personne ou créature.
      </li>
    </ul>
    <h2 class="h3">Cérémonie d’Allégeance</h2>
    <p>
      L’Initié a accès à un cursus plus étendu que les Adeptes et Aspirants. En plus de l’astromancie, il peut étudier par exemple l’alchimie, les arts
      oratoires, la botanique, les créatures magiques, l’histoire, la politique et les stratégies militaires. Il côtoiera des mentors membres des cinq cercles
      de magie et devra choisir un cercle auquel il devra prêter allégeance. Le rang de <NuxtLink to="/regles/specialisations/mage">Dévoué</NuxtLink> lui sera
      assigné, il lui sera par la suite impossible de changer d’allégeance pour un autre cercle de magie, et il fera l’acquisition une capacité spécifique au
      cercle.
    </p>
    <h2 class="h3">Cérémonie d’Élévation</h2>
    <p>
      Lorsqu’un mage Dévoué est jugé prêt par les mentors de son cercle de magie, alors il peut tenter un examen très difficile et sans préparation imposé par
      ses mentors. En cas de réussite, il peut poursuivre avec cette cérémonie. Le rang de
      <NuxtLink to="/regles/specialisations/haut-mage">Haut Mage</NuxtLink> lui sera assigné. Il peut accéder à l’ensemble des pouvoirs et des savoirs de son
      cercle de magie, et acquiert deux capacités spécifiques à son cercle de magie.
    </p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/tar/breadcrumb";

const parent: Breadcrumb[] = [
  { text: "Annexes", to: "/regles/annexes" },
  { text: "Astromancie", to: "/regles/astromancie" },
];
const title: string = "Rites initiatiques";

useSeo({
  title,
  description: "Découvrez les rites initiatiques des écoles occultes : cérémonies, serments et rangs qui guident la progression des mages.",
});
</script>
