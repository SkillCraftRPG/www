<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" />
    <p>🚧</p>
    <LanguageList v-if="languages.length" :items="languages" />
  </main>
</template>

<script setup lang="ts">
import type { Language, SearchResults } from "~/types/game";

const config = useRuntimeConfig();
const title: string = "Langues";

const { data } = await useLazyAsyncData<SearchResults<Language>>(
  "languages",
  () =>
    $fetch("/api/rules/languages?sort=Slug", {
      baseURL: config.public.apiBaseUrl,
    }),
  {
    server: false,
  },
);

const languages = computed<Language[]>(() => data.value?.items ?? []);

useSeo({
  title,
  description: "🚧",
});
</script>
