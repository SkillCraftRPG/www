<template>
  <LinkCard :text="statistic.summary" :title="statistic.name" :to="`/regles/statistiques/${statistic.slug}`">
    <template v-if="!hideAttribute" #subtitle-override>
      <h3 class="card-subtitle h6 mb-2 text-body-secondary"><AttributeIcon /> {{ statistic.attribute.name }}</h3>
    </template>
  </LinkCard>
</template>

<script lang="ts" setup>
import { parsingUtils } from "logitar-js";

import type { Statistic } from "~/types/game";

const { parseBoolean } = parsingUtils;

const props = defineProps<{
  noAttribute?: boolean | string;
  statistic: Statistic;
}>();

const hideAttribute = computed<boolean>(() => parseBoolean(props.noAttribute) ?? false);
</script>
