<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" />
    <p>🚧</p>
    <ul>
      <li>
        <NuxtLink to="/regles/herboristerie/poisons">Poisons</NuxtLink>
      </li>
      <li>
        <NuxtLink to="/regles/herboristerie/remedes">Remèdes</NuxtLink>
      </li>
    </ul>
  </main>
</template>

<script setup lang="ts">
const title: string = "Herboristerie";

useSeo({
  title,
  description: "🚧",
});
</script>
