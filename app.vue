<template>
  <NuxtLayout>
    <NuxtPage />
  </NuxtLayout>
</template>

<script setup lang="ts">
useHead({
  titleTemplate: (chunk) => {
    const brand: string = $t("brand");
    const separator: string = "·";
    return chunk ? `${chunk} ${separator} ${brand}` : brand;
  },
});
</script>
