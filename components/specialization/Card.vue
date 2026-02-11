<template>
  <LinkCard :title="specialization.name" :to="`/regles/specialisations/${specialization.slug}`">
    <template v-if="specialization.doctrine" #subtitle-override>
      <h3 class="card-subtitle h6 mb-2 text-body-secondary"><TalentIcon /> {{ specialization.doctrine.name }}</h3>
    </template>
    <div v-if="specialization.summary" class="card-text">{{ specialization.summary }}</div>
  </LinkCard>
</template>

<script lang="ts" setup>
import type { Specialization } from "~/types/specializations";

defineProps<{
  specialization: Specialization;
}>();
</script>
