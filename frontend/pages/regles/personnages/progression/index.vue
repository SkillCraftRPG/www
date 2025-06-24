<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb active="Progression" :parent="parent" />
    <p>
      Au fil de ses aventures, un personnage suit une progression croissante qui lui permet d’améliorer ses capacités existantes ou d’en obtenir des nouvelles.
    </p>
    <p>Le système SkillCraft utilise <strong>3 mesures</strong> de progression :</p>
    <div class="row">
      <div v-for="(item, index) in items" :key="index" class="col-xs-12 col-sm-6 col-md-4 mb-4">
        <AppCard class="d-flex flex-column h-100" clickable :text="item.description" :title="item.title" @click="navigate(item.path)" />
      </div>
    </div>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const router = useRouter();
const title: string = "Progression de personnage";

type MenuItem = {
  path: string;
  title: string;
  description: string;
};
const items: MenuItem[] = [
  {
    path: "/regles/personnages/progression/experience",
    title: "Expérience",
    description: "La mesure la plus spécifique, elle est acquise lorsque certains objectifs sont atteints.",
  },
  {
    path: "/regles/personnages/progression/niveau",
    title: "Niveau",
    description:
      "Une mesure plus générale, le niveau augmente lorsque l'expérience atteint un certain seuil. En montant de niveau, le personnage peut améliorer ses capacités ou en acquérir de nouvelles.",
  },
  {
    path: "/regles/personnages/progression/tiers",
    title: "Tiers",
    description: "La mesure la plus globale, elle augmente lorsque le personnage se spécialise. Le tiers limite la puissante maximale de ses capacités.",
  },
];

const parent = computed<Breadcrumb[]>(() => [{ text: "Personnages", to: "/regles/personnages" }]);

function navigate(to: string): void {
  router.push(to);
}

useSeoMeta({
  title,
  description:
    "Découvrez la progression des personnages, guidée par l’expérience, le niveau et le tiers, qui permettent d’améliorer et d’acquérir des capacités.",
});
useLinks();
</script>
