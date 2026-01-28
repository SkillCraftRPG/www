<template>
  <a :href="url" target="_blank">
    <div class="card clickable">
      <div class="card-body">
        <img :src="picture" :alt="name" class="img-fluid" />
      </div>
    </div>
  </a>
</template>

<script setup lang="ts">
import type { Download } from "~/types/components";

defineProps<Download>();
</script>

<style scoped>
.card {
  text-align: center;
}
</style>
