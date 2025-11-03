<template>
  <main class="container">
    <template v-if="lineage">
      <h1>{{ title }}</h1>
      <AppBreadcrumb :active="title" :parent="parent" />
      <MarkdownContent v-if="lineage.description" :text="lineage.description" />
      <LineageChildren v-if="lineage.children.length" :children="lineage.children" />
      <LineageLanguages v-if="showLanguages" :languages="lineage.languages" />
      <LineageNames v-if="showNames" :names="lineage.names" />
      <LineagePhysical :lineage="lineage" />
      <LineageSpeeds v-if="showSpeeds" :speeds="lineage.speeds" />
      <LineageFeatures v-if="lineage.features.length" :lineage="lineage" />
    </template>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";
import type { Lineage } from "~/types/lineages";
import type { SearchResults } from "~/types/game";

const config = useRuntimeConfig();
const options = { baseURL: config.public.apiBaseUrl };
const route = useRoute();

const slug = computed<string>(() => (Array.isArray(route.params.slug) ? route.params.slug[0] : route.params.slug));
const { data } = await useAsyncData<Lineage>(
  `lineage:${slug.value}`,
  async () => {
    const lineage = await $fetch<Lineage>(`/api/lineages/slug:${slug.value}`, options);
    if (lineage) {
      const results = await $fetch<SearchResults<Lineage>>(`/api/lineages?parent=${lineage.id}&sort=Slug`, options);
      lineage.children = [...results.items];
    }
    return lineage;
  },
  { watch: [slug] },
);

const lineage = computed<Lineage | undefined>(() => data.value ?? undefined);
const title = computed<string>(() => lineage.value?.name ?? "");
const description = computed<string>(() => lineage.value?.metaDescription ?? "");
const parent = computed<Breadcrumb[]>(() => {
  const parent: Breadcrumb[] = [{ text: "Espèces", to: "/regles/especes" }];
  if (lineage.value?.parent) {
    parent.push({ text: lineage.value.parent.name, to: `/regles/especes/${lineage.value.parent.slug}` });
  }
  return parent;
});
const showLanguages = computed<boolean>(() =>
  Boolean(lineage.value && (lineage.value.languages.items.length || lineage.value.languages.extra > 0 || lineage.value.languages.text)),
);
const showNames = computed<boolean>(() =>
  Boolean(
    lineage.value &&
      (lineage.value.names.text ||
        lineage.value.names.family.length > 0 ||
        lineage.value.names.female.length > 0 ||
        lineage.value.names.male.length > 0 ||
        lineage.value.names.unisex.length > 0 ||
        lineage.value.names.custom.length > 0),
  ),
);
const showSpeeds = computed<boolean>(() =>
  Boolean(
    lineage.value &&
      (lineage.value.speeds.walk || lineage.value.speeds.climb || lineage.value.speeds.swim || lineage.value.speeds.fly || lineage.value.speeds.burrow),
  ),
);

useSeo({ title, description });

// TODO(fpion): URLs should have a hierarchy
</script>
