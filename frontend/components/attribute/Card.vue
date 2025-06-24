<template>
  <AppCard clickable :text="attribute.summary ?? undefined" :title="attribute.name" @click="navigate" />
</template>

<script lang="ts" setup>
import type { Attribute } from "~/types/game";

const router = useRouter();

const props = defineProps<{
  attribute: Attribute;
}>();

function navigate(): void {
  router.push(`/regles/attributs/${props.attribute.slug}`);
}
</script>
