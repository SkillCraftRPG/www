<template>
  <footer class="bg-dark">
    <div class="container-fluid text-center py-3">
      <NuxtLink to="/">
        <img src="@/assets/img/logo.png" :alt="`${$t('brand')} Logo`" height="32" />
      </NuxtLink>
      {{ " " }}
      <NuxtLink to="/" class="text-light">© {{ $t("brand") }} {{ version }} {{ year }}.</NuxtLink>
    </div>
  </footer>
</template>

<script setup lang="ts">
const config = useRuntimeConfig();
const year: number = new Date().getUTCFullYear();

const version = computed<string>(() => config.public.version);
</script>

<style scoped>
footer {
  width: 100%;
}
</style>
