<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <RulesBreadcrumb active="Abjuration" :parent="parent" />
    <p>
      Le cercle d’abjuration rassemble les pouvoirs dont la fonction est de protéger, de défendre. Bien que ces pouvoirs ne blessent pas directement, ils
      peuvent quand même blesser involontairement une créature qui ne respecte pas les interdits.
    </p>
    <!-- Garde partagée (Allégeance) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Garde partagée</h2>
      <div class="h5">
        <TarBadge variant="secondary">Allégeance</TarBadge>
      </div>
    </div>
    <p>
      Lorsque le personnage <NuxtLink to="/regles/aventure/environnement/vision">voit</NuxtLink> une créature située à 9 mètres ou moins de sa position recevoir
      des <NuxtLink to="/regles/combat/degats">points de dégâts</NuxtLink>, il peut partager sa
      <NuxtLink to="/regles/talents/initiation-magique">garde magique</NuxtLink> avec celle-ci en
      <NuxtLink to="/regles/combat/deroulement/tour">réaction</NuxtLink>. L’excédent de points de dégâts reçus par la garde est transféré à la créature.
    </p>
    <!-- Abjuration totale (Élévation) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Abjuration totale</h2>
      <div class="h5">
        <TarBadge variant="secondary">Élévation</TarBadge>
      </div>
    </div>
    <p>
      Lorsque le personnage <NuxtLink to="/regles/magie/pouvoirs/canalisation">canalise</NuxtLink> un
      <NuxtLink to="/regles/magie/pouvoirs">pouvoir</NuxtLink> associé au cercle d’Abjuration, il ajoute un bonus égal ses
      <NuxtLink to="/regles/attributs/sens">Sens</NuxtLink> (minimum&nbsp;1) à son <NuxtLink to="/regles/competences/tests">test</NuxtLink> d’<NuxtLink
        to="/regles/competences/occultisme"
        >Occultisme</NuxtLink
      >.
    </p>
    <!-- Résistance magique (Élévation) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Résistance magique</h2>
      <div class="h5">
        <TarBadge variant="secondary">Élévation</TarBadge>
      </div>
    </div>
    <p>
      Le personnage se voit conférer l’<NuxtLink to="/regles/competences/tests/avantage-desavantage">avantage</NuxtLink> à ses
      <NuxtLink to="/regles/competences/tests/sauvegarde">jets de sauvegarde</NuxtLink> contre les <NuxtLink to="/regles/magie/pouvoirs">pouvoirs</NuxtLink>, et
      est <NuxtLink to="/regles/combat/degats/efficacite">résistant</NuxtLink> aux <NuxtLink to="/regles/combat/degats">points de dégâts</NuxtLink> infligés par
      un pouvoir.
    </p>
    <SpellList v-if="spells.length" :items="spells" :scope="category" />
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/tar/breadcrumb";
import type { SearchResults } from "~/types/game";
import type { Spell } from "~/types/magic";
import { SpellCategories } from "~/types/constants";

const config = useRuntimeConfig();
const parent: Breadcrumb[] = [
  { text: "Annexes", to: "/regles/annexes" },
  { text: "Astromancie", to: "/regles/astromancie" },
];
const title: string = "Cercle d’Abjuration";

const category: string = SpellCategories.Abjuration;
const { data } = await useLazyAsyncData<SearchResults<Spell>>(
  `spells:${category}`,
  () =>
    $fetch(`/api/spells?category=${category}`, {
      baseURL: config.public.apiBaseUrl,
    }),
  {
    server: false,
  },
);
const spells = computed<Spell[]>(() => data.value?.items ?? []);

useSeo({
  title,
  description: "Découvrez le cercle d’Abjuration : des pouvoirs d’Astromancie voués à protéger, défendre et résister aux forces magiques.",
});
</script>
