<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Lorsque le personnage acquiert le talent <NuxtLink to="/regles/talents/herboristerie">Herboristerie</NuxtLink>, il apprend un nombre de remèdes et de
      poisons de base égal à son <NuxtLink to="/regles/competences/rang">rang</NuxtLink> de <NuxtLink to="/regles/competences/medecine">Médecine</NuxtLink>.
      Chaque fois que son rang de Médecine augmente, il peut apprendre un nouveau remède ou poison. Le talent
      <NuxtLink to="/regles/talents/apothicairerie">Apothicairerie</NuxtLink> lui permet d’apprendre les remèdes avancés, tandis que le talent
      <NuxtLink to="/regles/talents/toxicologie">Toxicologie</NuxtLink> lui permet d’apprendre les poisons avancés.
    </p>
    <p>
      La concoction de remèdes et de poisons de base nécessite <NuxtLink to="/regles/aventure/temps">10 minutes</NuxtLink>, tandis que la concoction des remèdes
      et poisons avancés requiert une heure. Le personnage doit bien évidemment posséder et consommer les ingrédients indiqués par les remèdes et poisons.
      L’application ou l’activation d’un remède ou d’un poison est généralement effectuée par l’activité
      <NuxtLink to="/regles/combat/activites/objet">Objet</NuxtLink> (une <NuxtLink to="/regles/combat/deroulement/tour">action</NuxtLink>).
    </p>
    <div class="row">
      <div v-for="(item, index) in items" :key="index" class="col-xs-12 col-sm-6 mb-4">
        <LinkCard class="d-flex flex-column h-100" :text="item.description" :title="item.title" :to="item.path" />
      </div>
    </div>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [{ text: "Annexes", to: "/regles/annexes" }];
const title: string = "Herboristerie";

type MenuItem = {
  path: string;
  title: string;
  description: string;
};
const items: MenuItem[] = [
  {
    path: "/regles/herboristerie/remedes",
    title: "Remèdes",
    description: "🚧",
  },
  {
    path: "/regles/herboristerie/poisons",
    title: "Poisons",
    description: "🚧",
  },
];

useSeo({
  title,
  description: "🚧",
});
</script>
