<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Lorsqu’une arme est utilisée afin d’effectuer une attaque, cette arme confère un bonus au <NuxtLink to="/regles/competences/tests">test</NuxtLink> de
      l’attaque. Ce bonus est indiqué dans la colonne <i>Attaque</i> de chaque arme.
    </p>
    <p>Ce bonus n’est appliqué qu’au test des attaques effectuées en maniant cette arme. Une attaque bénéficie donc du bonus d’une seule arme à la fois.</p>
    <p>Ce bonus varie en fonction de la taille de l’arme.</p>
    <table class="table table-striped text-center">
      <thead>
        <tr>
          <th scope="col" class="w-50">Taille de l’arme</th>
          <th scope="col" class="w-50">Bonus au test</th>
        </tr>
      </thead>
      <tbody>
        <tr>
          <td>Attaque à mains nues</td>
          <td>+0</td>
        </tr>
        <tr>
          <td>Armes légères</td>
          <td>+1</td>
        </tr>
        <tr>
          <td>Armes à une main</td>
          <td>+2</td>
        </tr>
        <tr>
          <td>Armes versatiles</td>
          <td>+3</td>
        </tr>
        <tr>
          <td>Armes à deux mains</td>
          <td>+4</td>
        </tr>
      </tbody>
    </table>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Équipement", to: "/regles/equipement" },
  { text: "Armes", to: "/regles/equipement/armes" },
];
const title: string = "Attaque";

useSeo({
  title,
  description: "Découvrez comment la taille d’une arme influence le bonus au test d’attaque, de l’attaque à mains nues aux armes à deux mains.",
});
</script>
