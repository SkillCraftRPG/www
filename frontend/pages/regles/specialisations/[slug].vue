<template>
  <main class="container">
    <template v-if="specialization">
      <h1>{{ title }}</h1>
      <AppBreadcrumb :active="title" :parent="parent" />
      <SpecializationInfo :specialization="specialization" />
      <MarkdownContent v-if="specialization.description" :text="specialization.description" />
      <SpecializationRequirements v-if="hasRequirements" :specialization="specialization" />
      <SpecializationOptions v-if="hasOptions" :specialization="specialization" />
      <SpecializationReservedTalent v-if="specialization.reservedTalent" :talent="specialization.reservedTalent" />
    </template>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";
import type { Specialization } from "~/types/specializations";

const config = useRuntimeConfig();
const parent: Breadcrumb[] = [{ text: "Spécialisations", to: "/regles/specialisations" }];
const route = useRoute();

const slug = computed<string>(() => (Array.isArray(route.params.slug) ? route.params.slug[0] : route.params.slug));
const { data } = await useAsyncData<Specialization>(
  `specialization:${slug.value}`,
  () =>
    $fetch(`/api/specializations/slug:${slug.value}`, {
      baseURL: config.public.apiBaseUrl,
    }),
  { watch: [slug] },
);

const specialization = computed<Specialization | undefined>(() => data.value ?? undefined);
const title = computed<string>(() => specialization.value?.name ?? "");
const description = computed<string>(() => specialization.value?.metaDescription ?? "");
const hasRequirements = computed<boolean>(() =>
  Boolean(specialization.value && (specialization.value.requirements.talent || specialization.value.requirements.other.length > 0)),
);
const hasOptions = computed<boolean>(() =>
  Boolean(specialization.value && (specialization.value.options.talents.length > 0 || specialization.value.options.other.length > 0)),
);

useSeo({ title, description });

// TODO(fpion): Specialization Tree
</script>
