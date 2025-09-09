<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb active="Mêlée" :parent="parent" />
    <p>Une créature bénéficie d’un abri lorsqu’un obstacle se dresse entre elle et son attaquant.</p>
    <p>
      Afin de déterminer le type d’abri dont elle bénéficie, tracez une ligne imaginaire depuis l’attaquant jusqu’à chaque sommet de la ou des
      <NuxtLink to="/regles/aventure/mouvement/espace-occupe">cases occupées</NuxtLink> par la cible, puis comptez le nombre de lignes bloquées par l’obstacle.
    </p>
    <p>Une créature peut bénéficier de plusieurs abris à la fois, mais seulement les effets de l’abri le plus élevé s’appliquent.</p>
    <table class="table table-striped text-center">
      <thead>
        <tr>
          <th scope="col" class="w-20">Type d’abri</th>
          <th scope="col" class="w-20">Lignées bloquées (carrés)</th>
          <th scope="col" class="w-20">Lignées bloquées (hexagones)</th>
          <th scope="col" class="w-40">Effets</th>
        </tr>
      </thead>
      <tbody>
        <tr>
          <td>Demi-abri</td>
          <td>2</td>
          <td>3</td>
          <td>
            Bonus (+2) à la <NuxtLink to="/regles/combat/attaque/defense">Défense</NuxtLink> et aux
            <NuxtLink to="/regles/competences/tests/sauvegarde">jets de sauvegarde</NuxtLink> d’<NuxtLink to="/regles/competences/acrobaties"
              >Acrobaties</NuxtLink
            >.
          </td>
        </tr>
        <tr>
          <td>Abri aux trois-quarts</td>
          <td>3</td>
          <td>4</td>
          <td>
            Bonus (+5) à la <NuxtLink to="/regles/combat/attaque/defense">Défense</NuxtLink> et aux
            <NuxtLink to="/regles/competences/tests/sauvegarde">jets de sauvegarde</NuxtLink> d’<NuxtLink to="/regles/competences/acrobaties"
              >Acrobaties</NuxtLink
            >.
          </td>
        </tr>
        <tr>
          <td>Abri total</td>
          <td>4</td>
          <td>6</td>
          <td>Ne peut être ciblée par l’attaque ou le <NuxtLink to="/regles/magie/pouvoirs">pouvoir</NuxtLink>.</td>
        </tr>
      </tbody>
    </table>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Combat", to: "/regles/combat" },
  { text: "Attaque", to: "/regles/combat/attaque" },
];
const title: string = "Abri";

useSeo({
  title,
  description: "Découvrez les règles d’abri : demi-abri, trois-quarts et abri total, avec lignes bloquées et bonus de défense ou protection complète.",
});
</script>
