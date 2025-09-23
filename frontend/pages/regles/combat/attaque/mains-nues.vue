<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>Une créature combat à mains nues lorsqu’elle attaque avec ses mains, pieds, ou tout autre membre de son corps.</p>
    <p>
      Elle effectue une <NuxtLink to="/regles/combat/attaque/melee">attaque de mêlée</NuxtLink> (<NuxtLink to="/regles/competences/tests">test</NuxtLink> de
      <NuxtLink to="/regles/competences/melee">Mêlée</NuxtLink>), par l’<NuxtLink to="/regles/combat/activites">activité</NuxtLink>{{ " " }}<i>Attaquer</i>.
      Elle n’ajoute son <NuxtLink to="/regles/competences/rang">rang</NuxtLink> que si elle est
      <NuxtLink to="/regles/talents/arts-martiaux">formée</NuxtLink> pour le combat à mains nues.
    </p>
    <p>
      Si l’attaque réussit, elle inflige 1 + <NuxtLink to="/regles/statistiques/force">Force</NuxtLink>{{ " "
      }}<NuxtLink to="/regles/combat/degats">points de dégâts</NuxtLink>{{ " " }}<NuxtLink to="/regles/combat/degats/types">contondants</NuxtLink>{{ " "
      }}<NuxtLink to="/regles/combat/degats/letalite">non létaux</NuxtLink>. Certains talents augmentent les points de dégâts infligés.
    </p>
    <p>
      Les <NuxtLink to="/regles/combat/attaque">attaques</NuxtLink> effectuées avec un membre de son corps déclenchent une
      <NuxtLink to="/regles/combat/attaque/opportunite">attaque d’opportunité</NuxtLink> si l’attaquant n’est pas formé pour le combat à mains nues.
    </p>
    <p>Les <NuxtLink to="/regles/talents">talents</NuxtLink> suivants améliorent votre capacité à combattre à mains nues :</p>
    <div class="row">
      <div v-for="talent in talents" :key="talent.id" class="col-xs-12 col-sm-6 col-md-4 col-lg-3 mb-4">
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
  { text: "Attaque", to: "/regles/combat/attaque" },
];
const title: string = "Combat à mains nues";
const { orderBy } = arrayUtils;

const query: string = ["arts-martiaux", "frappe-precise", "frappe-puissante", "point-de-conscience"].map((slug) => `slug=${slug}`).join("&");
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
  description: "Découvrez les règles du combat à mains nues : attaques, dégâts, talents spéciaux et options pour améliorer votre efficacité.",
});

// TODO(fpion): Arts martiaux, enlève l'attaque d'opportunité
</script>
