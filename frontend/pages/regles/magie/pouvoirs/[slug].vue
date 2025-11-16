<template>
  <main class="container">
    <template v-if="spell">
      <h1>{{ title }}</h1>
      <AppBreadcrumb :active="title" :parent="parent" />
      <SpellInfo :spell="spell" />
      <MarkdownContent v-if="spell.description" :text="spell.description" />
      <template v-for="group in effects" :key="group.level">
        <div class="d-flex align-items-center gap-3">
          <h2 class="h3">Niveau {{ group.level }}</h2>
          <div class="h5">
            <TarBadge variant="secondary">Énergie&nbsp;:&nbsp;{{ $n(calculateStamina(group.level), "integer") }}</TarBadge>
          </div>
        </div>
        <SpellEffect
          v-for="(effect, index) in group.effects"
          :key="index"
          :effect="effect"
          :title="group.effects.length > 1 ? (effect.name ?? spell.name) : undefined"
        />
      </template>
    </template>
  </main>
</template>

<script setup lang="ts">
import { arrayUtils } from "logitar-js";

import type { Breadcrumb } from "~/types/components";
import type { Spell, SpellEffect } from "~/types/magic";

const config = useRuntimeConfig();
const parent: Breadcrumb[] = [
  { text: "Magie", to: "/regles/magie" },
  { text: "Pouvoirs", to: "/regles/magie/pouvoirs" },
];
const route = useRoute();
const { orderBy } = arrayUtils;

const slug = computed<string>(() => (Array.isArray(route.params.slug) ? route.params.slug[0] : route.params.slug));
const { data } = await useAsyncData<Spell>(
  `spell:${slug.value}`,
  () =>
    $fetch(`/spells/${slug.value}.json`, {
      baseURL: config.public.apiBaseUrl,
    }),
  { watch: [slug] },
);

const spell = computed<Spell | undefined>(() => data.value ?? undefined);
const title = computed<string>(() => spell.value?.name ?? "");
const description = computed<string>(() => spell.value?.metaDescription ?? "");

type GroupedEffects = {
  level: number;
  effects: SpellEffect[];
};
const effects = computed<GroupedEffects[]>(() => {
  if (!spell.value) {
    return [];
  }
  const tier: number = spell.value.tier;
  const map: Map<number, SpellEffect[]> = new Map();
  spell.value.effects.forEach((effect) => {
    const level: number = effect.level;
    const effects: SpellEffect[] = map.get(level) ?? [];
    effects.push(effect);
    map.set(level, effects);
  });
  return orderBy(
    Array.from(map.entries()).map(([level, effects]) => ({ level: level + tier + (tier < 3 ? 1 : 2), effects: orderBy(effects, "name") })),
    "level",
  );
});

function calculateStamina(level: number): number {
  if (!spell.value) {
    return 0;
  }
  const base: number = 4 + spell.value.tier * 2;
  return base * level;
}

useSeo({ title, description });
</script>
