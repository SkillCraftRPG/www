<template>
  <div>
    <h2 class="h3">Description</h2>
    <p v-if="content.morphology">
      <strong>Morphologie et apparence physique.</strong>
      {{ " " }}
      <MarkdownContent inline :text="content.morphology" />
    </p>
    <p v-if="content.psychology">
      <strong>Psychologie et personnalité.</strong>
      {{ " " }}
      <MarkdownContent inline :text="content.psychology" />
    </p>
    <p v-if="content.culture">
      <strong>Culture et traditions.</strong>
      {{ " " }}
      <MarkdownContent inline :text="content.culture" />
    </p>
    <p v-if="content.history">
      <strong>Histoire récente.</strong>
      {{ " " }}
      <MarkdownContent inline :text="content.history" />
    </p>
    <p v-if="content.geography">
      <strong>Situation géographique.</strong>
      {{ " " }}
      <MarkdownContent inline :text="content.geography" />
    </p>
    <p v-if="content.politics">
      <strong>Organisation politique.</strong>
      {{ " " }}
      <MarkdownContent inline :text="content.politics" />
    </p>
    <p v-if="content.relations">
      <strong>Relations inter-espèces.</strong>
      {{ " " }}
      <MarkdownContent inline :text="content.relations" />
    </p>
  </div>
</template>

<script setup lang="ts">
import type { LineageContent } from "~/types/lineages";

defineProps<{
  content: LineageContent;
}>();
</script>
