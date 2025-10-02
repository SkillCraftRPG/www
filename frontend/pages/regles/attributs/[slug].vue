<template>
  <main class="container">
    <template v-if="attribute">
      <h1>{{ title }}</h1>
      <AppBreadcrumb :active="title" :parent="parent" />
      <MarkdownContent v-if="attribute.description" :text="attribute.description" />
      <AttributeStatistics v-if="attribute.statistics.length > 0" :attribute="attribute" />
      <AttributeSkills v-if="attribute.skills.length > 0" :attribute="attribute" />
    </template>
  </main>
</template>

<script setup lang="ts">
import type { Attribute } from "~/types/game";
import type { Breadcrumb } from "~/types/components";

const config = useRuntimeConfig();
const parent: Breadcrumb[] = [{ text: "Attributs", to: "/regles/attributs" }];
const route = useRoute();

const slug = computed<string>(() => (Array.isArray(route.params.slug) ? route.params.slug[0] : route.params.slug));
const { data } = await useAsyncData<Attribute>(
  `attribute:${slug}`,
  () =>
    $fetch(`/api/attributes/slug:${slug.value}`, {
      baseURL: config.public.apiBaseUrl,
    }),
  { watch: [slug] },
);

const attribute = computed<Attribute | undefined>(() => data.value ?? undefined);
const title = computed<string>(() => attribute.value?.name ?? "");
const description = computed<string>(() => attribute.value?.metaDescription ?? "");

useSeo({ title, description });
</script>
