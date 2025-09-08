<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Le nombre de points d’<NuxtLink to="/regles/statistiques/energie">Énergie</NuxtLink> dépensés par la
      <NuxtLink to="/regles/magie/pouvoirs/canalisation">canalisation</NuxtLink> d’un pouvoir dépend du tiers de celui-ci ainsi que du
      <NuxtLink to="/regles/magie/pouvoirs/niveau">niveau</NuxtLink> canalisé.
    </p>
    <p>Ce nombre est obtenu en multipliant la base par le niveau canalisé. La base est déterminée par le tiers du pouvoir.</p>
    <p>
      Une créature peut dépenser un nombre de points d’Énergie supérieur à son nombre restant. Lorsqu’elle en fait ainsi, le pouvoir est canalisé, mais les
      points d’Énergie de la créature chutent à 0 et elle tombe <strong>inconsciente</strong>.
    </p>
    <p>Les <NuxtLink to="/regles/talents">talents</NuxtLink> suivants permettent de réduire cette dépense d’Énergie :</p>
    <div class="row">
      <div v-for="talent in talents" :key="talent.id" class="col-xs-12 col-sm-6 mb-4">
        <TalentCard class="d-flex flex-column h-100" :talent="talent" />
      </div>
    </div>
    <table class="table table-striped text-center">
      <thead>
        <tr>
          <th scope="col" class="w-25">Tiers</th>
          <th scope="col" class="w-25">Base</th>
          <th scope="col" class="w-25">Niveau</th>
          <th scope="col" class="w-25">Dépense d’Énergie</th>
        </tr>
      </thead>
      <tbody>
        <tr>
          <td>0</td>
          <td>4</td>
          <td>1</td>
          <td>4</td>
        </tr>
        <tr>
          <td>0</td>
          <td>4</td>
          <td>2</td>
          <td>8</td>
        </tr>
        <tr>
          <td>0</td>
          <td>4</td>
          <td>3</td>
          <td>12</td>
        </tr>
        <tr>
          <td>1</td>
          <td>6</td>
          <td>2</td>
          <td>12</td>
        </tr>
        <tr>
          <td>1</td>
          <td>6</td>
          <td>3</td>
          <td>18</td>
        </tr>
        <tr>
          <td>1</td>
          <td>6</td>
          <td>4</td>
          <td>24</td>
        </tr>
        <tr>
          <td>2</td>
          <td>8</td>
          <td>3</td>
          <td>24</td>
        </tr>
        <tr>
          <td>2</td>
          <td>8</td>
          <td>4</td>
          <td>32</td>
        </tr>
        <tr>
          <td>2</td>
          <td>8</td>
          <td>5</td>
          <td>40</td>
        </tr>
        <tr>
          <td>3</td>
          <td>10</td>
          <td>5</td>
          <td>50</td>
        </tr>
        <tr>
          <td>3</td>
          <td>10</td>
          <td>6</td>
          <td>60</td>
        </tr>
        <tr>
          <td>3</td>
          <td>10</td>
          <td>7</td>
          <td>70</td>
        </tr>
      </tbody>
    </table>
  </main>
</template>

<script setup lang="ts">
import { arrayUtils } from "logitar-js";

import type { Breadcrumb } from "~/types/components";
import type { Talent } from "~/types/game";
import { getTalents } from "~/services/talents";

const parent: Breadcrumb[] = [
  { text: "Magie", to: "/regles/magie" },
  { text: "Pouvoirs", to: "/regles/magie/pouvoirs" },
];
const slugs: Set<string> = new Set(["maximisation-magique", "optimisation-magique"]);
const title: string = "Dépense d’Énergie";
const { orderBy } = arrayUtils;

const allTalents = ref<Talent[]>(getTalents());

const talents = computed<Talent[]>(() =>
  orderBy(
    allTalents.value.filter(({ slug }) => slugs.has(slug)).map((talent) => ({ ...talent, sort: [talent.tier, talent.slug].join("_") })),
    "sort",
  ),
);

useSeo({
  title,
  description: "Découvrez comment la dépense d’Énergie pour canaliser un pouvoir varie selon son tiers et son niveau, avec options de réduction.",
});
</script>
