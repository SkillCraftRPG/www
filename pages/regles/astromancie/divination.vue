<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <RulesBreadcrumb active="Divination" :parent="parent" />
    <p>
      Ce cercle rassemble les pouvoirs tentant de comprendre le passé, le présent ou le futur. Ces pouvoirs sont craints et recherchés par toutes les classes
      sociales, autant par les nobles désirant augmenter leur richesse que par les paysans désireux d’une bonne récolte.
    </p>
    <!-- Expert divinateur (Allégeance) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Expert divinateur</h2>
      <div class="h5">
        <TarBadge variant="secondary">Allégeance</TarBadge>
      </div>
    </div>
    <p>
      Le personnage réduit de moitié la <NuxtLink to="/regles/magie/pouvoirs/energie">dépense en points d’Énergie</NuxtLink> lorsqu’il
      <NuxtLink to="/regles/magie/pouvoirs/canalisation">canalise</NuxtLink> un <NuxtLink to="/regles/magie/pouvoirs">pouvoir</NuxtLink>
      associé au cercle de Divination.
    </p>
    <!-- Prophétie (Élévation) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Prophétie</h2>
      <div class="h5">
        <TarBadge variant="secondary">Élévation</TarBadge>
      </div>
    </div>
    <p>
      Le personnage peut désormais effectuer jusqu’à quatre <NuxtLink to="/regles/talents/initiation-magique">prédictions</NuxtLink> entre deux
      <NuxtLink to="/regles/aventure/repos/sommeil">nuits de sommeil</NuxtLink>.
    </p>
    <!-- Vision magique (Élévation) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Vision magique</h2>
      <div class="h5">
        <TarBadge variant="secondary">Élévation</TarBadge>
      </div>
    </div>
    <p>
      Le personnage se confère une des capacités suivantes par une <NuxtLink to="/regles/combat/deroulement/tour">action</NuxtLink>. Cette capacité prend fin
      s’il tombe <NuxtLink to="/regles/combat/conditions/incapable">incapable</NuxtLink>, s’il fait
      <NuxtLink to="/regles/aventure/repos/halte">halte</NuxtLink> ou s’il complète une
      <NuxtLink to="/regles/aventure/repos/sommeil">nuit de sommeil</NuxtLink>. Il doit faire halte ou compléter une nuit de sommeil afin de réutiliser cette
      capacité.
    </p>
    <ul>
      <li>Il acquiert une <NuxtLink to="/regles/aventure/environnement/vision">vision dans le noir</NuxtLink> à une distance de 18 mètres.</li>
      <li>Il peut voir dans la dimension spirituelle à une distance de 18 mètres.</li>
      <li>Il peut lire et comprendre toute <NuxtLink to="/regles/langues/scripts">langue écrite</NuxtLink>.</li>
      <li>
        Il peut discerner les créatures et objets <NuxtLink to="/regles/combat/conditions/invisible">invisibles</NuxtLink> situées à 3 mètres ou moins de sa
        position s’il n’y a pas d’obstacle physique tel un mur le séparant de ces créatures et objets.
      </li>
    </ul>
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
const title: string = "Cercle de Divination";

const category: string = SpellCategories.Divination;
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
  description: "Découvrez le cercle de Divination : des pouvoirs d’Astromancie pour comprendre le passé, le présent et l’avenir.",
});
</script>
