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
    <template v-if="spells.length">
      <h2 class="h3">Liste des pouvoirs</h2>
      <SpellList :items="spells" />
    </template>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";
import type { SearchResults } from "~/types/game";
import type { Spell } from "~/types/magic";
import { SpellCategories } from "~/types/constants";

const config = useRuntimeConfig();
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
    path: "/regles/domaines/divins/savoir",
    title: "Savoir",
    description: "Domaine divin de la connaissance, de la mémoire et de l’apprentissage.",
  },
  {
    path: "/regles/domaines/divins/supercherie",
    title: "Supercherie",
    description: "Domaine divin lié à la ruse, aux illusions, aux ombres et aux charmes.",
  },
  {
    path: "/regles/domaines/divins/tempete",
    title: "Tempête",
    description: "Domaine divin axé sur la foudre, la riposte et la force des tempêtes.",
  },
  {
    path: "/regles/domaines/divins/vie",
    title: "Vie",
    description: "Domaine divin axé sur la guérison, la vitalité et la protection des vivants.",
  },
];

const category: string = SpellCategories.Divine;
const { data } = await useLazyAsyncData<SearchResults<Spell>>(
  `spells:${category}`,
  () =>
    $fetch(`/api/spells?category=${category}`, {
      baseURL: config.public.apiBaseUrl,
    }),
  {
    server: false,
  },
);

const spells = computed<Spell[]>(() => data.value?.items ?? []);

useSeo({
  title,
  description: "Découvrez les Domaines divins, sources de pouvoirs sacrés et d’attaques divines, liés aux principes majeurs façonnant foi, magie et destinée.",
});
</script>
