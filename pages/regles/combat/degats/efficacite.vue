<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Certains <NuxtLink to="/regles/aventure/interaction-objets">objets</NuxtLink> ou certaines créatures réagissent différemment aux dégâts de certains
      <NuxtLink to="/regles/combat/degats/types">types</NuxtLink>.
    </p>
    <ul>
      <li>
        <strong>Résistance.</strong> Lorsqu’une créature ou un objet résistant à un type de dégâts reçoit des points de dégâts de ce type, ceux-ci sont réduits
        de moitié. Cette division s’effectue à la fin du calcul, après l’application de tous les autres modificateurs.
      </li>
      <li>
        <strong>Vulnérabilité.</strong> Lorsqu’une créature ou un objet vulnérable à un type de dégâts reçoit des points de dégâts de ce type, ceux-ci sont
        doublés. Cette multiplication s’effectue à la fin du calcul, après l’application de tous les autres modificateurs.
      </li>
      <li>
        <strong>Immunité.</strong> Lorsqu’une créature ou un objet immunisé à un type de dégâts reçoit des points de dégâts de ce type, ceux-ci sont réduits à
        0.
      </li>
    </ul>
    <p>
      Lorsqu’une créature bénéficie de plusieurs résistances à une même source de dégâts, ou qu’elle est affligée de plusieurs vulnérabilités à la même source,
      alors une seule instance s’applique. Si elle est vulnérable et résistante à une même source de dégâts, aucune de ces conditions ne s’applique.
    </p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Combat", to: "/regles/combat" },
  { text: "Dégâts", to: "/regles/combat/degats" },
];
const title: string = "Efficacité";

useSeo({
  title,
  description: "Découvrez comment résistance, vulnérabilité et immunité influencent les dégâts subis selon le type d’attaque ou de pouvoir.",
});
</script>
