<template>
  <main class="container">
    <template v-if="title">
      <h1>{{ title }}</h1>
      <AppBreadcrumb :active="title" :parent="parent" />
    </template>
    <table v-if="specialization" class="table table-striped text-center">
      <tbody>
        <tr>
          <th scope="row" class="w-50">Tiers</th>
          <td class="w-50">{{ specialization.tier }}</td>
        </tr>
      </tbody>
    </table>
    <div v-if="html" v-html="html"></div>
    <template v-if="hasRequirements">
      <h2 class="h3">Requis</h2>
      <ul>
        <li v-for="(other, index) in specialization?.requirements.other" :key="index" v-html="(marked.parse(other) as string).replace(/<\/?p>/g, '')"></li>
        <li v-if="specialization?.requirements.talent">
          <strong>Talent obligatoire.</strong>{{ " "
          }}<NuxtLink :to="`/regles/talents/${specialization?.requirements.talent}`">{{ specialization?.requirements.talent }}</NuxtLink>
        </li>
      </ul>
    </template>
    <template v-if="hasOptions">
      <h2 class="h3">Options</h2>
      <ul>
        <li v-if="specialization?.options.talents.length">
          <strong>Talents optionnels.</strong>
          <ul>
            <li v-for="talent in specialization?.options.talents" :key="talent">
              <NuxtLink :to="`/regles/talents/${talent}`">{{ talent }}</NuxtLink>
            </li>
          </ul>
        </li>
        <li v-for="(other, index) in specialization?.options.other" :key="index" v-html="(marked.parse(other) as string).replace(/<\/?p>/g, '')"></li>
      </ul>
    </template>
    <template v-if="reservedTalent">
      <h2 class="h3">Talent réservé : {{ reservedTalent.name }}</h2>
      <p>Le personnage acquiert les capacités suivantes.</p>
      <ul v-if="reservedTalent.description.length > 0">
        <li v-for="(line, index) in reservedTalent.description" :key="index" v-html="(marked.parse(line) as string).replace(/<\/?p>/g, '')"></li>
      </ul>
      <template v-if="reservedTalent.discountedTalents.length > 0">
        <h3 class="h5">Talents à rabais</h3>
        <ul>
          <li v-for="talent in reservedTalent.discountedTalents" :key="talent">
            <NuxtLink :to="`/regles/talents/${talent}`">{{ talent }}</NuxtLink>
          </li>
        </ul>
      </template>
      <template v-for="feature in reservedTalent.features" :key="feature.name">
        <h3 class="h5">{{ feature.name }}</h3>
        <div v-html="marked.parse(feature.description ?? '')"></div>
      </template>
    </template>
  </main>
</template>

<script setup lang="ts">
import { marked } from "marked";

import specializations from "~/assets/data/specializations.json";
import type { Breadcrumb } from "~/types/components";
import type { ReservedTalent, Specialization } from "~/types/game";

const parent: Breadcrumb[] = [{ text: "Spécialisations", to: "/regles/specialisations" }];
const route = useRoute();

const slug = computed<string>(() => (Array.isArray(route.params.slug) ? route.params.slug[0] : route.params.slug));
const specialization = computed<Specialization | undefined>(() => specializations.filter((specialization) => specialization.slug === slug.value)[0]);
const html = computed<string | undefined>(() => (specialization.value?.description ? (marked.parse(specialization.value.description) as string) : undefined));
const title = computed<string | undefined>(() => specialization.value?.name);

const hasRequirements = computed<boolean>(() =>
  Boolean(specialization.value && (specialization.value.requirements.talent || specialization.value.requirements.other.length > 0)),
);
const hasOptions = computed<boolean>(() =>
  Boolean(specialization.value && (specialization.value.options.talents.length > 0 || specialization.value.options.other.length > 0)),
);

const reservedTalent = computed<ReservedTalent | undefined>(() => specialization.value?.reservedTalent);

useSeo({
  title: title.value,
  description: specialization.value?.summary,
});
</script>
