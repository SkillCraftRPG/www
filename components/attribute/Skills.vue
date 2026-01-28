<template>
  <div>
    <h2 class="h3">Compétences</h2>
    <p>La valeur de cet attribut est ajoutée aux tests des compétences ci-dessous.</p>
    <div class="row">
      <div v-for="skill in skills" :key="skill.id" class="col-xs-12 col-sm-6 col-md-4 col-lg-3 mb-4">
        <SkillCard class="d-flex flex-column h-100" no-attribute :skill="skill" />
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import { arrayUtils } from "logitar-js";

import type { Attribute, Skill } from "~/types/game";

const { orderBy } = arrayUtils;

const props = defineProps<{
  attribute: Attribute;
}>();

const skills = computed<Skill[]>(() => orderBy(props.attribute.skills, "slug"));
</script>
