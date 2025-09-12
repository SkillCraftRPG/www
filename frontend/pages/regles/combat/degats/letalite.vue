<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p class="text-danger">
      <!-- TODO(fpion): déplacer dans statistique  -->
      Lorsqu’il est question de la Vitalité d’une créature, il existe deux valeurs : sa Vitalité maximale, ainsi que sa Vitalité actuelle, une valeur qui varie
      entre 0 et la valeur maximale.
    </p>
    <p>🚧</p>
    <h2 class="h3">Létal</h2>
    <p>
      Lorsqu’une créature reçoit des points de dégâts <strong>létaux</strong>, ceux-ci sont soustraits de sa
      <NuxtLink to="/regles/statistiques/vitalite">Vitalité</NuxtLink> actuelle.
    </p>
    <p>Par exemple, si une créature possédant 10 points de Vitalité reçoit 3 points de dégâts létaux, sa Vitalité actuelle tombe à 7.</p>
    <p>La perte de points de Vitalité n’a aucun effet sur les capacités d’une créature, sauf lorsque ses points de Vitalité <strong>atteignent 0</strong>.</p>
    <h2 class="h3">Non létal</h2>
    <p>Lorsqu’une créature reçoit des points de dégâts <strong>non létaux</strong>, ceux-ci sont additionnés.</p>
    <p>
      Par exemple, si une créature reçoit 3 points de dégâts non létaux, elle en cumule 3. Si elle reçoit ensuite 4 points de dégats non létaux, elle en cumule
      maintenant 7.
    </p>
    <p>
      Lorsque la somme des points de dégâts létaux reçus par une créature est supérieure ou égale à sa Vitalité actuelle, elle tombe
      <NuxtLink to="/regles/combat/conditions/inconscient">inconsciente</NuxtLink>.
    </p>
    <p>Elle reprend conscience lorsque sa Vitalité actuelle dépasse les points de dégâts non létaux reçus, ou lorsque ceux-ci <strong>diminuent</strong>.</p>
    <!-- TODO(fpion): effet du repos (sommeil/halte) sur les points de dégâts non létaux -->
    <!-- TODO(fpion): parler du non létal dans la condition inconscient -->
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Combat", to: "/regles/combat" },
  { text: "Dégâts", to: "/regles/combat/degats" },
];
const title: string = "Létalité";

useSeo({
  title,
  description: "🚧",
});
</script>
