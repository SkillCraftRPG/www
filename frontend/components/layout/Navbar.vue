<template>
  <nav class="navbar navbar-expand-lg bg-body-tertiary" data-bs-theme="dark">
    <div class="container-fluid">
      <NuxtLink to="/" class="navbar-brand">
        <img src="@/assets/img/logo.png" :alt="`${Brand} Logo`" height="32" />
        {{ Brand }}
        <span v-if="environment !== 'production'" class="badge text-bg-warning">{{ environment }}</span>
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
            <NuxtLink to="/regles" class="nav-link"><font-awesome-icon icon="fas fa-book" /> Règles</NuxtLink>
          </li>
        </ul>
      </div>
    </div>
  </nav>
</template>

<script setup lang="ts">
import { Brand } from "~/types/constants";

const environment: string = process.env.NODE_ENV ?? "production";
</script>
