<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb active="Points" :parent="parent" />
    <p>Dès sa <NuxtLink to="/regles/personnages/creation">création</NuxtLink>, un personnage reçoit 12 points de talent.</p>
    <p>Il obtient également 1 point à chaque fois qu’il progresse à un <NuxtLink to="/regles/personnages/progression/niveau">niveau</NuxtLink> supérieur.</p>
    <p>Il peut dépenser ces points afin d’<NuxtLink to="/regles/talents/acquisition">acquérir</NuxtLink> de nouveaux talents.</p>
    <p>Le coût en points d’un talent varie en fonction de son tiers.</p>
    <TalentCostTable />
    <h2 class="h3">Rabais</h2>
    <p>
      Lorsqu’un personnage bénéficie d’un rabais sur un talent, alors il pourra acquérir ce talent en dépensant 1 point de talent de moins que le nombre qui lui
      serait normalement nécessaire.
    </p>
    <p>Il peut bénéficier de plusieurs rabais sur un même talent, ce qui peut lui permettre d’acquérir un talent à très faible coût ou gratuitement.</p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [{ text: "Talents", to: "/regles/talents" }];
const title: string = "Points de talents";

useSeo({
  title,
  description:
    "Découvrez le fonctionnement des points de talents : acquisition, coûts selon les tiers, progression et rabais permettant d’obtenir des talents à moindre prix.",
});
</script>
