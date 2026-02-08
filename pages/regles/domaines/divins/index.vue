<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Lorsque le personnage acquiert le talent <NuxtLink to="/regles/talents/spiritualite">Spiritualité</NuxtLink>, il peut sélectionner un
      <strong>domaine divin</strong> ou un <NuxtLink to="/regles/domaines/animisme">domaine d’animisme</NuxtLink>. Il ne peut acquérir qu’un seul de ces
      domaines et ne peut jamais changer celui-ci.
    </p>
    <p>
      Lorsqu’il sélectionne un domaine divin, il acquiert la capacité de <NuxtLink to="/regles/personnages/progression/tiers">tiers 0</NuxtLink> associée à ce
      domaine. Il peut désormais acquérir les <NuxtLink to="/regles/magie/pouvoirs">pouvoirs</NuxtLink> de tiers 0 associés à celui-ci et acquiert gratuitement
      un de ces pouvoirs.
    </p>
    <ul>
      <li>
        Lorsqu’il acquiert la spécialisation <NuxtLink to="/regles/specialisations/clerc">Clerc</NuxtLink>, il acquiert la capacité de tiers 1 associée à ce
        domaine divin, et peut désormais invoquer le <strong>pouvoir divin</strong> associé à ce domaine.
      </li>
      <li>
        Lorsqu’il acquiert la spécialisation <NuxtLink to="/regles/specialisations/pretre">Prêtre</NuxtLink>, il acquiert la capacité de tiers 2 associée à ce
        domaine, et peut désormais effectuer une <strong>attaque divine</strong> infligeant des
        <NuxtLink to="/regles/combat/degats">points de dégâts</NuxtLink> du <NuxtLink to="/regles/combat/degats/types">type</NuxtLink> spécifié par ce domaine.
      </li>
    </ul>
    <h2 class="h3">Liste des domaines</h2>
    <div class="row">
      <div v-for="(item, index) in items" :key="index" class="col-xs-12 col-sm-6 col-md-4 col-lg-3 mb-4">
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
    <h3 class="h5">Pouvoirs de tiers 2</h3>
    <div class="row">
      <div v-for="(spell, index) in spells.tier2" :key="index" class="col-xs-12 col-sm-6 col-md-4 mb-4">
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
    path: "/regles/domaines/divins/arcanes",
    title: "Arcanes",
    description: "Domaine divin dédié à la magie, aux mystères et à la maîtrise des secrets.",
  },
  {
    path: "/regles/domaines/divins/forge",
    title: "Forge",
    description: "Pouvoirs sacrés de forge, bénédictions d’armes et maîtrise artisanale.",
  },
  {
    path: "/regles/domaines/divins/guerre",
    title: "Guerre",
    description: "Domaine divin martial offrant bonus et prières de combat.",
  },
  {
    path: "/regles/domaines/divins/lumiere",
    title: "Lumière",
    description: "Domaine divin radiant dédié à la purification et à la protection.",
  },
  {
    path: "/regles/domaines/divins/mort",
    title: "Mort",
    description: "Domaine divin lié au cycle de la vie et aux pouvoirs nécrotiques.",
  },
  {
    path: "/regles/domaines/divins/nature",
    title: "Nature",
    description: "Domaine divin dédié à la nature, l’animisme et la protection.",
  },
  {
    path: "/regles/domaines/divins/obscurite",
    title: "Obscurité",
    description: "Domaine divin du crépuscule, du repos et de la pénombre.",
  },
  {
    path: "/regles/domaines/divins/ordre",
    title: "Ordre",
    description: "Domaine divin de la loi, de la paix, de l’union et de l’autorité.",
  },
  {
    path: "/regles/domaines/divins/supercherie",
    title: "Supercherie",
    description: "Domaine divin lié à la ruse, aux illusions, aux ombres et aux charmes.",
  },
];

type Spells = {
  tier0: MenuItem[];
  tier1: MenuItem[];
  tier2: MenuItem[];
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
    {
      path: "/regles/magie/pouvoirs/preservation",
      title: "Préservation",
      description: "Stabilise un mourant, préserve un corps ou simule la mort pour protéger.",
    },
    {
      path: "/regles/magie/pouvoirs/thaumaturgie",
      title: "Thaumaturgie",
      description: "Effets mineurs, réparation d’objets et prières soignantes pour plusieurs alliés.",
    },
  ],
  tier1: [
    {
      path: "/regles/magie/pouvoirs/guerison",
      title: "Guérison",
      description: "Guérit une ou plusieurs créatures au toucher ou par un mot à distance.",
    },
    {
      path: "/regles/magie/pouvoirs/protection-contre-la-magie",
      title: "Protection contre la magie",
      description: "Détection, dissipation et interruption des effets magiques adverses.",
    },
    {
      path: "/regles/magie/pouvoirs/protection-contre-le-bien-et-le-mal",
      title: "Protection contre le bien et le mal",
      description: "Détection et protection contre les créatures surnaturelles hostiles.",
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
  tier2: [
    {
      path: "/regles/magie/pouvoirs/esprits-gardiens",
      title: "Esprits gardiens",
      description: "Esprits protecteurs infligeant des dégâts et entravant les ennemis.",
    },
  ],
};

useSeo({
  title,
  description: "🚧",
});
</script>
