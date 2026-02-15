<template>
  <main>
    <template v-if="questLog">
      <div class="container">
        <h1>{{ title }}</h1>
        <Breadcrumb divider="›">
          <BreadcrumbItem to="/">Accueil</BreadcrumbItem>
          <BreadcrumbItem active>Journal de quêtes</BreadcrumbItem>
          <BreadcrumbItem active>{{ title }}</BreadcrumbItem>
        </Breadcrumb>
        <MarkdownContent v-if="questLog.htmlContent" :text="questLog.htmlContent" />
      </div>
      <div class="container-fluid">
        <div class="row">
          <QuestList class="col-3" :quests="questLog.quests" :selected="quest" @selected="quest = $event" />
          <QuestInfo v-if="quest" class="col-9" :quest="quest" />
        </div>
      </div>
    </template>
  </main>
</template>

<script setup lang="ts">
import type { Quest, QuestLog } from "~/types/quests";

const config = useRuntimeConfig();
const route = useRoute();

const slug = computed<string>(() => (Array.isArray(route.params.slug) ? route.params.slug[0] : route.params.slug));
const { data } = await useAsyncData<QuestLog>(
  `quest-log:${slug.value}`,
  () =>
    $fetch(`/api/quests/logs/slug:${slug.value}`, {
      baseURL: config.public.apiBaseUrl,
    }),
  { watch: [slug] },
);

const quest = ref<Quest | undefined>();

const questLog = computed<QuestLog | undefined>(() => data.value ?? undefined);
const title = computed<string>(() => questLog.value?.title ?? "");
const description = computed<string>(() => questLog.value?.metaDescription ?? "");

useSeo({ title, description });
</script>
