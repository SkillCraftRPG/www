<template>
  <main class="container">
    <template v-if="title">
      <h1>{{ title }}</h1>
      <AppBreadcrumb :active="title" :parent="parent" />
    </template>
    <table v-if="education?.wealthMultiplier" class="table table-striped">
      <tbody>
        <tr>
          <th scope="row">Argent de départ</th>
          <td>×{{ education.wealthMultiplier }}</td>
        </tr>
      </tbody>
    </table>
    <div v-if="html" v-html="html"></div>
    <template v-if="skill">
      <h2 class="h3">Compétence</h2>
      <p>
        Cette <NuxtLink to="/regles/competences">compétence</NuxtLink> est fondamentale aux personnages ayant reçu cette éducation. Au moment de sa
        <NuxtLink to="/regles/personnages/creation">création</NuxtLink>, il doit être <NuxtLink to="/regles/competences/formation">formé</NuxtLink> pour
        celle-ci.
      </p>
      <SkillCard class="mb-4" :skill="skill" />
    </template>
    <template v-if="feature">
      <h2 class="h3">Particularité : {{ education?.feature?.name }}</h2>
      <div v-html="feature"></div>
    </template>
  </main>
</template>

<script setup lang="ts">
import { marked } from "marked";

import type { Breadcrumb } from "~/types/components";
import type { Education, Skill } from "~/types/game";
import { getEducation } from "~/services/educations";

const parent: Breadcrumb[] = [{ text: "Éducations", to: "/regles/educations" }];
const route = useRoute();

const education = ref<Education | undefined>(getEducation(Array.isArray(route.params.slug) ? route.params.slug[0] : route.params.slug, { skill: true }));

const feature = computed<string | undefined>(() =>
  education.value?.feature?.description ? (marked.parse(education.value.feature.description) as string) : undefined,
);
const html = computed<string | undefined>(() => (education.value?.description ? (marked.parse(education.value.description) as string) : undefined));
const skill = computed<Skill | undefined>(() => education.value?.skill ?? undefined);
const title = computed<string | undefined>(() => education.value?.name);

useSeo({
  title: title.value,
  description: education.value?.summary,
});
</script>
