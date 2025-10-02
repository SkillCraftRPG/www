<template>
  <main class="container">
    <template v-if="lineage">
      <h1>{{ title }}</h1>
      <AppBreadcrumb :active="title" :parent="parent" />
      <MarkdownContent v-if="lineage.description" :text="lineage.description" />
      <LineageTraits :lineage="lineage" />
    </template>
  </main>
</template>

<script setup lang="ts">
import species from "~/assets/data/species.json";
import type { Breadcrumb } from "~/types/components";
import type { Lineage } from "~/types/lineages";

const parent: Breadcrumb[] = [{ text: "Espèces", to: "/regles/especes" }];
const route = useRoute();

const slug = computed<string>(() => (Array.isArray(route.params.slug) ? route.params.slug[0] : route.params.slug));

const lineage = computed<Lineage | undefined>(() => species.filter((species) => species.slug === slug.value)[0]);
const title = computed<string>(() => lineage.value?.name ?? "");
const description = computed<string>(() => lineage.value?.metaDescription ?? "");

useSeoMeta({ title, description });
</script>
