<template>
  <main class="container">
    <template v-if="article">
      <h1>{{ title }}</h1>
      <EncyclopediaBreadcrumb :article="article" />
      <MarkdownContent v-if="article.htmlContent" :text="article.htmlContent" />
    </template>
  </main>
</template>

<script setup lang="ts">
import type { Article } from "~/types/encyclopedia";

const config = useRuntimeConfig();
const route = useRoute();
const slug: string = "ungar";

const path = computed<string>(() => (Array.isArray(route.params.slugs) ? route.params.slugs.join("/") : route.params.slugs));
const { data } = await useAsyncData<Article>(
  `article:${slug}:${path.value}`,
  () =>
    $fetch(`/api/collections/slug:${slug}/articles/${path.value}`, {
      baseURL: config.public.apiBaseUrl,
    }),
  { watch: [path] },
);

const article = computed<Article | undefined>(() => data.value ?? undefined);
const title = computed<string>(() => article.value?.title ?? "");
const description = computed<string>(() => article.value?.metaDescription ?? "");

useSeo({ title, description });
</script>
