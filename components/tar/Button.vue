<template>
  <button :class="classes" :disabled="parseBoolean(disabled)" :name="name" :type="type" :value="value" @click="$emit('click')">
    <slot v-if="parseBoolean(loading)" name="spinner">
      <TarSpinner inline small />
      <span class="visually-hidden" role="status">{{ status }}</span>
      <template v-if="text">&nbsp;</template>
    </slot>
    <slot v-else-if="icon" name="icon-override">
      <FontAwesomeIcon :icon="icon" />
      <template v-if="text">&nbsp;</template>
    </slot>
    <template v-if="text">{{ text }}</template>
    <slot></slot>
  </button>
</template>

<style scoped>
button:disabled {
  cursor: not-allowed !important;
}
</style>

<script setup lang="ts">
import { FontAwesomeIcon } from "@fortawesome/vue-fontawesome";
import { parsingUtils } from "logitar-js";

import type { ButtonOptions } from "~/types/tar/button";

const { parseBoolean } = parsingUtils;

const props = withDefaults(defineProps<ButtonOptions>(), {
  size: "medium",
  status: "Loading…",
  type: "button",
  variant: "primary",
});

const classes = computed<string[]>(() => {
  const classes = ["btn"];
  if (props.variant) {
    classes.push(parseBoolean(props.outline) ? `btn-outline-${props.variant}` : `btn-${props.variant}`);
  }
  if (parseBoolean(props.nowrap)) {
    classes.push("text-nowrap");
  }
  switch (props.size) {
    case "large":
      classes.push("btn-lg");
      break;
    case "small":
      classes.push("btn-sm");
      break;
  }
  return classes;
});

defineEmits<{
  /**
   * The button has been clicked.
   */
  (e: "click"): void;
}>();
</script>
