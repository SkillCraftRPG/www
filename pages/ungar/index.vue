<template>
  <main class="container">
    <template v-if="collection">
      <h1>{{ title }}</h1>
      <EncyclopediaBreadcrumb :collection="collection" />
      <MarkdownContent v-if="collection.htmlContent" :text="collection.htmlContent" />
    </template>
  </main>
</template>

<script setup lang="ts">
import type { Collection } from "~/types/encyclopedia";

const config = useRuntimeConfig();
const slug: string = "ungar";

const { data } = await useAsyncData<Collection>(`collection:${slug}`, () =>
  $fetch(`/api/collections/slug:${slug}`, {
    baseURL: config.public.apiBaseUrl,
  }),
);

const collection = computed<Collection | undefined>(() => data.value ?? undefined);
const title = computed<string>(() => collection.value?.name ?? "");
const description = computed<string>(() => collection.value?.metaDescription ?? "");

useSeo({ title, description });
</script>
