<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const title: string = "Progression de personnage";

const parent = computed<Breadcrumb[]>(() => [{ text: "Personnages", to: "/regles/personnages" }]);

useSeoMeta({
  title,
  description: "", // TODO(fpion): implement
});
useLinks();
</script>
