<template>
  <span v-if="parseBoolean(inline)" :class="classes" aria-hidden="true"></span>
  <div v-else :class="classes" :role="role">
    <slot name="label-override">
      <span class="visually-hidden">{{ label }}</span>
    </slot>
  </div>
</template>

<script setup lang="ts">
import { parsingUtils } from "logitar-js";

import type { SpinnerOptions } from "~/types/tar/spinner";

const { parseBoolean } = parsingUtils;

const props = withDefaults(defineProps<SpinnerOptions>(), {
  label: "Loading…",
  role: "status",
});

const classes = computed<string[]>(() => {
  const type = parseBoolean(props.grow) ? "grow" : "border";
  const classes = [`spinner-${type}`];
  if (parseBoolean(props.small)) {
    classes.push(`spinner-${type}-sm`);
  }
  if (props.variant) {
    classes.push(`text-${props.variant}`);
  }
  return classes;
});
</script>
