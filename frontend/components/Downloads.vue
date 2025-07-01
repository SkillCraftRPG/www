<template>
  <div class="my-4 row">
    <div v-for="download in downloads" :key="download.id" class="col-xs-12 col-sm-6 col-md-4 col-lg-3 mb-4">
      <Download v-bind="download" />
    </div>
  </div>
</template>

<script setup lang="ts">
import type { Download } from "~/types/components";

const downloads: Download[] = [
  {
    id: "moteur-de-jeu",
    name: "Moteur de jeu",
    picture: "https://skillcraftrpg.blob.core.windows.net/books/moteur-de-jeu.jpg",
    url: "https://skillcraftrpg.blob.core.windows.net/books/MoteurDeJeu_v0.7.1.pdf",
  },
  {
    id: "ungar-ultima-ignis",
    name: "Ungar — Ultima Ignis",
    picture: "https://skillcraftrpg.blob.core.windows.net/books/ungar-ultima-ignis.jpg",
    url: "https://skillcraftrpg.blob.core.windows.net/books/Ungar_Ultima_Ignis_v0.7.0.pdf",
  },
  {
    id: "ungar-c-1000ac",
    name: "Ungar c. 1000AC",
    picture: "https://skillcraftrpg.blob.core.windows.net/books/ungar-c-1000-ac.jpg",
    url: "https://skillcraftrpg.blob.core.windows.net/books/Ungar_c1000AC_v0.7.1.pdf",
  },
  {
    id: "grimoire",
    name: "Grimoire",
    picture: "https://skillcraftrpg.blob.core.windows.net/books/grimoire.jpg",
    url: "https://skillcraftrpg.blob.core.windows.net/books/Grimoire_v0.7.0.pdf",
  },
];
</script>
