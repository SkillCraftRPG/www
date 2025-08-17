<template>
  <table class="table table-striped text-center">
    <thead>
      <tr>
        <th scope="col" class="w-15">Service</th>
        <th scope="col" class="w-15">Prix (deniers)</th>
        <th scope="col" class="w-70">Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td colspan="3">
          <i>Couvert (un repas dans une auberge, un restaurant, une taverne, etc.)</i>
        </td>
      </tr>
      <tr v-for="item in items" :key="item.id">
        <td>{{ item.name }}</td>
        <td>{{ $n(item.board.price, "price") }}</td>
        <td>{{ item.board.description }}</td>
      </tr>
      <tr>
        <td colspan="3">
          <i>Gîte (pour une personne dans une auberge)</i>
        </td>
      </tr>
      <tr v-for="item in items" :key="item.id">
        <td>{{ item.name }}</td>
        <td>{{ $n(item.bed.price, "price") }}</td>
        <td>{{ item.bed.description }}</td>
      </tr>
    </tbody>
  </table>
</template>

<script setup lang="ts">
import type { Accommodation } from "~/types/items";

defineProps<{
  items: Accommodation[];
}>();
</script>
