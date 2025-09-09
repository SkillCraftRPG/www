<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>Une créature inconsciente est <NuxtLink to="/regles/combat/conditions/incapable">incapable</NuxtLink> : elle ne peut pas bouger ni parler.</p>
    <ul>
      <li>Elle n’est pas consciente de son environnement et de ce qui se déroule autour d’elle.</li>
      <li>Elle <strong>lâche</strong> les objets qu’elle tient et s’effondre <NuxtLink to="/regles/combat/conditions/renverse">renversée</NuxtLink> au sol.</li>
      <li>
        Elle échoue automatiquement ses <NuxtLink to="/regles/competences/tests/sauvegarde">jets de sauvegarde</NuxtLink> d’<NuxtLink
          to="/regles/competences/athletisme"
          >Athlétisme</NuxtLink
        >
        et d’<NuxtLink to="/regles/competences/acrobaties">Acrobaties</NuxtLink>.
      </li>
      <li>
        Le <NuxtLink to="/regles/competences/tests">test</NuxtLink> des <NuxtLink to="/regles/combat/attaque">attaques</NuxtLink> dirigées contre elle se voit
        conférer l’<NuxtLink to="/regles/competences/tests/avantage-desavantage">avantage</NuxtLink>, et les
        <NuxtLink to="/regles/combat/attaque/melee">attaques de mêlée</NuxtLink> la ciblant sont automatiquement une
        <NuxtLink to="/regles/competences/tests/critique">réussite critique</NuxtLink>.
      </li>
    </ul>
    <p>
      Une créature inconsciente reprend généralement conscience lorsque ses points d’<NuxtLink to="/regles/statistiques/energie">Énergie</NuxtLink> remontent
      au-delà de 0, après une heure de <NuxtLink to="/regles/aventure/repos/sommeil">sommeil</NuxtLink> ou de
      <NuxtLink to="/regles/aventure/repos/halte">halte</NuxtLink>.
    </p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Combat", to: "/regles/combat" },
  { text: "Conditions", to: "/regles/combat/conditions" },
];
const title: string = "Inconscient";

useSeo({
  title,
  description:
    "Découvrez les effets de l’état inconscient : incapacité totale, échec automatique aux jets, avantage aux attaques reçues et coups critiques en mêlée.",
});
</script>
