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
        <LinkCard class="d-flex flex-column h-100" :text="domain.description" :title="domain.title" :to="domain.path" />
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
      path: "#",
      title: "Ancêtres",
      description: "🚧",
    },
    {
      path: "#",
      title: "Astres",
      description: "🚧",
    },
    {
      path: "/regles/domaines/animisme/berger",
      title: "Berger",
      description: "Totems animaux, auras protectrices et invocations puissantes au service du Berger.",
    },
    {
      path: "#",
      title: "Lune",
      description: "🚧",
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
      path: "#",
      title: "Feu (Spirituel)",
      description: "🚧",
    },
    {
      path: "#",
      title: "Rêves (Naturel)",
      description: "🚧",
    },
  ],
};

type Spells = {
  tier0: MenuItem[];
  tier1: MenuItem[];
};
const spells: Spells = {
  tier0: [
    // {
    //   path: "/regles/magie/pouvoirs/flammes-feeriques",
    //   title: "Flammes féériques",
    //   description: "Feux féeriques, auras révélatrices et flammes radiantes poursuivant les cibles.",
    // }, // Naturel
    // {
    //   path: "/regles/magie/pouvoirs/frisson",
    //   title: "Frisson",
    //   description: "Main spectrale, mot d’effroi ou onde vitale infligeant peur, drains ou soins.",
    // }, // Spirituel
    // {
    //   path: "/regles/magie/pouvoirs/habiletes-feeriques",
    //   title: "Habiletés féériques",
    //   description: "Effets féeriques, réparation d’objets, vision nocturne et croissance végétale.",
    // }, // Naturel
    // {
    //   path: "/regles/magie/pouvoirs/preservation",
    //   title: "Préservation",
    //   description: "Stabilise un mourant, préserve un corps ou simule la mort pour protéger.",
    // }, // Spirituel
    {
      path: "/regles/magie/pouvoirs/resistance-elementaire",
      title: "Résistance élémentaire",
      description: "Renforce les sauvegardes, absorbe l’élément reçu et confère une résistance durable.",
    },
    {
      path: "/regles/magie/pouvoirs/souffle-empoisonne",
      title: "Souffle empoisonné",
      description: "Souffle toxique infligeant du poison, purge l’empoisonnement ou frappe en cône.",
    },
    {
      path: "/regles/magie/pouvoirs/vignes-epineuses",
      title: "Vignes épineuses",
      description: "Fouet de ronces, zone entravante ou ronces camouflées infligeant des dégâts.",
    },
  ],
  tier1: [
    // {
    //   path: "/regles/magie/pouvoirs/affaiblissement",
    //   title: "Affaiblissement",
    //   description: "Attaques nécrotiques affaiblissant, empoisonnant ou privant une cible de sens.",
    // }, // Spirituel
    {
      path: "/regles/magie/pouvoirs/augmentation-naturelle",
      title: "Augmentation naturelle",
      description: "Bénédictions animales variées, respiration aquatique et formes druidiques puissantes.",
    },
    {
      path: "/regles/magie/pouvoirs/liberte",
      title: "Liberté",
      description: "Mobilité accrue, évasion totale et déplacement sans contraintes.",
    },
    {
      path: "/regles/magie/pouvoirs/protection-contre-la-magie",
      title: "Protection contre la magie",
      description: "Détection, dissipation et interruption des effets magiques adverses.",
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
