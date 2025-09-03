<template>
  <div>
    <table class="table table-striped text-center">
      <thead>
        <tr>
          <th scope="col" class="w-20">Nom</th>
          <th scope="col" class="w-20">Prix (deniers)</th>
          <th scope="col" class="w-20">Vigueur</th>
          <th scope="col" class="w-20">Taille</th>
          <th scope="col" class="w-20">Charge (kg)</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="item in items" :key="item.id">
          <td>{{ item.name }}</td>
          <td>{{ $n(item.price, "price") }}</td>
          <td>{{ $n(item.vigor, "integer") }}</td>
          <td>{{ $t(`size.category.options.${item.size}`) }}</td>
          <td>{{ $n(calculateLoad(item), "integer") }}</td>
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

function calculateLoad(mount: Mount): number {
  if (typeof mount.load === "number") {
    return mount.load;
  }
  return (5 + mount.vigor) * 10 * getLoadMultiplier(mount.size);
}
</script>
