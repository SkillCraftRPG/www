<template>
  <ClientOnly>
    <ListMode class="mb-4" v-model="mode" />
    <div v-if="mode === 'grid'" class="row">
      <div v-for="attribute in attributes" :key="attribute.id" class="col-xs-12 col-sm-6 col-md-4 col-lg-3 col-fifth mb-4">
        <AttributeDetailCard :attribute="attribute" class="d-flex flex-column h-100" />
      </div>
    </div>
    <table v-else-if="mode === 'list'" class="table table-striped">
      <thead>
        <tr>
          <th scope="col">Attribut</th>
          <th scope="col">Statistiques</th>
          <th scope="col">Compétences</th>
          <th scope="col">Résumé</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="attribute in attributes" :key="attribute.id">
          <td>
            <NuxtLink :to="`/regles/attributs/${attribute.slug}`">{{ attribute.name }}</NuxtLink>
            <br />
            <span class="text-muted"><AttributeCategory :attribute="attribute" /></span>
          </td>
          <td>
            <template v-for="(statistic, index) in sortStatistics(attribute)" :key="statistic.id">
              <NuxtLink :to="`/regles/statistiques/${statistic.slug}`">{{ statistic.name }}</NuxtLink>
              <br v-if="index < attribute.statistics.length - 1" />
            </template>
          </td>
          <td>
            <template v-for="(skill, index) in sortSkills(attribute)" :key="skill.id">
              <NuxtLink :to="`/regles/competences/${skill.slug}`">{{ skill.name }}</NuxtLink>
              <br v-if="index < attribute.skills.length - 1" />
            </template>
          </td>
          <td>
            <template v-if="attribute.summary">{{ attribute.summary }}</template>
            <span v-else class="text-muted">{{ "—" }}</span>
          </td>
        </tr>
      </tbody>
    </table>
  </ClientOnly>
</template>

<script setup lang="ts">
import { arrayUtils } from "logitar-js";

import type { Attribute, Skill, Statistic } from "~/types/game";
import type { ListMode } from "~/types/components";

const { orderBy } = arrayUtils;

const props = defineProps<{
  items: Attribute[];
}>();

const mode = ref<ListMode>("grid");

const attributes = computed<Attribute[]>(() => props.items);

function sortSkills(attribute: Attribute): Skill[] {
  return orderBy(attribute.skills, "name");
}
function sortStatistics(attribute: Attribute): Statistic[] {
  return orderBy(attribute.statistics, "name");
}
</script>
