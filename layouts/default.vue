<template>
  <div class="d-flex flex-column min-vh-100">
    <LayoutNavbar />
    <div class="flex-grow-1 py-3">
      <slot></slot>
      <Transition name="fade">
        <button
          v-if="showScrollTop"
          type="button"
          class="btn btn-lg btn-primary btn-scroll position-fixed end-0 m-3 rounded-circle shadow"
          :style="{ bottom: `${footerOverlap}px` }"
          @click="scrollToTop"
        >
          <font-awesome-icon icon="fas fa-arrow-up" />
        </button>
      </Transition>
    </div>
    <LayoutFooter id="footer" />
  </div>
</template>

<script setup lang="ts">
const footerOverlap = ref<number>(0);
const showScrollTop = ref<boolean>(false);

function scrollToTop(): void {
  window.history.replaceState(window.history.state, "", window.location.pathname + window.location.search);
  window.scrollTo({ top: 0, left: 0, behavior: "smooth" });
}

function update(): void {
  showScrollTop.value = window.scrollY > 200;

  const footer: HTMLElement | null = document.getElementById("footer");
  if (footer) {
    const footerTop: number = footer.getBoundingClientRect().top + window.scrollY;
    const viewportBottom: number = window.scrollY + window.innerHeight;
    const overlap: number = viewportBottom - footerTop;
    footerOverlap.value = Math.max(0, Math.min(footer.offsetHeight, overlap));
  } else {
    footerOverlap.value = 0;
    return;
  }
}

onMounted(() => {
  update();
  window.addEventListener("resize", update);
  window.addEventListener("scroll", update, { passive: true });
});

onBeforeUnmount(() => {
  window.removeEventListener("resize", update);
  window.removeEventListener("scroll", update);
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
