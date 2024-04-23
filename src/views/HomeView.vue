<script setup lang="ts">
import ProgressItem from "@/components/ProgressItem.vue";
import progress from "@/assets/data/progress.json";
</script>

<template>
  <main class="container">
    <ProgressItem v-if="progress" :item="progress" />
  </main>
</template>
