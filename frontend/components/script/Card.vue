<template>
  <LinkCard :text="script.summary" :title="script.name" :to="`/regles/langues/scripts/${script.slug}`" />
</template>

<script lang="ts" setup>
import type { Script } from "~/types/game";

defineProps<{
  script: Script;
}>();
</script>
