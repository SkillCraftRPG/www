<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <EncyclopediaBreadcrumb :collection="collection" />
    <p>
      Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam non ex non odio vehicula varius. Cras imperdiet tempor massa vitae congue. Mauris vitae
      sapien eget orci gravida ullamcorper. Interdum et malesuada fames ac ante ipsum primis in faucibus. Quisque condimentum lectus sit amet magna fringilla,
      lacinia interdum ligula maximus. Phasellus ac pretium nunc. Nullam convallis turpis sed mi interdum pharetra. In porta nec metus eu lacinia. Sed feugiat
      tortor non eros congue, eget scelerisque magna vulputate. Proin eget convallis nisl, quis volutpat nulla. Proin volutpat ut dolor in consectetur. Donec
      condimentum justo eu tortor tempus, at consectetur lacus mollis. Donec egestas, ipsum id mattis hendrerit, magna nisl accumsan lectus, eu ultricies est
      turpis nec dolor. Sed at dictum urna.
    </p>
  </main>
</template>

<script setup lang="ts">
import type { Collection } from "~/types/encyclopedia";
import type { Actor } from "~/types/game";

const actor: Actor = {
  type: "System",
  id: "00000000-0000-0000-0000-000000000000",
  isDeleted: false,
  displayName: "System",
};
const now: string = new Date().toISOString();
const collection: Collection = {
  id: "00000000-0000-0000-0000-000000000000",
  version: 0,
  createdBy: actor,
  createdOn: now,
  updatedBy: actor,
  updatedOn: now,
  key: "ungar",
  name: "Ungar",
  articles: [],
}; // TOOD(fpion): collection should come from the CMS

const title = computed<string>(() => collection.name ?? ""); // TODO(fpion): name should be mandatory
const description = computed<string>(() => ""); // TODO(fpion): meta description should come from the CMS

useSeo({ title, description });
</script>
