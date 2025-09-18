<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>Une créature agonisante est <NuxtLink to="/regles/combat/conditions/inconscient">inconsciente</NuxtLink>. Son état peut être stable ou instable.</p>
    <p>La condition prend fin lorsque ses points de <NuxtLink to="/regles/statistiques/vitalite">Vitalité</NuxtLink> remontent à une valeur supérieure à 0.</p>
    <h2 class="h3">Instable</h2>
    <p>
      Lorsque les points de <NuxtLink to="/regles/statistiques/vitalite">Vitalité</NuxtLink> d’une créature chutent à 0, elle tombe à l’<NuxtLink
        to="/regles/combat/mort-agonie"
        >agonie</NuxtLink
      >
      en état instable, et risque la <NuxtLink to="/regles/combat/conditions/mort">mort</NuxtLink>.
    </p>
    <p>Si elle est <NuxtLink to="/regles/combat/degats/soins">soignée</NuxtLink>, elle ne récupère aucun point de Vitalité, mais son état se stabilise.</p>
    <p>Elle retombe également en état instable si son état était stable, mais qu’elle est <NuxtLink to="/regles/combat/degats">blessée</NuxtLink>.</p>
    <p>
      Elle peut également être <NuxtLink to="/regles/combat/activites/stabiliser">stabilisée</NuxtLink> et recevoir le
      <NuxtLink to="/regles/combat/activites/coup-grace">coup de grâce</NuxtLink>.
    </p>
    <p>
      Chaque fois qu’une créature tombe ou retombe en état instable, sa <NuxtLink to="/regles/combat/conditions/fatigue">Fatigue</NuxtLink> augmente d’un
      niveau.
    </p>
    <h2 class="h3">Stable</h2>
    <p>
      Une créature à l’<NuxtLink to="/regles/combat/mort-agonie">agonie</NuxtLink> mais dans un état stable ne risque pas activement la
      <NuxtLink to="/regles/combat/conditions/mort">mort</NuxtLink>.
    </p>
    <p>
      Elle peut être <NuxtLink to="/regles/combat/degats/soins">soignée</NuxtLink> normalement. Son état retombe instable si elle est
      <NuxtLink to="/regles/combat/degats">blessée</NuxtLink>.
    </p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Combat", to: "/regles/combat" },
  { text: "Conditions", to: "/regles/combat/conditions" },
];
const title: string = "Agonisant";

useSeo({
  title,
  description: "Découvrez l’état agonisant : une créature inconsciente, stable ou instable, risquant la mort ou pouvant être stabilisée et soignée.",
});
</script>
