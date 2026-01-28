<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Vous tentez de vous échapper d’une situation nuisant à votre <NuxtLink to="/regles/aventure/mouvement">mobilité</NuxtLink>, par exemple de l’<NuxtLink
        to="/regles/combat/activites/agripper"
        >emprise d’une autre créature</NuxtLink
      >, d’un <NuxtLink to="/regles/equipement/armes/martiales">filet</NuxtLink> ou d’une
      <NuxtLink to="/regles/magie/pouvoirs">végétation vous enchevêtrant</NuxtLink>.
    </p>
    <p>
      Cette action vous permet d’effectuer ou de répéter le <NuxtLink to="/regles/competences/tests">test</NuxtLink> approprié, habituellement un test
      d’<NuxtLink to="/regles/competences/athletisme">Athlétisme</NuxtLink> ou d’<NuxtLink to="/regles/competences/acrobaties">Acrobaties</NuxtLink>.
    </p>
    <p>
      Si vous réussissez le test, vous vous libérez de cette situation. Si vous êtes affligés de plusieurs situations, vous devez vous libérer de chacune
      d’entre elles séparément.
    </p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Combat", to: "/regles/combat" },
  { text: "Activités", to: "/regles/combat/activites" },
];
const title: string = "S’échapper";

useSeo({
  title,
  description: "Découvrez comment s’échapper d’une entrave ou d’un effet limitant la mobilité grâce à un test d’Athlétisme ou d’Acrobaties réussi.",
});
</script>
