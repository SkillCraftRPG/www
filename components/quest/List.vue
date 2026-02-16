<template>
  <div>
    <TarSelect class="mb-4" floating id="sort" label="Tri" :options="sortOptions" v-model="sort">
      <template #after>
        <TarCheckbox id="group" label="Grouper" switch v-model="group" />
      </template>
    </TarSelect>
    <template v-if="group">
      <div v-for="grouped in groupedQuests" :key="grouped.group" class="mb-4">
        <h2 class="h4">{{ grouped.group }}</h2>
        <div v-for="quest in grouped.quests" :key="quest.id" class="mb-2">
          <QuestCard :quest="quest" :selected="selected?.id === quest.id" @click="$emit('selected', quest)" />
        </div>
      </div>
    </template>
    <template v-else>
      <div v-for="quest in sortedQuests" :key="quest.id" class="mb-2">
        <QuestCard :quest="quest" :selected="selected?.id === quest.id" @click="$emit('selected', quest)" />
      </div>
    </template>
  </div>
</template>

<script setup lang="ts">
import { arrayUtils } from "logitar-js";

import type { Quest } from "~/types/quests";
import type { SelectOption } from "~/types/tar/select";

type GroupedQuests = {
  group: string;
  quests: Quest[];
};
type SortableQuest = Quest & {
  sort: string;
};

const sortOptions: SelectOption[] = [
  { text: "Nom (croissant)", value: "title_asc" },
  { text: "Nom (décroissant)", value: "title_desc" },
  { text: "Progression (croissant)", value: "progress_asc" },
  { text: "Progression (décroissant)", value: "progress_desc" },
];
const { orderBy, orderByDescending } = arrayUtils;

const props = defineProps<{
  quests: Quest[];
  selected?: Quest;
}>();

const emit = defineEmits<{
  (e: "selected", quest: Quest | undefined): void;
}>();

const group = ref<boolean>(false);
const sort = ref<string>("title_asc");

const groupedQuests = computed<GroupedQuests[]>(() => {
  const map: Map<string, Quest[]> = new Map();
  props.quests.forEach((quest) => {
    const key: string = quest.group?.name ?? "";
    const quests: Quest[] | undefined = map.get(key);
    if (quests) {
      quests.push(quest);
    } else {
      map.set(key, [quest]);
    }
  });
  return orderBy(
    [...map.entries()].map(([group, quests]) => ({ group, quests: sortQuests(quests) })),
    "group",
  );
});
const sortedQuests = computed<Quest[]>(() => sortQuests(props.quests));

function sortQuests(quests: Quest[]): Quest[] {
  const options: string[] = sort.value.split("_");
  if (options.length === 2) {
    const sortable: SortableQuest[] = quests.map((quest) => toSortable(quest, options[0]));
    switch (options[1]) {
      case "asc":
        return orderBy(sortable, "sort");
      case "desc":
        return orderByDescending(sortable, "sort");
    }
  }
  return quests;
}

function toSortable(quest: Quest, field: string): SortableQuest {
  switch (field) {
    case "progress":
      return { ...quest, sort: [quest.progressRatio, unaccent(quest.title)].join("_") };
    case "title":
      return { ...quest, sort: unaccent(quest.title) };
  }
  return { ...quest, sort: "" };
}

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
