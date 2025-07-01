<template>
  <ClientOnly>
    <div class="row">
      <div class="col-xs-12 col-sm-6 mb-4">
        <CustomizationKindSelect label="Filtrer par type" placeholder="Tous" v-model="kind" />
      </div>
      <div class="col-xs-12 col-sm-6 mb-4">
        <ListMode v-model="mode" />
      </div>
    </div>
    <div v-if="mode === 'grid'" class="row">
      <div v-for="customization in customizations" :key="customization.id" class="col-xs-12 col-sm-6 col-md-4 col-lg-3 mb-4">
        <CustomizationCard :customization="customization" class="d-flex flex-column h-100" />
      </div>
    </div>
    <table v-else-if="mode === 'list'" class="table table-striped">
      <thead>
        <tr>
          <th scope="col">Personnalisation</th>
          <th scope="col">Résumé</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="customization in customizations" :key="customization.id">
          <td>
            <NuxtLink :to="`/regles/dons-handicaps/${customization.slug}`">{{ customization.name }}</NuxtLink>
            <br />
            <span class="text-muted"><CustomizationKind :customization="customization" /></span>
          </td>
          <td>
            <template v-if="customization.summary">{{ customization.summary }}</template>
            <span v-else class="text-muted">{{ "—" }}</span>
          </td>
        </tr>
      </tbody>
    </table>
  </ClientOnly>
</template>

<script setup lang="ts">
import type { Customization, CustomizationKind } from "~/types/game";
import type { ListMode } from "~/types/components";

const props = defineProps<{
  items: Customization[];
}>();

const kind = ref<CustomizationKind>();
const mode = ref<ListMode>("grid");

const customizations = computed<Customization[]>(() => {
  let customizations: Customization[] = [...props.items];
  if (kind.value) {
    customizations = customizations.filter((customization) => customization.kind === kind.value);
  }
  return customizations;
});
</script>
