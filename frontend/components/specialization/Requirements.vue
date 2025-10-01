<template>
  <div>
    <h2 class="h3">Requis</h2>
    <ul v-if="specialization.requirements.other.length > 0">
      <li v-for="(requirement, index) in specialization.requirements.other" :key="index">
        <MarkdownContent inline :text="requirement" />
      </li>
    </ul>
    <p v-else>Aucun critère.</p>
    <template v-if="specialization.requirements.talent">
      <h3 class="h5">Talent obligatoire</h3>
      <div class="mb-4">
        <TalentCard :talent="specialization.requirements.talent" />
      </div>
    </template>
  </div>
</template>

<script setup lang="ts">
import type { Specialization } from "~/types/specializations";

defineProps<{
  specialization: Specialization;
}>();
</script>
