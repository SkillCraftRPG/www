<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Certains pouvoir peuvent être <NuxtLink to="/regles/magie/pouvoirs/canalisation">canalisés</NuxtLink> en rituel, en plus de pouvoir être canalisés
      normalement.
    </p>
    <p>
      Le rituel doit être d’une durée minimale de <NuxtLink to="/regles/aventure/temps">10 minutes</NuxtLink> additionnées à la durée de canalisation normale du
      pouvoir.
    </p>
    <p>
      Collaborez avec votre maître de jeu afin de déterminer en quoi consiste le rituel. N’oubliez pas d’inclure toutes les <strong>composantes</strong> du
      pouvoir dans les étapes du rituel.
    </p>
    <p>
      Lorsque vous canalisez un pouvoir en rituel, vous réussissez automatiquement le <NuxtLink to="/regles/competences/tests">test</NuxtLink> d’<NuxtLink
        to="/regles/competences/occultisme"
        >Occultisme</NuxtLink
      >, et la canalisation ne vous coûte qu’un seul point d’<NuxtLink to="/regles/statistiques/energie">Énergie</NuxtLink>. Cette
      <NuxtLink to="/regles/magie/pouvoirs/energie">dépense</NuxtLink> ne peut être réduite d’aucune manière.
    </p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Magie", to: "/regles/magie" },
  { text: "Pouvoirs", to: "/regles/magie/pouvoirs" },
];
const title: string = "Rituel";

useSeo({
  title,
  description:
    "Découvrez les rituels : canalisez un pouvoir sans test d’Occultisme, avec un seul point d’Énergie, en suivant un temps et des composantes spécifiques.",
});
</script>
