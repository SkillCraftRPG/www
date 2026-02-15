<template>
  <div>
    <div v-for="quest in sortedQuests" :key="quest.id" class="mb-2">
      <QuestCard :quest="quest" :selected="selected?.id === quest.id" @click="$emit('selected', quest)" />
    </div>
  </div>
</template>

<script setup lang="ts">
import { arrayUtils } from "logitar-js";

import type { Quest } from "~/types/quests";

const { orderBy } = arrayUtils;

const props = defineProps<{
  quests: Quest[];
  selected?: Quest;
}>();

const emit = defineEmits<{
  (e: "selected", quest: Quest | undefined): void;
}>();

const sortedQuests = computed<Quest[]>(() => orderBy(props.quests, "title"));

watch(
  sortedQuests,
  (sortedQuests) => {
    if (props.selected) {
      if (!sortedQuests.length) {
        emit("selected", undefined);
      }
    } else if (sortedQuests.length) {
      emit("selected", sortedQuests[0]);
    }
  },
  { immediate: true },
);
</script>
