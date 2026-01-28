<template>
  <div>
    <h2 class="h3">Attribut</h2>
    <p>L’attribut suivant influence la valeur de cette statistique.</p>
    <div class="row">
      <div class="col-xs-12 col-sm-6 col-md-4 col-lg-3 mb-4">
        <AttributeCard :attribute="attribute" />
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import type { Attribute } from "~/types/game";

defineProps<{
  attribute: Attribute;
}>();
</script>
