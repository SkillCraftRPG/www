<template>
  <footer class="bg-dark">
    <div class="fluid">
      <NuxtLink to="/" class="text-light">
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
  position: absolute;
  bottom: 0;
  width: 100%;
  height: 60px;
  line-height: 60px;
  text-align: center;
}
</style>
