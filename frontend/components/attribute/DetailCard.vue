<template>
  <div class="card">
    <div class="card-body">
      <h2 class="card-title h5">
        <NuxtLink :to="`/regles/attributs/${attribute.slug}`">{{ attribute.name }}</NuxtLink>
      </h2>
      <h3 class="card-subtitle h6 mb-2 text-body-secondary">
        <AttributeCategory :attribute="attribute" />
      </h3>
      <p v-if="attribute.summary" class="card-text">{{ attribute.summary }}</p>
      <template v-if="statistics.length">
        <h3 class="h5">Statistiques</h3>
        <ul>
          <li v-for="statistic in statistics" :key="statistic.id">
            <NuxtLink :to="`/regles/statistiques/${statistic.slug}`">{{ statistic.name }}</NuxtLink>
          </li>
        </ul>
      </template>
      <template v-if="skills.length">
        <h3 class="h5">Compétences</h3>
        <ul>
          <li v-for="skill in skills" :key="skill.id">
            <NuxtLink :to="`/regles/competences/${skill.slug}`">{{ skill.name }}</NuxtLink>
          </li>
        </ul>
      </template>
    </div>
  </div>
</template>

<script lang="ts" setup>
import { arrayUtils } from "logitar-js";

import type { Attribute, Skill, Statistic } from "~/types/game";

const { orderBy } = arrayUtils;

const props = defineProps<{
  attribute: Attribute;
}>();

const skills = computed<Skill[]>(() => orderBy(props.attribute.skills, "name"));
const statistics = computed<Statistic[]>(() => orderBy(props.attribute.statistics, "name"));
</script>
