<template>
  <div>
    <h2 class="h3">Locuteurs typiques</h2>
    <MarkdownContent :text="text" />
  </div>
</template>

<script setup lang="ts">
defineProps<{
  text: string;
}>();
</script>
