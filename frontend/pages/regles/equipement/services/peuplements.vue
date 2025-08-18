<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>En Ouespéro, il existe quatre types de peuplements. Ils sont détaillés ci-dessous.</p>
    <p>
      La majorité des royaumes sont composés d’une poignée de cité, dont la capitale, de quelques centres urbains (villes), et d’une multitude de villages
      dispersés autour des centres urbains. Les villes et cités sont généralement reliées par des routes pavées, dégagées et sécurisées à une certaine mesure.
      Les villages sont reliés aux villes par des sentiers de terre battus souvent accidentés et dangereux.
    </p>
    <p>
      Il existe des routes commerciales entre les centres urbains de royaumes voisins, ces routes sont également entretenues afin de faciliter le transport de
      marchandises par des véhicules terrestres.
    </p>
    <ul>
      <li v-for="(settlement, index) in settlements" :key="index">
        <strong>{{ settlement.name }}.</strong> {{ settlement.description }}
      </li>
    </ul>
    <h2 class="h3">Artisans et marchands</h2>
    <p>La table ci-dessous indique le nombre d’artisans et de marchands d’une spécialité par nombre d’habitants.</p>
    <p>
      En divisant la population d’un peuplement par ce nombre d’habitants, on obtient le nombre d’établissements de cette spécialité dans le peuplement. Lorsque
      la population d’un peuplement est inférieure au nombre d’habitants pour une spécialité, le peuplement n’a généralement aucun établissement offrant cette
      spécialité.
    </p>
    <div class="row">
      <div v-for="(list, index) in specialties" :key="index" class="col">
        <table class="table table-striped text-center">
          <thead>
            <tr>
              <th scope="col" class="w-50">Spécialité</th>
              <th scope="col" class="w-50">Habitants</th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="(specialty, index) in list" :key="index">
              <td>{{ specialty.name }}</td>
              <td>{{ $n(specialty.quantity, "integer") }}</td>
            </tr>
          </tbody>
        </table>
      </div>
    </div>
    <p>
      <font-awesome-icon icon="fas fa-triangle-exclamation" /> Toute ville portuaire comprend au moins un shipchandler, même si sa population est inférieure au
      nombre d’habitants.
    </p>
    <button class="btn btn-lg btn-primary position-fixed bottom-0 end-0 m-3 rounded-circle" @click="scrollToTop">
      <font-awesome-icon icon="fas fa-arrow-up" />
    </button>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Équipement", to: "/regles/equipement" },
  { text: "Services", to: "/regles/equipement/services" },
];
const title: string = "Peuplements";

type Settlement = {
  name: string;
  description: string;
};
const settlements = ref<Settlement[]>([
  {
    name: "Village",
    description:
      "Il compte entre 1 et 1 000 habitants, avec une médiane se situant entre 50 et 300. Un village est une communauté agraire se rattachant à un centre rbain plus gros. Il contient les services de base pour satisfaire les besoins des paysans locaux.",
  },
  {
    name: "Ville",
    description:
      "Elle compte entre 1 000 et 8 000 habitants, avec une médiane de 2 500 habitants. Une ville est souvent entourée de villages, auxquels elle fournit des services plus avancés. Certaines villes sont fortifiées, lorsqu’elles sont fréquemment menacées.",
  },
  {
    name: "Cité",
    description:
      "Elle compte entre 8 000 et 12 000 habitants, avec une médiane de 10 000 habitants. Un grand royaume ne compte généralement qu’une poignée de cités. Les cités sont pour la plupart toutes fortifiées et offrent la majorité des services d’artisanat et de marchandage.",
  },
  {
    name: "Grande cité",
    description:
      "Elle compte 12 000 habitants et plus, sans limite supérieure. Ces cités sont irrégulières, certains royaumes peuvent en compter une ou plusieurs, mais la majorité des royaumes n’en comptent aucune. On retrouve dans les grandes cités une grande diversité culturelle et des établissements très rares, par exemple une université ou une Tour de la Magie.",
  },
]);

type Specialty = {
  name: string;
  quantity: number;
};
const specialties = ref<Specialty[][]>(
  [
    "Cordonnier:150|Maroquinier:200|Servant:250|Tailleur:250|Barbier:350|Costumier:400|Joaillier:400|Taverne / Restaurant:400|Herboriste:450|Maçon:500|Pâtissier:500|Menuisier:550|Tisserand:600|Bourrelier:650|Marchand de chandelles:700|Marchand de textiles:700|Tonnelier:700|Boulanger:800",
    "Potier:800|Fabricant de fourreaux:850|Porteur d’eau:850|Marchand de vins:900|Chapelier:950|Boucher de volaille:1000|Laveur:1000|Boucher:1200|Poissonnier:1200|Ceinturier:1400|Marchand de cervoises:1400|Marchand d’épices:1400|Plâtrier:1400|Forgeron:1500|Peintre:1500|Médecin:1700|Couvreur:1800|Cordier:1900",
    "Serrurier:1900|Auberge:2000|Copiste:2000|Fabricant de tapis:2000|Sculpteur:2000|Tanneur:2000|Coutelier:2300|Marchand de foin:2300|Gantier:2400|Marchand de bois:2400|Sculpteur sur bois:2400|Voyant:2800|Relieur:3000|Souffleur de verre:3300|Shipchandler:3600|Éclairagiste:3900|Libraire:6300",
  ].map((list) =>
    list.split("|").map((value) => {
      const values: string[] = value.split(":");
      return { name: values[0], quantity: Number(values[1]) };
    }),
  ),
);

useSeo({
  title,
  description: "🚧",
});
</script>
