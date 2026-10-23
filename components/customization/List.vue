<template>
  <ClientOnly>
    <div class="row">
      <div class="col-xs-12 col-sm-6 col-md-4 mb-4">
        <SearchInput :model-value="search" @update:model-value="setQuery('search', $event)" />
      </div>
      <div class="col-xs-12 col-sm-6 col-md-4 mb-4">
        <CustomizationKindSelect label="Filtrer par type" :model-value="kind" placeholder="Tous" @update:model-value="setQuery('kind', $event)" />
      </div>
      <div class="col-xs-12 col-sm-6 col-md-4 mb-4">
        <ListMode :model-value="mode" @update:model-value="setMode" />
      </div>
    </div>
    <div v-if="mode === 'grid'" class="row">
      <div v-for="customization in customizations" :key="customization.id" class="col-xs-12 col-sm-6 col-md-4 col-lg-3 mb-4">
        <CustomizationCard :customization="customization" class="d-flex flex-column h-100" />
      </div>
    </div>
    <table v-else-if="mode === 'list'" class="table table-striped text-center">
      <thead>
        <tr>
          <th scope="col" class="w-20">Personnalisation</th>
          <th scope="col" class="w-20">Type</th>
          <th scope="col" class="w-60">Résumé</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="customization in customizations" :key="customization.id">
          <td>
            <NuxtLink :to="`/regles/dons-handicaps/${customization.slug}`">{{ customization.name }}</NuxtLink>
          </td>
          <td>
            <CustomizationKind class="text-muted" :customization="customization" />
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

const { mode, setMode } = useListMode();

const props = defineProps<{
  items: Customization[];
}>();

const kind = computed<CustomizationKind | "">(() => {
  switch (getQuery("kind").toLocaleLowerCase()) {
    case "disability":
      return "Disability";
    case "gift":
      return "Gift";
    default:
      return "";
  }
});
const search = computed<string>(() => getQuery("search").trim().toLocaleLowerCase());

const customizations = computed<Customization[]>(() =>
  props.items.filter((customization) => {
    if (kind.value && customization.kind !== kind.value) {
      return false;
    }
    if (
      search.value &&
      !customization.name.toLocaleLowerCase().includes(search.value) &&
      !(customization.summary ?? "").toLocaleLowerCase().includes(search.value)
    ) {
      return false;
    }
    return true;
  }),
);
</script>
