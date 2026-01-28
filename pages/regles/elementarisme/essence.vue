<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      L’essence élémentaire est représentée par des points que le personnage peut utiliser afin d’activer de
      <NuxtLink to="/regles/elementarisme/capacites">puissants effets</NuxtLink>.
    </p>
    <p>
      Chaque point est matérialisé par un petit orbe intangible, transparent et coloré en fonction de l’élément, flottant autour du personnage. Par exemple, un
      point d’essence élémentaire de Feu pourrait être représenté par un orbe incandescent rouge, orange et jaune à l’intérieur une flamme brûle.
    </p>
    <p>Par une <NuxtLink to="/regles/combat/deroulement/tour">action</NuxtLink>, le personnage peut créer un ou plusieurs points d’essence élémentaire.</p>
    <p>Il dépense 5 points d’<NuxtLink to="/regles/statistiques/energie">Énergie</NuxtLink> par point d’essence élémentaire qu’il désire créer.</p>
    <p>
      S’il désire créer plusieurs points par une même action, il doit effectuer un <NuxtLink to="/regles/competences/tests">test</NuxtLink> d’<NuxtLink
        to="/regles/competences/occultisme"
        >Occultisme</NuxtLink
      >. S’il tente de créer un nombre de points supérieur à son <NuxtLink to="/regles/personnages/progression/tiers">tiers</NuxtLink>, alors le test est
      affligé du <NuxtLink to="/regles/competences/tests/avantage-desavantage">désavantage</NuxtLink>. Le talent
      <NuxtLink to="/regles/talents/fermete-elementaire">Fermeté élémentaire</NuxtLink> améliore les chances de succès du personnage.
    </p>
    <p>
      La <NuxtLink to="/regles/competences/tests/difficulte">difficulté</NuxtLink> est égale au nombre de points qu’il possède présentement, additionné au
      nombre de points qu’il tente de créer, le tout multiplié par 5. Par exemple, s’il possède présentement 2 points d’essence élémentaire et qu’il désire en
      créer 3, alors il doit dépenser 15 points d’Énergie, il doit effectuer un test d’Occultisme de difficulté égale à 25, et il effectue le test avec
      désavantage si son tiers est inférieur à 3.
    </p>
    <p>En cas de réussite, les points d’Énergie sont convertis en points d’essence élémentaire, qui se matérialisent autour du personnage.</p>
    <p>En cas d’échec, l’effet varie selon le <NuxtLink to="/regles/competences/tests/2d10">résultat</NuxtLink> :</p>
    <ul>
      <li><i>Échec avec Espérance.</i> Le personnage crée un seul point d’essence élémentaire et dépense seulement 5 points d’Énergie.</li>
      <li>
        <i>Échec avec Damnation.</i> Le personnage crée un seul point d’essence élémentaire au coût de 5 points d’Énergie. Il dépense la moitié des points
        d’Énergie restants, et reçoit un nombre égal de <NuxtLink to="/regles/combat/degats/types">points de dégâts magiques</NuxtLink>.
      </li>
      <li>
        <i>Échec critique.</i>
        Le personnage ne crée aucun point d’essence élémentaire, perd tous les points d’Énergie, et reçoit un nombre égal de points de dégâts magiques.
      </li>
    </ul>
    <p>
      Les points de dégâts ainsi reçus ne peuvent être réduits que par le talent
      <NuxtLink to="/regles/talents/fermete-elementaire">Fermeté élémentaire</NuxtLink>.
    </p>
    <p>Les points d’essence élémentaire disparaissent après <NuxtLink to="/regles/aventure/temps">une heure</NuxtLink> s’ils ne sont pas utilisés.</p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Annexes", to: "/regles/annexes" },
  { text: "Élémentarisme", to: "/regles/elementarisme" },
];
const title: string = "Essence élémentaire";

useSeo({
  title,
  description: "🚧",
});
</script>
