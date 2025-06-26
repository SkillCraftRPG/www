<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Le niveau le plus spécifique de progression est sans doute l’Expérience. Lorsqu’un personnage débute son aventure, il ne possède aucun point d’expérience.
      Il progresse en atteignant certains objectifs, et le maître de jeu lui octroie des points d’expérience. Lorsqu’un certain seuil est acquis, le
      <NuxtLink to="/regles/personnages/progression/niveau">niveau</NuxtLink> du personnage augmente.
    </p>
    <h2 class="h3">Gain d’Expérience</h2>
    <p>
      Il existe plusieurs méthodes de gagner des points d’expérience. C’est le maître de jeu, le narrateur de l’histoire, qui choisit sa méthode, et qui octroie
      les points d’expérience lorsqu’il sent que les personnages ont progressé dans leur aventure.
    </p>
    <ul>
      <li v-for="(method, index) in methods" :key="index">
        <strong>{{ method.name }}.</strong> {{ method.description }}
      </li>
    </ul>
    <h2 class="h3">Niveau et Expérience</h2>
    <p>
      La table ci-dessous présente le seuil d’expérience requise afin de progresser à un niveau supérieur, ainsi que l’expérience totale pour chaque niveau.
    </p>
    <table class="table table-striped">
      <thead>
        <tr>
          <th scope="col">Niveau</th>
          <th scope="col">Expérience requise</th>
          <th scope="col">Expérience totale</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="(total, index) in threshold" :key="index">
          <td>{{ index }}</td>
          <td>
            <template v-if="index">{{ total - threshold[index - 1] }}</template>
            <span v-else class="text-muted">{{ "—" }}</span>
          </td>
          <td>{{ total }}</td>
        </tr>
      </tbody>
    </table>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

type Method = {
  name: string;
  description: string;
};
const methods: Method[] = [
  {
    name: "Combat",
    description:
      "Les personnages acquièrent des points d’expérience en sortant victorieux de batailles. Le maître de jeu octroie des points d’expérience en fonction de la difficulté du combat et de la manière dont les personnages ont agi.",
  },
  {
    name: "Développement de personnage",
    description:
      "Lorsque les personnages progressent ou complètent leurs objectifs personnels, le maître de jeu leur octroie des points d’expérience. Cela permet d’encourager les arcs narratifs individuels et les interactions entre les personnages.",
  },
  {
    name: "Diplomatie et réussites sociales",
    description:
      "Dans des campagnes axées sur l’intrigue ou la politique, les personnages peuvent gagner de l’Expérience par la négociation, l’intimidation, la ruse ou d’autres interactions sociales importantes.",
  },
  {
    name: "Exploration",
    description:
      "Le maître de jeu octroie de l’Expérience lorsque les personnages découvrent de nouveaux lieux, résolvent des énigmes, surmontent des obstacles, cartographient des zones dangereuses ou complètent des zones inexplorées.",
  },
  {
    name: "Jalons",
    description:
      "Des points d’expérience peuvent être octroyés lorsque les personnages complètent des objectifs majeurs en coopérant. Cette méthode encourage le jeu d’équipe plutôt que les exploits individuels.",
  },
  {
    name: "Temps",
    description:
      "Le maître de jeu peut décider de simplement octroyer des points d’expérience lorsque le temps en jeu avance. Il peut également se baser sur le temps réel écoulé pendant ou entre les sessions de jeu.",
  },
];

const threshold: number[] = [
  0, 100, 400, 1100, 2400, 4500, 7600, 11900, 17600, 24900, 34000, 45100, 58400, 74100, 92400, 113500, 137600, 164900, 195600, 229900, 268000,
];
const title: string = "Expérience";

const parent = computed<Breadcrumb[]>(() => [
  { text: "Personnages", to: "/regles/personnages" },
  { text: "Progression", to: "/regles/personnages/progression" },
]);

useSeo({
  title,
  description: "Découvrez les différentes façons de gagner de l’Expérience dans SkillCraft et d’améliorer votre personnage au fil de ses aventures.",
});
</script>
