<script setup lang="ts">
const year: number = new Date().getUTCFullYear();
const version = import.meta.env.VITE_APP_VERSION;
// <a href="https://www.flaticon.com/free-icons/player-versus-player" title="player versus player icons">Player versus player icons created by Freepik - Flaticon</a>
</script>

<template>
  <footer class="bg-dark">
    <div class="fluid">
      <RouterLink :to="{ name: 'Home' }" class="text-light">
        <img src="@/assets/img/logo.png" alt="SkillCraftRPG Logo" height="32" /> © Logitar {{ version }} {{ year }}.
      </RouterLink>
    </div>
  </footer>
</template>

<style scoped>
footer {
  position: absolute;
  bottom: 0;
  width: 100%;
  height: 60px;
  line-height: 60px;
  text-align: center;
}
</style>
