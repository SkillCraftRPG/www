<template>
  <div></div>
</template>

<script setup lang="ts">
import { signOut } from "@/api/account";

const account = useAccountStore();

const isLoading = ref<boolean>(false);

onMounted(async () => {
  isLoading.value = true;
  try {
    await signOut();
    account.signOut();
  } catch (e: unknown) {
    console.error(e); // TDOO(fpion): handleError(e);
  } finally {
    isLoading.value = false;
    await navigateTo("/connexion");
  }
});
</script>
