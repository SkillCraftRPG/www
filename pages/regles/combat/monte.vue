<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb active="Monté" :parent="parent" />
    <p>
      Vous pouvez monter une créature consentante d’une <NuxtLink to="/regles/especes/taille">catégorie de taille</NuxtLink> supérieure ou plus à la vôtre et
      possédant une anatomie appropriée.
    </p>
    <p>
      L’action <NuxtLink to="/regles/combat/activites/deplacement">Déplacement</NuxtLink> vous permet de
      <NuxtLink to="/regles/aventure/mouvement/types">monter</NuxtLink> ou de <NuxtLink to="/regles/aventure/mouvement/types">démonter</NuxtLink> votre monture.
    </p>
    <p>
      Lorsqu’une des situations suivantes se produit, vous pouvez <NuxtLink to="/regles/combat/activites/demonter">démonter</NuxtLink> votre monture en
      <NuxtLink to="/regles/combat/deroulement/tour">réaction</NuxtLink>. Si vous n’effectuez pas cette réaction, vous êtes
      <NuxtLink to="/regles/combat/conditions/renverse">renversés</NuxtLink> au sol à 1,5 mètres de votre monture.
    </p>
    <ul>
      <li>Votre monture est renversée.</li>
      <li>Vous êtes renversés.</li>
      <li>Un effet déplace votre monture contre son gré.</li>
    </ul>
    <p>
      Lorsque votre monture provoque une <NuxtLink to="/regles/combat/attaque/opportunite">attaque d’opportunité</NuxtLink>, l’attaquant peut cibler la monture
      ou son destrier.
    </p>
    <p>
      Vous pouvez contrôler votre monture si celle-ci a été entraînée comme monture et qu’elle n’est pas une créature intelligente. Les
      <NuxtLink to="/regles/equipement/montures-vehicules">animaux domestiques</NuxtLink> sont tous entraînés comme monture.
    </p>
    <ul>
      <li>
        Lorsque vous contrôlez votre monture, elle joue pendant votre <NuxtLink to="/regles/combat/deroulement/tour">tour</NuxtLink>. Elle ne peut effectuer que
        les actions <NuxtLink to="/regles/combat/activites/deplacement">Déplacement</NuxtLink>,
        <NuxtLink to="/regles/combat/activites/pas-prudent">Pas prudent</NuxtLink> et <NuxtLink to="/regles/combat/activites/defense">Défense</NuxtLink>.
      </li>
      <li>
        Une créature non entraînée ou intelligente possède sa propre valeur d’<NuxtLink to="/regles/combat/deroulement/initiative">Initiative</NuxtLink> et joue
        son <NuxtLink to="/regles/combat/deroulement/tour">tour</NuxtLink> indépendamment du vôtre. Elle peut agir comme bon lui semble et n’est pas limitée
        dans les <NuxtLink to="/regles/combat/activites">activités</NuxtLink> qu’elle peut effectuer.
      </li>
    </ul>
    <p>Le <NuxtLink to="/regles/talents">talent</NuxtLink> suivant améliore votre capacité à combattre sur un monture.</p>
    <div class="row">
      <div v-for="talent in talents" :key="talent.id" class="col-xs-12 mb-4">
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
const parent: Breadcrumb[] = [{ text: "Combat", to: "/regles/combat" }];
const title: string = "Combat monté";
const { orderBy } = arrayUtils;

const query: string = ["monture-de-combat"].map((slug) => `slug=${slug}`).join("&");
const { data } = await useAsyncData<SearchResults<Talent>>("talents:combat-monte", () =>
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
  description: "Découvrez les règles du combat monté : contrôle de votre monture, actions possibles, risques de renversement et attaques d’opportunité.",
});
</script>
