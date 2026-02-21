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
    <h2 class="h3">Table des matières</h2>
    <ul>
      <li>
        <a href="#basic">Remèdes de base</a>
        <ul>
          <li v-for="poison in basic" :key="poison.id">
            <a :href="`#${poison.id}`">{{ poison.name }}</a>
          </li>
        </ul>
      </li>
      <li>
        <a href="#advanced">Remèdes avancés</a>
        <ul>
          <li v-for="poison in advanced" :key="poison.id">
            <a :href="`#${poison.id}`">{{ poison.name }}</a>
          </li>
        </ul>
      </li>
    </ul>
    <h2 id="basic" class="h3">Remèdes de base</h2>
    <p>Le talent <NuxtLink to="/regles/talents/herboristerie">Herboristerie</NuxtLink> permet d’apprendre les remèdes de base.</p>
    <template v-for="remedy in basic" :key="remedy.id">
      <h3 :id="remedy.id" class="h5">{{ remedy.name }}</h3>
      <MarkdownContent :text="remedy.description" />
    </template>
    <h2 id="advanced" class="h3">Remèdes avancés</h2>
    <p>Le talent <NuxtLink to="/regles/talents/apothicairerie">Apothicairerie</NuxtLink> permet d’apprendre les remèdes avancés.</p>
    <template v-for="remedy in advanced" :key="remedy.id">
      <h3 :id="remedy.id" class="h5">{{ remedy.name }}</h3>
      <MarkdownContent :text="remedy.description" />
    </template>
  </main>
</template>

<script setup lang="ts">
import { arrayUtils } from "logitar-js";

import type { Breadcrumb } from "~/types/components";
import type { Remedy } from "~/types/game";
import { getRemedies } from "~/services/herbalism";

const parent: Breadcrumb[] = [{ text: "Herboristerie", to: "/regles/herboristerie" }];
const title: string = "Remèdes";
const { orderBy } = arrayUtils;

const poisons = ref<Remedy[]>(getRemedies());

const advanced = computed<Remedy[]>(() =>
  orderBy(
    poisons.value.filter(({ category }) => category === "Advanced"),
    "slug",
  ),
);
const basic = computed<Remedy[]>(() =>
  orderBy(
    poisons.value.filter(({ category }) => category === "Basic"),
    "slug",
  ),
);

useSeo({
  title,
  description:
    "Découvrez les remèdes de base et avancés : potions, infusions et onguents soignant poisons, blessures, fatigue et effets néfastes grâce à l’herboristerie.",
});
</script>
