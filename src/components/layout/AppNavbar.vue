<script setup lang="ts">
const environment = import.meta.env.MODE.toLowerCase();
</script>

<template>
  <nav class="navbar navbar-expand-lg bg-body-tertiary" data-bs-theme="dark">
    <div class="container-fluid">
      <RouterLink :to="{ name: 'Home' }" class="navbar-brand">
        <img src="@/assets/img/logo.png" alt="SkillCraftRPG Logo`" height="32" /> SkillCraftRPG
        <span v-if="environment !== 'production'" class="badge text-bg-warning">{{ environment }}</span>
      </RouterLink>
    </div>
  </nav>
</template>
