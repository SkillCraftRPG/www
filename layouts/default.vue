<template>
  <div class="d-flex flex-column min-vh-100">
    <LayoutNavbar />
    <div class="flex-grow-1 py-3">
      <slot></slot>
    </div>
    <LayoutFooter />
  </div>
</template>
