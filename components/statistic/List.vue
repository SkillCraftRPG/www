<template>
  <ClientOnly>
    <div class="row">
      <div class="col-xs-12 col-sm-6 col-md-4 mb-4">
        <SearchInput :model-value="search" @update:model-value="setQuery('search', $event)" />
      </div>
      <div class="col-xs-12 col-sm-6 col-md-4 mb-4">
        <AttributeSelect
          :attributes="attributes"
          label="Filtrer par attribut"
          :model-value="attribute"
          placeholder="Tous"
          @update:model-value="setQuery('attribute', $event)"
        />
      </div>
      <div class="col-xs-12 col-sm-6 col-md-4 mb-4">
        <ListMode :model-value="mode" @update:model-value="setMode" />
      </div>
    </div>
    <div v-if="mode === 'grid'" class="row">
      <div v-for="statistic in statistics" :key="statistic.id" class="col-xs-12 col-sm-6 col-md-4 col-lg-3 mb-4">
        <StatisticCard class="d-flex flex-column h-100" :statistic="statistic" />
      </div>
    </div>
    <table v-else-if="mode === 'list'" class="table table-striped text-center">
      <thead>
        <tr>
          <th scope="col" class="w-20">Statistique</th>
          <th scope="col" class="w-20">Attribut</th>
          <th scope="col" class="w-60">Résumé</th>
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
          <td>
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

const { mode, setMode } = useListMode();
const { orderBy } = arrayUtils;

const props = defineProps<{
  items: Statistic[];
}>();

const attributes = ref<Attribute[]>([]);

const attribute = computed<string>(() => getQuery("attribute").toLocaleLowerCase());
const search = computed<string>(() => getQuery("search").trim().toLocaleLowerCase());

const statistics = computed<Statistic[]>(() =>
  props.items.filter((statistic) => {
    if (attribute.value && statistic.attribute?.slug.toLocaleLowerCase() !== attribute.value) {
      return false;
    }
    if (search.value && !statistic.name.toLocaleLowerCase().includes(search.value) && !(statistic.summary ?? "").toLocaleLowerCase().includes(search.value)) {
      return false;
    }
    return true;
  }),
);

watch(
  () => props.items,
  (items) => {
    const map = new Map<string, Attribute>();
    items.forEach((statistic) => {
      if (statistic.attribute) {
        map.set(statistic.attribute.id, statistic.attribute);
      }
    });
    attributes.value = orderBy([...map.values()], "slug");
  },
  { deep: true, immediate: true },
);
</script>
