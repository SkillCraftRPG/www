<template>
  <ClientOnly>
    <div class="row">
      <div class="col-xs-12 col-sm-6 mb-4">
        <AttributeSelect
          :attributes="attributes"
          label="Filtrer par attribut"
          :model-value="attribute"
          placeholder="Tous"
          variable
          @update:model-value="setQuery('attribute', $event)"
        />
      </div>
      <div class="col-xs-12 col-sm-6 mb-4">
        <ListMode :model-value="mode" @update:model-value="setMode" />
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

const { orderBy } = arrayUtils;
const { mode, setMode } = useListMode();

const props = defineProps<{
  items: Skill[];
}>();

const attributes = ref<Attribute[]>([]);

const attribute = computed<string>(() => getQuery("attribute").toLocaleLowerCase());

const skills = computed<Skill[]>(() => {
  if (!attribute.value) {
    return props.items;
  }
  return props.items.filter((skill) => (attribute.value === "variable" ? !skill.attribute : skill.attribute?.slug.toLocaleLowerCase() === attribute.value));
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
