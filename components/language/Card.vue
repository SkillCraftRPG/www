<template>
  <LinkCard :text="language.summary" :title="language.name" :to="`/regles/langues/${language.slug}`">
    <template v-if="language.script" #subtitle-override>
      <h3 class="card-subtitle h6 mb-2 text-body-secondary"><font-awesome-icon icon="fas fa-scroll" /> {{ language.script.name }}</h3>
    </template>
  </LinkCard>
</template>

<script lang="ts" setup>
import type { Language } from "~/types/game";

defineProps<{
  language: Language;
}>();
</script>
