<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>Les dégâts ne sont jamais permanents. Ils peuvent être soignés par certaines capacités physiques ou surnaturelles.</p>
    <p>
      Une créature <NuxtLink to="/regles/combat/conditions/agonisant">agonisante</NuxtLink> peut être soignée, mais si elle est instable, elle est stabilisée et
      ne récupère aucun point de <NuxtLink to="/regles/statistiques/vitalite">Vitalité</NuxtLink>.
    </p>
    <p>Une créature <NuxtLink to="/regles/combat/mort-agonie">morte</NuxtLink> ne peut être soignée. Elle doit d’abord être ressuscitée.</p>
    <h2 class="h3">Létal</h2>
    <p>Lorsqu’une créature est soignée, elle récupère un certain nombre de points de <NuxtLink to="/regles/statistiques/vitalite">Vitalité</NuxtLink>.</p>
    <p>Sa Vitalité actuelle ne peut dépasser sa Vitalité maximale par des soins.</p>
    <p>
      Par exemple, si une créature possède 3 points de Vitalité actuelle sur un maximum 10 et qu’elle est soignée d’un point, sa Vitalité actuelle remonte à 4.
      Si elle est ensuite soignée de 7 points, alors sa Vitalité actuelle remonte à 10, soit sa valeur maximale de Vitalité.
    </p>
    <h2 class="h3">Non létal</h2>
    <p>
      Lorsqu’une créature est soignée, ses points de dégâts <NuxtLink to="/regles/combat/degats/letalite">non létaux</NuxtLink> diminuent d’une valeur égale aux
      points de Vitalité récupérés.
    </p>
    <p>Ses points de dégâts non létaux ne peuvent jamais descendre en deçà de 0.</p>
    <p>
      Par exemple, si une créature cumule 5 points de dégâts non létaux et est soignée d’un point, alors ses points de dégâts non létaux descendent à 2. Si elle
      est ensuite soignée de 7 points, alors ses points de dégâts non létaux descendent à 0.
    </p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Combat", to: "/regles/combat" },
  { text: "Dégâts", to: "/regles/combat/degats" },
];
const title: string = "Soins";

useSeo({
  title,
  description:
    "Découvrez comment les soins restaurent la Vitalité d’une créature, réduisent les dégâts létaux ou non létaux et les limites associées à la guérison.",
});
</script>
