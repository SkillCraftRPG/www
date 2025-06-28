<template>
  <LinkCard :subtitle="subtitle" :text="caste.summary" :title="caste.name" :to="`/regles/castes/${caste.slug}`" />
</template>

<script lang="ts" setup>
import type { Caste } from "~/types/game";

const props = defineProps<{
  caste: Caste;
}>();

const subtitle = computed<string | undefined>(() => props.caste.skill?.name ?? undefined);
</script>
