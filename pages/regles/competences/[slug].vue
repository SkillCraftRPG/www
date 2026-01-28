<template>
  <main class="container">
    <template v-if="skill">
      <h1>{{ title }}</h1>
      <AppBreadcrumb :active="title" :parent="parent" />
      <MarkdownContent v-if="skill.description" :text="skill.description" />
      <SkillAttribute :attribute="skill.attribute ?? undefined" />
      <SkillTalents v-if="skill.talents && skill.talents.length > 0" :talents="skill.talents" />
    </template>
  </main>
</template>

<script setup lang="ts">
import { arrayUtils } from "logitar-js";

import type { Breadcrumb } from "~/types/components";
import type { SearchResults, Skill, Talent } from "~/types/game";

const config = useRuntimeConfig();
const parent: Breadcrumb[] = [{ text: "Compétences", to: "/regles/competences" }];
const route = useRoute();
const { orderBy } = arrayUtils;

const slug = computed<string>(() => (Array.isArray(route.params.slug) ? route.params.slug[0] : route.params.slug));
const { data } = await useAsyncData<Skill>(
  `skill:${slug.value}`,
  async () => {
    const skill = await $fetch<Skill>(`/api/skills/slug:${slug.value}`, {
      baseURL: config.public.apiBaseUrl,
    });
    if (skill) {
      const results = await $fetch<SearchResults<Talent>>(`/api/talents?skill=${skill.id}`, {
        baseURL: config.public.apiBaseUrl,
      });
      skill.talents = orderBy(
        results.items.map((talent) => ({ ...talent, sort: [talent.tier, talent.slug].join("_") })),
        "sort",
      );
    }
    return skill;
  },
  { watch: [slug] },
);

const skill = computed<Skill | undefined>(() => data.value ?? undefined);
const title = computed<string>(() => skill.value?.name ?? "");
const description = computed<string>(() => skill.value?.metaDescription ?? "");

useSeo({ title, description });
</script>
