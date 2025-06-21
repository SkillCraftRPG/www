<template>
  <main class="container">
    <template v-if="title">
      <h1>{{ title }}</h1>
      <AppBreadcrumb :active="title" :parent="parent" />
    </template>
    <div v-if="html" v-html="html"></div>
    <template v-if="skill">
      <h2 class="h3">Attribut</h2>
      <template v-if="attribute">
        <p>La valeur de l’attribut ci-dessous est ajoutée aux tests de cette compétence.</p>
        <div class="row">
          <div class="col-xs-12 col-sm-6 col-md-4 col-lg-3 mb-4">
            <AttributeCard :attribute="attribute" />
          </div>
        </div>
      </template>
      <p v-else>
        <!-- TODO(fpion): explanation test -->
        {{ "[…]" }}
      </p>
    </template>
  </main>
</template>

<script setup lang="ts">
import { marked } from "marked";

import type { Attribute, Skill } from "~/types/game";
import type { Breadcrumb } from "~/types/components";

const config = useRuntimeConfig();
const route = useRoute();

const { data } = await useFetch(`/api/skills/${route.params.slug}`, {
  baseURL: config.public.apiBaseUrl,
  cache: "no-cache",
});

const skill = computed<Skill | undefined>(() => data.value as Skill | undefined);
const attribute = computed<Attribute | undefined>(() => skill.value?.attribute ?? undefined);
const html = computed<string | undefined>(() => (skill.value?.description ? (marked.parse(skill.value.description) as string) : undefined));
const parent = computed<Breadcrumb[]>(() => [{ text: "Compétences", to: "/regles/competences" }]);
const title = computed<string | undefined>(() => skill.value?.name);

useSeoMeta({
  title,
  description: skill.value?.summary,
});
useLinks();
</script>
