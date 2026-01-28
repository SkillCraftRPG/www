<template>
  <div>
    <h2 class="h3">Ethnies</h2>
    <p>Cette espèce se décline en les ethnies suivantes.</p>
    <div class="row">
      <div v-for="lineage in children" :key="lineage.id" class="col-xs-12 col-sm-6 col-md-4 mb-4">
        <LineageCard class="d-flex flex-column h-100" :lineage="lineage" />
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import type { Lineage } from "~/types/lineages";

defineProps<{
  children: Lineage[];
}>();
</script>
