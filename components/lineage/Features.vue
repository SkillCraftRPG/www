<template>
  <div>
    <h2 class="h3">Particularités</h2>
    <p>Le personnage acquiert les capacités suivantes.</p>
    <LineageFeature v-for="(feature, index) in features" :key="index" :feature="feature" />
  </div>
</template>

<script setup lang="ts">
import { arrayUtils } from "logitar-js";

import type { Feature } from "~/types/game";
import type { LineageBase } from "~/types/lineages";

const { orderBy } = arrayUtils;

const props = defineProps<{
  lineage: LineageBase;
}>();

const features = computed<Feature[]>(() => orderBy(props.lineage.features, "name"));
</script>
