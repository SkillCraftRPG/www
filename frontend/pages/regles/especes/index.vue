<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" />
    <p>🚧</p>
  </main>
</template>

<script setup lang="ts">
const title: string = "Espèces";

useSeo({
  title,
  description: "🚧",
});
</script>
