<template>
  <div>
    <h2 class="h3">Système d’écriture</h2>
    <p>Cette langue utilise le système d’écriture suivant.</p>
    <ScriptCard class="mb-4" :script="script" />
  </div>
</template>

<script setup lang="ts">
import type { Script } from "~/types/game";

defineProps<{
  script: Script;
}>();
</script>
