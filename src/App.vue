<script setup lang="ts">
import { RouterView } from "vue-router";
import { TarToaster } from "logitar-vue3-ui";
import { provide } from "vue";

import AppFooter from "./components/layout/AppFooter.vue";
import AppNavbar from "./components/layout/AppNavbar.vue";
import { handleErrorKey } from "./inject/App";
import { useToastStore } from "./stores/toast";

const toasts = useToastStore();

function handleError(e: unknown): void {
  if (e) {
    console.error(e);
  }
  toasts.error();
}
provide(handleErrorKey, handleError);
</script>

<template>
  <AppNavbar />
  <RouterView class="my-3" />
  <AppFooter />
  <TarToaster :toasts="toasts.toasts" @hidden="toasts.remove" />
</template>
