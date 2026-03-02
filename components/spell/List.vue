<template>
  <ClientOnly>
    <ListMode class="mb-4" v-model="mode" />
    <template v-for="group in groups" :key="group.tier">
      <h3 class="h5">Pouvoirs de tiers {{ group.tier }}</h3>
      <div v-if="mode === 'grid'" class="row">
        <div v-for="spell in group.spells" :key="spell.id" class="col-xs-12 col-sm-6 col-md-4 mb-4">
          <SpellCard :category="category" :spell="spell" class="d-flex flex-column h-100" />
        </div>
      </div>
      <table v-else-if="mode === 'list'" class="table table-striped text-center">
        <thead>
          <tr>
            <th scope="col" :class="{ 'w-25': Boolean(category), 'w-third': !category }">Nom</th>
            <th v-if="category" scope="col" class="w-twelfth">Catégorie</th>
            <th scope="col" class="w-two-thirds">Résumé</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="spell in group.spells" :key="spell.id">
            <td>
              <NuxtLink :to="`/regles/magie/pouvoirs/${spell.slug}`">{{ spell.name }}</NuxtLink>
            </td>
            <td v-if="category">
              <template v-if="findCategory(spell)">{{ findCategory(spell) }}</template>
              <span v-else class="text-muted">{{ "—" }}</span>
            </td>
            <td>
              <template v-if="spell.summary">{{ spell.summary }}</template>
              <span v-else class="text-muted">{{ "—" }}</span>
            </td>
          </tr>
        </tbody>
      </table>
    </template>
  </ClientOnly>
</template>

<script setup lang="ts">
import { arrayUtils } from "logitar-js";

import type { ListMode } from "~/types/components";
import type { Spell, SpellCategory } from "~/types/magic";

type SpellGroup = {
  tier: number;
  spells: Spell[];
};

const { orderBy } = arrayUtils;

const props = defineProps<{
  category?: string;
  items: Spell[];
}>();

const mode = ref<ListMode>("grid");

const groups = computed<SpellGroup[]>(() => {
  const map = new Map<number, Spell[]>();
  props.items.forEach((spell) => {
    const spells: Spell[] | undefined = map.get(spell.tier);
    if (spells) {
      spells.push(spell);
    } else {
      map.set(spell.tier, [spell]);
    }
  });

  const groups: SpellGroup[] = [];
  for (let tier = 0; tier <= 3; tier++) {
    const spells: Spell[] = orderBy(map.get(tier) ?? [], "slug");
    if (spells.length) {
      groups.push({ tier, spells });
    }
  }
  return groups;
});

function findCategory(spell: Spell): string | undefined {
  const category: SpellCategory | undefined = spell.categories.find((category) => category.parent?.id === props.category);
  return category?.name;
} // TODO(fpion): refactor, not very performant
</script>
