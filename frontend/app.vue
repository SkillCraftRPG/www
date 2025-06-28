<template>
  <NuxtLayout>
    <NuxtPage />
  </NuxtLayout>
</template>

<script setup lang="ts">
useHead({
  titleTemplate: (chunk) => (chunk ? `${chunk} %separator %brand` : "%brand"),
  templateParams: {
    brand: "SkillCraft", // TODO(fpion): duplication with useSeo.vue
    separator: "·",
  },
});
</script>
