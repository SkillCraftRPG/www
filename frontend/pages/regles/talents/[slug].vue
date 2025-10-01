<template>
  <main class="container">
    <template v-if="talent">
      <h1>{{ title }}</h1>
      <AppBreadcrumb :active="title" :parent="parent" />
      <TalentInfo :talent="talent" />
      <MarkdownContent v-if="talent.description" :text="talent.description" />
      <TalentSkill v-if="talent.skill" :skill="talent.skill" :training="talent.name === talent.skill.name" />
      <TalentRequired v-if="talent.requiredTalent" :talent="talent.requiredTalent" />
    </template>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";
import type { Talent } from "~/types/game";

const config = useRuntimeConfig();
const parent: Breadcrumb[] = [{ text: "Talents", to: "/regles/talents" }];
const route = useRoute();

const slug = computed<string>(() => (Array.isArray(route.params.slug) ? route.params.slug[0] : route.params.slug));
const { data } = await useAsyncData<Talent>(
  `talent:${slug.value}`,
  () =>
    $fetch(`/api/talents/slug:${slug.value}`, {
      baseURL: config.public.apiBaseUrl,
    }),
  { watch: [slug] },
);

const talent = computed<Talent | undefined>(() => data.value ?? undefined);
const title = computed<string>(() => talent.value?.name ?? "");
const description = computed<string>(() => talent.value?.metaDescription ?? "");

useSeoMeta({ title, description });

// TODO(fpion): TalentTree
</script>
