<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Les systèmes d’écriture définissent la forme écrite des langues et servent à consigner le savoir, les lois, les traditions et les récits. Certaines
      langues disposent d’une écriture codifiée et largement diffusée, tandis que d’autres n’existent que sous forme orale et ne peuvent être transcrites.
    </p>
    <ScriptList v-if="scripts.length" :items="scripts" />
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";
import type { Script, SearchResults } from "~/types/game";

const config = useRuntimeConfig();
const parent: Breadcrumb[] = [{ text: "Langues", to: "/regles/langues" }];
const title: string = "Systèmes d’écriture";

const { data } = await useLazyAsyncData<SearchResults<Script>>(
  "scripts",
  () =>
    $fetch("/api/scripts?sort=Slug", {
      baseURL: config.public.apiBaseUrl,
    }),
  {
    server: false,
  },
);

const scripts = computed<Script[]>(() => data.value?.items ?? []);

useSeo({
  title,
  description: "Découvrez les alphabets utilisés pour écrire les langues de l’univers, leur rôle culturel et les langues qui ne possèdent aucune forme écrite.",
});
</script>
