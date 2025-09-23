<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb active="Multiples" :parent="parent" />
    <p>Un personnage possédant la formation appropriée peut porter deux armures simultanément.</p>
    <p>Il est impossible de porter deux couches d’armure appartenant à la même catégorie.</p>
    <p>
      Lorsqu’un personnage porte deux couches d’armure, les morceaux de l’armure appartenant à la catégorie la plus légère n’offrent que la moitié des
      <NuxtLink to="/regles/equipement/defense">points de Défense</NuxtLink>.
    </p>
    <p>
      S’il porte deux armures <NuxtLink to="/regles/equipement/armures/partielles">complètes</NuxtLink>, alors il bénéficie des
      <NuxtLink to="/regles/equipement/armures/proprietes">propriétés</NuxtLink> combinées des deux armures.
    </p>
    <template v-if="talent">
      <p>Le talent suivant forme le personnage au port de deux couches d’armure :</p>
      <TalentCard class="mb-4" :talent="talent" />
    </template>
    <h2 class="h3">Exemples</h2>
    <p>Voici quelques exemples de port d’armures multiples.</p>
    <ul>
      <li>
        Un personnage porte deux couches d’armure sans être formé. Il est donc affligé des pénalités
        <NuxtLink to="/regles/equipement/armures/formation">sans formation</NuxtLink>, même s’il est formé pour chaque armure individuellement.
      </li>
      <li>Un personnage ne peut porter un plastron sous une peau d’animal, car ces deux armes appartiennent à la même catégorie.</li>
      <li>
        Un personnage porte une plate complète et une cotte de mailles. La cotte de mailles ne confère que la moitié de ses points de Défense, soit 1. Les deux
        armures confèrent un bonus de 9 à la Défense au personnage.
      </li>
      <li>
        Un personnage porte une brigande par-dessus une plate partielle. La brigandine confère un point de Défense (exception), pour une Défense totale de 6.
      </li>
      <li>
        Un personnage porte une armure de cuir ainsi qu’une plate complète. Les deux armures sont complètes. L’armure de cuir ne confère aucun point de Défense,
        mais la propriété <i>Matelassée</i> s’applique tant que l’armure de cuir n’est pas brisée.
      </li>
    </ul>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";
import type { Talent } from "~/types/game";

const config = useRuntimeConfig();
const parent: Breadcrumb[] = [
  { text: "Équipement", to: "/regles/equipement" },
  { text: "Armures", to: "/regles/equipement/armures" },
];
const title: string = "Armures multiples";

const { data } = await useAsyncData<Talent>("talents", () =>
  $fetch("/api/talents/slug:blinde", {
    baseURL: config.public.apiBaseUrl,
  }),
);
const talent = computed<Talent | undefined>(() => data.value ?? undefined);

useSeo({
  title,
  description: "Découvrez les règles pour porter deux couches d’armure et combiner leurs effets.",
});
</script>
