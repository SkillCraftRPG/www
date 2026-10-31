<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <RulesBreadcrumb active="Couronne" :parent="parent" />
    <p>
      Le Serment de la Couronne se prête aux idéaux de la civilisation : esprit d’une nation, fidélité à un souverain ou service d’une divinité de la loi. Ses
      paladins servent la société et les lois justes qui l’unissent. Gardiens vigilants contre la barbarie, on les appelle aussi exemplaires ou sentinelles.
      Souvent membres d’un ordre de chevalerie, ils prêtent serment en y étant admis. Leurs préceptes, souvent fixés par le souverain, insistent généralement
      sur les points suivants.
    </p>
    <ul>
      <li><strong>Loi.</strong> La loi prime : elle ciment la civilisation et exige le respect.</li>
      <li><strong>Loyauté.</strong> Sa parole l’engage ; sans loyauté, serments et lois n’ont plus de sens.</li>
      <li><strong>Courage.</strong> Il doit faire ce qu’exige l’ordre, même face à des chances écrasantes, car s’il n’agit pas, nul autre ne le fera.</li>
      <li><strong>Responsabilité.</strong> Il assume les suites de ses actes et s’acquitte de ses devoirs et obligations.</li>
    </ul>
    <h2 class="h3">Défi du champion</h2>
    <p>
      Par une <NuxtLink to="/regles/combat/deroulement/tour">action</NuxtLink>, le personnage invoque son
      <NuxtLink to="/regles/specialisations/champion">pouvoir divin</NuxtLink> et lance un défi à une ou plusieurs créatures de son choix situées à 9 mètres ou
      moins de sa position. Il effectue un <NuxtLink to="/regles/competences/tests">test</NuxtLink> d’<NuxtLink to="/regles/competences/occultisme"
        >Occultisme</NuxtLink
      >
      et chaque créature doit effectuer un <NuxtLink to="/regles/competences/tests/sauvegarde">jet de sauvegarde</NuxtLink> de
      <NuxtLink to="/regles/competences/discipline">Discipline</NuxtLink> de <NuxtLink to="/regles/competences/tests/difficulte">difficulté</NuxtLink> égale au
      résultat du test. En cas d’échec, une créature ne peut volontairement s’éloigner de plus de 9 mètres du personnage. L’effet prend fin si le personnage
      devient <NuxtLink to="/regles/combat/conditions/incapable">incapable</NuxtLink>, s’il <NuxtLink to="/regles/combat/conditions/mort">meurt</NuxtLink>, ou
      si la distance le séparant de la créature est de plus de 9 mètres.
    </p>
    <h2 class="h3">Renverser le cours</h2>
    <p>
      Par une <NuxtLink to="/regles/combat/deroulement/tour">action</NuxtLink>, le personnage invoque son
      <NuxtLink to="/regles/specialisations/champion">pouvoir divin</NuxtLink> afin de soigner une ou plusieurs créatures situées à 9 mètres ou moins de sa
      position pouvant l’<NuxtLink to="/regles/combat/conditions/assourdi">entendre</NuxtLink>. Chaque créature
      <NuxtLink to="/regles/combat/degats/soins">récupère</NuxtLink> 1d12&nbsp;+&nbsp;<NuxtLink to="/regles/attributs/sante">Santé</NuxtLink> points de
      <NuxtLink to="/regles/statistiques/vitalite">Vitalité</NuxtLink>, si sa Vitalité courante est inférieure ou égale à la moitié de sa Vitalité maximale.
    </p>
    <h2 class="h3">Saint inflexible</h2>
    <p>
      Le personnage se voit conférer l’<NuxtLink to="/regles/competences/tests/avantage-desavantage">avantage</NuxtLink> à ses
      <NuxtLink to="/regles/competences/tests/sauvegarde">jets de sauvegarde</NuxtLink> contre les effets l’<NuxtLink to="/regles/combat/conditions/assomme"
        >assommant</NuxtLink
      >
      ou le <NuxtLink to="/regles/combat/conditions/paralyse">paralysant</NuxtLink>.
    </p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/tar/breadcrumb";

const parent: Breadcrumb[] = [
  { text: "Annexes", to: "/regles/annexes" },
  { text: "Serments sacrés", to: "/regles/domaines/serments" },
];
const title: string = "Serment de la Couronne";

useSeo({
  title,
  description:
    "Découvrez le Serment de la Couronne de SkillCraft, ses préceptes de loi, de loyauté et de courage, ainsi que ses pouvoirs divins de protection et de guérison.",
});
</script>
