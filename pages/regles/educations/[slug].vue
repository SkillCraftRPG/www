<template>
  <main class="container">
    <template v-if="education">
      <h1>{{ title }}</h1>
      <AppBreadcrumb :active="title" :parent="parent" />
      <EducationInfo :education="education" />
      <MarkdownContent v-if="education.description" :text="education.description" />
      <EducationSkill v-if="education.skill" :skill="education.skill" />
      <EducationFeature v-if="education.feature" :feature="education.feature" />
    </template>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";
import type { Education } from "~/types/game";

const config = useRuntimeConfig();
const parent: Breadcrumb[] = [{ text: "Éducations", to: "/regles/educations" }];
const route = useRoute();

const slug = computed<string>(() => (Array.isArray(route.params.slug) ? route.params.slug[0] : route.params.slug));
const { data } = await useAsyncData<Education>(
  `education:${slug.value}`,
  () =>
    $fetch(`/api/educations/slug:${slug.value}`, {
      baseURL: config.public.apiBaseUrl,
    }),
  { watch: [slug] },
);

const education = computed<Education | undefined>(() => data.value ?? undefined);
const title = computed<string>(() => education.value?.name ?? "");
const description = computed<string>(() => education.value?.metaDescription ?? "");

useSeo({ title, description });
</script>
