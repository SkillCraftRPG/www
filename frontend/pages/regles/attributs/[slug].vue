<template>
  <main class="container">
    <template v-if="title">
      <h1>{{ title }}</h1>
      <AppBreadcrumb :active="title" :parent="parent" />
    </template>
    <div v-if="html" v-html="html"></div>
  </main>
</template>

<script setup lang="ts">
import { marked } from "marked";

import type { Attribute } from "~/types/game";
import type { Breadcrumb } from "~/types/components";

const config = useRuntimeConfig();
const route = useRoute();

const { data } = await useFetch(`/api/attributes/${route.params.slug}`, {
  baseURL: config.public.apiBaseUrl,
});

const attribute = computed<Attribute | undefined>(() => data.value as Attribute | undefined);
const html = computed<string | undefined>(() => (attribute.value?.description ? (marked.parse(attribute.value.description) as string) : undefined));
const parent = computed<Breadcrumb[]>(() => [{ text: "Attributs", to: "/regles/attributs" }]);
const title = computed<string | undefined>(() => attribute.value?.name);

useSeoMeta({
  title,
  description: attribute.value?.summary,
});
useLinks();
</script>
