<template>
  <div>
    <h2 class="h3">
      Talent réservé&nbsp;:&nbsp;<i>{{ talent.name }}</i>
    </h2>
    <p>Le personnage acquiert les capacités suivantes.</p>
    <ul v-if="talent.description.length > 0">
      <li v-for="(line, index) in talent.description" :key="index">
        <MarkdownContent inline :text="line" />
      </li>
    </ul>
    <template v-if="talent.discountedTalents.length > 0">
      <h3 class="h5">Talents à rabais</h3>
      <div class="row">
        <div v-for="talent in talents" :key="talent.id" class="col-xs-12 col-sm-6 col-md-4 col-lg-3 mb-4">
          <TalentCard class="d-flex flex-column h-100" :talent="talent" />
        </div>
      </div>
    </template>
    <div v-for="(feature, index) in features" :key="index">
      <h3 class="h5">{{ feature.name }}</h3>
      <MarkdownContent v-if="feature.description" :text="feature.description" />
    </div>
  </div>
</template>

<script setup lang="ts">
import { arrayUtils } from "logitar-js";

import type { ReservedTalent } from "~/types/specializations";
import type { Feature, Talent } from "~/types/game";

const { orderBy } = arrayUtils;

const props = defineProps<{
  talent: ReservedTalent;
}>();

const features = computed<Feature[]>(() => orderBy(props.talent.features, "name"));
const talents = computed<Talent[]>(() => orderBy(props.talent.discountedTalents, "slug"));
</script>
