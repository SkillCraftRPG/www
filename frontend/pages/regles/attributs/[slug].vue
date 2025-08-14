<template>
  <main class="container">
    <template v-if="title">
      <h1>{{ title }}</h1>
      <AppBreadcrumb :active="title" :parent="parent" />
    </template>
    <div v-if="html" v-html="html"></div>
    <template v-if="statistics.length">
      <h2 class="h3">Statistiques</h2>
      <p>Cet attribut influence la valeur des statistiques ci-dessous.</p>
      <div class="row">
        <div v-for="statistic in statistics" :key="statistic.id" class="col-xs-12 col-sm-6 col-md-4 col-lg-3 mb-4">
          <StatisticCard class="d-flex flex-column h-100" no-attribute :statistic="statistic" />
        </div>
      </div>
    </template>
    <template v-if="skills.length">
      <h2 class="h3">Compétences</h2>
      <p>La valeur de cet attribut est ajoutée aux tests des compétences ci-dessous.</p>
      <div class="row">
        <div v-for="skill in skills" :key="skill.id" class="col-xs-12 col-sm-6 col-md-4 col-lg-3 mb-4">
          <SkillCard class="d-flex flex-column h-100" no-attribute :skill="skill" />
        </div>
      </div>
    </template>
  </main>
</template>

<script setup lang="ts">
import { arrayUtils } from "logitar-js";
import { marked } from "marked";

import type { Attribute, Skill, Statistic } from "~/types/game";
import type { Breadcrumb } from "~/types/components";
import { getAttribute } from "~/services/attributes";

const parent: Breadcrumb[] = [{ text: "Attributs", to: "/regles/attributs" }];
const route = useRoute();
const { orderBy } = arrayUtils;

const attribute = ref<Attribute | undefined>(
  getAttribute(Array.isArray(route.params.slug) ? route.params.slug[0] : route.params.slug, { statistics: true, skills: true }),
);

const html = computed<string | undefined>(() => (attribute.value?.description ? (marked.parse(attribute.value.description) as string) : undefined));
const skills = computed<Skill[]>(() => (attribute.value?.skills ? orderBy(attribute.value.skills, "slug") : []));
const statistics = computed<Statistic[]>(() => (attribute.value?.statistics ? orderBy(attribute.value.statistics, "slug") : []));
const title = computed<string | undefined>(() => attribute.value?.name);

useSeo({
  title: title.value,
  description: attribute.value?.summary,
});
</script>
