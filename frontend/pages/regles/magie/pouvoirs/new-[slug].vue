<template>
  <main class="container">
    <template v-if="spell">
      <h1>{{ title }}</h1>
      <AppBreadcrumb :active="title" :parent="parent" />
      <SpellInfoNew :spell="spell" />
      <MarkdownContent v-if="spell.description" :text="spell.description" />
      <template v-for="group in abilities" :key="group.level">
        <div class="d-flex align-items-center gap-3">
          <h2 class="h3">Niveau {{ group.level }}</h2>
          <div class="h5">
            <TarBadge variant="secondary">Énergie&nbsp;:&nbsp;{{ $n(calculateStamina(group.level), "integer") }}</TarBadge>
          </div>
        </div>
        <SpellAbility
          v-for="(ability, index) in group.abilities"
          :key="index"
          :ability="ability"
          :title="group.abilities.length > 1 ? (ability.name ?? spell.name) : undefined"
        />
      </template>
    </template>
  </main>
</template>

<script setup lang="ts">
import { arrayUtils } from "logitar-js";

import type { Breadcrumb } from "~/types/components";
import type { SpellNew, SpellAbility } from "~/types/magic";

const config = useRuntimeConfig();
const parent: Breadcrumb[] = [
  { text: "Magie", to: "/regles/magie" },
  { text: "Pouvoirs", to: "/regles/magie/pouvoirs" },
];
const route = useRoute();
const { orderBy } = arrayUtils;

const slug = computed<string>(() => (Array.isArray(route.params.slug) ? route.params.slug[0] : route.params.slug));
const { data } = await useAsyncData<SpellNew>(
  `spell:${slug.value}`,
  () =>
    $fetch(`/api/spells/slug:${slug.value}`, {
      baseURL: config.public.apiBaseUrl,
    }),
  { watch: [slug] },
);

const spell = computed<SpellNew | undefined>(() => data.value ?? undefined);
const title = computed<string>(() => spell.value?.name ?? "");
const description = computed<string>(() => spell.value?.metaDescription ?? "");

type GroupedAbilities = {
  level: number;
  abilities: SpellAbility[];
};
const abilities = computed<GroupedAbilities[]>(() => {
  if (!spell.value) {
    return [];
  }
  const tier: number = spell.value.tier;
  const map: Map<number, SpellAbility[]> = new Map();
  spell.value.abilities.forEach((ability) => {
    const level: number = ability.level;
    const abilities: SpellAbility[] = map.get(level) ?? [];
    abilities.push(ability);
    map.set(level, abilities);
  });
  return orderBy(
    Array.from(map.entries()).map(([level, abilities]) => ({ level: level + tier + (tier < 3 ? 1 : 2), abilities: orderBy(abilities, "name") })),
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
