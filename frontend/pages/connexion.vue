<template>
  <main class="container">
    <h1>{{ $t("users.signIn.title") }}</h1>
    <ClientOnly>
      <InvalidCredentials v-model="invalidCredentials" />
      <form @submit.prevent="submit">
        <UsernameInput v-model="username" />
        <PasswordInput ref="passwordRef" v-model="password" />
        <div class="mb-3">
          <TarButton
            :disabled="isLoading"
            icon="fas fa-arrow-right-to-bracket"
            :loading="isLoading"
            :status="$t('loading')"
            :text="$t('users.signIn.submit')"
            type="submit"
          />
        </div>
      </form>
    </ClientOnly>
  </main>
</template>

<script setup lang="ts">
import PasswordInput from "~/components/PasswordInput.vue";
import type { CurrentUser, SignInPayload } from "~/types/account";
import { signIn } from "~/api/account";

const account = useAccountStore();
const route = useRoute();

const invalidCredentials = ref<boolean>(false);
const isLoading = ref<boolean>(false);
const password = ref<string>("");
const passwordRef = ref<InstanceType<typeof PasswordInput> | null>(null);
const username = ref<string>("");

function onError(e: unknown): void {
  //if (isError(e, StatusCodes.BadRequest, ErrorCodes.InvalidCredentials)) {
  invalidCredentials.value = true;
  password.value = "";
  passwordRef.value?.focus();
  //} else {
  console.error(e); // TODO(fpion): handleError(e);
  //}
}

async function submit(): Promise<void> {
  if (!isLoading.value) {
    isLoading.value = true;
    invalidCredentials.value = false;
    try {
      const payload: SignInPayload = {
        identifier: username.value,
        password: password.value,
      };
      const currentUser: CurrentUser = await signIn(payload);
      account.signIn(currentUser);
      await navigateTo(route.query.redirect?.toString() || "/profil");
    } catch (e: unknown) {
      onError(e);
    } finally {
      isLoading.value = false;
    }
  }
}
</script>
