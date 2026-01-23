<template>
  <main class="container">
    <h1>Hello World!</h1>
    <p>Length: {{ slugs.length }}</p>
    <ul>
      <li v-for="(slug, index) in slugs" :key="index">{{ slug }}</li>
    </ul>
  </main>
</template>

<script setup lang="ts">
const route = useRoute();

const slugs = computed<string[]>(() => {
  const slugs: string | string[] = route.params.slugs;
  return Array.isArray(slugs) ? slugs : [slugs];
});
</script>
