<template>
  <LinkCard :text="spell.summary" :title="spell.name" :to="`/regles/magie/pouvoirs/${spell.slug}`">
    <template v-if="subCategory" #subtitle-override>
      <h3 class="card-subtitle h6 mb-2 text-body-secondary"><font-awesome-icon icon="fas fa-tag" />&nbsp;{{ subCategory }}</h3>
    </template>
  </LinkCard>
</template>

<script lang="ts" setup>
import type { Spell, SpellCategory } from "~/types/magic";

const props = defineProps<{
  category?: string;
  spell: Spell;
}>();

const subCategory = computed<string | undefined>(() => {
  if (!props.category) {
    return undefined;
  }
  const category: SpellCategory | undefined = props.spell.categories.find((category) => category.parent?.id === props.category);
  return category?.name;
});
</script>
