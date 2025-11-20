<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Les remèdes ont la fonction de <NuxtLink to="/regles/combat/degats/soins">guérir</NuxtLink>, au contraire des
      <NuxtLink to="/regles/herboristerie/poisons">poisons</NuxtLink>. Ils servent à soigner des effets naturels, c’est-à-dire induits par une source non
      magique, et ne peuvent être utilisés qu’afin de guérir des effets temporaires. Certaines plantes magiques, par exemple le l’édelweiss (étoile d’argent ou
      étoile des neiges), les fruits de l’arbre à lotos ou encore la racine de mandragore, peuvent être incorporés à un remède afin de guérir les effets
      permanents et/ou induits par une source <NuxtLink to="/regles/magie">magique</NuxtLink>.
    </p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [{ text: "Herboristerie", to: "/regles/herboristerie" }];
const title: string = "Remèdes";

useSeo({
  title,
  description: "🚧",
});
</script>
