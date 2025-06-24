<template>
  <div :class="{ card: true, clickable: isClickable }">
    <div class="card-body">
      <h2 class="card-title h5">{{ title }}</h2>
      <p class="card-text">{{ text }}</p>
      <slot></slot>
    </div>
  </div>
</template>

<script setup lang="ts">
import { parsingUtils } from "logitar-js";

const { parseBoolean } = parsingUtils;

const props = defineProps<{
  clickable?: boolean | string;
  text?: string;
  title?: string;
}>();

const isClickable = computed<boolean>(() => parseBoolean(props.clickable) ?? false);
</script>
