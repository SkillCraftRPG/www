<template>
  <main class="container">
    <template v-if="title">
      <h1>{{ title }}</h1>
      <AppBreadcrumb :active="title" :parent="parent" />
    </template>
    <div v-if="html" v-html="html"></div>
    <h2 class="h3">Traits</h2>
    <ul>
      <li v-for="(trait, index) in traits" :key="index">
        <strong>{{ trait.name }}.</strong>{{ " " }}<span v-html="trait.description"></span>
      </li>
      <template v-if="lineage">
        <li><strong>Langues.</strong> {{ lineage.languages.text }}</li>
        <li><strong>Noms.</strong> {{ lineage.names.text }}</li>
        <li><strong>Taille.</strong> {{ $t(`size.category.options.${lineage.size}`) }} ({{ lineage.height }} cm)</li>
        <li>
          <strong>Poids.</strong>
          <ul>
            <li>Dénutrition : {{ lineage.weight.malnutrition }}</li>
            <li>Maigre : {{ lineage.weight.skinny }}</li>
            <li>Normal : {{ lineage.weight.normal }}</li>
            <li>Surpoids : {{ lineage.weight.overweight }}</li>
            <li>Obèse : {{ lineage.weight.obese }}</li>
          </ul>
        </li>
        <li>
          <strong>Âge.</strong>
          <ul>
            <li>Enfant : moins de {{ lineage.age.teenager }}</li>
            <li>Adolescent : {{ lineage.age.teenager }} à {{ lineage.age.adult - 1 }}</li>
            <li>Adulte : {{ lineage.age.adult }} à {{ lineage.age.mature - 1 }}</li>
            <li>Mature : {{ lineage.age.mature }} à {{ lineage.age.venerable - 1 }}</li>
            <li>Vénérable : {{ lineage.age.venerable }} et plus</li>
          </ul>
        </li>
      </template>
    </ul>
    <template v-if="lineage">
      <h2 class="h3">Vitesses</h2>
      <table class="table table-striped">
        <tbody>
          <tr>
            <th class="w-third" scope="row">Marche</th>
            <td class="w-third">{{ lineage.speeds.walk }}</td>
            <td class="w-third">{{ $n(lineage.speeds.walk / 4, "decimal") }} mètres par seconde</td>
          </tr>
        </tbody>
      </table>
    </template>
  </main>
</template>

<script setup lang="ts">
import { arrayUtils } from "logitar-js";
import { marked } from "marked";

import species from "~/assets/data/species.json";
import type { Breadcrumb } from "~/types/components";
import type { Lineage, Trait } from "~/types/game";

const parent: Breadcrumb[] = [{ text: "Espèces", to: "/regles/especes" }];
const route = useRoute();
const slug: string = Array.isArray(route.params.slug) ? route.params.slug[0] : route.params.slug;
const { orderBy } = arrayUtils;

const lineage = ref<Lineage | undefined>(species.filter((species) => species.slug === slug)[0]);

const html = computed<string | undefined>(() => (lineage.value?.description ? (marked.parse(lineage.value.description) as string) : undefined));
const title = computed<string | undefined>(() => lineage.value?.name);
const traits = computed<Trait[]>(() =>
  orderBy(
    lineage.value?.traits.map(({ name, description }) => ({
      name: name,
      description: (marked.parse(description) as string).replace(/<\/?p>/g, ""),
    })) ?? [],
    "name",
  ),
);

useSeo({
  title: title.value,
  description: lineage.value?.summary,
});

/*
 * size: string;
 * height: string;
 * weight: Weight;
 * age: Age;
 */
</script>
