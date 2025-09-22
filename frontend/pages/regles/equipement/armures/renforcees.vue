<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb active="Renforcées" :parent="parent" />
    <p>Un personnage peut renforcer une armure afin d’augmenter ses points de <NuxtLink to="/regles/equipement/resistance">Résistance</NuxtLink>.</p>
    <p>Ce renforcement peut être effectué sur toute armure non magique ainsi que sur un <NuxtLink to="/regles/equipement/boucliers">bouclier</NuxtLink>.</p>
    <p>
      Le renforcement nécessite d’être formé avec les <NuxtLink to="/regles/equipement/outils">outils de forgeron</NuxtLink> (objet en métal) ou les
      <NuxtLink to="/regles/equipement/outils">outils de maroquinier</NuxtLink> (objet en cuir), de posséder ces outils et de pouvoir les utiliser.
    </p>
    <p>
      Le renforcement s’effectue en <NuxtLink to="/regles/aventure/temps">une heure</NuxtLink>, et peut être effectué pendant une
      <NuxtLink to="/regles/aventure/repos/halte">halte</NuxtLink>.
    </p>
    <p>Les renforts ne sont pas cumulables. Si un objet déjà renforcé est renforcé à nouveau, le renfort le plus élevé prédomine.</p>
    <p>
      Ces renforts sont permanents : ils peuvent donc être <NuxtLink to="/regles/equipement/reparation">réparés</NuxtLink>. Ils peuvent également être retirés
      afin d’en récupérer les matériaux.
    </p>
    <p>
      Il est possible de renforcer une <NuxtLink to="/regles/equipement/armures/partielles">pièce d’armure</NuxtLink>. Cette action nécessite seulement 10
      minutes et ⅙ ({{ $n(1 / 6, "percentage") }}) des matériaux, mais le renfort n’augmente que de ⅙ ({{ $n(1 / 6, "percentage") }}) les points de Résistance
      de l’armure complète.
    </p>
    <p>
      Le coût en matériaux pour renforcer un objet est égal à son prix divisé par ses points de Résistance, multiplié par le niveau de renforcement. Par
      exemple, il coûtera 20 deniers pour renforcer au niveau 2 une armure coûtant 50 deniers et possédant 5 points de Résistance.
    </p>
    <p>Il coûtera généralement le double du prix pour faire renforcer un objet auprès d’un artisan afin de payer son temps de travail et son expertise.</p>
    <p>
      Il existe plusieurs niveaux de renforcement. L’artisan sélectionne un niveau lorsqu’il renforce un équipement. Voici les niveaux de renforcement et le
      <NuxtLink to="/regles/talents">talent</NuxtLink> requis afin de pouvoir renforcer à ce niveau.
    </p>
    <table class="table table-striped text-center">
      <thead>
        <tr>
          <th scope="col" class="w-50">Niveau</th>
          <th scope="col" class="w-50">Talent requis</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="level in levels" :key="level.level">
          <td>+{{ $n(level.level, "integer") }}</td>
          <td>
            <NuxtLink v-if="level.talent" :to="`/regles/talents/${level.talent.slug}`">{{ level.talent.name }}</NuxtLink>
          </td>
        </tr>
      </tbody>
    </table>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";
import type { SearchResults, Talent } from "~/types/game";

const config = useRuntimeConfig();
const parent: Breadcrumb[] = [
  { text: "Équipement", to: "/regles/equipement" },
  { text: "Armures", to: "/regles/equipement/armures" },
];
const title: string = "Armures renforcées";

const query: string = ["artisan-virtuose", "expertise-artisanale", "maitre-artisan"].map((slug) => `slug=${slug}`).join("&");
const { data } = await useAsyncData<SearchResults<Talent>>("talents", () =>
  $fetch(`/api/talents?${query}`, {
    baseURL: config.public.apiBaseUrl,
  }),
);

const talents = computed<Map<string, Talent>>(() => new Map((data.value?.items ?? []).map((talent) => [talent.slug, talent])));

type Level = {
  level: number;
  talent?: Talent;
};
const levels = ref<Level[]>([
  {
    level: 1,
    talent: talents.value.get("expertise-artisanale"),
  },
  {
    level: 2,
    talent: talents.value.get("maitre-artisan"),
  },
  {
    level: 3,
    talent: talents.value.get("artisan-virtuose"),
  },
]);

useSeo({
  title,
  description: "Découvrez comment renforcer vos armures et boucliers pour accroître leur Résistance, avec coûts, talents requis et niveaux de renforcement.",
});
</script>
