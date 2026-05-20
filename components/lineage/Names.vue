<template>
  <div>
    <div class="d-flex justify-content-between align-items-center">
      <h2 class="h3">Noms</h2>
      <div class="mb-3">
        <TarButton v-if="hasNames" icon="fas fa-dice" text="Randomiser" @click="randomize" />
      </div>
    </div>
    <MarkdownContent v-if="names.text" :text="names.text" />
    <div class="d-none d-md-block">
      <table v-if="hasNames" class="table table-striped text-center">
        <thead>
          <tr>
            <th class="w-15" scope="col">Catégorie</th>
            <th class="w-70" scope="col">Noms</th>
            <th class="w-15" scope="col">Sélection</th>
          </tr>
        </thead>
        <tbody>
          <tr v-if="names.family.length">
            <td>Noms de famille</td>
            <td>{{ names.family.join(", ") }}</td>
            <td>
              <template v-if="selection.has('family')">{{ selection.get("family") }}</template>
              <span v-else class="text-muted">{{ "—" }}</span>
            </td>
          </tr>
          <tr v-if="names.female.length">
            <td>Prénoms féminins</td>
            <td>{{ names.female.join(", ") }}</td>
            <td>
              <template v-if="selection.has('female')">{{ selection.get("female") }}</template>
              <span v-else class="text-muted">{{ "—" }}</span>
            </td>
          </tr>
          <tr v-if="names.male.length">
            <td>Prénoms masculins</td>
            <td>{{ names.male.join(", ") }}</td>
            <td>
              <template v-if="selection.has('male')">{{ selection.get("male") }}</template>
              <span v-else class="text-muted">{{ "—" }}</span>
            </td>
          </tr>
          <tr v-if="names.unisex.length">
            <td>Prénoms unisexes</td>
            <td>{{ names.unisex.join(", ") }}</td>
            <td>
              <template v-if="selection.has('unisex')">{{ selection.get("unisex") }}</template>
              <span v-else class="text-muted">{{ "—" }}</span>
            </td>
          </tr>
          <tr v-for="(custom, index) in categories" :key="index">
            <td>{{ custom.category }}</td>
            <td>{{ custom.values.join(", ") }}</td>
            <td>
              <template v-if="selection.has(custom.category)">{{ selection.get(custom.category) }}</template>
              <span v-else class="text-muted">{{ "—" }}</span>
            </td>
          </tr>
        </tbody>
      </table>
    </div>
    <div class="d-md-none text-center">
      <TarCard v-if="names.family.length" class="mb-3" title="Noms de famille">
        <div>{{ names.family.join(", ") }}</div>
        <div v-if="selection.has('family')">
          <strong>{{ selection.get("family") }}</strong>
        </div>
      </TarCard>
      <TarCard v-if="names.female.length" class="mb-3" title="Prénoms féminins">
        <div>{{ names.female.join(", ") }}</div>
        <div v-if="selection.has('female')">
          <strong>{{ selection.get("female") }}</strong>
        </div>
      </TarCard>
      <TarCard v-if="names.male.length" class="mb-3" title="Prénoms masculins">
        <div>{{ names.male.join(", ") }}</div>
        <div v-if="selection.has('male')">
          <strong>{{ selection.get("male") }}</strong>
        </div>
      </TarCard>
      <TarCard v-if="names.unisex.length" class="mb-3" title="Prénoms unisexes">
        <div>{{ names.unisex.join(", ") }}</div>
        <div v-if="selection.has('unisex')">
          <strong>{{ selection.get("unisex") }}</strong>
        </div>
      </TarCard>
      <TarCard v-for="(custom, index) in categories" :key="index" class="mb-3" :title="custom.category">
        <div>{{ custom.values.join(", ") }}</div>
        <div v-if="selection.has(custom.category)">
          <strong>{{ selection.get(custom.category) }}</strong>
        </div>
      </TarCard>
    </div>
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

const categories = computed<NameCategory[]>(() =>
  orderBy(
    props.names.custom.map((custom) => ({ ...custom, sort: unaccent(custom.category) })),
    "sort",
  ),
);
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
