<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Au contraire des <NuxtLink to="/regles/herboristerie/remedes">remèdes</NuxtLink>, le rôle des poisons est d’infliger une certaine
      <NuxtLink to="/regles/combat/degats">douleur</NuxtLink>, une nuisance, ou même d’apporter la <NuxtLink to="/regles/combat/mort-agonie">mort</NuxtLink> à
      leurs victimes. Ils sont considérés comme une source naturelle, ils peuvent donc être guéris par les remèdes.
    </p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [{ text: "Herboristerie", to: "/regles/herboristerie" }];
const title: string = "Poisons";

useSeo({
  title,
  description: "🚧",
});
</script>
