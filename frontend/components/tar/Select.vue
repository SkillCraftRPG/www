<template>
  <div>
    <slot v-if="!isFloating" name="label-override">
      <label v-if="label" :for="id" class="form-label">
        {{ label }}
        <slot name="label-required" v-if="isLabelRequired">
          <span class="text-danger">*</span>
        </slot>
      </label>
    </slot>
    <slot name="before"></slot>
    <div class="input-group">
      <slot name="prepend"></slot>
      <div v-if="isFloating" class="form-floating">
        <slot>
          <select
            :aria-describedby="describedBy"
            :aria-label="ariaLabel"
            :class="classes"
            :disabled="isDisabled"
            :id="id"
            :multiple="isMultiple"
            :name="name"
            ref="selectRef"
            :required="isRequired"
            :value="modelValue"
            @input="$emit('update:model-value', ($event.target as HTMLInputElement).value)"
          >
            <slot name="placeholder-override">
              <option v-if="placeholder" :disabled="isRequired && options.length > 0" value="">{{ placeholder }}</option>
            </slot>
            <option v-for="(option, index) in options" :key="index" :disabled="option.disabled" :label="option.label" :value="option.value">
              {{ option.text }}
            </option>
          </select>
        </slot>
        <slot name="label-override">
          <label :for="id">
            {{ label }}
            <slot name="label-required" v-if="isLabelRequired">
              <span class="text-danger">*</span>
            </slot>
          </label>
        </slot>
      </div>
      <slot v-else>
        <select
          :aria-describedby="describedBy"
          :aria-label="ariaLabel"
          :class="classes"
          :disabled="isDisabled"
          :id="id"
          :multiple="isMultiple"
          :name="name"
          ref="selectRef"
          :required="isRequired"
          :value="modelValue"
          @input="$emit('update:model-value', ($event.target as HTMLInputElement).value)"
        >
          <slot name="placeholder-override">
            <option v-if="placeholder" :disabled="isRequired && options.length > 0" value="">{{ placeholder }}</option>
          </slot>
          <option v-for="(option, index) in options" :key="index" :disabled="option.disabled" :label="option.label" :value="option.value">
            {{ option.text }}
          </option>
        </select>
      </slot>
      <slot name="append"></slot>
    </div>
    <slot name="after"></slot>
  </div>
</template>

<script setup lang="ts">
import { computed, ref } from "vue";
import { parsingUtils } from "logitar-js";

import type { SelectOptions } from "~/types/tar";

const { parseBoolean } = parsingUtils;

const props = withDefaults(defineProps<SelectOptions>(), {
  options: () => [],
});

const selectRef = ref<HTMLSelectElement>();

const isDisabled = computed<boolean>(() => parseBoolean(props.disabled) ?? false);
const isFloating = computed<boolean>(() => parseBoolean(props.floating) ?? false);
const isMultiple = computed<boolean>(() => parseBoolean(props.multiple) ?? false);
const isRequired = computed<boolean>(() => parseBoolean(props.required) ?? false);
const isLabelRequired = computed<boolean>(() => isRequired.value || (typeof props.required === "string" && props.required.trim().toLowerCase() === "label"));

const classes = computed<string[]>(() => {
  const classes = ["form-select"];
  switch (props.size) {
    case "large":
      classes.push("form-select-lg");
      break;
    case "small":
      classes.push("form-select-sm");
      break;
  }
  if (props.status) {
    classes.push(`is-${props.status}`);
  }
  return classes;
});

/**
 * Focuses the select element.
 */
function focus(): void {
  selectRef.value?.focus();
}
defineExpose({ focus });

defineEmits<{
  /**
   * The select value has been updated.
   */
  (e: "update:model-value", value?: string): void;
}>();
</script>
