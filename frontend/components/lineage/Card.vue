<template>
  <LinkCard :text="lineage.summary" :title="lineage.name" :to="`/regles/especes/${lineage.slug}`" />
</template>

<script lang="ts" setup>
import type { Lineage } from "~/types/game";

defineProps<{
  lineage: Lineage;
}>();
</script>
