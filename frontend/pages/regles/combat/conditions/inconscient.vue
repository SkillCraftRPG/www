<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>Une créature inconsciente est <NuxtLink to="/regles/combat/conditions/incapable">incapable</NuxtLink> : elle ne peut pas bouger ni parler.</p>
    <ul>
      <li>Elle n’est pas consciente de son environnement et de ce qui se déroule autour d’elle.</li>
      <li>
        Elle <NuxtLink to="/regles/combat/activites/lacher">lâche</NuxtLink> les objets qu’elle tient et s’effondre
        <NuxtLink to="/regles/combat/conditions/renverse">renversée</NuxtLink> au sol.
      </li>
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
      Lorsqu’une créature est inconsciente parce que ses points d’<NuxtLink to="/regles/statistiques/energie">Énergie</NuxtLink> sont de 0, elle reprend
      conscience lorsque ceux-ci remontent au-delà de 0, généralement après une <NuxtLink to="/regles/aventure/temps">heure</NuxtLink> de
      <NuxtLink to="/regles/aventure/repos/sommeil">sommeil</NuxtLink> ou de <NuxtLink to="/regles/aventure/repos/halte">halte</NuxtLink>.
    </p>
    <p>
      Lorsqu’une créature est inconsciente parce qu’elle cumule un nombre de points de dégâts
      <NuxtLink to="/regles/combat/degats/letalite">non létaux</NuxtLink> supérieur ou égal à ses points de
      <NuxtLink to="/regles/statistiques/vitalite">Vitalité</NuxtLink>, elle reprend conscience lorsque ses points de Vitalité sont supérieurs à ses points de
      dégâts non létaux cumulés. Cette situation peut se produire lorsqu’elle est <NuxtLink to="/regles/combat/degats/soins">soignée</NuxtLink>, ou lorsqu’elle
      se <NuxtLink to="/regles/aventure/repos">repose</NuxtLink>.
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
    "Découvrez la condition inconscient : une créature incapable, inconsciente de son environnement et vulnérable aux attaques, jusqu’à régénération.",
});
</script>
