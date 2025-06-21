<template>
  <div :class="{ card: true, clickable: isClickable }" @click="navigate">
    <div class="card-body">
      <h2 class="card-title h5">
        <template v-if="isClickable">{{ skill.name }}</template>
        <NuxtLink v-else :to="`/regles/competences/${skill.slug}`">{{ skill.name }}</NuxtLink>
      </h2>
      <h3 v-if="attribute" class="card-subtitle h6 mb-2 text-body-secondary">
        <template v-if="isClickable">{{ attribute.name }}</template>
        <NuxtLink v-else :to="`/regles/attributs/${attribute.slug}`">{{ attribute.name }}</NuxtLink>
        <!-- TODO(fpion): "N/A" or other text in list (Skills Page) -->
      </h3>
      <p v-if="skill.summary" class="card-text">{{ skill.summary }}</p>
    </div>
  </div>
</template>

<script lang="ts" setup>
import { parsingUtils } from "logitar-js";

import type { Attribute, Skill } from "~/types/game";

const router = useRouter();
const { parseBoolean } = parsingUtils;

const props = withDefaults(
  defineProps<{
    clickable?: boolean | string;
    skill: Skill;
  }>(),
  {
    clickable: false,
  },
);

const attribute = computed<Attribute | undefined>(() => props.skill.attribute ?? undefined);
const isClickable = computed<boolean>(() => parseBoolean(props.clickable) ?? false);

function navigate(): void {
  if (isClickable.value) {
    router.push(`/regles/competences/${props.skill.slug}`);
  }
}
</script>
