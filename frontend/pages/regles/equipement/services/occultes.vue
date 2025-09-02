<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb active="Occultes" :parent="parent" />
    <p>
      Il peut être rare et complexe, toutefois possible, de trouver des services d’occultisme, c’est-à-dire un temple ou un emplacement canalisant certains
      <NuxtLink to="/regles/pouvoirs">pouvoirs</NuxtLink>.
    </p>
    <p>
      Ces services sont rares, ils sont donc onéreux, et ceux les prodiguant peuvent exiger des services en échange plutôt qu’une simple
      <NuxtLink to="/regles/equipement/monnaie">transaction monétaire</NuxtLink>.
    </p>
    <p>
      La formule suivante permet de déterminer le prix de services d’occultisme. Il peut être possible de fournir les ingrédients afin de réduire ce prix, mais
      le fournisseur de services peut refuser d’utiliser les ingrédients fournis par un client.
    </p>
    <p class="text-center">
      Prix = ((Niveau<sub>Pouvoir</sub> + Tiers<sub>Pouvoir</sub>)<sup>2</sup> × 10) + (Prix<sub>Matériaux</sub> × 1,5) + (Prix<sub>Focus</sub> ÷ 10)
    </p>
    <table class="table table-striped text-center">
      <thead>
        <tr>
          <th scope="col" class="w-20">Pouvoir</th>
          <th scope="col" class="w-10">Niveau</th>
          <th scope="col" class="w-10">Prix (deniers)</th>
          <th scope="col" class="w-60">Description</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="(service, index) in services" :key="index">
          <td>{{ service.power }}</td>
          <td>{{ $n(service.level, "integer") }}</td>
          <td>{{ $n(service.price, "price") }}</td>
          <td>{{ service.description }}</td>
        </tr>
      </tbody>
    </table>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Équipement", to: "/regles/equipement" },
  { text: "Services", to: "/regles/equipement/services" },
];
const title: string = "Services occultes";

type OccultService = {
  power: string;
  level: number;
  price: number;
  description: string;
};
const services = ref<OccultService[]>([
  {
    power: "Augure",
    level: 0,
    price: 0,
    description: "Recevoir un augure à propos d’un plan d’action.",
  },
  {
    power: "Communion",
    level: 3,
    price: 300,
    description: "Recevoir une réponse oui/non à une question de la part d’une entité.",
  },
  {
    power: "Guérison",
    level: 2,
    price: 100,
    description: "Permet de récupérer environ 20 points de Vitalité.",
  },
  {
    power: "Identification",
    level: 2,
    price: 100,
    description: "Identifier les capacités et dangers d’un artefact magique, qui peut s’y harmoniser et autres conditions d’utilisation générales.",
  },
  {
    power: "Préservation",
    level: 3,
    price: 100,
    description: "Protection contre l’agonie durant les 8 prochaines heures.",
  },
  {
    power: "Protection contre la magie",
    level: 3,
    price: 160,
    description: "Mettre fin à un pouvoir de niveau de puissance similaire.",
  },
  {
    power: "Restauration",
    level: 2,
    price: 100,
    description: "Mettre fin à une maladie, un poison ou une condition mineure.",
  },
  {
    power: "Restauration",
    level: 3,
    price: 200,
    description: "Mettre fin à une condition majeure ou une malédiction.",
  },
  {
    power: "Restauration",
    level: 4,
    price: 400,
    description: "Régénération complète de Vitalité et des membres perdus, fin des conditions mineures.",
  },
  {
    power: "Résurrection",
    level: 5,
    price: 1000,
    description: "Ressusciter une créature morte dans les 10 dernières minutes. Le corps de la créature doit posséder toutes ses fonctions vitales.",
  },
  {
    power: "Résurrection",
    level: 6,
    price: 1500,
    description:
      "Ressusciter une créature morte dans les 10 dernières journées, neutralisant poisons et maladies non magiques, fermant ses blessures mais ne restaurant pas ses membres manquants. Le corps de la créature doit posséder toutes ses fonctions vitales.",
  },
  {
    power: "Résurrection",
    level: 7,
    price: 2500,
    description:
      "Ressusciter une créature morte dans le dernier siècle, neutralisant poisons et maladies non magiques, fermant ses blessures, restaurant ses membres manquants et ses fonctions vitales.",
  },
]);

useSeo({
  title,
  description:
    "Découvrez les services occultes : augures, guérisons, protections et résurrections, rares et coûteux, proposés par temples et praticiens du mystique.",
});
</script>
