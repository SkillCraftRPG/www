<template>
  <table class="table table-striped text-center">
    <thead>
      <tr>
        <th scope="col" class="w-15">Nom</th>
        <th scope="col" class="w-10">Prix (deniers)</th>
        <th scope="col" class="w-10">Vitesse (lieues)</th>
        <th scope="col" class="w-65">Description</th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="item in items" :key="item.id">
        <td>{{ item.name }}</td>
        <td>{{ $n(item.price, "price") }}</td>
        <td>{{ $n(item.speed, "ship_speed") }}</td>
        <td>{{ item.description }}</td>
      </tr>
    </tbody>
  </table>
</template>

<script setup lang="ts">
import type { Ship } from "~/types/items";

defineProps<{
  items: Ship[];
}>();
</script>
