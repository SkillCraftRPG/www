<template>
  <LinkCard :text="attribute.summary" :title="attribute.name" :to="`/regles/attributs/${attribute.slug}`" />
</template>

<script lang="ts" setup>
import type { Attribute } from "~/types/game";

defineProps<{
  attribute: Attribute;
}>();
</script>
