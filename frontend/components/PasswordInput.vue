<template>
  <TarInput
    class="mb-3"
    floating
    :id="id"
    :label="label ? $t(label) : undefined"
    :model-value="modelValue"
    :placeholder="placeholder || label ? $t(placeholder || label) : undefined"
    ref="inputRef"
    :required="required"
    :status="status"
    :type="type"
    @update:model-value="onModelValueUpdate"
  />
</template>

<script setup lang="ts">
import TarInput from "~/components/tar/Input.vue";
import type { InputStatus, InputType } from "~/types/tar";

const props = withDefaults(
  defineProps<{
    id?: string;
    label?: string;
    modelValue?: string;
    placeholder?: string;
    required?: boolean | string;
    type?: InputType;
  }>(),
  {
    id: "password",
    label: "users.signIn.password",
    required: true,
    type: "password",
  },
);

const inputRef = ref<InstanceType<typeof TarInput> | null>(null);
const touched = ref<boolean>(false);

const status = computed<InputStatus | undefined>(() => (touched.value ? (props.modelValue?.length ? "valid" : "invalid") : undefined));

const emit = defineEmits<{
  (e: "update:model-value", value: string): void;
}>();

function onModelValueUpdate(value: string | undefined): void {
  touched.value = true;
  emit("update:model-value", value ?? "");
}

function focus(): void {
  inputRef.value?.focus();
}
defineExpose({ focus });
</script>
