<template>
  <!-- Dark mode selector, which is a simple dropdown menu with Light, Dark and Auto -->
  <div class="dropdown" data-bs-theme="dark">
    <button class="btn btn-flat btn-sm mt-1 mx-1 dropdown-toggle btn-dark" type="button" id="themeSelector" data-bs-toggle="dropdown" aria-expanded="false">
      <font-awesome-icon icon="fas fa-moon" width="16px" v-if="theme.currentTheme === 'dark'" />
      <font-awesome-icon icon="fas fa-sun" width="16px" v-else-if="theme.currentTheme === 'light'" />
      <font-awesome-icon icon="fas fa-adjust" width="16px" v-else />
      {{ $t("theme.title") }}
    </button>
    <ul class="dropdown-menu dropdown-menu-end" aria-labelledby="themeSelector">
      <li>
        <button class="dropdown-item" @click="theme.setTheme('light')"><font-awesome-icon icon="fas fa-sun" width="16px" /> {{ $t("theme.light") }}</button>
      </li>
      <li>
        <button class="dropdown-item" @click="theme.setTheme('dark')"><font-awesome-icon icon="fas fa-moon" width="16px" /> {{ $t("theme.dark") }}</button>
      </li>
      <li>
        <button class="dropdown-item" @click="theme.setTheme('auto')"><font-awesome-icon icon="fas fa-adjust" width="16px" /> {{ $t("theme.auto") }}</button>
      </li>
    </ul>
  </div>
</template>

<script setup lang="ts">
const theme = useThemeStore();
</script>
