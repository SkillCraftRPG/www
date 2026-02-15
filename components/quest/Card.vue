<template>
  <div :class="classes">
    <div class="card-body">
      <h2 class="card-title h5">{{ quest.title }}</h2>
      <h3 v-if="quest.group" class="card-subtitle h6 mb-2 text-body-secondary">{{ quest.group.name }}</h3>
      <div class="card-text">
        <TarProgress :label="$n(quest.progressRatio, 'percentage')" :value="quest.progressRatio * 100" />
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import { parsingUtils } from "logitar-js";

import type { Quest } from "~/types/quests";

const { parseBoolean } = parsingUtils;

const props = defineProps<{
  quest: Quest;
  selected?: boolean | string;
}>();

const classes = computed<string[]>(() => ["card", parseBoolean(props.selected) ? "selected" : "clickable"]);
</script>
