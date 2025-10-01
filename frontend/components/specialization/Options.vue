<template>
  <div>
    <h2 class="h3">Options</h2>
    <ul v-if="specialization.options.other.length > 0">
      <li v-for="(option, index) in specialization.options.other" :key="index">
        <MarkdownContent inline :text="option" />
      </li>
    </ul>
    <p v-else>Aucune option.</p>
    <template v-if="specialization.options.talents.length > 0">
      <h3 class="h5">Talents optionnels</h3>
      <div class="row">
        <div v-for="talent in talents" :key="talent.id" class="col-xs-12 col-sm-6 col-md-4 col-lg-3 mb-4">
          <TalentCard class="d-flex flex-column h-100" :talent="talent" />
        </div>
      </div>
    </template>
  </div>
</template>

<script setup lang="ts">
import { arrayUtils } from "logitar-js";

import type { Specialization } from "~/types/specializations";
import type { Talent } from "~/types/game";

const { orderBy } = arrayUtils;

const props = defineProps<{
  specialization: Specialization;
}>();

const talents = computed<Talent[]>(() => orderBy(props.specialization.options.talents, "slug"));
</script>
