<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <RulesBreadcrumb :active="title" :parent="parent" />
    <p>
      Les serments sacrés lient les guerriers de la foi à un ensemble de préceptes qui guident leurs actions et leurs convictions. Chaque serment incarne des
      idéaux particuliers et confère des capacités divines propres à ceux qui s’y consacrent. Si le personnage contrevient gravement ou de manière répétée aux
      préceptes de son serment, par exemple en poursuivant de sombres ambitions ou en servant une puissance maléfique, le joueur ou le maître de jeu peut
      décider de remplacer les capacités de son serment par celles du <NuxtLink to="/regles/domaines/serments/briseur">Briseur de serment</NuxtLink>, jusqu’à ce
      qu’il se repente et renoue avec ses engagements.
    </p>
    <h2 class="h3">Serments de l’Inquisiteur</h2>
    <p>
      Lorsque le personnage acquiert la spécialisation <NuxtLink to="/regles/specialisations/inquisiteur">Inquisiteur</NuxtLink>, il doit prêter un serment
      sacré à un ensemble de préceptes. Il choisit l’une des options ci-dessous et acquiert les capacités spécifiques à cette option.
    </p>
    <div class="row">
      <div v-for="(item, index) in inquisiteur" :key="index" class="col-xs-12 col-sm-6 col-md-4 mb-4">
        <LinkCard class="d-flex flex-column h-100" :text="item.description" :title="item.title" :to="item.path" />
      </div>
    </div>
    <h2 class="h3">Serments du Paladin</h2>
    <p>
      Lorsque le personnage acquiert la spécialisation <NuxtLink to="/regles/specialisations/paladin">Paladin</NuxtLink>, il doit prêter un serment sacré à un
      ensemble de préceptes. Il choisit l’une des options ci-dessous et acquiert les capacités spécifiques à cette option.
    </p>
    <div class="row">
      <div v-for="(item, index) in paladin" :key="index" class="col-xs-12 col-sm-6 col-md-4 mb-4">
        <LinkCard class="d-flex flex-column h-100" :text="item.description" :title="item.title" :to="item.path" />
      </div>
    </div>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/tar/breadcrumb";

const parent: Breadcrumb[] = [{ text: "Annexes", to: "/regles/annexes" }];
const title: string = "Serments sacrés";

type MenuItem = {
  path: string;
  title: string;
  description: string;
};
const inquisiteur: MenuItem[] = [
  {
    path: "/regles/domaines/serments/conquete",
    title: "Conquête",
    description: "Imposez votre domination par la force, la terreur et les châtiments divins.",
  },
  {
    path: "/regles/domaines/serments/sentinelle",
    title: "Sentinelle",
    description: "Protégez et veillez sur les royaumes mortels des menaces extra-dimensionnelles.",
  },
  {
    path: "/regles/domaines/serments/vengeance",
    title: "Vengeance",
    description: "Traquez vos ennemis jurés et châtiez-les par tous les moyens nécessaires.",
  },
];
const paladin: MenuItem[] = [
  {
    path: "/regles/domaines/serments/couronne",
    title: "Couronne",
    description: "Défendez la loi et la couronne, protégez vos alliés et résistez aux menaces.",
  },
  {
    path: "/regles/domaines/serments/devotion",
    title: "Dévotion",
    description: "Défendez la justice et l’honneur par la foi, la protection et le combat sacré.",
  },
  {
    path: "/regles/domaines/serments/redemption",
    title: "Rédemption",
    description: "Privilégiez la paix et la rédemption, soignez et châtiez les agresseurs.",
  },
];

useSeo({
  title,
  description:
    "Découvrez les serments sacrés de SkillCraft, leurs préceptes et pouvoirs divins pour les Paladins et Inquisiteurs, de la protection à la conquête.",
});
</script>
