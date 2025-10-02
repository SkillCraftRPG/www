<template>
  <div
    :class="classes"
    :id="modalId"
    tabindex="-1"
    :aria-labelledby="labelId"
    aria-hidden="true"
    :data-bs-backdrop="parseBoolean(static) ? 'static' : undefined"
    :data-bs-keyboard="parseBoolean(static) ? false : undefined"
  >
    <div :class="dialogClasses">
      <div class="modal-content">
        <div class="modal-header">
          <h1 v-if="title" class="modal-title fs-5" :id="labelId">{{ title }}</h1>
          <button type="button" class="btn-close" data-bs-dismiss="modal" :aria-label="close"></button>
          <slot name="title-override"></slot>
        </div>
        <div class="modal-body">
          <slot></slot>
        </div>
        <div class="modal-footer">
          <slot name="footer"></slot>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import { Modal } from "bootstrap";
import { nanoid } from "nanoid";
import { parsingUtils } from "logitar-js";

import type { ModalOptions } from "~/types/tar/modal";

const { parseBoolean } = parsingUtils;

const props = withDefaults(defineProps<ModalOptions>(), {
  close: "Close",
  fade: true,
});

const modal = ref<Modal>();

const classes = computed<string[]>(() => {
  const classes = ["modal"];
  if (parseBoolean(props.fade)) {
    classes.push("fade");
  }
  return classes;
});
const dialogClasses = computed<string[]>(() => {
  const classes = ["modal-dialog"];
  if (parseBoolean(props.centered)) {
    classes.push("modal-dialog-centered");
  }
  if (parseBoolean(props.scrollable)) {
    classes.push("modal-dialog-scrollable");
  }
  switch (props.fullscreen) {
    case true:
      classes.push("modal-fullscreen");
      break;
    case "below-small":
      classes.push("modal-fullscreen-sm-down");
      break;
    case "below-medium":
      classes.push("modal-fullscreen-md-down");
      break;
    case "below-large":
      classes.push("modal-fullscreen-lg-down");
      break;
    case "below-x-large":
      classes.push("modal-fullscreen-xl-down");
      break;
    case "below-xx-large":
      classes.push("modal-fullscreen-xxl-down");
      break;
  }
  switch (props.size) {
    case "small":
      classes.push("modal-sm");
      break;
    case "large":
      classes.push("modal-lg");
      break;
    case "x-large":
      classes.push("modal-xl");
      break;
  }
  return classes;
});
const modalId = computed<string>(() => props.id ?? nanoid());
const labelId = computed<string>(() => `${modalId.value}-label`);

/**
 * Hides the modal.
 */
function hide(): void {
  modal.value?.hide();
}
/**
 * Shows the modal.
 */
function show(): void {
  modal.value?.show();
}
/**
 * Hides the modal if it is shown, or shows it otherwise.
 */
function toggle(): void {
  modal.value?.toggle();
}
defineExpose({ hide, show, toggle });

onMounted(() => {
  const element = document.getElementById(modalId.value);
  if (element) {
    modal.value = Modal.getOrCreateInstance(element);
  }
});
</script>
