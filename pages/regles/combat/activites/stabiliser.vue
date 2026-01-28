<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Vous stabilisez une créature <NuxtLink to="/regles/combat/mort-agonie">mourante</NuxtLink>. Celle-ci doit être
      <NuxtLink to="/regles/combat/conditions/agonisant">agonisante</NuxtLink> et instable. Cette action n’a aucun effet contre une créature agonisante et
      stable.
    </p>
    <p>Cette action vous expose aux <NuxtLink to="/regles/combat/attaque/opportunite">attaques d’opportunité</NuxtLink>.</p>
    <p>
      Effectuez un <NuxtLink to="/regles/competences/tests">test</NuxtLink> de <NuxtLink to="/regles/competences/medecine">Médecine</NuxtLink> de
      <NuxtLink to="/regles/competences/tests/difficulte">difficulté moyenne</NuxtLink>. Le destin de la créature dépend de votre résultat.
    </p>
    <ul>
      <li>
        <strong>Réussite critique.</strong> La créature est stabilisée. Elle reprend conscience et récupère immédiatement un point de
        <NuxtLink to="/regles/statistiques/vitalite">Vitalité</NuxtLink>. Elle pourra jouer son prochain
        <NuxtLink to="/regles/combat/deroulement/tour">tour</NuxtLink> normalement.
      </li>
      <li>
        <strong>Réussite.</strong> La créature est stabilisée. Elle ne risque plus la mort, sauf si elle est
        <NuxtLink to="/regles/combat/degats">blessée</NuxtLink> à nouveau. Elle reprend conscience si elle reçoit des
        <NuxtLink to="/regles/combat/degats/soins">soins</NuxtLink>, ou après <NuxtLink to="/regles/aventure/temps">une heure</NuxtLink>.
      </li>
      <li><strong>Échec.</strong> La créature reste agonisante et instable. Rien ne vous empêche de réessayer !</li>
      <li>
        <strong>Échec critique.</strong> Vous <NuxtLink to="/regles/combat/activites/coup-grace">achevez</NuxtLink> la créature, bien malgré vous. Elle peut
        être ressuscitée si les conditions sont respectées.
      </li>
    </ul>
    <p>
      Si vous possédez une <NuxtLink to="/regles/equipement/outils">trousse de premiers soins</NuxtLink>, vous pouvez utiliser 1, 2 ou 3 charges de la trousse
      afin de conférer à votre test de un bonus +5, de +10, ou une réussite automatique.
    </p>
    <p>
      Le <NuxtLink to="/regles/talents">talent</NuxtLink> <NuxtLink to="/regles/talents/medecine">Médecine</NuxtLink> améliore votre capacité à stabiliser un
      mourant.
    </p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Combat", to: "/regles/combat" },
  { text: "Activités", to: "/regles/combat/activites" },
];
const title: string = "Stabiliser";

useSeo({
  title,
  description:
    "Découvrez comment stabiliser une créature mourante grâce à un test de Médecine, avec des résultats allant de la réussite critique à l’échec fatal.",
});
</script>
