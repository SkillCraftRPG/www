<template>
  <div>
    <h2 class="h3">Langues</h2>
    <MarkdownContent v-if="languages.text" :text="languages.text" />
    <div v-if="languages.extra > 0" class="h5 mb-3">
      <TarBadge variant="secondary">Au&nbsp;choix&nbsp;:&nbsp;{{ languages.extra }}</TarBadge>
    </div>
    <template v-if="items.length">
      <p>Le personnage connaît également les langues suivantes.</p>
      <div v-for="language in items" :key="language.id" class="col-xs-12 mb-4">
        <LanguageCard class="d-flex flex-column h-100" :language="language" />
      </div>
    </template>
  </div>
</template>

<script setup lang="ts">
import { arrayUtils } from "logitar-js";

import type { Language } from "~/types/game";
import type { Languages } from "~/types/lineages";

const { orderBy } = arrayUtils;

const props = defineProps<{
  languages: Languages;
}>();

const items = computed<Language[]>(() => orderBy(props.languages.items, "slug"));
</script>
