<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      En Ouespéro, on compte en moyenne une <NuxtLink to="/regles/equipement/services/peuplements">auberge pour 2000 habitants</NuxtLink>. On ne trouvera donc
      aucune auberge dans un village, une seule auberge dans une ville, et plusieurs auberges dans une cité. Les auberges offrent des services de gîte, de
      couvert et on peut s’y procurer de l’alcool.
    </p>
    <p>
      En comparaison, on compte environ une taverne pour 400 habitants, celles-ci sont donc bien plus répandues. Cependant, les tavernes n’offrent pas de
      service de gîte, et elles offrent parfois des services de couvert ou des produits du terroir, mais plus rarement des repas complets.
    </p>
    <p>
      Les prix des services décrits dans la table ci-dessus sont pour une personne. De manière générale, les auberges offrent des services de couvert et de gîte
      dans la même catégorie de dépense. Elles peuvent offrir un rabais lorsqu’un client prend le service de gîte avec plusieurs repas.
    </p>
    <ItemAccommodationServices :items="services.accommodation" />
    <h3 id="alcool" class="h5">Alcool</h3>
    <p>
      Alcools variés : cervoise, piquette et vins pour accompagner festins, tavernes et banquets. La consommation d’alcool peut causer l’<NuxtLink
        to="/regles/aventure/environnement/alcoolemie"
        >ébriété</NuxtLink
      >.
    </p>
    <ItemAlcoholList :items="services.alcohol" />
  </main>
</template>

<script setup lang="ts">
import services from "~/assets/data/items/services.json";
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Équipement", to: "/regles/equipement" },
  { text: "Services", to: "/regles/equipement/services" },
];
const title: string = "Gîte et couvert";

useSeo({
  title,
  description:
    "Découvrez les auberges et tavernes d’Ouespéro : gîte, repas et alcools variés comme cervoise, piquette et vins, essentiels à la vie sociale et aux festins",
});
</script>
