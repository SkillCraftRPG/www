<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>Certaines créatures sont résistantes ou immunisées aux armes physiques sont vulnérables à l’argent.</p>
    <p>Certains aventuriers prennent donc le soin de faire plaquer leurs armes de ce métal.</p>
    <p>
      Le personnage peut faire effectuer ce plaquage par un forgeron maîtrisant son art au coût de
      <NuxtLink to="/regles/equipement/monnaie">100 deniers</NuxtLink> par arme ou pour 10 munitions.
    </p>
    <p>Ce coût inclut les matériaux, la connaissance, l’expertise et le temps nécessaire afin d’effectuer ces travaux sans nuire à l’efficacité de l’arme.</p>
    <p>Un certain dicton populaire dirait même « l’acier pour les hommes, l’argent pour les monstres ».</p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Équipement", to: "/regles/equipement" },
  { text: "Armes", to: "/regles/equipement/armes" },
];
const title: string = "Plaquage d’argent";

useSeo({
  title,
  description: "Découvrez comment le plaquage en argent permet de vaincre des créatures résistantes aux armes ordinaires et son coût pour armes et munitions.",
});
</script>
