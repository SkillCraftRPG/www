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
          <input
            :aria-describedby="describedBy"
            :class="classes"
            :disabled="isDisabled"
            :id="id"
            :maxlength="maxLength"
            :max="maxValue"
            :minlength="minLength"
            :min="minValue"
            :name="name"
            :pattern="pattern"
            :placeholder="placeholder"
            :readonly="isReadonly"
            ref="inputRef"
            :required="isRequired"
            :step="inputStep"
            :type="type"
            :value="modelValue"
            @input="$emit('update:model-value', ($event.target as HTMLInputElement).value)"
          />
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
        <input
          :aria-describedby="describedBy"
          :class="classes"
          :disabled="isDisabled"
          :id="id"
          :maxlength="maxLength"
          :max="maxValue"
          :minlength="minLength"
          :min="minValue"
          :name="name"
          :pattern="pattern"
          :placeholder="placeholder"
          :readonly="isReadonly"
          ref="inputRef"
          :required="isRequired"
          :step="inputStep"
          :type="type"
          :value="modelValue"
          @input="$emit('update:model-value', ($event.target as HTMLInputElement).value)"
        />
      </slot>
      <slot name="append"></slot>
    </div>
    <slot name="after"></slot>
  </div>
</template>

<script setup lang="ts">
import { computed, ref } from "vue";
import { parsingUtils } from "logitar-js";

import type { InputOptions } from "~/types/tar";

const { parseBoolean, parseNumber } = parsingUtils;

const props = defineProps<InputOptions>();

const inputRef = ref<HTMLInputElement>();

const isDisabled = computed<boolean>(() => parseBoolean(props.disabled) ?? false);
const isFloating = computed<boolean>(() => parseBoolean(props.floating) ?? false);
const isReadonly = computed<boolean>(() => parseBoolean(props.readonly) ?? false);
const isRequired = computed<boolean>(() => parseBoolean(props.required) ?? false);
const isLabelRequired = computed<boolean>(() => isRequired.value || (typeof props.required === "string" && props.required.trim().toLowerCase() === "label"));

const classes = computed<string[]>(() => {
  const classes: string[] = [];
  if (props.type === "range") {
    classes.push("form-range");
  } else if (isReadonly.value && parseBoolean(props.plaintext)) {
    classes.push("form-control-plaintext");
  } else {
    classes.push("form-control");
  }
  switch (props.size) {
    case "large":
      classes.push("form-control-lg");
      break;
    case "small":
      classes.push("form-control-sm");
      break;
  }
  if (props.status) {
    classes.push(`is-${props.status}`);
  }
  return classes;
});

const isDateTime = computed<boolean>(() => isDateTimeInput(props.type));
const isNumeric = computed<boolean>(() => isNumericInput(props.type));
const isTextual = computed<boolean>(() => isTextualInput(props.type));
const maxLength = computed<number | undefined>(() => {
  return isTextual.value ? parseNumber(props.max) || undefined : undefined;
});
const maxValue = computed<number | string | undefined>(() => {
  if (isNumeric.value) {
    return parseNumber(props.max);
  } else if (isDateTime.value) {
    return props.max;
  }
  return undefined;
});
const minLength = computed<number | undefined>(() => {
  return isTextual.value ? parseNumber(props.min) || undefined : undefined;
});
const minValue = computed<number | string | undefined>(() => {
  if (isNumeric.value) {
    return parseNumber(props.min);
  } else if (isDateTime.value) {
    return props.min;
  }
  return undefined;
});
const inputStep = computed<number | string | undefined>(() => {
  if (typeof props.step === "string" && props.step.trim().toLowerCase() === "any") {
    return "any";
  }
  if (isNumeric.value) {
    return parseNumber(props.step);
  } else if (isDateTime.value) {
    const step = typeof props.step === "string" ? props.step.trim() : props.step;
    return parseNumber(step);
  }
  return undefined;
});

/**
 * Focuses the input element.
 */
function focus(): void {
  inputRef.value?.focus();
}
defineExpose({ focus });

defineEmits<{
  /**
   * The input value has been updated.
   */
  (e: "update:model-value", value?: string): void;
}>();
</script>
