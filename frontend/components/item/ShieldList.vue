<template>
  <div>
    <table class="table table-striped text-center">
      <thead>
        <tr>
          <th scope="col" class="w-15">Bouclier</th>
          <th scope="col" class="w-15">Prix (deniers)</th>
          <th scope="col" class="w-15">Poids (kg)</th>
          <th scope="col" class="w-15">Défense</th>
          <th scope="col" class="w-15">Résistance</th>
          <th scope="col" class="w-25">Propriétés</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="shield in items" :key="shield.id">
          <td>{{ shield.name }}</td>
          <td>{{ $n(shield.price, "price") }}</td>
          <td>{{ $n(shield.weight, "weight") }}</td>
          <td>{{ $n(shield.defense, "defense") }}</td>
          <td>{{ $n(shield.resistance, "resistance") }}</td>
          <td>{{ shield.properties.length ? shield.properties.join(", ") : "—" }}</td>
        </tr>
      </tbody>
    </table>
    <h4 class="h6">Descriptions</h4>
    <ul>
      <li v-for="shield in items" :key="shield.id">
        <strong>{{ shield.name }}.</strong> {{ shield.description }}
      </li>
    </ul>
  </div>
</template>

<script setup lang="ts">
import type { Shield } from "~/types/items";

defineProps<{
  items: Shield[];
}>();
</script>
