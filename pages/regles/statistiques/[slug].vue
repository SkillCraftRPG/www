<template>
  <main class="container">
    <template v-if="statistic">
      <h1>{{ title }}</h1>
      <AppBreadcrumb :active="title" :parent="parent" />
      <MarkdownContent v-if="statistic.htmlContent" :text="statistic.htmlContent" />
      <StatisticAttribute :attribute="statistic.attribute" />
    </template>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";
import type { Statistic } from "~/types/game";

const config = useRuntimeConfig();
const parent: Breadcrumb[] = [{ text: "Statistiques", to: "/regles/statistiques" }];
const route = useRoute();

const slug = computed<string>(() => (Array.isArray(route.params.slug) ? route.params.slug[0] : route.params.slug));
const { data } = await useAsyncData<Statistic>(
  `statistic:${slug.value}`,
  () =>
    $fetch(`/api/statistics/slug:${slug.value}`, {
      baseURL: config.public.apiBaseUrl,
    }),
  { watch: [slug] },
);

const statistic = computed<Statistic | undefined>(() => data.value ?? undefined);
const title = computed<string>(() => statistic.value?.name ?? "");
const description = computed<string>(() => statistic.value?.metaDescription ?? "");

useSeo({ title, description });
</script>
