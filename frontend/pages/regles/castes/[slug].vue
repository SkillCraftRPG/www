<template>
  <main class="container">
    <template v-if="caste">
      <h1>{{ title }}</h1>
      <AppBreadcrumb :active="title" :parent="parent" />
      <CasteInfo :caste="caste" />
      <MarkdownContent v-if="caste.description" :text="caste.description" />
      <CasteSkill v-if="caste.skill" :skill="caste.skill" />
      <CasteFeature v-if="caste.feature" :feature="caste.feature" />
    </template>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";
import type { Caste } from "~/types/game";

const config = useRuntimeConfig();
const parent: Breadcrumb[] = [{ text: "Castes", to: "/regles/castes" }];
const route = useRoute();

const slug = computed<string>(() => (Array.isArray(route.params.slug) ? route.params.slug[0] : route.params.slug));
const { data } = await useAsyncData<Caste>(
  `caste:${slug.value}`,
  () =>
    $fetch(`/api/castes/slug:${slug.value}`, {
      baseURL: config.public.apiBaseUrl,
    }),
  { watch: [slug] },
);

const caste = computed<Caste | undefined>(() => data.value ?? undefined);
const title = computed<string>(() => caste.value?.name ?? "");
const description = computed<string>(() => caste.value?.metaDescription ?? "");

useSeo({ title, description });
</script>
