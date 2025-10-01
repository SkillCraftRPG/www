<template>
  <div>
    <h2 class="h3">Statistiques</h2>
    <p>Cet attribut influence la valeur des statistiques ci-dessous.</p>
    <div class="row">
      <div v-for="statistic in statistics" :key="statistic.id" class="col-xs-12 col-sm-6 col-md-4 col-lg-3 mb-4">
        <StatisticCard class="d-flex flex-column h-100" no-attribute :statistic="statistic" />
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import { arrayUtils } from "logitar-js";

import type { Attribute, Statistic } from "~/types/game";

const { orderBy } = arrayUtils;

const props = defineProps<{
  attribute: Attribute;
}>();

const statistics = computed<Statistic[]>(() => orderBy(props.attribute.statistics, "slug"));
</script>
