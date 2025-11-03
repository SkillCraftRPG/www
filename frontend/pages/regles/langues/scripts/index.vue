<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>🚧</p>
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
  description: "🚧",
});
</script>
