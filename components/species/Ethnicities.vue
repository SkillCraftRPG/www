<template>
  <div>
    <h2 class="h3">Ethnies</h2>
    <p>Cette espèce se décline en les ethnies suivantes.</p>
    <div class="row">
      <div v-for="ethnicity in species.ethnicities" :key="ethnicity.id" class="col-xs-12 col-sm-6 col-md-4 mb-4">
        <EthnicityCard class="d-flex flex-column h-100" :ethnicity="ethnicity" :species="species" />
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import type { Species } from "~/types/lineages";

defineProps<{
  species: Species;
}>();
</script>
