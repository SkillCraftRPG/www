<template>
  <main class="container">
    <template v-if="language">
      <h1>{{ title }}</h1>
      <AppBreadcrumb :active="title" :parent="parent" />
      <MarkdownContent v-if="language.htmlContent" :text="language.htmlContent" />
      <LanguageScript v-if="language.script" :script="language.script" />
      <LanguageSpeakers v-if="language.typicalSpeakers" :text="language.typicalSpeakers" />
    </template>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";
import type { Language } from "~/types/game";

const config = useRuntimeConfig();
const parent: Breadcrumb[] = [{ text: "Langues", to: "/regles/langues" }];
const route = useRoute();

const slug = computed<string>(() => (Array.isArray(route.params.slug) ? route.params.slug[0] : route.params.slug));
const { data } = await useAsyncData<Language>(
  `language:${slug.value}`,
  () =>
    $fetch(`/api/rules/languages/slug:${slug.value}`, {
      baseURL: config.public.apiBaseUrl,
    }),
  { watch: [slug] },
);

const language = computed<Language | undefined>(() => data.value ?? undefined);
const title = computed<string>(() => language.value?.name ?? "");
const description = computed<string>(() => language.value?.metaDescription ?? "");

useSeo({ title, description });
</script>
