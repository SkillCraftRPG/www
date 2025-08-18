<template>
  <div>
    <table class="table table-striped text-center">
      <thead>
        <tr>
          <th scope="col" class="w-sixth">Nom</th>
          <th scope="col" class="w-sixth">Prix (deniers)</th>
          <th scope="col" class="w-sixth">Vigueur</th>
          <th scope="col" class="w-sixth">Taille</th>
          <th scope="col" class="w-sixth">Charge (kg)</th>
          <th scope="col" class="w-sixth">Vitesse (lieues)</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="item in items" :key="item.id">
          <td>{{ item.name }}</td>
          <td>{{ $n(item.price, "price") }}</td>
          <td>{{ $n(item.vigor, "integer") }}</td>
          <td>{{ $t(`size.category.options.${item.size}`) }}</td>
          <td>{{ $n(calculateLoad(item), "integer") }}</td>
          <td>{{ $n(item.speed, "league") }}</td>
        </tr>
      </tbody>
    </table>
    <h4 class="h6">Descriptions</h4>
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
