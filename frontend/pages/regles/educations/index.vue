<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" />
    <!-- TODO(fpion): explanation text -->
    <p>{{ "[…]" }}</p>
    <div class="row">
      <div v-for="education in educations" :key="education.id" class="col-xs-12 col-sm-6 col-md-4 col-lg-3 mb-4">
        <EducationCard class="d-flex flex-column h-100" :education="education" />
      </div>
    </div>
  </main>
</template>

<script setup lang="ts">
import type { Education, SearchResults } from "~/types/game";

const config = useRuntimeConfig();
const title: string = "Éducations";

const { data } = await useFetch("/api/educations", {
  baseURL: config.public.apiBaseUrl,
  cache: "no-cache",
  server: false,
});
const educations = computed<Education[]>(() => (data.value as SearchResults<Education>)?.items ?? []);

useSeo({
  title,
  description: "", // TODO(fpion): meta description
});
</script>
