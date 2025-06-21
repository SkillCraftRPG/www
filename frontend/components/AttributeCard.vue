<template>
  <div class="card clickable" @click="navigate">
    <div class="card-body">
      <h2 class="card-title h5">{{ attribute.name }}</h2>
      <p v-if="attribute.summary" class="card-text">{{ attribute.summary }}</p>
    </div>
  </div>
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
