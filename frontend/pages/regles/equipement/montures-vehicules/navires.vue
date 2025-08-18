<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>Le nœud est l’unité de mesure de la vitesse des navires maritimes. Il correspond à un mille nautique par heure, soit 1 852 mètres.</p>
    <p>
      Pour un navire, les conditions idéales sont un plein vent dans les voiles et un fort courant dans la même direction que le navire. Ces conditions idéales
      permettent aux navires d’atteindre des vitesses largement supérieures à leur vitesse moyenne.
    </p>
    <ItemShipList :items="ships" />
    <h3 id="equipage" class="h5">Équipage</h3>
    <p>L’équipage d’un navire dépend de sa taille et de sa méthode de propulsion.</p>
    <ul>
      <li v-for="ship in ships" :key="ship.id">
        <strong>{{ ship.name }}.</strong> {{ ship.crew }}
      </li>
    </ul>
    <h3 id="maintenance" class="h5">Maintenance</h3>
    <p>
      La durée de vie d’un navire dépend grandement de son utilisation et de son entretien. Certains navires n’accompliront pas un seul voyage, alors que
      d’autres peuvent atteindre 50 à 100 ans. L’entretien du navire est primordial à sa longévité, ainsi qu’à la sécurité de la cargaison et des passagers. La
      durée de vie moyenne d’un navire est estimée à 15 ans.
    </p>
    <p>
      De manière générale, l’ensemble du navire devra être réparé ou remplacé pendant sa durée de vie. Le capitaine estime ses frais d’entretien en répartissant
      le prix de son navire dans cette durée.
    </p>
    <p>
      Pendant une année typique, un navire est stationné pendant la saison froide et ne naviguera que pendant la saison chaude, soit entre 6 et 7 mois par
      année. Cette durée peut varier en fonction du climat.
    </p>
    <p>La table ci-dessous répertorie le prix de maintenance en deniers d’un navire par unité de temps d’opération, en excluant la saison froide.</p>
    <ItemShipMaintenance :items="ships" />
    <p>
      <font-awesome-icon icon="fas fa-triangle-exclamation" /> Le navire de guerre a une surcharge de frais d’entretien à cause de son équipement militaire. Il
      a donc les mêmes frais d’entretien que la galère malgré son prix moins élevé.
    </p>
    <button class="btn btn-lg btn-primary position-fixed bottom-0 end-0 m-3 rounded-circle" @click="scrollToTop">
      <font-awesome-icon icon="fas fa-arrow-up" />
    </button>
  </main>
</template>

<script setup lang="ts">
import { arrayUtils } from "logitar-js";

import type { Breadcrumb } from "~/types/components";
import type { Ship } from "~/types/items";
import { getShips } from "~/services/items";

const parent: Breadcrumb[] = [
  { text: "Équipement", to: "/regles/equipement" },
  { text: "Montures et véhicules", to: "/regles/equipement/montures-vehicules" },
];
const title: string = "Navires";
const { orderBy } = arrayUtils;

const ships = ref<Ship[]>(orderBy(getShips(), "slug"));

useSeo({
  title,
  description: "🚧",
});
</script>
