<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Lorsque le personnage acquiert le talent <NuxtLink to="/regles/talents/spiritualite">Spiritualité</NuxtLink>, il peut sélectionner un
      <NuxtLink to="/regles/domaines/divins">domaine divin</NuxtLink> ou un <strong>domaine d’animisme</strong>. Il ne peut acquérir qu’un seul de ces domaines
      et ne peut jamais changer celui-ci.
    </p>
    <p>Les domaines d’animisme sont associés à une ou deux catégories : <strong>naturel</strong> et <strong>spirituel</strong>.</p>
    <ul>
      <li>
        Les domaines naturels lui permettent d’acquérir les spécialisations <NuxtLink to="/regles/specialisations/druide">Druide</NuxtLink> et
        <NuxtLink to="/regles/specialisations/archidruide">Archidruide</NuxtLink>, qui lui confèrent respectivement une capacité de tiers 2 et deux capacités de
        tiers 3 associées à ce domaine.
      </li>
      <li>
        Les domaines spirituels lui permettent d’acquérir les spécialisations <NuxtLink to="/regles/specialisations/chaman">Chaman</NuxtLink> et
        <NuxtLink to="/regles/specialisations/totem">Totem</NuxtLink>, qui lui confèrent respectivement une capacité de tiers 2 et deux capacités de tiers 3
        associées à ce domaine.
      </li>
    </ul>
    <p>
      Lorsque le personnage sélectionne un domaine d’animisme, il doit sélectionner une des catégories associées à ce domaine. Il ne peut sélectionner qu’une
      seule catégorie et ne peut jamais changer celle-ci.
    </p>
    <p>
      Il acquiert la capacité de <NuxtLink to="/regles/personnages/progression/tiers">tiers 0</NuxtLink> associée à ce domaine. Il peut désormais acquérir les
      <NuxtLink to="/regles/magie/pouvoirs">pouvoirs</NuxtLink> de tiers 0 associés à la catégorie sélectionnée et acquiert gratuitement un de ces pouvoirs.
    </p>
    <p>
      Lorsqu’il acquiert la spécialisation <NuxtLink to="/regles/specialisations/animiste">Animiste</NuxtLink>, le personnage acquiert la capacité de tiers 1
      associée à ce domaine d’animisme.
    </p>
    <h2 class="h3">Liste des domaines</h2>
    <p>Les domaines suivants sont associés aux deux catégories (naturel et spirituel).</p>
    <div class="row">
      <div v-for="(domain, index) in domains.generic" :key="index" class="col-xs-12 col-sm-6 col-md-4 mb-4">
        <LinkCard class="d-flex flex-column h-100" :text="domain.description" :title="domain.title" :to="domain.path" />
      </div>
    </div>
    <h3 class="h5">Domaines spécifiques</h3>
    <p>Les domaines suivants sont associés à une seule catégorie.</p>
    <div class="row">
      <div v-for="(domain, index) in domains.specific" :key="index" class="col-xs-12 col-sm-6 mb-4">
        <LinkCard class="d-flex flex-column h-100" :text="domain.description" :title="`${domain.title} (${domain.category})`" :to="domain.path" />
      </div>
    </div>
    <template v-if="spells.length">
      <h2 class="h3">Liste des pouvoirs</h2>
      <SpellList :category="category" :items="spells" />
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
const title: string = "Domaines d’animisme";

type MenuItem = {
  path: string;
  title: string;
  description: string;
};

type Domain = MenuItem & {
  category?: "Naturel" | "Spirituel";
};
type Domains = {
  generic: Domain[];
  specific: Domain[];
};
const domains: Domains = {
  generic: [
    {
      path: "/regles/domaines/animisme/ancetres",
      title: "Ancêtres",
      description: "Esprits ancestraux, rites funéraires et lien sacré avec le compagnon primordial.",
    },
    {
      path: "/regles/domaines/animisme/astres",
      title: "Astres",
      description: "Constellations vivantes, forme étoilée et présages guidés par le ciel nocturne.",
    },
    {
      path: "/regles/domaines/animisme/berger",
      title: "Berger",
      description: "Totems animaux, auras protectrices et invocations puissantes au service du Berger.",
    },
    {
      path: "/regles/domaines/animisme/lune",
      title: "Lune",
      description: "Métamorphoses bestiales, puissance nocturne et formes sauvages lunaires.",
    },
    {
      path: "/regles/domaines/animisme/mycetes",
      title: "Mycètes",
      description: "Spores nécrotiques, forme fongique, zombification et nuages toxiques des Mycètes.",
    },
    {
      path: "/regles/domaines/animisme/terre",
      title: "Terre",
      description: "Sérénité, déplacements fluides, immunités et harmonie avec la nature sauvage.",
    },
  ],
  specific: [
    {
      path: "/regles/domaines/animisme/feu",
      title: "Feu",
      category: "Spirituel",
      description: "Esprit incendiaire, flammes sacrées et renouveau par la destruction.",
    },
    {
      path: "/regles/domaines/animisme/reves",
      title: "Rêves",
      category: "Naturel",
      description: "Magie féérique, ombres et voyages à travers les rêves.",
    },
  ],
};

const category: string = SpellCategories.Animism;
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
  description:
    "Découvrez les Domaines d’animisme, liés aux forces naturelles et spirituelles, et choisissez la voie qui façonne vos pouvoirs et votre lien au monde.",
});
</script>
