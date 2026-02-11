<template>
  <main class="container">
    <template v-if="lineage">
      <h1>{{ title }}</h1>
      <AppBreadcrumb :active="title" :parent="parent" />
      <MarkdownContent v-if="lineage.htmlContent" :text="lineage.htmlContent" />
      <SpeciesEthnicities v-if="species && species.ethnicities.length" :species="species" />
      <LineageLanguages v-if="showLanguages" :languages="lineage.languages" />
      <LineageNames v-if="showNames" :names="lineage.names" />
      <LineagePhysical :lineage="lineage" />
      <LineageSpeeds v-if="showSpeeds" :speeds="lineage.speeds" />
      <LineageFeatures v-if="lineage.features.length" :lineage="lineage" />
    </template>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";
import type { Ethnicity, LineageBase, Species } from "~/types/lineages";
import type { SearchResults } from "~/types/game";

const config = useRuntimeConfig();
const options = { baseURL: config.public.apiBaseUrl };
const route = useRoute();

const segments = computed<string[]>(() => (Array.isArray(route.params.segments) ? route.params.segments : [route.params.segments]));
const slug = computed<string>(() => (Array.isArray(route.params.slug) ? route.params.slug[0] : route.params.slug));
const { data } = await useAsyncData<LineageBase>(
  `lineage:${segments.value.join("/")}`,
  async () => {
    if (segments.value.length > 2) {
      throw new Error("Segments must contain exactly 1 or 2 elements.");
    } else if (segments.value.length === 2) {
      return await $fetch<Ethnicity>(`/api/species/${segments.value[0]}/ethnicities/${segments.value[1]}`, options);
    }
    const species = await $fetch<Species>(`/api/species/slug:${segments.value[0]}`, options);
    if (species) {
      const results = await $fetch<SearchResults<Ethnicity>>(`/api/species/${species.id}/ethnicities?sort=Name`, options);
      species.ethnicities = [...results.items];
    }
    return species;
  },
  { watch: [slug] },
);

const lineage = computed<LineageBase | undefined>(() => data.value ?? undefined);
const title = computed<string>(() => lineage.value?.name ?? "");
const description = computed<string>(() => lineage.value?.metaDescription ?? "");

const ethnicity = computed<Ethnicity | undefined>(() => {
  const ethnicity = lineage.value as Ethnicity;
  return ethnicity?.species ? ethnicity : undefined;
});
const species = computed<Species | undefined>(() => {
  const species = lineage.value as Species;
  if (species?.ethnicities) {
    return species;
  }
  return ethnicity.value?.species ?? undefined;
});

const parent = computed<Breadcrumb[]>(() => {
  const parent: Breadcrumb[] = [{ text: "Espèces", to: "/regles/especes" }];
  if (species.value && ethnicity.value) {
    parent.push({ text: species.value.name, to: `/regles/especes/${species.value.slug}` });
  }
  return parent;
});

const showLanguages = computed<boolean>(() =>
  Boolean(lineage.value && (lineage.value.languages.items.length || lineage.value.languages.extra > 0 || lineage.value.languages.text)),
);
const showNames = computed<boolean>(() =>
  Boolean(
    lineage.value &&
      (lineage.value.names.text ||
        lineage.value.names.family.length > 0 ||
        lineage.value.names.female.length > 0 ||
        lineage.value.names.male.length > 0 ||
        lineage.value.names.unisex.length > 0 ||
        lineage.value.names.custom.length > 0),
  ),
);
const showSpeeds = computed<boolean>(() =>
  Boolean(
    lineage.value &&
      (lineage.value.speeds.walk || lineage.value.speeds.climb || lineage.value.speeds.swim || lineage.value.speeds.fly || lineage.value.speeds.burrow),
  ),
);

useSeo({ title, description });
</script>
