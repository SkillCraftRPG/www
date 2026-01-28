<template>
  <div>
    <h2 class="h3">Attribut</h2>
    <template v-if="attribute">
      <p>La valeur de l’attribut ci-dessous est ajoutée aux <NuxtLink to="/regles/competences/tests">tests</NuxtLink> de cette compétence.</p>
      <div class="row">
        <div class="col-xs-12 col-sm-6 col-md-4 col-lg-3 mb-4">
          <AttributeCard :attribute="attribute" />
        </div>
      </div>
    </template>
    <p v-else>
      Cette compétence n’est associée à aucun <NuxtLink to="/regles/attributs">attribut</NuxtLink>. Lorsqu’un
      <NuxtLink to="/regles/competences/tests">test</NuxtLink> est effectué, l’attribut est sélectionné en fonction du contexte du test.
    </p>
  </div>
</template>

<script setup lang="ts">
import type { Attribute } from "~/types/game";

defineProps<{
  attribute?: Attribute;
}>();
</script>
