<template>
  <table class="table table-striped text-center">
    <thead>
      <tr>
        <th scope="col" class="w-20">Alcool</th>
        <th scope="col" class="w-10">Quantité</th>
        <th scope="col" class="w-10">Prix (deniers)</th>
        <th scope="col" class="w-60">Description</th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="item in items" :key="item.id">
        <td>{{ item.name }}</td>
        <td>{{ formatQuantity(item.quantity) }}</td>
        <td>{{ $n(item.price, "price") }}</td>
        <td>{{ item.description }}</td>
      </tr>
    </tbody>
  </table>
</template>

<script setup lang="ts">
import type { Alcohol, Volume } from "~/types/items";

defineProps<{
  items: Alcohol[];
}>();

function formatQuantity(quantity: Volume): string {
  return [$n(quantity.value, "integer"), quantity.unit].join(" ");
}
</script>
