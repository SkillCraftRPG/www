<template>
  <main class="container">
    <template v-if="title">
      <h1>{{ title }}</h1>
      <AppBreadcrumb :active="title" :parent="parent" />
    </template>
    <div v-if="html" v-html="html"></div>
    <!-- TODO(fpion): Statistics -->
    <template v-if="skills.length">
      <h2 class="h3">Compétences</h2>
      <p>La valeur de cet attribut est ajoutée aux tests des compétences ci-dessous.</p>
      <div class="row">
        <div v-for="skill in skills" :key="skill.id" class="col-xs-12 col-sm-6 col-md-4 col-lg-3 mb-4">
          <SkillCard class="d-flex flex-column h-100" clickable no-attribute :skill="skill" />
        </div>
      </div>
    </template>
  </main>
</template>

<script setup lang="ts">
import { arrayUtils } from "logitar-js";
import { marked } from "marked";

import type { Attribute, Skill } from "~/types/game";
import type { Breadcrumb } from "~/types/components";

const config = useRuntimeConfig();
const route = useRoute();
const { orderBy } = arrayUtils;

const { data } = await useFetch(`/api/attributes/${route.params.slug}`, {
  baseURL: config.public.apiBaseUrl,
  cache: "no-cache",
});

const attribute = computed<Attribute | undefined>(() => data.value as Attribute | undefined);
const html = computed<string | undefined>(() => (attribute.value?.description ? (marked.parse(attribute.value.description) as string) : undefined));
const parent = computed<Breadcrumb[]>(() => [{ text: "Attributs", to: "/regles/attributs" }]);
const skills = computed<Skill[]>(() => (attribute.value?.skills ? orderBy(attribute.value.skills, "name") : []));
const title = computed<string | undefined>(() => attribute.value?.name);

useSeoMeta({
  title,
  description: attribute.value?.summary,
});
useLinks();
</script>
