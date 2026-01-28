<template>
  <main class="container">
    <template v-if="customization">
      <h1>{{ title }}</h1>
      <AppBreadcrumb :active="title" :parent="parent" />
      <CustomizationInfo :customization="customization" />
      <MarkdownContent v-if="customization.description" :text="customization.description" />
    </template>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";
import type { Customization } from "~/types/game";

const config = useRuntimeConfig();
const parent: Breadcrumb[] = [{ text: "Dons & Handicaps", to: "/regles/dons-handicaps" }];
const route = useRoute();

const slug = computed<string>(() => (Array.isArray(route.params.slug) ? route.params.slug[0] : route.params.slug));
const { data } = await useAsyncData<Customization>(
  `customization:${slug.value}`,
  () =>
    $fetch(`/api/customizations/slug:${slug.value}`, {
      baseURL: config.public.apiBaseUrl,
    }),
  { watch: [slug] },
);

const customization = computed<Customization | undefined>(() => data.value ?? undefined);
const title = computed<string>(() => customization.value?.name ?? "");
const description = computed<string>(() => customization.value?.metaDescription ?? "");

useSeo({ title, description });
</script>
