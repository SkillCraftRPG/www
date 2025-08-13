<template>
  <div>
    <table class="table table-striped text-center">
      <thead>
        <tr>
          <th scope="col" class="w-15">Armure</th>
          <th scope="col" class="w-15">Prix (deniers)</th>
          <th scope="col" class="w-15">Poids (kg)</th>
          <th scope="col" class="w-15">Défense</th>
          <th scope="col" class="w-15">Résistance</th>
          <th scope="col" class="w-25">Propriétés</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="armor in items" :key="armor.id">
          <td>{{ armor.name }}</td>
          <td>{{ $n(armor.price, "price") }}</td>
          <td>{{ $n(armor.weight, "weight") }}</td>
          <td>{{ $n(armor.defense, "defense") }}</td>
          <td>{{ $n(armor.resistance, "resistance") }}</td>
          <td>{{ armor.properties.length ? armor.properties.join(", ") : "—" }}</td>
        </tr>
      </tbody>
    </table>
    <h4 class="h6">Descriptions</h4>
    <ul>
      <li v-for="armor in items" :key="armor.id">
        <strong>{{ armor.name }}.</strong> {{ armor.description }}
      </li>
    </ul>
  </div>
</template>

<script setup lang="ts">
import type { Armor } from "~/types/items";

defineProps<{
  items: Armor[];
}>();
</script>
