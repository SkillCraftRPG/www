<template>
  <LinkCard :text="species.summary" :title="species.name" :to="`/regles/especes/${species.slug}`" />
</template>

<script lang="ts" setup>
import type { Species } from "~/types/lineages";

defineProps<{
  species: Species;
}>();
</script>
