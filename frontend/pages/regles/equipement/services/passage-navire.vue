<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Le prix d’un passage de navire dépend de plusieurs facteurs : le <NuxtLink to="/regles/equipement/montures-vehicules">navire</NuxtLink> employé, le trajet
      et le nombre de passagers. Le capitaine suit les étapes suivantes afin de fournir le prix d’un passage de navire.
    </p>
    <ol>
      <li>
        Il calcule les frais d’opération de son navire. Il additionne la rémunération de l’équipage et les frais d’entretien quotidiens. Il ajoute une marge de
        profit entre 10 % et 50 % (en moyenne 30 %) variant en fonction des risques associés au trajet. Il obtient ainsi un nombre de deniers par jour.
      </li>
      <li>
        Il établit la distance du trajet en miles nautiques. On peut multiplier une distance en lieues par 2,6 afin de la convertir en miles nautiques (par
        exemple, 8 lieues équivalent à 20,8 miles nautiques). Il inclut le retour si les passagers effectuent un aller-retour, ou s’il ne peut rentabiliser son
        retour, par exemple s’il dépose ses passagers dans un port et qu’il revient sans passager ni cargaison.
      </li>
      <li>
        La plupart des navires sont équipés afin de voyager jour et nuit. La distance moyenne parcourue par un navire est donc égale à sa vitesse moyenne
        multipliée par les 24 heures dans une journée.
      </li>
      <li>
        Le capitaine divise la distance du trajet par la distance moyenne parcourue par son navire. Il arrondit généralement à la hausse et obtient la durée du
        trajet en jours.
      </li>
      <li>Il calcule le prix total du voyage en multipliant les frais d’opération quotidiens par la durée du trajet en jours.</li>
      <li>Il calcule le prix d’un passage en divisant ce prix total par le nombre de passagers.</li>
    </ol>
    <p>
      La table suivante répertorie la distance quotidienne moyenne parcourue par un navire, les frais d’opération quotidiens moyens du navire, le prix minimum
      d’un passage et le nombre maximal de passagers.
    </p>
    <table class="table table-striped text-center">
      <thead>
        <tr>
          <th scope="col" class="w-20">Navire</th>
          <th scope="col" class="w-20">Distance (miles nautique)</th>
          <th scope="col" class="w-20">Frais d’opération (deniers)</th>
          <th scope="col" class="w-20">Minimum (deniers)</th>
          <th scope="col" class="w-20">Passagers</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="ship in ships" :key="ship.id">
          <td>
            {{ ship.name }}
            <template v-if="ship.isHalfDay">(demi-journée)</template>
          </td>
          <td>{{ $n(ship.distance, "integer") }}</td>
          <td>{{ $n(ship.cost.operating, "price") }}</td>
          <td>{{ $n(ship.cost.minimum, "price") }}</td>
          <td>{{ $n(ship.passengers, "integer") }}</td>
        </tr>
      </tbody>
    </table>
  </main>
</template>

<script setup lang="ts">
import { arrayUtils } from "logitar-js";

import type { Breadcrumb } from "~/types/components";
import type { Ship } from "~/types/items";
import { getShips } from "~/services/items";

const parent: Breadcrumb[] = [
  { text: "Équipement", to: "/regles/equipement" },
  { text: "Services", to: "/regles/equipement/services" },
];
const title: string = "Passage en navire";
const { orderBy } = arrayUtils;

const ships = ref<Ship[]>(orderBy(getShips(), "slug"));

useSeo({
  title,
  description: "🚧",
});
</script>
