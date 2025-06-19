<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const route = useRoute();

const parent = computed<Breadcrumb[]>(() => [{ text: "Compétences", to: "/regles/competences" }]);
const title = computed<string>(() => {
  const slug: string = route.params.slug.toString();
  return slug[0].toUpperCase() + slug.substring(1);
});
</script>

<template>
  <div class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam rutrum congue urna, a elementum ex maximus ut. Sed suscipit aliquet nisl, eget molestie lorem
      congue vel. Mauris congue, lectus sit amet venenatis ultrices, dui libero tempus lacus, sed suscipit elit dolor id felis. Nulla imperdiet justo a nibh
      tristique, sed ullamcorper urna pharetra. Nunc neque mi, posuere id porttitor quis, ultricies vitae enim. Nam eu tellus urna. Morbi pulvinar turpis et
      sapien consectetur, sed posuere nunc tincidunt. Cras a diam consequat, euismod tortor hendrerit, accumsan mi. Cras blandit odio ut sapien vulputate, a
      lobortis tortor imperdiet. Vestibulum sit amet justo nec nibh egestas varius. Aenean quis neque venenatis purus blandit tincidunt. Nulla fermentum nisl ac
      mauris hendrerit, ut dignissim odio varius. In at velit eros. Aliquam dapibus metus pretium felis condimentum rutrum. Donec sapien risus, rutrum a
      eleifend eget, pellentesque eget justo.
    </p>
  </div>
</template>
