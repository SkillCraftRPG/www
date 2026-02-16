import { defineStore } from "pinia";

export const useQuestStore = defineStore(
  "quest",
  () => {
    const isGrouping = ref<boolean>(false);
    const sortOption = ref<string>("title_asc");

    return { isGrouping, sortOption };
  },
  { persist: true },
);
