<template>
  <LinkCard :text="ethnicity.summary" :title="ethnicity.name" :to="to" />
</template>

<script lang="ts" setup>
import type { Ethnicity, Species } from "~/types/lineages";

const props = defineProps<{
  ethnicity: Ethnicity;
  species?: Species;
}>();

const to = computed<string>(() => {
  const species: Species | undefined = props.species ?? props.ethnicity.species ?? undefined;
  if (!species) {
    throw new Error(`A species is required for ethnicity "${props.ethnicity.name} (Id=${props.ethnicity.id})".`);
  }
  return `/regles/especes/${species.slug}/${props.ethnicity.slug}`;
});
</script>
