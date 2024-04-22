<script setup lang="ts">
import { RouterView } from "vue-router";

import AppFooter from "./components/layout/AppFooter.vue";
import AppNavbar from "./components/layout/AppNavbar.vue";
</script>

<template>
  <AppNavbar />
  <RouterView class="my-3" />
  <AppFooter />
</template>
