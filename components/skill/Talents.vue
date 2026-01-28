<template>
  <div>
    <h2 class="h3">Talents</h2>
    <p>
      L’acquisition des <NuxtLink to="/regles/talents">talents</NuxtLink> ci-dessous <NuxtLink to="/regles/competences/formation">forme</NuxtLink> le personnage
      pour cette compétence et augmente (+1) le <NuxtLink to="/regles/competences/rang">rang</NuxtLink> de cette compétence.
    </p>
    <div class="row">
      <div v-for="talent in talents" :key="talent.id" class="col-xs-12 col-sm-6 col-md-4 col-lg-3 mb-4">
        <TalentCard class="d-flex flex-column h-100" no-skill :talent="talent" />
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import type { Talent } from "~/types/game";

defineProps<{
  talents: Talent[];
}>();
</script>
