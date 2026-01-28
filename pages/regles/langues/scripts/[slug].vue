<template>
  <main class="container">
    <template v-if="script">
      <h1>{{ title }}</h1>
      <AppBreadcrumb :active="title" :parent="parent" />
      <MarkdownContent v-if="script.htmlContent" :text="script.htmlContent" />
      <ScriptLanguages v-if="script.languages" :languages="script.languages" />
    </template>
  </main>
</template>

<script setup lang="ts">
import { arrayUtils } from "logitar-js";

import type { Breadcrumb } from "~/types/components";
import type { Language, Script, SearchResults } from "~/types/game";

const config = useRuntimeConfig();
const parent: Breadcrumb[] = [
  { text: "Langues", to: "/regles/langues" },
  { text: "Systèmes d’écriture", to: "/regles/langues/scripts" },
];
const route = useRoute();
const { orderBy } = arrayUtils;

const slug = computed<string>(() => (Array.isArray(route.params.slug) ? route.params.slug[0] : route.params.slug));
const { data } = await useAsyncData<Script>(
  `script:${slug.value}`,
  async () => {
    const script = await $fetch<Script>(`/api/scripts/slug:${slug.value}`, {
      baseURL: config.public.apiBaseUrl,
    });
    if (script) {
      const results = await $fetch<SearchResults<Language>>(`/api/rules/languages?script=${script.id}`, {
        baseURL: config.public.apiBaseUrl,
      });
      script.languages = orderBy(results.items, "slug");
    }
    return script;
  },
  { watch: [slug] },
);

const script = computed<Script | undefined>(() => data.value ?? undefined);
const title = computed<string>(() => script.value?.name ?? "");
const description = computed<string>(() => script.value?.metaDescription ?? "");

useSeo({ title, description });
</script>
