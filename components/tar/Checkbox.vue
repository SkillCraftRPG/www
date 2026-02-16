<script setup lang="ts">
import { computed, ref } from "vue";
import { nanoid } from "nanoid";
import { parsingUtils } from "logitar-js";

import type { CheckboxOptions } from "~/types/tar/checkbox";

const { parseBoolean } = parsingUtils;

const props = defineProps<CheckboxOptions>();

const inputRef = ref<HTMLInputElement>();

const classes = computed<string[]>(() => {
  const classes = ["form-check"];
  if (parseBoolean(props.inline)) {
    classes.push("form-check-inline");
  }
  if (parseBoolean(props.reverse)) {
    classes.push("form-check-reverse");
  }
  if (parseBoolean(props.switch)) {
    classes.push("form-switch");
  }
  return classes;
});
const inputId = computed<string>(() => props.id ?? nanoid());
const inputRole = computed<string | undefined>(() => props.role ?? (props.switch ? "switch" : undefined));

const emit = defineEmits<{
  (e: "update:model-value", value: boolean): void;
}>();
function onChange(event: Event): void {
  emit("update:model-value", (event.target as HTMLInputElement).checked);
}

function focus(): void {
  inputRef.value?.focus();
}
defineExpose({ focus });
</script>

<template>
  <div :class="classes">
    <slot name="before"></slot>
    <slot>
      <input
        :aria-describedby="describedBy"
        :aria-label="ariaLabel"
        :checked="parseBoolean(modelValue)"
        class="form-check-input"
        :disabled="parseBoolean(disabled)"
        :id="inputId"
        :name="name"
        ref="inputRef"
        :required="parseBoolean(required)"
        :role="inputRole"
        type="checkbox"
        :value="value"
        @change="onChange"
      />
      <slot name="label-override">
        <label v-if="label" class="form-check-label" :for="inputId">{{ label }}</label>
      </slot>
    </slot>
    <slot name="after"></slot>
  </div>
</template>
