<template>
  <NuxtLayout>
    <NuxtPage />
  </NuxtLayout>
</template>

<script setup lang="ts">
import { Brand as brand } from "./types/constants";

useHead({
  titleTemplate: (chunk) => (chunk ? `${chunk} %separator %brand` : "%brand"),
  templateParams: {
    brand,
    separator: "·",
  },
});
</script>
