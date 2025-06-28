<template>
  <main class="container">
    <template v-if="title">
      <h1>{{ title }}</h1>
      <AppBreadcrumb :active="title" :parent="parent" />
    </template>
    <table v-if="talent" class="table table-striped">
      <tbody>
        <tr>
          <th scope="row">Achats multiples</th>
          <td>
            <TalentAllowMultiplePurchases :talent="talent" />
          </td>
        </tr>
        <tr>
          <th scope="row">Talent requis</th>
          <td>
            <NuxtLink v-if="talent.requiredTalent" :to="`/regles/talents/${talent.requiredTalent.slug}`">{{ talent.requiredTalent.name }}</NuxtLink>
            <span v-else class="text-muted">{{ "—" }}</span>
          </td>
        </tr>
      </tbody>
    </table>
    <div v-if="html" v-html="html"></div>
    <template v-if="skill">
      <h2 class="h3">Compétence</h2>
      <p>
        L’acquisition de ce talent forme le personnage pour la <NuxtLink to="/regles/competences">compétence</NuxtLink> ci-dessous et augmente de +1 le rang de
        cette compétence.
      </p>
      <SkillCard class="mb-4" :skill="skill" />
    </template>
    <!-- TODO(fpion): TalentTree -->
  </main>
</template>

<script setup lang="ts">
import { marked } from "marked";

import type { Breadcrumb } from "~/types/components";
import type { Skill, Talent } from "~/types/game";

const config = useRuntimeConfig();
const route = useRoute();

const { data } = await useFetch(`/api/talents/${route.params.slug}`, {
  baseURL: config.public.apiBaseUrl,
  cache: "no-cache",
});

const talent = computed<Talent | undefined>(() => data.value as Talent | undefined);
const html = computed<string | undefined>(() => (talent.value?.description ? (marked.parse(talent.value.description) as string) : undefined));
const parent = computed<Breadcrumb[]>(() => [{ text: "Talents", to: "/regles/talents" }]);
const skill = computed<Skill | undefined>(() => talent.value?.skill ?? undefined);
const title = computed<string | undefined>(() => talent.value?.name);

useSeo({
  title: title.value,
  description: talent.value?.summary,
});
</script>
