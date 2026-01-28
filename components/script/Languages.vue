<template>
  <div>
    <h2 class="h3">Langues</h2>
    <p>Les langues suivantes utilisent ce système d’écriture.</p>
    <div class="row">
      <div v-for="language in languages" :key="language.id" class="col-xs-12 col-sm-6 col-md-4 col-lg-3 mb-4">
        <LanguageCard class="d-flex flex-column h-100" :language="language" />
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import type { Language } from "~/types/game";

defineProps<{
  languages: Language[];
}>();
</script>
