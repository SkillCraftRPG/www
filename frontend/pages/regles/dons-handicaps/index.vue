<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" />
    <p>
      <!-- TODO(fpion): redact -->
      […]
    </p>
  </main>
</template>

<script setup lang="ts">
const title: string = "Dons & Handicaps";

useSeo({
  title,
  description: "", // TODO(fpion): meta description
});
</script>
