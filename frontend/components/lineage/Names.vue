<template>
  <div>
    <div class="d-flex justify-content-between align-items-center">
      <h2 class="h3">Noms</h2>
      <div class="mb-3">
        <TarButton v-if="hasNames" icon="fas fa-dice" text="Randomiser" @click="randomize" />
      </div>
    </div>
    <MarkdownContent v-if="names.text" :text="names.text" />
    <table v-if="hasNames" class="table table-striped text-center">
      <thead>
        <tr>
          <th scope="col">Catégorie</th>
          <th scope="col">Noms</th>
          <th scope="col">Sélection</th>
        </tr>
      </thead>
      <tbody>
        <tr v-if="names.family.length">
          <td>Noms de famille</td>
          <td>{{ names.family.join(", ") }}</td>
          <td>{{ selection.get("family") ?? "—" }}</td>
        </tr>
        <tr v-if="names.female.length">
          <td>Prénoms féminins</td>
          <td>{{ names.female.join(", ") }}</td>
          <td>{{ selection.get("female") ?? "—" }}</td>
        </tr>
        <tr v-if="names.male.length">
          <td>Prénoms masculins</td>
          <td>{{ names.male.join(", ") }}</td>
          <td>{{ selection.get("male") ?? "—" }}</td>
        </tr>
        <tr v-if="names.unisex.length">
          <td>Prénoms unisexes</td>
          <td>{{ names.unisex.join(", ") }}</td>
          <td>{{ selection.get("unisex") ?? "—" }}</td>
        </tr>
        <tr v-for="(custom, index) in categories" :key="index">
          <td>{{ custom.category }}</td>
          <td>{{ custom.values.join(", ") }}</td>
          <td>{{ selection.get(custom.category) ?? "—" }}</td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script setup lang="ts">
import { arrayUtils } from "logitar-js";

import type { NameCategory, Names } from "~/types/lineages";

const { orderBy } = arrayUtils;

const props = defineProps<{
  names: Names;
}>();

const selection = ref<Map<string, string>>(new Map());

const categories = computed<NameCategory[]>(() => orderBy(props.names.custom, "category"));
const hasNames = computed<boolean>(
  () =>
    props.names.family.length > 0 ||
    props.names.female.length > 0 ||
    props.names.male.length > 0 ||
    props.names.unisex.length > 0 ||
    props.names.custom.length > 0,
);

function pick(values: string[]): string {
  return values[Math.floor(Math.random() * values.length)] ?? "";
}
function randomize(): void {
  selection.value.clear();
  selection.value.set("family", pick(props.names.family));
  selection.value.set("female", pick(props.names.female));
  selection.value.set("male", pick(props.names.male));
  selection.value.set("unisex", pick(props.names.unisex));
  props.names.custom.forEach((custom) => selection.value.set(custom.category, pick(custom.values)));
}
</script>
