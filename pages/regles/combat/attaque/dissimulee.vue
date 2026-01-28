<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb active="Dissimulée" :parent="parent" />
    <p>
      Lorsqu’une créature tente d’attaquer une cible qu’elle ne peut pas voir, son <NuxtLink to="/regles/competences/tests">test</NuxtLink> est affligé du
      <NuxtLink to="/regles/competences/tests/avantage-desavantage">désavantage</NuxtLink>. Cette pénalité s’applique même si l’attaquant entend sa cible ou
      qu’il sait où elle se trouve.
    </p>
    <p>
      L’attaque échoue automatiquement si la cible ne se trouve pas à l’emplacement ciblé. Dans ce cas, le maître de jeu annonce simplement que l’attaque a
      échoué. Il n’indique pas si la cible se trouvait à l’emplacement ciblé ou non.
    </p>
    <p>
      Lorsqu’une créature <NuxtLink to="/regles/combat/activites/cacher">dissimulée</NuxtLink> tente d’attaquer une cible qui n’est pas au courant de sa
      présence, son <NuxtLink to="/regles/competences/tests">test</NuxtLink> se voit conférer l’<NuxtLink to="/regles/competences/tests/avantage-desavantage"
        >avantage</NuxtLink
      >. La position de l’attaquant est ensuite révélée, que l’attaque réussisse ou non, sauf si l’attaquant a acquis le
      <NuxtLink to="/regles/talents">talent</NuxtLink> <NuxtLink to="/regles/talents/maraudage">Maraudage</NuxtLink>, que l’attaque échoue, et qu’il s’agit
      d’une <NuxtLink to="/regles/combat/attaque/distance">attaque à distance</NuxtLink>.
    </p>
    <p>
      Voici quelques exemples de situations permettant de bénéficier de cet avantage : <NuxtLink to="/regles/combat/activites/cacher">se cacher</NuxtLink>, être
      dans une <NuxtLink to="/regles/aventure/environnement/vision">zone obscurcie</NuxtLink>, être
      <NuxtLink to="/regles/combat/conditions/invisible">invisible</NuxtLink>.
    </p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Combat", to: "/regles/combat" },
  { text: "Attaque", to: "/regles/combat/attaque" },
];
const title: string = "Attaque dissimulée";

useSeo({
  title,
  description:
    "Découvrez les règles des attaques dissimulées : infligez désavantage aux ennemis aveugles ou distraits et gagnez l’avantage en restant caché ou invisible.",
});
</script>
