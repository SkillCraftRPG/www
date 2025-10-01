<template>
  <main class="container">
    <h1>UserProfile</h1>
    <div v-if="profile">{{ profile }}</div>
  </main>
</template>

<script setup lang="ts">
import type { UserProfile } from "~/types/account";
import { getProfile } from "~/api/account";

const isLoading = ref<boolean>(false);
const profile = ref<UserProfile>();

onMounted(async () => {
  isLoading.value = true;
  try {
    profile.value = await getProfile();
  } catch (e: unknown) {
    console.error(e); // TODO(fpion): handleError(e);
  } finally {
    isLoading.value = false;
  }
});
</script>
