<template>
  <ClientOnly>
    <div class="row">
      <div class="col-xs-12 col-sm-6 mb-4">
        <ScriptSelect :scripts="scripts" label="Filtrer par alphabet" :model-value="script?.id" placeholder="Tous" @selected="script = $event" />
      </div>
      <div class="col-xs-12 col-sm-6 mb-4">
        <ListMode class="mb-4" v-model="mode" />
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
import type { ListMode } from "~/types/components";

const { orderBy } = arrayUtils;

const props = defineProps<{
  items: Language[];
}>();

const script = ref<Script>();
const scripts = ref<Script[]>([]);
const mode = ref<ListMode>("grid");

const languages = computed<Language[]>(() => {
  let languages: Language[] = [...props.items];
  if (script.value) {
    languages = languages.filter((language) => language.script?.id === script.value?.id);
  }
  return languages;
});

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
