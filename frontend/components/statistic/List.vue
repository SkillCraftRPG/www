<template>
  <ClientOnly>
    <div class="row">
      <div class="col-xs-12 col-sm-6 mb-4">
        <AttributeSelect :attributes="attributes" label="Filtrer par attribut" :model-value="attribute?.id" placeholder="Tous" @selected="attribute = $event" />
      </div>
      <div class="col-xs-12 col-sm-6 mb-4">
        <ListMode v-model="mode" />
      </div>
    </div>
    <div v-if="mode === 'grid'" class="row">
      <div v-for="statistic in statistics" :key="statistic.id" class="col-xs-12 col-sm-6 col-md-4 col-lg-3 mb-4">
        <StatisticCard class="d-flex flex-column h-100" :statistic="statistic" />
      </div>
    </div>
    <table v-else-if="mode === 'list'" class="table table-striped">
      <thead>
        <tr>
          <th scope="col">Statistique</th>
          <th scope="col">Attribut</th>
          <th scope="col">Résumé</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="statistic in statistics" :key="statistic.id">
          <td>
            <NuxtLink :to="`/regles/statistiques/${statistic.slug}`">{{ statistic.name }}</NuxtLink>
          </td>
          <td>
            <NuxtLink v-if="statistic.attribute" :to="`/regles/attributs/${statistic.attribute.slug}`">{{ statistic.attribute.name }}</NuxtLink>
            <span v-else class="text-muted">{{ "—" }}</span>
          </td>
          <td class="summary-col">
            <template v-if="statistic.summary">{{ statistic.summary }}</template>
            <span v-else class="text-muted">{{ "—" }}</span>
          </td>
        </tr>
      </tbody>
    </table>
  </ClientOnly>
</template>

<script setup lang="ts">
import { arrayUtils } from "logitar-js";

import type { Attribute, Statistic } from "~/types/game";
import type { ListMode } from "~/types/components";

const { orderBy } = arrayUtils;

const props = defineProps<{
  items: Statistic[];
}>();

const attribute = ref<Attribute>();
const attributes = ref<Attribute[]>([]);
const mode = ref<ListMode>("grid");

const statistics = computed<Statistic[]>(() => {
  let statistics: Statistic[] = [...props.items];
  if (attribute.value) {
    statistics = statistics.filter((statistic) => statistic.attribute?.id === attribute.value?.id);
  }
  return statistics;
});

watch(
  () => props.items,
  (items) => {
    const map = new Map<string, Attribute>();
    items.forEach((statistic) => {
      if (statistic.attribute) {
        map.set(statistic.attribute.id, statistic.attribute);
      }
    });
    attributes.value = orderBy([...map.values()], "name");
  },
  { deep: true, immediate: true },
);
</script>
