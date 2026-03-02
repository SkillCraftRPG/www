<template>
  <LinkCard :text="spell.summary" :title="spell.name" :to="`/regles/magie/pouvoirs/${spell.slug}`">
    <template v-if="category" #subtitle-override>
      <h3 class="card-subtitle h6 mb-2 text-body-secondary"><font-awesome-icon icon="fas fa-tag" />&nbsp;{{ category.name }}</h3>
    </template>
  </LinkCard>
</template>

<script lang="ts" setup>
import type { Spell, SpellCategory } from "~/types/magic";

defineProps<{
  category?: SpellCategory;
  spell: Spell;
}>();
</script>
