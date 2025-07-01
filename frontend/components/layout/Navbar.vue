<template>
  <nav class="navbar navbar-expand-lg bg-body-tertiary" data-bs-theme="dark">
    <div class="container-fluid">
      <NuxtLink to="/" class="navbar-brand">
        <img src="@/assets/img/logo.png" :alt="`${brand} Logo`" height="32" />
        {{ brand }}
        <span v-if="environment !== 'production'" class="badge text-bg-warning">{{ environment }}</span>
      </NuxtLink>
    </div>
  </nav>
</template>

<script setup lang="ts">
import { brand } from "~/types/constants";

const environment: string = process.env.NODE_ENV ?? "production";
</script>
