<template>
  <span class="icon-circle" aria-hidden="true" v-html="icon"></span>
</template>

<script setup lang="ts">
const props = defineProps<{
  circle: string;
}>();

const glyphs = indexGlyphs(import.meta.glob("~/assets/img/astromancie/cercles/*.svg", { eager: true, import: "default", query: "?raw" }));

function indexGlyphs(modules: Record<string, string>): Map<string, string> {
  const index = new Map<string, string>();
  for (const [path, svg] of Object.entries(modules)) {
    const file = path
      .split(/[/\\]/)
      .pop()
      ?.replace(/\.svg$/i, "");
    if (file) {
      index.set(file, svg);
    }
  }
  return index;
}

const icon = computed<string>(() => glyphs.get(unaccent(props.circle.trim()).toLocaleLowerCase("fr")) ?? "");
</script>

<style scoped>
.icon-circle {
  display: inline-flex;
  align-items: center;
  justify-content: center;
  width: 1.1em;
  height: 1.1em;
  line-height: 1;
  vertical-align: -0.15em;
}

.icon-circle :deep(svg) {
  display: block;
  height: 100%;
  width: 100%;
}
</style>
