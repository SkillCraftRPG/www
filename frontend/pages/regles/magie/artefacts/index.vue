<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb active="Artefacts" :parent="parent" />
    <p>
      Les objets magiques, trouvés dans les trésors de monstres vaincus ou dans des lieux oubliés, offrent à un personnage des capacités autrement inaccessibles
      ou renforcent les siennes de façon extraordinaire.
    </p>
    <div class="row">
      <div v-for="(item, index) in items" :key="index" class="col-xs-12 col-sm-6 col-md-4 mb-4">
        <LinkCard class="d-flex flex-column h-100" :text="item.description" :title="item.title" :to="item.path" />
      </div>
    </div>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [{ text: "Magie", to: "/regles/magie" }];
const title: string = "Artefacts magiques";

type MenuItem = {
  path: string;
  title: string;
  description: string;
};
const items: MenuItem[] = [
  {
    path: "/regles/magie/artefacts/harmonisation",
    title: "Harmonisation",
    description: "Rituel créant un lien magique indispensable pour activer un artefact.",
  },
  {
    path: "/regles/magie/artefacts/port-maniement",
    title: "Port et maniement",
    description: "Règles précisant comment porter ou manier correctement un artefact magique.",
  },
  {
    path: "/regles/magie/artefacts/utilisation",
    title: "Utilisation",
    description: "Guide sur l’usage des artefacts : actions, mots, charges, pouvoirs et limites.",
  },
];

useSeo({
  title,
  description:
    "Découvrez les artefacts magiques : harmonisation, port approprié et règles d’utilisation, offrant des pouvoirs uniques et des effets extraordinaires aux aventuriers.",
});

// TODO(fpion): Spell Scrolls; https://roll20.net/compendium/dnd5e/Spell%20Scroll#content
</script>
