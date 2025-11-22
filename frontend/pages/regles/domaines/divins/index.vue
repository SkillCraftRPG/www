<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Lorsque le personnage acquiert le talent <NuxtLink to="/regles/talents/spiritualite">Spiritualité</NuxtLink>, il peut sélectionner un
      <strong>domaine divin</strong> ou un <NuxtLink to="/regles/domaines/animisme">domaine d'animisme</NuxtLink>. Il ne peut acquérir qu’un seul de ces
      domaines et ne peut jamais changer celui-ci.
    </p>
    <p>
      Lorsqu’il sélectionne un domaine divin, il acquiert la capacité de <NuxtLink to="/regles/personnages/progression/tiers">tiers 0</NuxtLink> de ce domaine
      divin, un <NuxtLink to="/regles/magie/pouvoirs">pouvoir</NuxtLink> associé à celui-ci, et peut désormais acquérir les pouvoirs de tiers 0 de ce domaine.
    </p>
    <ul>
      <li>
        Lorsqu’il acquiert la spécialisation <NuxtLink to="/regles/specialisations/clerc">Clerc</NuxtLink>, il acquiert la capacité de tiers 1 de ce domaine
        divin, et peut désormais invoquer le <strong>pouvoir divin</strong> de ce domaine.
      </li>
      <li>
        Lorsqu’il acquiert la spécialisation <NuxtLink to="/regles/specialisations/pretre">Prêtre</NuxtLink>, il acquiert la capacité de tiers 2 de ce domaine,
        et peut désormais effectuer une <strong>attaque divine</strong> infligeant des <NuxtLink to="/regles/combat/degats">points de dégâts</NuxtLink> du
        <NuxtLink to="/regles/combat/degats/types">type</NuxtLink> spécifié par ce domaine.
      </li>
    </ul>
    <h2 class="h3">Liste des domaines</h2>
    <div class="row">
      <div v-for="(item, index) in items" :key="index" class="col-xs-12 col-sm-6 col-md-4 mb-4">
        <LinkCard class="d-flex flex-column h-100" :text="item.description" :title="item.title" :to="item.path" />
      </div>
    </div>
    <h2 class="h3">Liste des pouvoirs</h2>
    <h3 class="h5">Pouvoirs de tiers 0</h3>
    <div class="row">
      <div v-for="(spell, index) in spells.tier0" :key="index" class="col-xs-12 col-sm-6 col-md-4 mb-4">
        <LinkCard class="d-flex flex-column h-100" :text="spell.description" :title="spell.title" :to="spell.path" />
      </div>
    </div>
    <h3 class="h5">Pouvoirs de tiers 1</h3>
    <div class="row">
      <div v-for="(spell, index) in spells.tier1" :key="index" class="col-xs-12 col-sm-6 col-md-4 mb-4">
        <LinkCard class="d-flex flex-column h-100" :text="spell.description" :title="spell.title" :to="spell.path" />
      </div>
    </div>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [{ text: "Annexes", to: "/regles/annexes" }];
const title: string = "Domaines divins";

type MenuItem = {
  path: string;
  title: string;
  description: string;
};
const items: MenuItem[] = [
  {
    path: "/regles/domaines/divins/forge",
    title: "Forge",
    description: "Pouvoirs sacrés de forge, bénédictions d’armes et maîtrise artisanale inspirée du métal.",
  },
  {
    path: "/regles/domaines/divins/supercherie",
    title: "Supercherie",
    description: "Ruse, illusions, ombres et charmes : les pouvoirs maîtres du domaine de Supercherie.",
  },
];

type Spells = {
  tier0: MenuItem[];
  tier1: MenuItem[];
};
const spells: Spells = {
  tier0: [
    {
      path: "/regles/magie/pouvoirs/benediction",
      title: "Bénédiction",
      description: "Octroie un bonus sacré aux alliés ou inflige un malus maudit aux ennemis.",
    },
    {
      path: "/regles/magie/pouvoirs/flamme-sacree",
      title: "Flamme sacrée",
      description: "Frappe une cible d’une flamme divine et facilite la prochaine attaque.",
    },
    {
      path: "/regles/magie/pouvoirs/lumiere",
      title: "Lumière",
      description: "Illumine un objet ou crée une sphère de lumière mobile.",
    },
  ],
  tier1: [
    {
      path: "/regles/magie/pouvoirs/guerison",
      title: "Guérison",
      description: "Guérit une ou plusieurs créatures au toucher ou par un mot à distance.",
    },
    {
      path: "/regles/magie/pouvoirs/protection-contre-les-poisons-et-maladies",
      title: "Protection contre les poisons et maladies",
      description: "Détecte et purge toxines, puis crée eau et nourriture pour tout un groupe.",
    },
    {
      path: "/regles/magie/pouvoirs/restauration",
      title: "Restauration",
      description: "Purifie une créature en levant maladies, malédictions ou afflictions.",
    },
  ],
};

useSeo({
  title,
  description: "🚧",
});
</script>
