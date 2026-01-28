<template>
  <ClientOnly>
    <ListMode class="mb-4" v-model="mode" />
    <div v-if="mode === 'grid'" class="row">
      <div v-for="script in scripts" :key="script.id" class="col-xs-12 col-sm-6 col-md-4 col-lg-3 mb-4">
        <ScriptCard class="d-flex flex-column h-100" :script="script" />
      </div>
    </div>
    <table v-else-if="mode === 'list'" class="table table-striped text-center">
      <thead>
        <tr>
          <th scope="col" class="w-20">Système d’écriture</th>
          <th scope="col" class="w-80">Résumé</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="script in scripts" :key="script.id">
          <td>
            <NuxtLink :to="`/regles/langues/scripts/${script.slug}`">{{ script.name }}</NuxtLink>
          </td>
          <td>
            <template v-if="script.summary">{{ script.summary }}</template>
            <span v-else class="text-muted">{{ "—" }}</span>
          </td>
        </tr>
      </tbody>
    </table>
  </ClientOnly>
</template>

<script setup lang="ts">
import type { ListMode } from "~/types/components";
import type { Script } from "~/types/game";

const props = defineProps<{
  items: Script[];
}>();

const mode = ref<ListMode>("grid");

const scripts = computed<Script[]>(() => props.items);
</script>
