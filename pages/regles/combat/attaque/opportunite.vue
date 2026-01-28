<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb active="Opportunité" :parent="parent" />
    <p>
      Certaines <NuxtLink to="/regles/combat/activites">activités</NuxtLink> en combat exposent une ou plusieurs de vos faiblesses. Les créatures autour de vous
      peuvent alors utiliser leur <NuxtLink to="/regles/combat/deroulement/tour">réaction</NuxtLink> et saisir l’opportunité de vous attaquer.
    </p>
    <p>
      Cette attaque doit absolument être effectuée <NuxtLink to="/regles/combat/attaque/melee">à mêlée</NuxtLink> (avec un membre de son corps ou en maniant une
      arme de mêlée). L’attaque est résolue juste avant que vous n’agissiez, ce qui peut avoir de graves conséquences.
    </p>
    <p>
      Une créature <NuxtLink to="/regles/combat/activites/deplacement">se déplaçant</NuxtLink> hors de votre portée de mêlée déclenche une attaque
      d’opportunité, sauf si elle a effectué un <NuxtLink to="/regles/combat/activites/pas-prudent">Pas prudent</NuxtLink>. Si elle se téléporte ou elle est
      déplacée contre son gré, par exemple en étant <NuxtLink to="/regles/combat/conditions/agrippe">agrippée</NuxtLink> ou par l’impact d’une explosion, elle
      ne déclenche pas d’attaque d’opportunité.
    </p>
    <p>Les talents suivants améliorent vos attaques d’opportunité, ou vous confèrent des déclencheurs additionnels :</p>
    <div class="row">
      <div v-for="talent in talents" :key="talent.id" class="col-xs-12 col-sm-6 col-md-4 mb-4">
        <TalentCard class="d-flex flex-column h-100" :talent="talent" />
      </div>
    </div>
    <p>Voici une liste non exhaustive des activités pouvant déclencher une attaque d’opportunité :</p>
    <ul>
      <li><NuxtLink to="/regles/combat/activites/aider">Aider</NuxtLink> une créature à effectuer une action déclenchant une attaque d’opportunité.</li>
      <li><NuxtLink to="/regles/combat/activites/viser-tirer">Attaquer à distance</NuxtLink>.</li>
      <li><NuxtLink to="/regles/combat/activites/canaliser">Canaliser un pouvoir</NuxtLink>.</li>
      <li><NuxtLink to="/regles/combat/activites/chargement">Charger une munition dans une arme</NuxtLink>.</li>
      <li>Délivrer le <NuxtLink to="/regles/combat/activites/coup-grace">coup de grâce</NuxtLink>.</li>
      <li><NuxtLink to="/regles/combat/activites/preparer">Préparer</NuxtLink> une action déclenchant une attaque d’opportunité.</li>
      <li><NuxtLink to="/regles/combat/activites/deplacement">Se déplacer</NuxtLink>.</li>
      <li><NuxtLink to="/regles/combat/activites/stabiliser">Stabiliser</NuxtLink> une créature agonisante.</li>
      <li>
        Utiliser un <NuxtLink to="/regles/combat/activites/objet">objet</NuxtLink> si des <NuxtLink to="/regles/combat/degats/soins">soins</NuxtLink> sont
        encourus, ou si l’action requiert deux mains.
      </li>
    </ul>
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
const title: string = "Attaque d’opportunité";
const { orderBy } = arrayUtils;

const query: string = ["chasse-mage", "conjecture", "fourberie", "intrepide", "magie-guerriere", "sentinelle"].map((slug) => `slug=${slug}`).join("&");
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
    "Découvrez les règles des attaques d’opportunité, leurs déclencheurs, et les talents qui les améliorent pour surprendre vos adversaires en combat.",
});
</script>
