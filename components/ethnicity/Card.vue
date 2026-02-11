<template>
  <LinkCard :text="ethnicity.summary" :title="ethnicity.name" :to="to" />
</template>

<script lang="ts" setup>
import type { Ethnicity, Species } from "~/types/lineages";

const props = defineProps<{
  ethnicity: Ethnicity;
  species?: Species | null;
}>();

const to = computed<string>(() => {
  const species: string = props.species?.slug ?? props.ethnicity.species?.slug ?? "";
  return `/regles/especes/${species}/${props.ethnicity.slug}`;
});
</script>
