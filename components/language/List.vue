<template>
  <ClientOnly>
    <div class="row">
      <div class="col-xs-12 col-sm-6 col-md-4 mb-4">
        <SearchInput :model-value="search" @update:model-value="setQuery('search', $event)" />
      </div>
      <div class="col-xs-12 col-sm-6 col-md-4 mb-4">
        <ScriptSelect
          :scripts="scripts"
          label="Filtrer par alphabet"
          :model-value="script"
          placeholder="Tous"
          @update:model-value="setQuery('script', $event)"
        />
      </div>
      <div class="col-xs-12 col-sm-6 col-md-4 mb-4">
        <ListMode class="mb-4" :model-value="mode" @update:model-value="setMode" />
      </div>
    </div>
    <div v-if="mode === 'grid'" class="row">
      <div v-for="language in languages" :key="language.id" class="col-xs-12 col-sm-6 col-md-4 col-lg-3 mb-4">
        <LanguageCard class="d-flex flex-column h-100" :language="language" />
      </div>
    </div>
    <table v-else-if="mode === 'list'" class="table table-striped text-center">
      <thead>
        <tr>
          <th scope="col" class="w-15">Langue</th>
          <th scope="col" class="w-15">Système d’écriture</th>
          <th scope="col" class="w-70">Résumé</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="language in languages" :key="language.id">
          <td>
            <NuxtLink :to="`/regles/langues/${language.slug}`">{{ language.name }}</NuxtLink>
          </td>
          <td>
            <NuxtLink v-if="language.script" :to="`/regles/langues/scripts/${language.script.slug}`">{{ language.script.name }}</NuxtLink>
            <span v-else class="text-muted">{{ "—" }}</span>
          </td>
          <td>
            <template v-if="language.summary">{{ language.summary }}</template>
            <span v-else class="text-muted">{{ "—" }}</span>
          </td>
        </tr>
      </tbody>
    </table>
  </ClientOnly>
</template>

<script setup lang="ts">
import { arrayUtils } from "logitar-js";

import type { Language, Script } from "~/types/game";

const { mode, setMode } = useListMode();
const { orderBy } = arrayUtils;

const props = defineProps<{
  items: Language[];
}>();

const scripts = ref<Script[]>([]);

const script = computed<string>(() => getQuery("script").toLocaleLowerCase());
const search = computed<string>(() => getQuery("search").trim().toLocaleLowerCase());

const languages = computed<Language[]>(() =>
  props.items.filter((language) => {
    if (script.value && language.script?.slug.toLocaleLowerCase() !== script.value) {
      return false;
    }
    if (search.value && !language.name.toLocaleLowerCase().includes(search.value) && !(language.summary ?? "").toLocaleLowerCase().includes(search.value)) {
      return false;
    }
    return true;
  }),
);

watch(
  () => props.items,
  (items) => {
    const map = new Map<string, Script>();
    items.forEach((language) => {
      if (language.script) {
        map.set(language.script.id, language.script);
      }
    });
    scripts.value = orderBy([...map.values()], "slug");
  },
  { deep: true, immediate: true },
);
</script>
