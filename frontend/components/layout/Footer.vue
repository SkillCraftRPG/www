<template>
  <footer class="bg-dark">
    <div class="fluid">
      <NuxtLink to="/" class="text-light">
        <img src="@/assets/img/logo.png" :alt="`${brand} Logo`" height="32" />
      </NuxtLink>
      {{ " " }}
      <NuxtLink to="/" class="text-light">© {{ brand }} {{ version }} {{ year }}.</NuxtLink>
    </div>
  </footer>
</template>

<script setup lang="ts">
import { brand, version } from "~/types/constants";

const year: number = new Date().getUTCFullYear();
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
