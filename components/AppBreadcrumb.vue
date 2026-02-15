<template>
  <Breadcrumb :divider="divider">
    <BreadcrumbItem to="/">Accueil</BreadcrumbItem>
    <BreadcrumbItem v-if="active !== 'Règles'" to="/regles">Règles</BreadcrumbItem>
    <BreadcrumbItem v-for="item in parent" :key="item.to" :to="item.to">{{ item.text }}</BreadcrumbItem>
    <BreadcrumbItem active>{{ active }}</BreadcrumbItem>
  </Breadcrumb>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

withDefaults(
  defineProps<{
    active: string;
    divider?: string;
    parent?: Breadcrumb[];
  }>(),
  {
    divider: "›",
    parent: () => [],
  },
);
</script>
