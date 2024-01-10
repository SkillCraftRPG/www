<script setup lang="ts">
import { onMounted, ref } from "vue";

import ProgressItem from "@/components/ProgressItem.vue";
import type { ProgressItem as ProgressItemT } from "@/types";
import { readProgress } from "@/api";

const root = ref<ProgressItemT>();

onMounted(async () => (root.value = await readProgress()));
</script>

<template>
  <main class="container">
    <ProgressItem v-if="root" :item="root" />
  </main>
</template>
