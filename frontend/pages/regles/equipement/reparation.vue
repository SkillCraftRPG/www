<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb active="Réparation" :parent="parent" />
    <p>
      L’équipement des personnages n’est pas éternel, et peut être brisé. La réparation d’un équipement est toujours moins onéreuse que l’achat d’un nouvel
      exemplaire.
    </p>
    <p>
      Certains artisans partent à l’aventure et financent leurs expéditions en réparant puis en vendant les objets endommagés ou brisés qu’ils trouvent pendant
      leur voyage.
    </p>
    <p>
      La réparation d’un équipement nécessite généralement des matériaux d’une valeur supérieure ou égale à ⅛ ({{ $n(1 / 8, "percentage") }}) du prix de vente
      de l’objet. Il coûtera généralement le double du prix pour faire réparer un objet auprès d’un artisan afin de payer son temps de travail et son expertise.
    </p>
    <p>
      Lorsqu’une <NuxtLink to="/regles/equipement/armures">armure</NuxtLink> ou un <NuxtLink to="/regles/equipement/boucliers">bouclier</NuxtLink> n’a pas perdu
      tous ses <NuxtLink to="/regles/equipement/resistance">points de Résistance</NuxtLink>, on effectue une règle de trois afin de calculer le coût de la
      réparation. Par exemple, il coûtera 30 deniers en matériaux afin de restaurer 12 points de Résistance à un bouclier possédant 20 points au total et ayant
      un prix de vente de 400 deniers.
    </p>
    <p>
      Les renforts sur un bouclier ou une armure peuvent également être réparés. Le coût en matériaux est le même que pour les autres points de Résistance de
      l’objet.
    </p>
    <p>
      La nature de l’objet, son état, la rareté des ressources nécessaires ainsi que les habiletés de l’artisan peuvent faire varier ce prix, à la discrétion du
      maître de jeu.
    </p>
    <p>Certains équipements peuvent être brisés définitivement, à la discrétion du maître de jeu, et ne peuvent donc pas être réparés.</p>
    <!-- TODO(fpion): trousse de réparation -->
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [{ text: "Équipement", to: "/regles/equipement" }];
const title: string = "Réparation d’équipement";

useSeo({
  title,
  description:
    "Découvrez comment restaurer armes, armures et boucliers. Règles de coût, matériaux et limites de réparation pour préserver l’équipement des aventuriers.",
});
</script>
