<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>Vous tentez de désarmer une créature.</p>
    <p>
      Effectuez un <NuxtLink to="/regles/competences/tests">test</NuxtLink> d’<NuxtLink to="/regles/combat/attaque">attaque</NuxtLink>{{ " "
      }}<NuxtLink to="/regles/competences/tests/oppose">opposé</NuxtLink> à un test d’<NuxtLink to="/regles/competences/athletisme">Athlétisme</NuxtLink> ou
      d’<NuxtLink to="/regles/competences/acrobaties">Acrobaties</NuxtLink>, au choix de la cible.
    </p>
    <p>
      Si votre test réussit, la cible est forcée de <NuxtLink to="/regles/combat/activites/lacher">lâcher</NuxtLink> son
      <NuxtLink to="/regles/equipement/armes">arme</NuxtLink>. L’arme tombe au sol, à ses pieds.
    </p>
    <p>
      Cette activité compte comme une attaque, elle n’est donc pas exempte de la pénalité des
      <NuxtLink to="/regles/combat/attaque/multiples">attaques multiples</NuxtLink>.
    </p>
    <p>Les <NuxtLink to="/regles/talents">talents</NuxtLink> suivants améliorent votre capacité à désarmer :</p>
    <div class="row">
      <div v-for="talent in talents" :key="talent.id" class="col-xs-12 col-sm-6 mb-4">
        <TalentCard class="d-flex flex-column h-100" :talent="talent" />
      </div>
    </div>
  </main>
</template>

<script setup lang="ts">
import { arrayUtils } from "logitar-js";

import type { Breadcrumb } from "~/types/components";
import type { SearchResults, Talent } from "~/types/game";

const config = useRuntimeConfig();
const parent: Breadcrumb[] = [
  { text: "Combat", to: "/regles/combat" },
  { text: "Activités", to: "/regles/combat/activites" },
];
const title: string = "Désarmer";
const { orderBy } = arrayUtils;

const query: string = ["manoeuvres-de-combat", "poigne-de-fer"].map((slug) => `slug=${slug}`).join("&");
const { data } = await useAsyncData<SearchResults<Talent>>("talents", () =>
  $fetch(`/api/talents?${query}`, {
    baseURL: config.public.apiBaseUrl,
  }),
);
const talents = computed<Talent[]>(() =>
  orderBy(
    (data.value?.items ?? []).map((talent) => ({ ...talent, sort: [talent.tier, talent.slug].join("_") })),
    "sort",
  ),
);

useSeo({
  title,
  description:
    "Découvrez l’action Désarmer : forcez un adversaire à lâcher son arme grâce à un test opposé et exploitez des talents pour améliorer cette capacité.",
});
</script>
