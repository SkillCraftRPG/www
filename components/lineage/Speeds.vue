<template>
  <div>
    <h2 class="h3">Vitesses</h2>
    <p>Le personnage est doté des <NuxtLink to="/regles/aventure/mouvement/vitesse">vitesses</NuxtLink> suivantes :</p>
    <table class="table table-striped text-center">
      <thead>
        <tr>
          <th scope="col" class="w-third">Type</th>
          <th scope="col" class="w-third">Points de mouvement</th>
          <th scope="col" class="w-third">Vitesse</th>
        </tr>
      </thead>
      <tbody>
        <tr v-if="speeds.walk > 0">
          <td>Marche</td>
          <td>{{ $n(speeds.walk, "integer") }}</td>
          <td>{{ $n(speeds.walk * 1.5, "decimal") }} mètres par seconde</td>
        </tr>
        <tr v-if="speeds.climb > 0">
          <td>Escalade</td>
          <td>{{ $n(speeds.climb, "integer") }}</td>
          <td>{{ $n(speeds.climb * 1.5, "decimal") }} mètres par seconde</td>
        </tr>
        <tr v-if="speeds.swim > 0">
          <td>Nage</td>
          <td>{{ $n(speeds.swim, "integer") }}</td>
          <td>{{ $n(speeds.swim * 1.5, "decimal") }} mètres par seconde</td>
        </tr>
        <tr v-if="speeds.fly > 0">
          <td>{{ speeds.hover ? "Lévitation" : "Vol" }}</td>
          <td>{{ $n(speeds.fly, "integer") }}</td>
          <td>{{ $n(speeds.fly * 1.5, "decimal") }} mètres par seconde</td>
        </tr>
        <tr v-if="speeds.burrow > 0">
          <td>Creusage</td>
          <td>{{ $n(speeds.burrow, "integer") }}</td>
          <td>{{ $n(speeds.burrow * 1.5, "decimal") }} mètres par seconde</td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script setup lang="ts">
import type { Speeds } from "~/types/lineages";

defineProps<{
  speeds: Speeds;
}>();
</script>
