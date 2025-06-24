<template>
  <div :class="{ card: true, clickable: isClickable }" @click="navigate">
    <div class="card-body">
      <h2 class="card-title h5">
        <template v-if="isClickable">{{ statistic.name }}</template>
        <NuxtLink v-else :to="`/regles/statistiques/${statistic.slug}`">{{ statistic.name }}</NuxtLink>
      </h2>
      <h3 v-if="!isNoAttribute && attribute" class="card-subtitle h6 mb-2 text-body-secondary">
        <template v-if="isClickable">{{ attribute.name }}</template>
        <NuxtLink v-else :to="`/regles/attributs/${attribute.slug}`">{{ attribute.name }}</NuxtLink>
      </h3>
      <p v-if="statistic.summary" class="card-text">{{ statistic.summary }}</p>
    </div>
  </div>
</template>

<script lang="ts" setup>
import { parsingUtils } from "logitar-js";

import type { Attribute, Statistic } from "~/types/game";

const router = useRouter();
const { parseBoolean } = parsingUtils;

const props = withDefaults(
  defineProps<{
    clickable?: boolean | string;
    noAttribute?: boolean | string;
    statistic: Statistic;
  }>(),
  {
    clickable: false,
  },
);

const attribute = computed<Attribute | undefined>(() => props.statistic.attribute ?? undefined);
const isClickable = computed<boolean>(() => parseBoolean(props.clickable) ?? false);
const isNoAttribute = computed<boolean>(() => parseBoolean(props.noAttribute) ?? false);

function navigate(): void {
  if (isClickable.value) {
    router.push(`/regles/statistiques/${props.statistic.slug}`);
  }
}
</script>
