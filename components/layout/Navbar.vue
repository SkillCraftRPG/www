<template>
  <nav class="navbar navbar-expand-lg bg-body-tertiary" data-bs-theme="dark">
    <div class="container-fluid">
      <NuxtLink to="/" class="navbar-brand">
        <img src="@/assets/img/logo.png" :alt="`${$t('brand')} Logo`" height="32" />
        {{ $t("brand") }}
        <TarBadge v-if="environment !== 'production'" variant="warning">{{ environment }}</TarBadge>
      </NuxtLink>
      <button
        class="navbar-toggler"
        type="button"
        data-bs-toggle="collapse"
        data-bs-target="#navbarSupportedContent"
        aria-controls="navbarSupportedContent"
        aria-expanded="false"
        aria-label="Toggle navigation"
      >
        <span class="navbar-toggler-icon"></span>
      </button>
      <div class="collapse navbar-collapse" id="navbarSupportedContent">
        <ul class="navbar-nav me-auto mb-2 mb-lg-0">
          <li class="nav-item">
            <NuxtLink to="/regles" class="nav-link"><font-awesome-icon icon="fas fa-dragon" /> Règles V8</NuxtLink>
          </li>
        </ul>
        <ul class="navbar-nav mb-2 mb-lg-0">
          <li class="nav-item">
            <LayoutTheme />
          </li>
        </ul>
      </div>
    </div>
  </nav>
</template>

<script setup lang="ts">
const environment: string = process.env.NODE_ENV ?? "production";
</script>
