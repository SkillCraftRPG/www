<template>
  <div>
    <h2 class="h3">Traits</h2>
    <ul>
      <li v-for="(trait, index) in traits" :key="index">
        <strong>{{ trait.name }}.</strong>{{ " " }}<MarkdownContent v-if="trait.description" inline :text="trait.description" />
      </li>
      <li><strong>Langues.</strong> {{ lineage.languages.text }}</li>
      <li><strong>Noms.</strong> {{ lineage.names.text }}</li>
      <li><strong>Vitesse de marche.</strong> {{ $n(lineage.speeds.walk, "integer") }} ({{ $n(lineage.speeds.walk / 4, "decimal") }} mètres par seconde)</li>
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
    </ul>
  </div>
</template>

<script setup lang="ts">
import { arrayUtils } from "logitar-js";

import type { Feature } from "~/types/game";
import type { Lineage } from "~/types/lineages";

const { orderBy } = arrayUtils;

const props = defineProps<{
  lineage: Lineage;
}>();

const traits = computed<Feature[]>(() => orderBy(props.lineage.traits, "name"));
</script>

<style></style>
