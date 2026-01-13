<template>
  <table class="table table-striped text-center">
    <thead>
      <tr>
        <th scope="col" class="w-20">Nom</th>
        <th scope="col" class="w-10">Prix (deniers)</th>
        <th scope="col" class="w-10">Poids (kg)</th>
        <th scope="col" class="w-10">Talents</th>
        <th scope="col" class="w-50">Description</th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="item in items" :key="item.id">
        <td>{{ item.name }}</td>
        <td>{{ $n(item.price, "price") }}</td>
        <td>{{ $n(item.weight, "weight") }}</td>
        <td>
          <span v-if="!item.talents || !item.talents.length" class="text-muted">{{ "—" }}</span>
          <NuxtLink v-else v-for="(talent, index) in item.talents" :key="index" class="d-inline-block" :to="`/regles/talents/${talent.split(':')[0]}`">
            {{ talent.split(":")[1] }}
          </NuxtLink>
        </td>
        <td>
          <MarkdownContent inline :text="item.description" />
        </td>
      </tr>
    </tbody>
  </table>
</template>

<script setup lang="ts">
import type { Tool } from "~/types/items";

defineProps<{
  items: Tool[];
}>();
</script>
