<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>🚧</p>
    <h2 class="h3">Table des matières</h2>
    <ul>
      <li>
        <a href="#betes">Bêtes</a>
        <ul>
          <li>
            <a href="#accessoires">Accessoires</a>
          </li>
        </ul>
      </li>
      <li>
        <a href="#vehicules">Véhicules</a>
      </li>
      <li>
        <a href="#navires">Navires</a>
        <ul>
          <li>
            <a href="#equipage">Équipage</a>
          </li>
          <li>
            <a href="#maintenance">Maintenance</a>
          </li>
        </ul>
      </li>
    </ul>
    <h2 id="betes" class="h3">Bêtes</h2>
    <p>
      Les bêtes sont dotées d’une <NuxtLink to="/regles/statistiques/charge">Charge</NuxtLink>, comme toute créature. Elles sont assujetties aux mêmes règles
      d’<NuxtLink to="/regles/equipement/encombrement">encombrement</NuxtLink> que toute autre créature.
    </p>
    <ItemMountList :items="mounts" />
    <h3 id="accessoires" class="h5">Accessoires</h3>
    <p>🚧</p>
    <ItemMountAccessoryList :items="mountAccessories" />
    <h2 id="vehicules" class="h3">Véhicules</h2>
    <p>🚧</p>
    <ItemList :items="vehicles" />
    <h2 id="navires" class="h3">Navires</h2>
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
import type { Item, Mount, MountAccessory, Ship } from "~/types/items";
import { getMountAccessories, getMounts, getShips, getVehicles } from "~/services/items";

const parent: Breadcrumb[] = [{ text: "Équipement", to: "/regles/equipement" }];
const title: string = "Montures et véhicules";
const { orderBy } = arrayUtils;

const mountAccessories = ref<MountAccessory[]>(orderBy(getMountAccessories(), "slug"));
const mounts = ref<Mount[]>(orderBy(getMounts(), "slug"));
const ships = ref<Ship[]>(orderBy(getShips(), "slug"));
const vehicles = ref<Item[]>(orderBy(getVehicles(), "slug"));

function scrollToTop(): void {
  window.history.replaceState(window.history.state, "", window.location.pathname + window.location.search);
  window.scrollTo({ top: 0, left: 0, behavior: "smooth" });
}

useSeo({
  title,
  description: "🚧",
});
</script>
