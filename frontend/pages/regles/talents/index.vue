<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" />
    <p>
      Une des facettes de la <NuxtLink to="/regles/personnages/progression">progression</NuxtLink> de personnage se matérialise par des talents, des capacités
      acquises au fil de ses aventures. Deux personnages suivant un parcours similaire peuvent totalement différer dans leurs choix de talents, ce qui permet au
      joueur de personnaliser son personnage en fonction de ses préférences.
    </p>
    <h2 class="h3">Points de talent</h2>
    <p>
      Dès sa <NuxtLink to="/regles/personnages/creation">création</NuxtLink>, un personnage reçoit 12 points de talent. Il obtient également 1 point à chaque
      fois qu’il progresse à un <NuxtLink to="/regles/personnages/progression/niveau">niveau</NuxtLink> supérieur. Il peut dépenser ces points afin d’acquérir
      de nouveaux talents. Le coût en points d’un talent dépend de son tiers.
    </p>
    <table class="table table-striped text-center">
      <thead>
        <tr>
          <th scope="col" class="w-50">Tiers du talent</th>
          <th scope="col" class="w-50">Coût en points</th>
        </tr>
      </thead>
      <tbody>
        <tr>
          <td>0</td>
          <td>2</td>
        </tr>
        <tr>
          <td>1</td>
          <td>3</td>
        </tr>
        <tr>
          <td>2</td>
          <td>4</td>
        </tr>
        <tr>
          <td>3</td>
          <td>5</td>
        </tr>
      </tbody>
    </table>
    <h3 class="h5">Rabais</h3>
    <p>
      Lorsqu’un personnage bénéficie d’un rabais sur un talent, alors il pourra acquérir ce talent en dépensant 1 point de talent de moins que le nombre qui lui
      serait normalement nécessaire. Il peut bénéficier de plusieurs rabais sur un même talent, ce qui peut lui permettre d’acquérir un talent à très faible
      coût ou gratuitement.
    </p>
    <h2 class="h3">Conditions d’acquisition</h2>
    <p>Afin d’acquérir un talent, un personnage doit satisfaire les conditions suivantes.</p>
    <ul>
      <li>Son <NuxtLink to="/regles/personnages/progression/tiers">tiers</NuxtLink> de personnage doit être supérieur ou égal au tiers du talent.</li>
      <li>Si le talent requiert un autre talent, alors le personnage doit préalablement avoir acquis le talent requis.</li>
      <li>Il doit dépenser les points de talent nécessaires.</li>
      <li>Le personnage doit satisfaire toute condition additionnelle spécifiée par le talent.</li>
    </ul>
    <h2 class="h3">Achats multiples</h2>
    <p>
      Sauf indication contraire, un talent ne peut être acquis qu’une seule fois. Seuls les talents portant la mention
      <i>Achats multiples</i> peuvent être acquis plusieurs fois. Chaque acquisition doit satisfaire les conditions indiquées ci-dessus.
    </p>
    <p>S’il possède un ou plusieurs rabais sur ce talent, alors chaque acquisition bénéficie du rabais.</p>
    <template v-if="talents.length">
      <h2 class="h3">Liste des talents</h2>
      <TalentList :items="talents" />
    </template>
  </main>
</template>

<script setup lang="ts">
import type { SearchResults, Talent } from "~/types/game";

const config = useRuntimeConfig();
const title: string = "Talents";

const { data } = await useFetch("/api/talents", {
  baseURL: config.public.apiBaseUrl,
  cache: "no-cache",
  server: false,
});
const talents = computed<Talent[]>(() => (data.value as SearchResults<Talent>)?.items ?? []);

useSeo({
  title,
  description: "Découvrez les talents : des capacités uniques qui enrichissent les personnages et façonnent leur style de jeu.",
});
</script>
