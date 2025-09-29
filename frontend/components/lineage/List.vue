<template>
  <ClientOnly>
    <ListMode class="mb-4" v-model="mode" />
    <div v-if="mode === 'grid'" class="row">
      <div v-for="lineage in lineages" :key="lineage.id" class="col-xs-12 col-sm-6 col-md-4 col-lg-3 mb-4">
        <LineageCard class="d-flex flex-column h-100" :lineage="lineage" />
      </div>
    </div>
    <table v-else-if="mode === 'list'" class="table table-striped">
      <thead>
        <tr>
          <th scope="col">Espèce</th>
          <th scope="col">Résumé</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="lineage in lineages" :key="lineage.id">
          <td>
            <NuxtLink :to="`/regles/especes/${lineage.slug}`">{{ lineage.name }}</NuxtLink>
          </td>
          <td class="summary-col">
            <template v-if="lineage.summary">{{ lineage.summary }}</template>
            <span v-else class="text-muted">{{ "—" }}</span>
          </td>
        </tr>
      </tbody>
    </table>
  </ClientOnly>
</template>

<script setup lang="ts">
import type { Lineage } from "~/types/game";
import type { ListMode } from "~/types/components";

const props = defineProps<{
  items: Lineage[];
}>();

const mode = ref<ListMode>("grid");

const lineages = computed<Lineage[]>(() => props.items);
</script>
