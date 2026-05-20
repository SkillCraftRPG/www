<template>
  <TarBreadcrumb :breadcrumbs="breadcrumbs" :divider="divider" />
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/tar/breadcrumb";

const props = withDefaults(
  defineProps<{
    active?: string;
    divider?: string;
    parent?: Breadcrumb[];
  }>(),
  {
    divider: "›",
  },
);

const breadcrumbs = computed<Breadcrumb[]>(() => {
  const breadcrumbs: Breadcrumb[] = [{ text: "Accueil", to: "/" }];
  if (props.active) {
    breadcrumbs.push({ text: "Règles", to: "/regles" });
  }
  props.parent?.forEach((parent) => breadcrumbs.push(parent));
  breadcrumbs.push({ text: props.active ?? "Règles" });
  return breadcrumbs;
});
</script>
