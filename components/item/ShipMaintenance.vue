<template>
  <table class="table table-striped text-center">
    <thead>
      <tr>
        <th scope="col" class="w-20">Navire</th>
        <th scope="col" class="w-20">Année</th>
        <th scope="col" class="w-20">Mois</th>
        <th scope="col" class="w-20">Semaine</th>
        <th scope="col" class="w-20">Jour</th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="item in items" :key="item.id">
        <td>{{ item.name }}</td>
        <td>{{ $n(item.maintenance.yearly, "price") }}</td>
        <td>{{ $n(item.maintenance.monthly, "price") }}</td>
        <td>{{ $n(item.maintenance.weekly, "price") }}</td>
        <td>{{ $n(item.maintenance.daily, "price") }}</td>
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
