<template>
  <Breadcrumb :divider="divider">
    <BreadcrumbItem to="/">Accueil</BreadcrumbItem>
    <BreadcrumbItem v-for="item in parent" :key="item.to" :to="item.to">{{ item.text }}</BreadcrumbItem>
    <BreadcrumbItem v-if="active" active>{{ active }}</BreadcrumbItem>
  </Breadcrumb>
</template>

<script setup lang="ts">
import type { Article, Collection } from "~/types/encyclopedia";
import type { Breadcrumb } from "~/types/components";

const props = withDefaults(
  defineProps<{
    article?: Article;
    collection?: Collection;
    divider?: string;
  }>(),
  {
    divider: "›",
  },
);

const active = computed<string>(() => props.article?.title ?? props.collection?.name ?? "");

const parent = computed<Breadcrumb[]>(() => {
  const parent: Breadcrumb[] = [];
  if (props.article) {
    let current: Article | null | undefined = props.article.parent;
    while (current) {
      parent.push({ text: current.title, to: current.slug });
      current = current.parent;
    }
    parent.push({ text: props.article.collection.name, to: `/${props.article.collection.slug}` });
    parent.reverse();
    for (let i = 1; i < parent.length; i++) {
      parent[i].to = `${parent[i - 1].to}/${parent[i].to}`;
    }
  }
  return parent;
});
</script>
