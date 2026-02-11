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
          <!-- Dark mode selector, which is a simple dropdown menu with Light, Dark and Auto -->
          <li class="nav-item">
            <div class="dropdown" data-bs-theme="dark">
              <button
                class="btn btn-flat btn-sm mt-1 mx-1 dropdown-toggle btn-dark"
                type="button"
                id="themeSelector"
                data-bs-toggle="dropdown"
                aria-expanded="false"
              >
                <font-awesome-icon icon="fas fa-moon" width="16px" v-if="theme.currentTheme === 'dark'" />
                <font-awesome-icon icon="fas fa-sun" width="16px" v-else-if="theme.currentTheme === 'light'" />
                <font-awesome-icon icon="fas fa-adjust" width="16px" v-else />
                {{ $t("theme.title") }}
              </button>
              <ul class="dropdown-menu dropdown-menu-end" aria-labelledby="themeSelector">
                <li>
                  <button class="dropdown-item" @click="theme.setTheme('light')">
                    <font-awesome-icon icon="fas fa-sun" width="16px" /> {{ $t("theme.light") }}
                  </button>
                </li>
                <li>
                  <button class="dropdown-item" @click="theme.setTheme('dark')">
                    <font-awesome-icon icon="fas fa-moon" width="16px" /> {{ $t("theme.dark") }}
                  </button>
                </li>
                <li>
                  <button class="dropdown-item" @click="theme.setTheme('auto')">
                    <font-awesome-icon icon="fas fa-adjust" width="16px" /> {{ $t("theme.auto") }}
                  </button>
                </li>
              </ul>
            </div>
          </li>
          <template v-if="user">
            <li class="nav-item d-block d-lg-none">
              <NuxtLink to="/profil" class="nav-link">
                <TarAvatar :display-name="user.displayName" :email-address="user.emailAddress ?? undefined" :size="24" :url="user.pictureUrl ?? undefined" />
                {{ user.displayName }}
              </NuxtLink>
            </li>
            <li class="nav-item d-block d-lg-none">
              <NuxtLink to="/deconnexion" class="nav-link"><font-awesome-icon icon="fas fa-arrow-right-from-bracket" /> {{ $t("users.signOut") }}</NuxtLink>
            </li>
            <li class="nav-item dropdown d-none d-lg-block">
              <a class="nav-link dropdown-toggle" href="#" role="button" data-bs-toggle="dropdown" aria-expanded="false">
                <TarAvatar :display-name="user.displayName" :email-address="user.emailAddress ?? undefined" :size="24" :url="user.pictureUrl ?? undefined" />
              </a>
              <ul class="dropdown-menu dropdown-menu-end">
                <li>
                  <NuxtLink to="/profil" class="dropdown-item">
                    <font-awesome-icon icon="fas fa-user" />
                    {{ user.displayName }}
                  </NuxtLink>
                </li>
                <li>
                  <NuxtLink to="/deconnexion" class="dropdown-item">
                    <font-awesome-icon icon="fas fa-arrow-right-from-bracket" /> {{ $t("users.signOut") }}
                  </NuxtLink>
                </li>
              </ul>
            </li>
          </template>
          <!-- <template v-else>
            <li class="nav-item">
              <NuxtLink to="/connexion" class="nav-link"><font-awesome-icon icon="fas fa-arrow-right-to-bracket" /> {{ $t("users.signIn.title") }}</NuxtLink>
            </li>
          </template> -->
        </ul>
      </div>
    </div>
  </nav>
</template>

<script setup lang="ts">
import type { CurrentUser } from "~/types/account";

const theme = useThemeStore();
const account = useAccountStore();
const environment: string = process.env.NODE_ENV ?? "production";

const user = computed<CurrentUser | undefined>(() => account.currentUser);
</script>
