<template>
  <ClientOnly>
    <ListMode class="mb-4" v-model="mode" />
    <div v-if="mode === 'grid'" class="row">
      <div v-for="caste in castes" :key="caste.id" class="col-xs-12 col-sm-6 col-md-4 col-lg-3 mb-4">
        <CasteCard class="d-flex flex-column h-100" :caste="caste" />
      </div>
    </div>
    <table v-else-if="mode === 'list'" class="table table-striped">
      <thead>
        <tr>
          <th scope="col">Caste</th>
          <th scope="col">Compétence</th>
          <th scope="col">Argent de départ</th>
          <th scope="col">Résumé</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="caste in castes" :key="caste.id">
          <td>
            <NuxtLink :to="`/regles/castes/${caste.slug}`">{{ caste.name }}</NuxtLink>
          </td>
          <td>
            <NuxtLink v-if="caste.skill" :to="`/regles/competences/${caste.skill.slug}`">{{ caste.skill.name }}</NuxtLink>
            <span v-else class="text-muted">{{ "—" }}</span>
          </td>
          <td>
            <template v-if="caste.wealthRoll">{{ caste.wealthRoll }}</template>
            <span v-else class="text-muted">{{ "—" }}</span>
          </td>
          <td>
            <template v-if="caste.summary">{{ caste.summary }}</template>
            <span v-else class="text-muted">{{ "—" }}</span>
          </td>
        </tr>
      </tbody>
    </table>
  </ClientOnly>
</template>

<script setup lang="ts">
import type { Caste } from "~/types/game";
import type { ListMode } from "~/types/components";

const props = defineProps<{
  items: Caste[];
}>();

const mode = ref<ListMode>("grid");

const castes = computed<Caste[]>(() => props.items);
</script>
