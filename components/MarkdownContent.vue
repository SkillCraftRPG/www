<template>
  <span v-if="isInline" v-html="html"></span>
  <div v-else v-html="html"></div>
</template>

<script setup lang="ts">
import { marked } from "marked";
import { parsingUtils } from "logitar-js";

const { parseBoolean } = parsingUtils;

const props = defineProps<{
  inline?: boolean | string;
  text: string;
}>();

const isInline = computed<boolean>(() => parseBoolean(props.inline) ?? false);
const html = computed<string>(() => {
  const html: string = marked.parse(props.text) as string;
  return isInline.value ? html.replace(/<\/?p>/g, "") : html;
});
</script>
