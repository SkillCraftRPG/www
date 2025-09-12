<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Vous lâchez un objet que vous tenez, par exemple une <NuxtLink to="/regles/equipement/armes">arme</NuxtLink>, un
      <NuxtLink to="/regles/equipement/boucliers">bouclier</NuxtLink>, ou une <NuxtLink to="/regles/equipement/general">torche</NuxtLink>. L’objet tombe au sol,
      à vos pieds, et vous ne bénéficiez plus de ses effets.
    </p>
    <p>Vous pouvez également lâcher une créature que vous tenez <NuxtLink to="/regles/combat/conditions/agrippe">agrippée</NuxtLink> afin de la libérer.</p>
    <p>
      Vous pouvez lâcher un objet ou une créature en <NuxtLink to="/regles/combat/deroulement/tour">action libre</NuxtLink>, ce qui vous permet de lâcher autant
      d’objets et de créatures que vous le désirez à tout moment.
    </p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Combat", to: "/regles/combat" },
  { text: "Activités", to: "/regles/combat/activites" },
];
const title: string = "Lâcher";

useSeo({
  title,
  description: "🚧",
});

// TODO(fpion): dégainer + lâcher en action libre grâce à la Free Item Interaction
</script>
