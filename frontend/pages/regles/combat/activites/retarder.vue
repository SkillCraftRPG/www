<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Vous remettez votre <NuxtLink to="/regles/combat/deroulement/tour">tour</NuxtLink> à plus tard dans le round. Vous ne pouvez pas retarder votre tour si
      vous avez déjà effectué une action ou plus.
    </p>
    <p>Vous prenez votre tour entre le tour de deux autres créatures. Vous ne pouvez interrompre le tour d’une autre créature.</p>
    <p>Vous êtes <NuxtLink to="/regles/combat/deroulement/depourvu">pris au dépourvu</NuxtLink> jusqu’à ce que vous preniez votre tour.</p>
    <p>
      Lorsque vous prenez votre tour, votre valeur d’<NuxtLink to="/regles/combat/deroulement/initiative">Initiative</NuxtLink> change pour cette nouvelle
      position, et reste ainsi jusqu’à la fin du combat ou jusqu’à ce que vous retardiez votre tour à nouveau.
    </p>
    <p>Si vous ne prenez pas votre tour avant que le prochain round ne débute, vous perdez votre tour et conservez votre valeur actuelle d’Initiative.</p>
    <p>À la discrétion du maître de jeu, lorsque vous effectuez l’action libre de retarder votre tour :</p>
    <ul>
      <li>
        Les <NuxtLink to="/regles/combat/degats">dégâts</NuxtLink> et effets persistants (négatifs ou positifs) s’appliquent au moment où vous prenez l’action
        libre, même s’ils se seraient appliqués à la fin de votre tour.
      </li>
      <li>
        Les effets persistants bénéfiques qui auraient pris fin à un moment quelconque pendant ou à la fin de votre tour prennent également fin à cet instant.
      </li>
      <li>
        Les effets persistants négatifs qui auraient pris fin à un moment quelconque pendant ou à la fin de votre tour perdurent jusqu’à ce que vous preniez
        votre tour, ou jusqu’à la fin du round si vous ne le prenez pas.
      </li>
    </ul>
    <p></p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Combat", to: "/regles/combat" },
  { text: "Activités", to: "/regles/combat/activites" },
];
const title: string = "Retarder";

useSeo({
  title,
  description:
    "Découvrez comment retarder votre tour modifie l’initiative et l’application des effets persistants, avec des risques de rester pris au dépourvu.",
});
</script>
