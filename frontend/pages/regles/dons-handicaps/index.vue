<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" />
    <p>
      <!-- TODO(fpion): redact -->
      […]
    </p>
    <div class="row">
      <div v-for="customization in customizations" :key="customization.id" class="col-xs-12 col-sm-6 col-md-4 col-lg-3 mb-4">
        <CustomizationCard :customization="customization" class="d-flex flex-column h-100" />
      </div>
    </div>
  </main>
</template>

<script setup lang="ts">
import type { Customization, SearchResults } from "~/types/game";

const config = useRuntimeConfig();
const title: string = "Dons & Handicaps";

const { data } = await useFetch("/api/customizations", {
  baseURL: config.public.apiBaseUrl,
  cache: "no-cache",
  server: false,
});

const customizations = computed<Customization[]>(() => (data.value as SearchResults<Customization>)?.items ?? []);

useSeo({
  title,
  description: "", // TODO(fpion): meta description
});
</script>
