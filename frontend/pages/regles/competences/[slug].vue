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
        Cette compétence n’est associée à aucun <NuxtLink to="/regles/attributs">attribut</NuxtLink>. Lorsqu’un test est effectué, l’attribut est sélectionné en
        fonction du contexte du test.
      </p>
    </template>
    <template v-if="talents.length">
      <h2 class="h3">Talents</h2>
      <p>
        L’acquisition des <NuxtLink to="/regles/talents">talents</NuxtLink> ci-dessous <NuxtLink to="/regles/competences/formation">forme</NuxtLink> le
        personnage pour cette compétence et augmente (+1) le <NuxtLink to="/regles/competences/rang">rang</NuxtLink> de cette compétence.
      </p>
      <div class="row">
        <div v-for="talent in talents" :key="talent.id" class="col-xs-12 col-sm-6 col-md-4 col-lg-3 mb-4">
          <TalentCard class="d-flex flex-column h-100" :talent="talent" />
        </div>
      </div>
    </template>
  </main>
</template>

<script setup lang="ts">
import { arrayUtils } from "logitar-js";
import { marked } from "marked";

import type { Attribute, SearchResults, Skill, Talent } from "~/types/game";
import type { Breadcrumb } from "~/types/components";

const config = useRuntimeConfig();
const parent: Breadcrumb[] = [{ text: "Compétences", to: "/regles/competences" }];
const route = useRoute();
const { orderBy } = arrayUtils;

const slug = ref<string>(Array.isArray(route.params.slug) ? route.params.slug[0] : route.params.slug);

type SkillWithTalents = Skill & {
  talents: Talent[];
};
const { data } = await useAsyncData<SkillWithTalents | undefined>("skill", async () => {
  const skill = await $fetch<Skill | undefined>(`/api/skills/slug:${slug.value}`, {
    baseURL: config.public.apiBaseUrl,
  });
  if (!skill) {
    return undefined;
  }
  const results = await $fetch<SearchResults<Talent>>(`/api/talents?skill=${skill.id}`, {
    baseURL: config.public.apiBaseUrl,
  });
  return { ...skill, talents: results.items };
});

const skill = ref<SkillWithTalents | undefined>(data.value ?? undefined);
const attribute = computed<Attribute | undefined>(() => skill.value?.attribute ?? undefined);
const html = computed<string | undefined>(() => (skill.value?.description ? (marked.parse(skill.value.description) as string) : undefined));
const talents = computed<Talent[]>(() => {
  return orderBy(
    (skill.value?.talents ?? []).map((talent) => ({ ...talent, sort: [talent.tier, talent.slug].join("_") })),
    "sort",
  );
});
const title = computed<string | undefined>(() => skill.value?.name);

useSeo({
  title: title.value,
  description: skill.value?.summary,
});
</script>
