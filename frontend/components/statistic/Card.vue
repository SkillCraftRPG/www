<template>
  <LinkCard :subtitle="statistic.attribute?.name" :text="statistic.summary" :title="statistic.name" :to="`/regles/statistiques/${statistic.slug}`" />
</template>

<script lang="ts" setup>
import type { Statistic } from "~/types/game";

withDefaults(
  defineProps<{
    clickable?: boolean | string;
    noAttribute?: boolean | string;
    statistic: Statistic;
  }>(),
  {
    clickable: false,
  },
);
</script>
