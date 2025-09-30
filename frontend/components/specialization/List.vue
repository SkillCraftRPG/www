<template>
  <ClientOnly>
    <ListMode v-model="mode" />
    <template v-for="group in groups" :key="group.tier">
      <h3 class="h5">Spécialisations de tiers {{ group.tier }}</h3>
      <div v-if="mode === 'grid'" class="row">
        <div v-for="specialization in group.specializations" :key="specialization.id" class="col-xs-12 col-sm-6 col-md-4 col-lg-3 mb-4">
          <SpecializationCard :specialization="specialization" class="d-flex flex-column h-100" />
        </div>
      </div>
      <table v-else-if="mode === 'list'" class="table table-striped">
        <thead>
          <tr>
            <th scope="col">Nom</th>
            <th scope="col">Résumé</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="specialization in group.specializations" :key="specialization.id">
            <td>
              <NuxtLink :to="`/regles/specialisations/${specialization.slug}`">{{ specialization.name }}</NuxtLink>
            </td>
            <td class="summary-col">
              <template v-if="specialization.summary">{{ specialization.summary }}</template>
              <span v-else class="text-muted">{{ "—" }}</span>
            </td>
          </tr>
        </tbody>
      </table>
    </template>
  </ClientOnly>
</template>

<script setup lang="ts">
import { arrayUtils } from "logitar-js";

import type { ListMode } from "~/types/components";
import type { Specialization } from "~/types/game";

type SpecializationGroup = {
  tier: number;
  specializations: Specialization[];
};

const { orderBy } = arrayUtils;

const props = defineProps<{
  items: Specialization[];
}>();

const mode = ref<ListMode>("grid");

const groups = computed<SpecializationGroup[]>(() => {
  const map = new Map<number, Specialization[]>();
  props.items.forEach((specialization) => {
    const specializations: Specialization[] | undefined = map.get(specialization.tier);
    if (specializations) {
      specializations.push(specialization);
    } else {
      map.set(specialization.tier, [specialization]);
    }
  });

  const groups: SpecializationGroup[] = [];
  for (let tier = 0; tier <= 3; tier++) {
    const specializations: Specialization[] = orderBy(map.get(tier) ?? [], "slug");
    if (specializations.length) {
      groups.push({ tier, specializations });
    }
  }
  return groups;
});
</script>
