<template>
  <ClientOnly>
    <h2 class="h3">Liste des pouvoirs</h2>
    <div class="row">
      <div class="col-xs-12 col-sm-6 col-md-4 mb-4">
        <SpellCategorySelect v-if="categories.length" :categories="categories" :model-value="category?.id" placeholder="Toutes" @selected="selectCategory" />
      </div>
      <div class="col-xs-12 col-sm-6 col-md-4 mb-4">
        <SpellCategorySelect
          v-if="subCategories.length"
          :categories="subCategories"
          id="sub-category"
          label="Sous-catégorie"
          :model-value="subCategory?.id"
          placeholder="Toutes"
          @selected="subCategory = $event"
        />
      </div>
      <div class="col-xs-12 col-sm-6 col-md-4 mb-4">
        <ListMode v-model="mode" />
      </div>
    </div>
    <template v-for="group in groups" :key="group.tier">
      <h3 class="h5">Pouvoirs de tiers {{ group.tier }}</h3>
      <div v-if="mode === 'grid'" class="row">
        <div v-for="spell in group.spells" :key="spell.id" class="col-xs-12 col-sm-6 col-md-4 mb-4">
          <SpellCard :category="spell.category" :spell="spell" class="d-flex flex-column h-100" />
        </div>
      </div>
      <table v-else-if="mode === 'list'" class="table table-striped text-center">
        <thead>
          <tr>
            <th scope="col" class="w-25">Nom</th>
            <th scope="col" class="w-twelfth">Catégorie</th>
            <th scope="col" class="w-two-thirds">Résumé</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="spell in group.spells" :key="spell.id">
            <td>
              <NuxtLink :to="`/regles/magie/pouvoirs/${spell.slug}`">{{ spell.name }}</NuxtLink>
            </td>
            <td>
              <template v-if="spell.category">{{ spell.category.name }}</template>
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

type CategorizedSpell = Spell & {
  category?: SpellCategory;
};
type SpellGroup = {
  tier: number;
  spells: CategorizedSpell[];
};

const { orderBy } = arrayUtils;

const props = defineProps<{
  items: Spell[];
  scope?: string;
}>();

const category = ref<SpellCategory | undefined>();
const mode = ref<ListMode>("grid");
const subCategory = ref<SpellCategory | undefined>();

const categories = computed<SpellCategory[]>(() => {
  const map = new Map<string, SpellCategory>();
  props.items.forEach((spell) => {
    spell.categories.forEach((category) => register(category, map));
  });
  const categories: SpellCategory[] = [];
  for (const category of map.values()) {
    if (category.parent) {
      const parent: SpellCategory | undefined = map.get(category.parent.id);
      if (parent) {
        parent.children.push(category);
      }
    }
    if (category.parent?.id === props.scope) {
      categories.push(category);
    }
  }
  return orderBy(categories, "key");
});
function register(category: SpellCategory, map: Map<string, SpellCategory>): void {
  map.set(category.id, category);
  if (category.parent) {
    register(category.parent, map);
  }
}
const subCategories = computed<SpellCategory[]>(() => orderBy(category.value?.children ?? [], "key"));

const groups = computed<SpellGroup[]>(() => {
  const map = new Map<number, Spell[]>();
  props.items.forEach((spell) => {
    if (subCategory.value && !spell.categories.some((cat) => cat.id === subCategory.value?.id)) {
      return;
    } else if (
      category.value &&
      !spell.categories.some((cat) => cat.id === category.value?.id) &&
      !spell.categories.some((cat) => cat.parent?.id === category.value?.id)
    ) {
      return;
    }

    const parentId: string | undefined = subCategory.value?.id ?? category.value?.id ?? props.scope;
    const categorized: CategorizedSpell = categorize(spell, parentId);
    const spells: Spell[] | undefined = map.get(spell.tier);
    if (spells) {
      spells.push(categorized);
    } else {
      map.set(spell.tier, [categorized]);
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
function categorize(spell: Spell, parentId: string | undefined): CategorizedSpell {
  const map: Map<string, SpellCategory> = new Map();
  for (const category of spell.categories) {
    let current: SpellCategory | undefined = category;
    while (current) {
      if (current.parent?.id === parentId) {
        map.set(current.id, current);
        break;
      }
      current = current.parent ?? undefined;
    }
  }
  return { ...spell, category: map.size === 1 ? [...map.values()][0] : undefined };
}

function selectCategory(value: SpellCategory | undefined): void {
  subCategory.value = undefined;
  category.value = value;
}
</script>
