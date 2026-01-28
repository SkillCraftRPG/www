<template>
  <div class="h3 mb-3">
    <TarBadge variant="secondary">Tiers&nbsp;:&nbsp;{{ $n(spell.tier, "integer") }}</TarBadge>
  </div>
</template>

<script setup lang="ts">
import type { Spell } from "~/types/magic";

defineProps<{
  spell: Spell;
}>();
</script>
