<template>
  <main class="container">
    <template v-if="specialization">
      <h1>{{ title }}</h1>
      <RulesBreadcrumb :active="title" :parent="parent" />
      <SpecializationInfo :specialization="specialization" />
      <MarkdownContent v-if="initialContent" :text="initialContent" />
      <template v-if="additionalContent">
        <div class="mb-3" v-show="!showMore">
          <a href="#" @click.stop="showMore = true">En savoir plus</a>
        </div>
        <MarkdownContent v-show="showMore" :text="additionalContent" />
      </template>
      <SpecializationTree :specialization="specialization" />
      <SpecializationRequirements v-if="hasRequirements" :specialization="specialization" />
      <SpecializationOptions v-if="hasOptions" :specialization="specialization" />
      <SpecializationDoctrine v-if="specialization.doctrine" :talent="specialization.doctrine" />
    </template>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/tar/breadcrumb";
import type { Specialization } from "~/types/specializations";

const config = useRuntimeConfig();
const parent: Breadcrumb[] = [{ text: "Spécialisations", to: "/regles/specialisations" }];
const route = useRoute();

const showMore = ref<boolean>(false);

const slug = computed<string>(() => (Array.isArray(route.params.slug) ? route.params.slug[0] : route.params.slug) ?? "");
const { data } = await useAsyncData<Specialization>(
  `specialization:${slug.value}`,
  () =>
    $fetch(`/api/specializations/slug:${slug.value}`, {
      baseURL: config.public.apiBaseUrl,
    }),
  { watch: [slug] },
);

const specialization = computed<Specialization | undefined>(() => data.value ?? undefined);
const title = computed<string>(() => specialization.value?.name ?? "");
const description = computed<string>(() => specialization.value?.metaDescription ?? "");
const hasRequirements = computed<boolean>(() =>
  Boolean(specialization.value && (specialization.value.requirements.talent || specialization.value.requirements.other.length > 0)),
);
const hasOptions = computed<boolean>(() =>
  Boolean(specialization.value && (specialization.value.options.talents.length > 0 || specialization.value.options.other.length > 0)),
);
const initialContent = computed<string>(() => {
  if (!specialization.value || !specialization.value.htmlContent) {
    return "";
  }
  const index: number = specialization.value.htmlContent.indexOf("\n");
  return index < 0 ? specialization.value.htmlContent : specialization.value.htmlContent.substring(0, index);
});
const additionalContent = computed<string>(() => {
  if (!specialization.value || !specialization.value.htmlContent) {
    return "";
  }
  const index: number = specialization.value.htmlContent.indexOf("\n");
  return index < 0 ? "" : specialization.value.htmlContent.substring(index + 1);
});

useSeo({ title, description });
</script>
