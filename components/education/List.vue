<template>
  <ClientOnly>
    <ListMode class="mb-4" v-model="mode" />
    <div v-if="mode === 'grid'" class="row">
      <div v-for="education in educations" :key="education.id" class="col-xs-12 col-sm-6 col-md-4 col-lg-3 mb-4">
        <EducationCard class="d-flex flex-column h-100" :education="education" />
      </div>
    </div>
    <table v-else-if="mode === 'list'" class="table table-striped text-center">
      <thead>
        <tr>
          <th scope="col" class="w-15">Caste</th>
          <th scope="col" class="w-15">Compétence</th>
          <th scope="col" class="w-15">Richesse de départ</th>
          <th scope="col" class="w-55">Résumé</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="education in educations" :key="education.id">
          <td>
            <NuxtLink :to="`/regles/educations/${education.slug}`">{{ education.name }}</NuxtLink>
          </td>
          <td>
            <NuxtLink v-if="education.skill" :to="`/regles/competences/${education.skill.slug}`">{{ education.skill.name }}</NuxtLink>
            <span v-else class="text-muted">{{ "—" }}</span>
          </td>
          <td>
            <template v-if="education.wealthMultiplier">×{{ $n(education.wealthMultiplier, "integer") }}</template>
            <span v-else class="text-muted">{{ "—" }}</span>
          </td>
          <td>
            <template v-if="education.summary">{{ education.summary }}</template>
            <span v-else class="text-muted">{{ "—" }}</span>
          </td>
        </tr>
      </tbody>
    </table>
  </ClientOnly>
</template>

<script setup lang="ts">
import type { Education } from "~/types/game";
import type { ListMode } from "~/types/components";

const props = defineProps<{
  items: Education[];
}>();

const mode = ref<ListMode>("grid");

const educations = computed<Education[]>(() => props.items);
</script>
