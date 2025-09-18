<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" />
    <p>🚧</p>
  </main>
</template>

<script setup lang="ts">
const title: string = "Taille";

useSeo({
  title,
  description: "🚧",
});

// TODO(fpion): TODO(fpion): catégorie de taille, Facteur de Charge, Espace occupé (carrés), Espace occupé (hexagones), component for table with props for reusability)
</script>
