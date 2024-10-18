<script setup lang="ts">
import { TarCard } from "logitar-vue3-ui";
import { ref } from "vue";

type Download = {
  id: string;
  name: string;
  picture: string;
  url: string;
};

const downloads = ref<Download[]>([
  {
    id: "moteur-de-jeu",
    name: "Moteur de jeu",
    picture: "https://skillcraftrpg.blob.core.windows.net/books/moteur-de-jeu.jpg",
    url: "https://skillcraftrpg.blob.core.windows.net/books/MoteurDeJeu_v0.7.1.pdf",
  },
  {
    id: "ungar-c-1000ac",
    name: "Ungar c. 1000AC",
    picture: "https://skillcraftrpg.blob.core.windows.net/books/ungar-c-1000-ac.jpg",
    url: "https://skillcraftrpg.blob.core.windows.net/books/Ungar_c1000AC_v0.7.1.pdf",
  },
]);
</script>

<template>
  <div class="my-3 row">
    <div v-for="download in downloads" :key="download.id" class="col-xl-6">
      <a download :href="download.url" target="_blank">
        <TarCard class="download">
          <img :src="download.picture" :alt="download.name" width="480" height="640" />
        </TarCard>
      </a>
    </div>
  </div>
</template>

<style scoped>
.download {
  text-align: center;
}
.download:hover {
  background-color: #d0d0d0;
  cursor: pointer;
}
</style>
