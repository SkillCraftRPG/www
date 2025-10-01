<template>
  <main class="container">
    <h1>Règles</h1>
    <AppBreadcrumb active="Règles" />
    <p>Les rubriques suivantes regroupent les règles du jeu. Elles sont classées par thème afin de faciliter la prise en main du système.</p>
    <p>
      Les rubriques sont également présentées en ordre logique d’utilisation : d’abord, la création et progression des personnages, puis les règles en
      découlant, et enfin les rubriques concernant le déroulement d’une partie de jeu.
    </p>
    <div class="d-flex flex-column justify-content-center align-items-center">
      <div class="grid">
        <NuxtLink v-for="(tile, index) in tiles" :key="index" :to="tile.to" class="tile">
          <font-awesome-icon class="icon" :icon="tile.icon" /> {{ tile.text }}
          <div class="w-100 px-3">
            <TarProgress
              :animated="tile.progress < 1"
              :label="tile.progress >= 1 ? '✓' : undefined"
              :striped="tile.progress < 1"
              :value="tile.progress * 100"
            />
          </div>
        </NuxtLink>
      </div>
    </div>
  </main>
</template>

<script setup lang="ts">
import type { RouteLocationAsPathGeneric, RouteLocationAsRelativeGeneric } from "vue-router";

import { Icons } from "~/types/constants";

type Tile = {
  icon: string;
  text: string;
  to: string | RouteLocationAsRelativeGeneric | RouteLocationAsPathGeneric;
  progress: number;
};

const tiles: Tile[] = [
  {
    icon: "fas fa-id-card",
    text: "Personnages",
    to: "/regles/personnages",
    progress: 1,
  },
  {
    icon: "fas fa-chart-simple",
    text: "Attributs",
    to: "/regles/attributs",
    progress: 1,
  },
  {
    icon: "fas fa-magnifying-glass-chart",
    text: "Statistiques",
    to: "/regles/statistiques",
    progress: 1,
  },
  {
    icon: Icons.skill,
    text: "Compétences",
    to: "/regles/competences",
    progress: 1,
  },
  {
    icon: "fas fa-paw",
    text: "Espèces",
    to: "/regles/especes",
    progress: (2 + 1) / 22,
  },
  {
    icon: "fas fa-wheelchair",
    text: "Dons & Handicaps",
    to: "/regles/dons-handicaps",
    progress: (1 + 2) / 47,
  },
  {
    icon: "fas fa-screwdriver-wrench",
    text: "Castes",
    to: "/regles/castes",
    progress: (1 + 1) / 11,
  },
  {
    icon: "fas fa-graduation-cap",
    text: "Éducations",
    to: "/regles/educations",
    progress: 1 / 11,
  },
  {
    icon: Icons.talent,
    text: "Talents",
    to: "/regles/talents",
    progress: (3 + 108) / 179,
  },
  {
    icon: "fas fa-landmark",
    text: "Spécialisations",
    to: "/regles/specialisations",
    progress: (3 + 5) / 60,
  },
  {
    icon: "fas fa-language",
    text: "Langues",
    to: "/regles/langues",
    progress: (0 + 0) / 22,
  },
  {
    icon: "fas fa-cart-shopping",
    text: "Équipement",
    to: "/regles/equipement",
    progress: 1,
  },
  {
    icon: "fas fa-person-hiking",
    text: "Aventure",
    to: "/regles/aventure",
    progress: 1,
  },
  {
    icon: "fas fa-hand-fist",
    text: "Combat",
    to: "/regles/combat",
    progress: 1,
  },
  {
    icon: "fas fa-wand-sparkles",
    text: "Magie",
    to: "/regles/magie",
    progress: 1,
  },
  {
    icon: "fas fa-book",
    text: "Annexes",
    to: "#",
    progress: 0,
  },
];
const title: string = "Règles";

useSeo({
  title,
  description: "Découvrez les règles de SkillCraft : création de personnage, attributs, compétences, castes, espèces, talents et plus encore.",
});
</script>

<style scoped>
.grid {
  display: grid;
  grid-template-columns: repeat(var(--columns), var(--column-width));
  gap: var(--gap);
  max-width: calc(var(--columns) * var(--column-width) + (var(--columns) - 1) * var(--gap));
  margin-bottom: var(--gap);
  --columns: 1;
  --gap: 1.5rem;
  --column-width: 13.5rem;
  --column-height: 13.5rem;
}

.tile {
  box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
  background-color: var(--bs-tertiary-bg);
  border: 1px solid var(--bs-border-color);
  border-radius: 0.75rem;
  width: 100%;
  max-width: var(--column-width);
  height: var(--column-height);
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  font-size: 1.5rem;
  text-decoration: none;
  gap: 0.5rem;
}
.tile:hover {
  background-color: var(--bs-secondary-bg);
  cursor: pointer;
}
.tile .icon {
  font-size: 4.5rem;
}

@media (min-width: 576px) {
  .grid {
    --columns: 2;
  }
}

@media (min-width: 768px) {
  .grid {
    --columns: 3;
  }
}

@media (min-width: 992px) {
  .grid {
    --columns: 4;
  }
}
</style>
