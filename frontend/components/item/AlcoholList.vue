<template>
  <table class="table table-striped text-center">
    <thead>
      <tr>
        <th scope="col" class="w-20">Alcool</th>
        <th scope="col" class="w-20">Quantité</th>
        <th scope="col" class="w-10">Prix (deniers)</th>
        <th scope="col" class="w-50">Description</th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="item in items" :key="item.id">
        <td>{{ item.name }}</td>
        <td>
          {{ item.volume }} oz /
          <template v-if="item.quantity">{{ item.quantity }}</template>
          <template v-else>{{ $n(ozToMl(item.volume), "integer") }} ml</template>
        </td>
        <td>{{ $n(item.price, "price") }}</td>
        <td>{{ item.description }}</td>
      </tr>
    </tbody>
  </table>
</template>

<script setup lang="ts">
import type { Alcohol } from "~/types/items";

defineProps<{
  items: Alcohol[];
}>();
</script>
