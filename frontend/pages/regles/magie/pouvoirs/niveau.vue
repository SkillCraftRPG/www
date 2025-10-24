<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>Un pouvoir se décline en plusieurs niveaux en fonction de son tiers.</p>
    <p>Une créature ne peut canaliser un pouvoir qu’au niveau de base.</p>
    <p>
      Le <NuxtLink to="/regles/talents">talent</NuxtLink> <NuxtLink to="/regles/talents/magie-puissante">Magie puissante</NuxtLink> permet de lever cette
      restriction.
    </p>
    <table class="table table-striped text-center">
      <thead>
        <tr>
          <th scope="col" class="w-25">Tiers</th>
          <th scope="col" class="w-25">Niveau de base</th>
          <th scope="col" class="w-25">Niveau intermédiaire</th>
          <th scope="col" class="w-25">Niveau supérieur</th>
        </tr>
      </thead>
      <tbody>
        <tr>
          <td>0</td>
          <td>1</td>
          <td>2</td>
          <td>3</td>
        </tr>
        <tr>
          <td>1</td>
          <td>2</td>
          <td>3</td>
          <td>4</td>
        </tr>
        <tr>
          <td>2</td>
          <td>3</td>
          <td>4</td>
          <td>5</td>
        </tr>
        <tr>
          <td>3</td>
          <td>5</td>
          <td>6</td>
          <td>7</td>
        </tr>
      </tbody>
    </table>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Magie", to: "/regles/magie" },
  { text: "Pouvoirs", to: "/regles/magie/pouvoirs" },
];
const title: string = "Niveau";

useSeo({
  title,
  description: "Découvrez comment les pouvoirs se déclinent en niveaux selon leur tier et les restrictions de canalisation associées.",
});
</script>
