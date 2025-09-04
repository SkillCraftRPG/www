<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Un personnage portant un <NuxtLink to="/regles/equipement/armures">armure</NuxtLink> ou un
      <NuxtLink to="/regles/equipement/boucliers">bouclier</NuxtLink> en bon état se voit conférer un bonus à la <strong>Défense</strong>.
    </p>
    <p>Ces points sont cumulables entre-eux, c’est-à-dire qu’un personnage peut bénéficier de bonus de points de Défense de plusieurs armures et boucliers.</p>
    <p>Si l’objet est <strong>brisé</strong>, alors il ne confère aucun bonus de Défense.</p>
    <p>Ce bonus est indiqué dans la colonne <i>Défense</i> de chaque objet.</p>
    <p>
      Certaines situations ont un impact sur les points de Défense conférés, par exemple une
      <NuxtLink to="/regles/equipement/armures/partielles">armure partielle</NuxtLink> ou des
      <NuxtLink to="/regles/equipement/armures/multiples">armures multiples</NuxtLink>.
    </p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [{ text: "Équipement", to: "/regles/equipement" }];
const title: string = "Défense";

useSeo({
  title,
  description: "Découvrez comment les armures et boucliers confèrent des points de Défense, leurs limites et les effets d’un objet brisé en combat.",
});
</script>
