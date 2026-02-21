<template>
  <div class="d-flex flex-column min-vh-100">
    <LayoutNavbar />
    <div class="flex-grow-1 py-3">
      <slot></slot>
      <Transition name="fade">
        <button
          v-if="showScrollTop"
          type="button"
          class="btn btn-lg btn-primary btn-scroll position-fixed bottom-0 end-0 m-3 rounded-circle shadow"
          @click="scrollToTop"
        >
          <font-awesome-icon icon="fas fa-arrow-up" />
        </button>
      </Transition>
    </div>
    <LayoutFooter />
  </div>
</template>

<script setup lang="ts">
const showScrollTop = ref<boolean>(false);

function onScroll(): void {
  showScrollTop.value = window.scrollY > 200;
}

function scrollToTop(): void {
  window.history.replaceState(window.history.state, "", window.location.pathname + window.location.search);
  window.scrollTo({ top: 0, left: 0, behavior: "smooth" });
}

onMounted(() => {
  window.addEventListener("scroll", onScroll, { passive: true });
});

onBeforeUnmount(() => {
  window.removeEventListener("scroll", onScroll);
});
</script>

<style scoped>
.btn-scroll {
  width: 64px;
  height: 64px;
  display: flex;
  align-items: center;
  justify-content: center;
  padding: 0;
}

.fade-enter-active,
.fade-leave-active {
  transition: opacity 0.2s ease;
}

.fade-enter-from,
.fade-leave-to {
  opacity: 0;
}
</style>
