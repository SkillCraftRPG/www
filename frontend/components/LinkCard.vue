<template>
  <NuxtLink class="card clickable" :to="to">
    <div class="card-body">
      <h2 v-if="title" class="card-title h5">{{ title }}</h2>
      <h3 v-if="subtitle" class="card-subtitle h6 mb-2 text-body-secondary">{{ subtitle }}</h3>
      <div v-if="text" class="card-text">{{ text }}</div>
      <slot></slot>
    </div>
  </NuxtLink>
</template>

<script setup lang="ts">
import type { RouteLocationAsPathGeneric, RouteLocationAsRelativeGeneric } from "vue-router";

defineProps<{
  subtitle?: string | null;
  text?: string | null;
  title?: string | null;
  to: string | RouteLocationAsRelativeGeneric | RouteLocationAsPathGeneric;
}>();
</script>
