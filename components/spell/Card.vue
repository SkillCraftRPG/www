<template>
  <LinkCard :text="spell.summary" :title="spell.name" :to="`/regles/magie/pouvoirs/${spell.slug}`" />
</template>

<script lang="ts" setup>
import type { Spell } from "~/types/magic";

defineProps<{
  spell: Spell;
}>();
</script>
