<template>
  <span>
    <TarImage v-if="src" circle :alt="alt" :height="height" :src="src" />
    <TarBadge v-else-if="icon" class="rounded-circle" :style="style" :variant="variant">
      <FontAwesomeIcon :icon="icon" />
    </TarBadge>
  </span>
</template>

<script setup lang="ts">
import md5 from "md5";
import { FontAwesomeIcon } from "@fortawesome/vue-fontawesome";
import { parsingUtils } from "logitar-js";

import type { AvatarOptions } from "~/types/tar/avatar";

const { parseNumber } = parsingUtils;

const props = withDefaults(defineProps<AvatarOptions>(), {
  icon: "fas fa-user",
  size: 32,
  variant: "secondary",
});

const alt = computed<string | undefined>(() => (props.displayName ? `${props.displayName}'s Avatar` : undefined));
const height = computed<number | undefined>(() => parseNumber(props.size) || undefined);
const src = computed<string | undefined>(() => {
  if (props.url) {
    return props.url;
  } else if (props.emailAddress) {
    return `https://www.gravatar.com/avatar/${md5(props.emailAddress)}`;
  }
  return undefined;
});
const style = computed(() => {
  return height.value ? { width: `${height.value}px`, height: `${height.value}px` } : undefined;
});
</script>

<style scoped>
.badge {
  display: inline-flex;
  align-items: center;
  justify-content: center;
  vertical-align: middle;
  flex-shrink: 0;
  font-size: inherit;
  font-weight: 400;
  line-height: 1;
  max-width: 100%;
  text-align: center;
  overflow: visible;
  position: relative;
  transition:
    color 0.15s ease-in-out,
    background-color 0.15s ease-in-out,
    box-shadow 0.15s ease-in-out;
}
</style>
