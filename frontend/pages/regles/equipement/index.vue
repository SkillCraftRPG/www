<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" />
    <p>Butins et trésors sont souvent les motivations des jeunes aventuriers intrépides.</p>
    <p>Sur leur route, ils trouveront des objets de valeurs multiples et auront besoin d’un équipement adapté à leurs voyages.</p>
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
    description: "🚧",
  },
  {
    path: "/regles/equipement/depart",
    title: "Équipement de départ",
    description: "🚧",
  },
];

/* TODO(fpion):
 * Entretien : vente et réparation d'équipement
 * Dépenses ❓
 * Encombrement ❓
 * Armures
 * Boucliers
 * Armes
 * Équipement général : Articles, Contenants, Vêtements
 * Marchandise : Bétail, Épices, Métaux, Nourriture, Repas, Textiles
 * Outils : Artisanat et trousses, Ensembles à jouer, Instruments de musique
 * Montures et véhicules : Bêtes, Accessoires, Véhicules, Navires
 * Services : Gîte et couvert, Professionnels, Occultes, Artisans et Marchands, Passage en navire
 */

useSeo({
  title,
  description: "", // TODO(fpion): implement
});
</script>
