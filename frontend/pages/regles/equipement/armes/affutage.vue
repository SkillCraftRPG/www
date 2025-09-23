<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>Un personnage peut affûter une arme afin de lui conférer un bonus temporaire de points de <NuxtLink to="/regles/combat/degats/jet">dégâts</NuxtLink>.</p>
    <p>
      Cet affûtage peut être effectué sur une arme non magique simple ou martiale, tant qu’elle n’est pas
      <NuxtLink to="/regles/equipement/armes/improvisees">improvisée</NuxtLink> ni brisée.
    </p>
    <p>
      L’affûtage nécessite d’être formé avec les <NuxtLink to="/regles/equipement/outils">outils de forgeron</NuxtLink> (arme en métal) ou les
      <NuxtLink to="/regles/equipement/outils">outils de sculpteur sur bois</NuxtLink> (arme en bois), de posséder ces outils et de pouvoir les utiliser.
    </p>
    <p>
      L’affûtage s’effectue en <NuxtLink to="/regles/aventure/temps">une heure</NuxtLink>, et peut être effectué pendant une
      <NuxtLink to="/regles/aventure/repos/halte">halte</NuxtLink>.
    </p>
    <p>Les affûtages ne sont pas cumulables. Si une arme déjà affûtée est affûtée à nouveau, l’affûtage le plus élevé prédomine.</p>
    <p>
      Lorsqu’une arme affûtée percute une surface solide, par exemple un mur, un <NuxtLink to="/regles/equipement/boucliers">bouclier</NuxtLink>, une
      <NuxtLink to="/regles/equipement/armures">armure</NuxtLink> ou une autre arme, si le résultat du
      <NuxtLink to="/regles/competences/tests">test</NuxtLink> est obtenu avec <NuxtLink to="/regles/competences/tests/2d10">Damnation</NuxtLink>, le niveau
      d’affûtage de l’arme réduit de un, jusqu’à atteindre 0.
    </p>
    <p>
      Il existe plusieurs niveaux d’affûtage. L’artisan sélectionne un niveau lorsqu’il affûte une arme. Voici les niveaux d’affûtage, le prix d’un affûtage
      auprès d’un professionnel, ainsi que le <NuxtLink to="/regles/talents">talent</NuxtLink> requis afin de pouvoir effectuer l’affûtage à ce niveau.
    </p>
    <table class="table table-striped text-center">
      <thead>
        <tr>
          <th scope="col" class="w-third">Niveau</th>
          <th scope="col" class="w-third">Prix (deniers)</th>
          <th scope="col" class="w-third">Talent requis</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="level in levels" :key="level.level">
          <td>+{{ $n(level.level, "integer") }}</td>
          <td>{{ $n(level.price, "price") }}</td>
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
  { text: "Armes", to: "/regles/equipement/armes" },
];
const title: string = "Affûtage";

const query: string = ["artisan-virtuose", "expertise-artisanale", "maitre-artisan"].map((slug) => `slug=${slug}`).join("&");
const { data } = await useAsyncData<SearchResults<Talent>>("talents", () =>
  $fetch(`/api/talents?${query}`, {
    baseURL: config.public.apiBaseUrl,
  }),
);
const talents = computed<Map<string, Talent>>(() => new Map((data.value?.items ?? []).map((talent) => [talent.slug, talent])));

type Level = {
  level: number;
  price: number;
  talent?: Talent;
};
const levels = ref<Level[]>([
  {
    level: 1,
    price: 5,
    talent: talents.value.get("expertise-artisanale"),
  },
  {
    level: 2,
    price: 15,
    talent: talents.value.get("maitre-artisan"),
  },
  {
    level: 3,
    price: 50,
    talent: talents.value.get("artisan-virtuose"),
  },
]);

useSeo({
  title,
  description:
    "Découvrez comment affûter vos armes pour obtenir un bonus temporaire de dégâts, selon vos talents et outils, avec règles claires et simples à appliquer.",
});
</script>
