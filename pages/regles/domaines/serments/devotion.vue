<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <RulesBreadcrumb active="Dévotion" :parent="parent" />
    <p>
      Le Serment de Dévotion lie le paladin aux idéaux de justice, de vertu et d’ordre. Cavaliers, chevaliers blancs ou guerriers sacrés, ils incarnent le
      chevalier en armure étincelante au service du bien commun. Ils exigent une conduite exemplaire et, parfois, jugent le monde à la même aune. Dévoués aux
      dieux de la loi et du bien, ils mesurent leur foi à leurs préceptes, prennent les anges pour modèles et ornent heaumes ou blasons d’ailes. Les
      formulations varient ; ils partagent ces préceptes.
    </p>
    <ul>
      <li><strong>Honnêteté.</strong> Il ne ment ni ne triche : sa parole vaut promesse.</li>
      <li><strong>Courage.</strong> Il n’hésite pas à agir, même si la prudence demeure sage.</li>
      <li>
        <strong>Compassion.</strong> Il aide autrui, protège les faibles, châtie qui les menace, et tempère de sagesse la miséricorde offerte à ses ennemis.
      </li>
      <li>
        <strong>Honneur.</strong> Il traite les autres avec équité, donne l’exemple par ses actes, et fait autant de bien que possible en causant le moins de
        mal.
      </li>
      <li><strong>Devoir.</strong> Il assume ses actes et leurs suites, protège ceux qui lui sont confiés, et obéit à une autorité juste.</li>
    </ul>
    <h2 class="h3">Abjuration arcane</h2>
    <p>
      Lorsque le personnage utilise le talent <NuxtLink to="/regles/talents/exorcisme">Exorcisme</NuxtLink> en désignant un type de créature différent de
      mort-vivant, si une cible échoue le <NuxtLink to="/regles/competences/tests/sauvegarde">jet de sauvegarde</NuxtLink>, que son niveau est inférieur ou égal
      au <NuxtLink to="/regles/personnages/progression/tiers">tiers</NuxtLink> du personnage et qu’elle provient d’une autre dimension, alors elle est bannie
      dans sa dimension d’origine pendant la prochaine <NuxtLink to="/regles/aventure/temps">minute</NuxtLink>. Le personnage n’a pas besoin de maintenir sa
      <NuxtLink to="/regles/magie/parametres/duree">concentration</NuxtLink> contre une créature bannie.
    </p>
    <h2 class="h3">Arme sacrée</h2>
    <p>
      Par une <NuxtLink to="/regles/combat/deroulement/tour">action</NuxtLink>, le personnage invoque son
      <NuxtLink to="/regles/specialisations/champion">pouvoir divin</NuxtLink> afin d’imprégner son
      <NuxtLink to="/regles/equipement/armes">arme</NuxtLink> d’énergie divine pendant <NuxtLink to="/regles/aventure/temps">une minute</NuxtLink>. L’arme émet
      de la <NuxtLink to="/regles/aventure/environnement/vision">clarté</NuxtLink> dans un rayon de 6 mètres et de la
      <NuxtLink to="/regles/aventure/environnement/vision">pénombre</NuxtLink> dans un rayon de 6 mètres additionnels. L’arme devient
      <NuxtLink to="/regles/combat/degats/types">magique</NuxtLink> et le personnage se voit conférer un bonus au
      <NuxtLink to="/regles/competences/tests">test</NuxtLink> de ses <NuxtLink to="/regles/combat/attaque/melee">attaques</NuxtLink> effectuées avec cette arme
      égal à sa <NuxtLink to="/regles/attributs/sante">Santé</NuxtLink> (minimum&nbsp;1). L’effet prend fin si le personnage y met fin en
      <NuxtLink to="/regles/combat/deroulement/tour">action libre</NuxtLink> ou s’il <NuxtLink to="/regles/combat/activites/lacher">lâche</NuxtLink> l’arme.
    </p>
    <h2 class="h3">Pureté d’esprit</h2>
    <p>
      Le personnage est en permanence sous les effets du <NuxtLink to="/regles/magie/pouvoirs/niveau">niveau 3</NuxtLink> du pouvoir
      <NuxtLink to="/regles/magie/pouvoirs/protection-contre-le-bien-et-le-mal">Protection contre le bien et le mal</NuxtLink>.
    </p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/tar/breadcrumb";

const parent: Breadcrumb[] = [
  { text: "Annexes", to: "/regles/annexes" },
  { text: "Serments sacrés", to: "/regles/domaines/serments" },
];
const title: string = "Serment de Dévotion";

useSeo({
  title,
  description:
    "Découvrez le Serment de Dévotion de SkillCraft, ses préceptes de justice, d’honneur et de compassion, ainsi que ses pouvoirs de protection et de combat sacré.",
});
</script>
