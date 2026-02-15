<template>
  <div>
    <h2 class="h3">{{ quest.title }}</h2>
    <MarkdownContent v-if="quest.htmlContent" :text="quest.htmlContent" />
    <template v-if="quest.completedEntries">
      <h3 class="h5">Entrées complétées</h3>
      <MarkdownContent :text="quest.completedEntries" />
    </template>
    <template v-if="quest.activeEntries">
      <h3 class="h5">Entrées actives</h3>
      <MarkdownContent :text="quest.activeEntries" />
    </template>
  </div>
</template>

<script setup lang="ts">
import type { Quest } from "~/types/quests";

defineProps<{
  quest: Quest;
}>();
</script>
