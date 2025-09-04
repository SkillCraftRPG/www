<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Les <NuxtLink to="/regles/equipement/armures">armures</NuxtLink> et <NuxtLink to="/regles/equipement/boucliers">boucliers</NuxtLink> sont dotés d’une
      valeur de Résistance, indiquée dans la colonne <i>Résistance</i>.
    </p>
    <p>Chaque fois qu’une armure ou un bouclier est <strong>percuté</strong>, cette valeur diminue de 1.</p>
    <p>
      Lorsque cette valeur chute à 0, l’objet est brisé. Il ne confère plus ses <NuxtLink to="/regles/equipement/defense">points de Défense</NuxtLink>, ni les
      bonus octroyés par exemple par ses <NuxtLink to="/regles/equipement/armures/proprietes">propriétés</NuxtLink>. L’acte de
      <NuxtLink to="/regles/equipement/reparation">réparer</NuxtLink> l’objet restaure ces bonus.
    </p>
    <p>Si le personnage est protégé par un bouclier et une ou plusieurs armures, alors il utilise d’abord son bouclier pour parer un coup.</p>
    <p>
      Lorsqu’il porte des <NuxtLink to="/regles/equipement/armures/multiples">armures multiples</NuxtLink>, c’est l’armure appartenant à la catégorie la plus
      légère qui voit sa Résistance diminuer en premier.
    </p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [{ text: "Équipement", to: "/regles/equipement" }];
const title: string = "Résistance";

useSeo({
  title,
  description: "Découvrez le rôle de la Résistance des armures et boucliers, comment elle diminue à chaque coup et l’impact des réparations en jeu.",
});
</script>
