<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>L’alchimie est une branche de l’occultisme née de techniques gardées secrètes et de spéculations mystiques.</p>
    <p>À l’origine, l’objectif des alchimistes était de transformer un métal impur en or ou en un autre métal pur.</p>
    <p>
      C’est grâce aux observations faites pendant leurs expériences que les alchimistes ont découvert l’art de la concoction de potions et autres artifices.
    </p>
    <h2 class="h3">Concoctions</h2>
    <p>
      Les <strong>concoctions</strong> sont des potions magiques pouvant être ingérées par une créature. Elles appartiennent à un tiers variant entre 0 et 3.
    </p>
    <p>
      Une concoction peut conférer un effet positif à une créature, par exemple un bonus. Elle peut également lui infliger un effet négatif, telle une pénalité.
    </p>
    <p>Une concoction doit être entièrement ingérée afin de faire effet. Plusieurs créatures ne peuvent donc pas se partager la même concoction.</p>
    <h2 class="h3">Intoxication</h2>
    <p>Lorsqu’une créature ingère une concoction, elle reçoit un nombre de <strong>points d’intoxication</strong> égal à 1 + tiers de la concoction.</p>
    <p>
      Lorsqu’elle complète une <NuxtLink to="/regles/aventure/repos/sommeil">nuit de sommeil</NuxtLink>, les points d’intoxication d’une créature descendent
      d’un nombre égal à son <NuxtLink to="/regles/personnages/progression/tiers">tiers</NuxtLink> (minimum 1) jusqu’à atteindre 0.
    </p>
    <p>Une créature possède un seuil de tolérance à l’intoxication égal à 3 + <NuxtLink to="/regles/attributs/vigueur">Vigueur</NuxtLink> (minimum 0).</p>
    <p>
      Lorsque ses points d’intoxication sont supérieurs à ce seuil, elle est <NuxtLink to="/regles/combat/conditions/empoisonne">empoisonnée</NuxtLink>. Cet
      empoisonnement ne disparaît que lorsque les points d’intoxication descendent à une valeur inférieure ou égale au seuil.
    </p>
    <p>
      Également, lorsqu’une créature gagne des points en étant empoisonnée à cause de l’intoxication, elle est affligée d’un <strong>niveau de Fatigue</strong>.
    </p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [{ text: "Magie", to: "/regles/magie" }];
const title: string = "Alchimie";

useSeo({
  title,
  description: "Découvrez l’art de l’alchimie : préparez des concoctions magiques, gérez l’intoxication et exploitez leurs effets positifs ou négatifs en jeu.",
});
</script>
