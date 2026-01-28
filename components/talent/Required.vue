<template>
  <div>
    <h2 class="h3">Talent requis</h2>
    <p>Le talent ci-dessous doit être acquis préalablement à l’acquisition de ce talent.</p>
    <TalentCard class="mb-4" :talent="talent" />
  </div>
</template>

<script setup lang="ts">
import type { Talent } from "~/types/game";

defineProps<{
  talent: Talent;
}>();
</script>
