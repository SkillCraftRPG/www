<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>Les talents réservés sont des capacités uniques à leur spécialisation.</p>
    <p>Lorsque vous acquérez le talent réservé d’une spécialisation, vous acquérez par le fait même cette spécialisation.</p>
    <p>
      Lorsque vous remplissez les <NuxtLink to="/regles/specialisations/acquisition">conditions d’acquisition</NuxtLink> d’une spécialisation, vous pouvez
      acquérir son talent réservé.
    </p>
    <p>
      L’acquisition du talent réservé se fait de la même manière que l’acquisition d’un <NuxtLink to="/regles/talents">talent</NuxtLink> normal : en dépensant
      des <NuxtLink to="/regles/talents/points">points de talent</NuxtLink>.
    </p>
    <p>Ce nombre de points varie en fonction du tiers de la spécialisation convoitée.</p>
    <table class="table table-striped text-center">
      <thead>
        <tr>
          <th scope="col" class="w-50">Tiers de la spécialisation</th>
          <th scope="col" class="w-50">Points de talent</th>
        </tr>
      </thead>
      <tbody>
        <tr>
          <td>1</td>
          <td>2</td>
        </tr>
        <tr>
          <td>2</td>
          <td>3</td>
        </tr>
        <tr>
          <td>3</td>
          <td>4</td>
        </tr>
      </tbody>
    </table>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [{ text: "Spécialisations", to: "/regles/specialisations" }];
const title: string = "Talent réservé";

useSeo({
  title,
  description: "Découvrez les talents réservés, capacités uniques liées aux spécialisations, avec coût en points selon le tiers de la spécialisation.",
});
</script>
