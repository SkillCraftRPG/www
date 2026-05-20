<template>
  <nav :aria-label="ariaLabel" :style="divider ? { '--bs-breadcrumb-divider': `'${divider}'` } : undefined">
    <ol class="breadcrumb">
      <li v-for="(breadcrumb, index) in breadcrumbs" :key="index" :class="getClasses(breadcrumb)" :aria-current="getAriaCurrent(breadcrumb)">
        <NuxtLink v-if="breadcrumb.to" :to="breadcrumb.to">{{ breadcrumb.text }}</NuxtLink>
        <template v-else>{{ breadcrumb.text }}</template>
      </li>
    </ol>
  </nav>
</template>

<script setup lang="ts">
import type { Breadcrumb, BreadcrumbOptions } from "~/types/tar/breadcrumb";

withDefaults(defineProps<BreadcrumbOptions>(), {
  breadcrumbs: () => [],
});

function getAriaCurrent(breadcrumb: Breadcrumb): "page" | undefined {
  return breadcrumb.to ? undefined : "page";
}
function getClasses(breadcrumb: Breadcrumb): string[] {
  const classes = ["breadcrumb-item"];
  if (!breadcrumb.to) {
    classes.push("active");
  }
  return classes;
}
</script>
