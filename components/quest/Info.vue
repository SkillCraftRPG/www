<template>
  <div>
    <h2 class="h3">{{ quest.title }}</h2>
    <MarkdownContent v-if="quest.htmlContent" :text="quest.htmlContent" />
    <p v-if="quest.grantedLevels" class="text-primary">
      <strong>Niveaux accordés : {{ $n(levels, "integer") }} / {{ $n(quest.grantedLevels, "integer") }}</strong>
    </p>
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

const props = defineProps<{
  quest: Quest;
}>();

const levels = computed<number>(() => props.quest.grantedLevels * props.quest.progressRatio);
</script>
