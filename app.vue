<template>
  <NuxtLayout>
    <NuxtPage />
  </NuxtLayout>
</template>

<script setup lang="ts">
useHead({
  titleTemplate: (chunk) => (chunk ? `${chunk} %separator %brand` : "%brand"),
  templateParams: {
    brand: $t("brand"),
    separator: "·",
  },
});
</script>
