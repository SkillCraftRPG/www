<template>
  <main class="container">
    <template v-if="title">
      <h1>{{ title }}</h1>
      <AppBreadcrumb :active="title" :parent="parent" />
    </template>
    <div v-if="html" v-html="html"></div>
  </main>
</template>

<script setup lang="ts">
import { marked } from "marked";

import type { Breadcrumb } from "~/types/components";
import type { Customization } from "~/types/game";
import { getCustomization } from "~/services/customizations";

const parent: Breadcrumb[] = [{ text: "Dons & Handicaps", to: "/regles/dons-handicaps" }];
const route = useRoute();

const customization = ref<Customization | undefined>(getCustomization(Array.isArray(route.params.slug) ? route.params.slug[0] : route.params.slug));

const html = computed<string | undefined>(() => (customization.value?.description ? (marked.parse(customization.value.description) as string) : undefined));
const title = computed<string | undefined>(() => customization.value?.name);

useSeo({
  title: title.value,
  description: customization.value?.summary,
});
</script>
