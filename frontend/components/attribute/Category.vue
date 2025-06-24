<template>
  <span><font-awesome-icon :icon="icon" /> {{ text }}</span>
</template>

<script lang="ts" setup>
import type { Attribute } from "~/types/game";

const props = defineProps<{
  attribute: Attribute;
}>();

const icon = computed<string>(() => {
  switch (props.attribute.value) {
    case "Dexterity":
    case "Vigor":
      return "fas fa-dumbbell";
    case "Intellect":
    case "Senses":
      return "fas fa-brain";
  }
  return "fas fa-heart";
});
const text = computed<string>(() => {
  switch (props.attribute.value) {
    case "Dexterity":
    case "Vigor":
      return "Physique";
    case "Intellect":
    case "Senses":
      return "Mental";
  }
  return "Universel";
});
</script>
