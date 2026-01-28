<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" />
    <p>Butins et trésors sont souvent les motivations des jeunes aventuriers intrépides.</p>
    <p>Sur leur route, ils trouveront des objets de valeur multiple et auront besoin d’équipement adapté à leurs voyages.</p>
    <p>Armes et armures, objets magiques, marchandises et autres objets de valeur pourront être troqués ou achetés à différents endroits.</p>
    <div class="row">
      <div v-for="(item, index) in items" :key="index" class="col-xs-12 col-sm-6 col-md-4 col-lg-3 mb-4">
        <LinkCard class="d-flex flex-column h-100" :text="item.description" :title="item.title" :to="item.path" />
      </div>
    </div>
  </main>
</template>

<script setup lang="ts">
const title: string = "Équipement";

type MenuItem = {
  path: string;
  title: string;
  description: string;
};
const items: MenuItem[] = [
  {
    path: "/regles/equipement/monnaie",
    title: "Système de monnaie",
    description: "Systèmes monétaires, pièces de monnaie, valeurs et conversions.",
  },
  {
    path: "/regles/equipement/encombrement",
    title: "Encombrement",
    description: "Définit la limite de poids qu’une créature peut porter et les pénalités.",
  },
  {
    path: "/regles/equipement/depenses",
    title: "Dépenses",
    description: "Styles de vie, quotidiens et confort offert entre deux aventures.",
  },
  {
    path: "/regles/equipement/vente",
    title: "Vente",
    description: "Revente d’armes, artefacts, marchandises et objets précieux.",
  },
  {
    path: "/regles/equipement/depart",
    title: "Équipement de départ",
    description: "Déterminer la richesse de départ et sélectionner l’équipement de départ.",
  },
  {
    path: "/regles/equipement/armes",
    title: "Armes",
    description: "Objets offensifs ou défensif utilisés par les personnages et créatures.",
  },
  {
    path: "/regles/equipement/armures",
    title: "Armures",
    description: "Protection portée par les aventuriers et hommes d’armes.",
  },
  {
    path: "/regles/equipement/boucliers",
    title: "Boucliers",
    description: "Catégories, propriétés, talents et particularités des boucliers.",
  },
  {
    path: "/regles/equipement/defense",
    title: "Défense",
    description: "Armures et boucliers ajoutent des points de Défense.",
  },
  {
    path: "/regles/equipement/resistance",
    title: "Résistance",
    description: "Chaque coup réduit la Résistance d’une armure ou d’un bouclier.",
  },
  {
    path: "/regles/equipement/reparation",
    title: "Réparation",
    description: "Réparation d’équipement, incluant coûts et limites.",
  },
  {
    path: "/regles/equipement/general",
    title: "Équipement général",
    description: "Articles généraux, contenants et vêtements.",
  },
  {
    path: "/regles/equipement/outils",
    title: "Outils et trousses",
    description: "Outils d’artisan, trousses, ensembles à jouer et instruments de musique.",
  },
  {
    path: "/regles/equipement/marchandise",
    title: "Marchandise",
    description: "Bétail, épices, nourriture, métaux et textiles.",
  },
  {
    path: "/regles/equipement/montures-vehicules",
    title: "Montures et véhicules",
    description: "Bêtes, accessoires, véhicules terrestres et navires.",
  },
  {
    path: "/regles/equipement/services",
    title: "Services",
    description: "Gîte et couvert, occultes, artisans et marchands, passage en navire.",
  },
];

useSeo({
  title,
  description: "Découvrez toutes les règles d’équipement : armes, armures, outils, services, montures, dépenses et marchandises pour vos aventures.",
});
</script>
