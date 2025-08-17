<template>
  <table class="table table-striped text-center">
    <thead>
      <tr>
        <th scope="col" class="w-15">Nom</th>
        <th scope="col" class="w-10">Prix (deniers)</th>
        <th scope="col" class="w-10">Poids (kg)</th>
        <th scope="col" class="w-65">Description</th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="item in items" :key="item.id">
        <td>{{ item.name }}</td>
        <td>
          <template v-if="item.isPriceMultiplier">×{{ $n(item.price, "decimal") }}</template>
          <template v-else>{{ $n(item.price, "price") }}</template>
        </td>
        <td>
          <template v-if="item.isWeightMultiplier">×{{ $n(item.weight, "decimal") }}</template>
          <template v-else>{{ $n(item.weight, "weight") }}</template>
        </td>
        <td>{{ item.description }}</td>
      </tr>
    </tbody>
  </table>
</template>

<script setup lang="ts">
import type { MountAccessory } from "~/types/items";

defineProps<{
  items: MountAccessory[];
}>();
</script>
