<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <RulesBreadcrumb active="Envoûtement" :parent="parent" />
    <p>
      Ce cercle rassemble les pouvoirs dont la fonction est de tromper, de séduire ou de contrôler la pensée. Leur usage en géopolitique peut être dévastateur,
      mais il peut également éviter des désastres.
    </p>
    <!-- Charme instinctif (Allégeance) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Charme instinctif</h2>
      <div class="h5">
        <TarBadge variant="secondary">Allégeance</TarBadge>
      </div>
    </div>
    <p>
      Lorsque le personnage <NuxtLink to="/regles/aventure/environnement/vision">voit</NuxtLink> une créature située à 9 mètres ou moins de sa position tenter
      de l’<NuxtLink to="/regles/combat/attaque">attaquer</NuxtLink>, il peut tenter de rediriger l’attaque contre une autre créature située dans la portée de
      l’attaque, avant de savoir si l’attaque <NuxtLink to="/regles/competences/tests/2d10">réussit ou échoue</NuxtLink>. En
      <NuxtLink to="/regles/combat/deroulement/tour">réaction</NuxtLink>, il effectue un <NuxtLink to="/regles/competences/tests">test</NuxtLink> d’<NuxtLink
        to="/regles/competences/occultisme"
        >Occultisme</NuxtLink
      >, et l’attaquant doit effectuer un <NuxtLink to="/regles/competences/tests/sauvegarde">jet de sauvegarde</NuxtLink> de
      <NuxtLink to="/regles/competences/discipline">Discipline</NuxtLink> de <NuxtLink to="/regles/competences/tests/difficulte">difficulté</NuxtLink> égale au
      résultat du test. En cas d’échec, l’attaque est redirigée contre une autre créature, au choix de l’attaquant. En cas de réussite, l’attaquant est immunisé
      à cette capacité pendant les <NuxtLink to="/regles/aventure/temps">24 prochaines heures</NuxtLink>. Les créatures immunisées aux
      <NuxtLink to="/regles/combat/conditions/charme">charmes</NuxtLink> ne sont pas affectées par cette capacité.
    </p>
    <!-- Envoûtement partagé (Élévation) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Envoûtement partagé</h2>
      <div class="h5">
        <TarBadge variant="secondary">Élévation</TarBadge>
      </div>
    </div>
    <p>
      Lorsque le personnage <NuxtLink to="/regles/magie/pouvoirs/canalisation">canalise</NuxtLink> un
      <NuxtLink to="/regles/magie/pouvoirs">pouvoir</NuxtLink> associé au cercle d’Envoûtement ne ciblant qu’une seule créature, il peut cibler une seconde
      créature différente. Il réutilise le résultat du <NuxtLink to="/regles/competences/tests">test</NuxtLink> d’<NuxtLink to="/regles/competences/occultisme"
        >Occultisme</NuxtLink
      >
      ainsi que le <NuxtLink to="/regles/combat/degats/jet">jet de dégâts</NuxtLink>.
    </p>
    <!-- Trou de mémoire (Élévation) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Trou de mémoire</h2>
      <div class="h5">
        <TarBadge variant="secondary">Élévation</TarBadge>
      </div>
    </div>
    <p>
      Lorsque le personnage <NuxtLink to="/regles/magie/pouvoirs/canalisation">canalise</NuxtLink> un
      <NuxtLink to="/regles/magie/pouvoirs">pouvoir</NuxtLink> associé au cercle d’Envoûtement ciblant une ou plusieurs créatures, il peut altérer le pouvoir
      afin que les créatures ne sachent pas qu’elles ont été <NuxtLink to="/regles/combat/conditions/charme">charmées</NuxtLink>.
    </p>
    <p>
      Également, avant qu’un pouvoir associé au cercle d’Envoûtement ne prenne fin, il peut tenter de faire oublier à une cible un certain
      <NuxtLink to="/regles/aventure/temps">temps</NuxtLink> pendant lequel elle a été charmée, s’il a préalablement altéré le pouvoir tel que décrit
      précédemment. Par une <NuxtLink to="/regles/combat/deroulement/tour">action</NuxtLink>, il effectue un
      <NuxtLink to="/regles/competences/tests">test</NuxtLink> d’<NuxtLink to="/regles/competences/occultisme">Occultisme</NuxtLink>, et la cible doit effectuer
      un <NuxtLink to="/regles/competences/tests/sauvegarde">jet de sauvegarde</NuxtLink> d’<NuxtLink to="/regles/competences/investigation"
        >Investigation</NuxtLink
      >
      de <NuxtLink to="/regles/competences/tests/difficulte">difficulté</NuxtLink> égale au résultat du test. En cas d’échec, la cible perd la mémoire d’un
      nombre d’heures égal à la moitié de la <NuxtLink to="/regles/statistiques/puissance">Puissance</NuxtLink> du personnage (minimum&nbsp;1). Il peut lui
      faire oublier un temps moindre, et la période de temps de l’oubli ne peut excéder la <NuxtLink to="/regles/magie/parametres/duree">durée</NuxtLink> du
      pouvoir.
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
const title: string = "Cercle d’Envoûtement";

const category: string = SpellCategories.Enchantment;
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
  description: "Découvrez le cercle d’Envoûtement : des pouvoirs d’Astromancie pour tromper, séduire et contrôler les pensées.",
});
</script>
