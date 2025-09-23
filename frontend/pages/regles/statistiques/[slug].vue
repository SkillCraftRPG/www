<template>
  <main class="container">
    <template v-if="title">
      <h1>{{ title }}</h1>
      <AppBreadcrumb :active="title" :parent="parent" />
    </template>
    <div v-if="html" v-html="html" class="mb-3"></div>
    <template v-if="attribute">
      <h2 class="h3">Attribut</h2>
      <p>L’attribut suivant influence la valeur de cette statistique.</p>
      <div class="row">
        <div class="col-xs-12 col-sm-6 col-md-4 col-lg-3 mb-4">
          <AttributeCard :attribute="attribute" />
        </div>
      </div>
    </template>
  </main>
</template>

<script setup lang="ts">
import { marked } from "marked";

import type { Attribute, Statistic } from "~/types/game";
import type { Breadcrumb } from "~/types/components";

const config = useRuntimeConfig();
const parent: Breadcrumb[] = [{ text: "Statistiques", to: "/regles/statistiques" }];
const route = useRoute();

const slug = ref<string>(Array.isArray(route.params.slug) ? route.params.slug[0] : route.params.slug);

const { data } = await useAsyncData<Statistic>("statistic", () =>
  $fetch(`/api/statistics/slug:${slug.value}`, {
    baseURL: config.public.apiBaseUrl,
  }),
);

const statistic = computed<Statistic | undefined>(() => data.value ?? undefined);
const attribute = computed<Attribute | undefined>(() => statistic.value?.attribute ?? undefined);
const html = computed<string | undefined>(() => (statistic.value?.description ? (marked.parse(statistic.value.description) as string) : undefined));
const title = computed<string | undefined>(() => statistic.value?.name);

useSeo({
  title: title.value,
  description: statistic.value?.summary,
});
</script>
