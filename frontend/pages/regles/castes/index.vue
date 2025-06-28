<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" />
    <p>
      <!-- TODO(fpion): redact -->
      […]
    </p>
    <div class="row">
      <div v-for="caste in castes" :key="caste.id" class="col-xs-12 col-sm-6 col-md-4 col-lg-3 mb-4">
        <CasteCard class="d-flex flex-column h-100" :caste="caste" />
      </div>
    </div>
  </main>
</template>

<script setup lang="ts">
import type { Caste, SearchResults } from "~/types/game";

const config = useRuntimeConfig();
const title: string = "Castes";

const { data } = await useFetch("/api/castes", {
  baseURL: config.public.apiBaseUrl,
  cache: "no-cache",
  server: false,
});
const castes = computed<Caste[]>(() => (data.value as SearchResults<Caste>)?.items ?? []);

useSeo({
  title,
  description: "", // TODO(fpion): meta description
});
</script>
