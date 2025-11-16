<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>L’habileté du personnage à percevoir les objets et événements de son environnement est gouvernée par le niveau de lumière.</p>
    <h2 class="h3">Zone obscurcie</h2>
    <p>
      Une zone <strong>légèrement obscurcie</strong> impose le <NuxtLink to="/regles/competences/tests/avantage-desavantage">désavantage</NuxtLink> aux
      <NuxtLink to="/regles/competences/tests">tests</NuxtLink> de <NuxtLink to="/regles/competences/perception">Perception</NuxtLink> en lien avec la vision
      effectués dans la zone. Voici des exemples de zones légèrement obscurcies : brouillard léger, végétation dense, pénombre.
    </p>
    <p>
      Une zone <strong>lourdement obscurcie</strong> <NuxtLink to="/regles/combat/conditions/aveugle">aveugle</NuxtLink> les créatures à l’intérieur de
      celle-ci. Voici des exemples de zones lourdement obscurcies : brouillard épais, tempête, obscurité.
    </p>
    <h2 class="h3">Lumière</h2>
    <p>
      La plupart des activités se produisent à la <strong>clarté</strong>, la lumière produite par exemple par le Soleil ou à proximité d’une torche, d’une
      lanterne ou d’un feu de camp.
    </p>
    <p>
      Une zone de <strong>pénombre</strong> (<i>légèrement obscurcie</i>) est décrite par une lumière qui est plus faible, par exemple à l’aube ou au
      crépuscule, sous une Lune brillante ou à une certaine distance d’une lanterne ou d’un feu de camp la nuit.
    </p>
    <p>Un emplacement dans le noir complet, sans source de lumière, est dans l’<strong>obscurité</strong> (<i>lourdement obscurci</i>).</p>
    <h3 class="h5">Ténèbres</h3>
    <p>
      Les <strong>ténèbres</strong> sont une zone d’obscurité magique créée par certaines capacités ou certains
      <NuxtLink to="/regles/magie/pouvoirs">pouvoirs</NuxtLink>. Elles ne laissent passer aucune lumière, qu’elle soit naturelle ou artificielle, sauf lorsque
      spécifié autrement.
    </p>
    <p>
      De manière générale, elles sont dissipées lorsque leur zone entre en contact avec une zone de lumière magique de
      <NuxtLink to="/regles/magie/pouvoirs/niveau">niveau</NuxtLink> supérieur ou égal.
    </p>
    <h2 class="h3">Types de vision</h2>
    <p>
      L’essentiel des actions d’un aventurier dépend de sa capacité à voir. L’obscurité, ou tout effet nuisant à sa vision, constitue donc un obstacle à sa
      réussite.
    </p>
    <h3 class="h5">Vision aveugle</h3>
    <p>Une créature dotée de <strong>vision aveugle</strong> peut percevoir son environnement sans yeux.</p>
    <h3 class="h5">Vision dans le noir</h3>
    <p>
      Une créature dotée de <strong>vision dans le noir</strong> est avantagée dans une zone obscurcie. Elle ne peut pas voir dans les ténèbres. À une certaine
      distance :
    </p>
    <ul>
      <li>Une zone de pénombre (légèrement obscurcie) est considérée comme à la clarté (non obscurcie).</li>
      <li>Une zone d’obscurité (lourdement obscurcie) est considérée comme une zone de pénombre (légèrement obscurcie).</li>
    </ul>
    <h3 class="h5">Vision absolue</h3>
    <p>Une créature dotée de <strong>vision absolue</strong> acquiert également les capacités suivantes.</p>
    <ul>
      <li>Elle peut voir dans la pénombre, l’obscurité et dans les ténèbres comme si elle était à la clarté.</li>
      <li>Elle peut voir les objets et créatures <NuxtLink to="/regles/combat/conditions/invisible">invisibles</NuxtLink>.</li>
      <li>
        Elle détecte les illusions visuelles et réussit automatiquement ses
        <NuxtLink to="/regles/competences/tests/sauvegarde">jets de sauvegarde</NuxtLink> contre ces illusions.
      </li>
      <li>Elle voit sous leur forme normale les créatures métamorphosées.</li>
      <li>Elle peut voir dans la dimension spirituelle.</li>
    </ul>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Aventure", to: "/regles/aventure" },
  { text: "Environnement", to: "/regles/aventure/environnement" },
];
const title: string = "Vision";

useSeo({
  title,
  description: "Découvrez l’impact de la lumière et des types de vision sur la perception : obscurité, pénombre, vision dans le noir, aveugle ou absolue.",
});
</script>
