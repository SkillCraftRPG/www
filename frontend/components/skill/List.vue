<template>
  <ClientOnly>
    <div class="row">
      <div class="col-xs-12 col-sm-6 mb-4">
        <AttributeSelect
          :attributes="attributes"
          label="Filtrer par attribut"
          :model-value="attribute?.id"
          placeholder="Tous"
          variable
          @selected="attribute = $event"
        />
      </div>
      <div class="col-xs-12 col-sm-6 mb-4">
        <ListMode v-model="mode" />
      </div>
    </div>
    <div v-if="mode === 'grid'" class="row">
      <div v-for="skill in skills" :key="skill.id" class="col-xs-12 col-sm-6 col-md-4 col-lg-3 mb-4">
        <SkillCard class="d-flex flex-column h-100" :skill="skill" />
      </div>
    </div>
    <table v-else-if="mode === 'list'" class="table table-striped text-center">
      <thead>
        <tr>
          <th scope="col" class="w-15">Compétence</th>
          <th scope="col" class="w-15">Attribut</th>
          <th scope="col" class="w-70">Résumé</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="skill in skills" :key="skill.id">
          <td>
            <NuxtLink :to="`/regles/competences/${skill.slug}`">{{ skill.name }}</NuxtLink>
          </td>
          <td>
            <NuxtLink v-if="skill.attribute" :to="`/regles/attributs/${skill.attribute.slug}`">{{ skill.attribute.name }}</NuxtLink>
            <i v-else class="text-muted">Variable</i>
          </td>
          <td>
            <template v-if="skill.summary">{{ skill.summary }}</template>
            <span v-else class="text-muted">{{ "—" }}</span>
          </td>
        </tr>
      </tbody>
    </table>
  </ClientOnly>
</template>

<script setup lang="ts">
import { arrayUtils } from "logitar-js";

import type { Attribute, Skill } from "~/types/game";
import type { ListMode } from "~/types/components";

const { orderBy } = arrayUtils;

const props = defineProps<{
  items: Skill[];
}>();

const attribute = ref<Attribute>();
const attributes = ref<Attribute[]>([]);
const mode = ref<ListMode>("grid");

const skills = computed<Skill[]>(() => {
  let skills: Skill[] = [...props.items];
  if (attribute.value) {
    skills = skills.filter((skill) => (attribute.value?.id === "variable" ? !skill.attribute : skill.attribute?.id === attribute.value?.id));
  }
  return skills;
});

watch(
  () => props.items,
  (items) => {
    const map = new Map<string, Attribute>();
    items.forEach((skill) => {
      if (skill.attribute) {
        map.set(skill.attribute.id, skill.attribute);
      }
    });
    attributes.value = orderBy([...map.values()], "slug");
  },
  { deep: true, immediate: true },
);
</script>
