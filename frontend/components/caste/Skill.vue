<template>
  <div>
    <h2 class="h3">Compétence</h2>
    <p>
      Cette <NuxtLink to="/regles/competences">compétence</NuxtLink> est fondamentale aux personnages appartenant à cette caste. Au moment de sa
      <NuxtLink to="/regles/personnages/creation">création</NuxtLink>, il doit être <NuxtLink to="/regles/competences/formation">formé</NuxtLink> pour celle-ci.
    </p>
    <SkillCard class="mb-4" :skill="skill" />
  </div>
</template>

<script setup lang="ts">
import type { Skill } from "~/types/game";

defineProps<{
  skill: Skill;
}>();
</script>
