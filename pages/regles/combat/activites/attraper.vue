<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      En <NuxtLink to="/regles/aventure/environnement/chute">chute libre</NuxtLink> ou emportés par un fort courant, vous tentez d’attraper une corniche, une
      branche d’arbre solide ou n’importe quoi qui peut vous sauver.
    </p>
    <p>Vous pouvez aussi tenter d’attraper une autre créature ou un objet.</p>
    <p>
      À sa discrétion, le maître de jeu peut exiger de vous un <NuxtLink to="/regles/competences/tests">test</NuxtLink> d’<NuxtLink
        to="/regles/competences/athletisme"
        >Athlétisme</NuxtLink
      >
      si la situation requiert une force particulièrement élevée, ou un test d’<NuxtLink to="/regles/competences/acrobaties">Acrobaties</NuxtLink> si elle
      requiert une vitesse fulgurante.
    </p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Combat", to: "/regles/combat" },
  { text: "Activités", to: "/regles/combat/activites" },
];
const title: string = "Attraper";

useSeo({
  title,
  description:
    "Découvrez l’action attraper : tentez de saisir une prise, un objet ou une créature pour éviter la chute ou résister aux courants, avec tests requis au besoin.",
});
</script>
