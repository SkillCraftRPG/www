<template>
  <div>
    <table class="table table-striped text-center">
      <thead>
        <tr>
          <th scope="col" class="w-sixth">Nom</th>
          <th scope="col" class="w-sixth">Prix (deniers)</th>
          <th scope="col" class="w-sixth">Vigueur</th>
          <th scope="col" class="w-sixth">Taille</th>
          <th scope="col" class="w-sixth">Capacité (kg)</th>
          <th scope="col" class="w-sixth">Vitesse</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="item in items" :key="item.id">
          <td>{{ item.name }}</td>
          <td>{{ $n(item.price, "price") }}</td>
          <td>{{ $n(item.vigor, "integer") }}</td>
          <td>{{ formatSize(item) }}</td>
          <td>{{ $n(item.capacity, "integer") }}</td>
          <td>×{{ $n(item.speed, "decimal") }}</td>
        </tr>
      </tbody>
    </table>
    <h3 class="h5">Descriptions</h3>
    <ul>
      <li v-for="item in items" :key="item.id">
        <strong>{{ item.name }}.</strong> {{ item.description }}
      </li>
    </ul>
  </div>
</template>

<script setup lang="ts">
import type { Mount } from "~/types/items";

defineProps<{
  items: Mount[];
}>();

function formatSize(mount: Mount): string {
  return mount.size; // TODO(fpion): implement
}
</script>
