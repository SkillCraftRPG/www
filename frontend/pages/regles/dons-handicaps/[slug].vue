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

import type { Breadcrumb } from "~/types/components";
import type { Customization } from "~/types/game";

const config = useRuntimeConfig();
const route = useRoute();

const { data } = await useFetch(`/api/customizations/${route.params.slug}`, {
  baseURL: config.public.apiBaseUrl,
  cache: "no-cache",
});

const customization = computed<Customization | undefined>(() => data.value as Customization | undefined);
const html = computed<string | undefined>(() => (customization.value?.description ? (marked.parse(customization.value.description) as string) : undefined));
const parent = computed<Breadcrumb[]>(() => [{ text: "Dons & Handicaps", to: "/regles/dons-handicaps" }]);
const title = computed<string | undefined>(() => customization.value?.name);

useSeo({
  title: title.value,
  description: customization.value?.summary,
});
</script>
