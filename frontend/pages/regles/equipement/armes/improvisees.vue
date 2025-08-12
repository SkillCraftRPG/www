<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>Lorsqu’une créature effectue une attaque en utilisant un objet qui n’est pas une arme, alors l’objet est alors considéré comme une arme improvisée.</p>
    <p>
      Une arme brisée, ou une arme lancée ne possédant pas la propriété <NuxtLink to="/regles/equipement/armes/proprietes">Jet</NuxtLink>, est aussi considérée
      comme une arme improvisée.
    </p>
    <p>
      La créature effectue un <NuxtLink to="/regles/competences/tests">test</NuxtLink> de <NuxtLink to="/regles/competences/melee">Mêlée</NuxtLink> si elle
      utilise l’objet en mêlée, ou un test d’<NuxtLink to="/regles/competences/orientation">Orientation</NuxtLink> si elle lance l’objet. La
      <NuxtLink to="/regles/equipement/armes/proprietes">portée</NuxtLink> d’une arme improvisée lancée est de 4/12.
    </p>
    <p>
      Comme toute autre arme, une <NuxtLink to="/regles/equipement/armes/formation">formation</NuxtLink> est nécessaire afin d’utiliser efficacement une arme
      improvisée. Le talent <NuxtLink to="/regles/talents/armes-improvisees">Armes improvisées</NuxtLink> forme une créature à manier une arme improvisée.
    </p>
    <p>
      Les points de dégâts infligés et leur létalité dépendent de la nature de l’objet. Si l’objet se rapproche d’une arme conventionnelle, il peut infliger les
      mêmes points de dégâts, ou légèrement moins. Ces paramètres sont déterminés par le maître de jeu.
    </p>
    <p>
      Par défaut, les armes improvisées infligent 1d4 points de dégâts. Les armes brisées et objets lancés ne possédant pas la propriété
      <strong>Jet</strong> infligent toujours 1d4 points de dégâts.
    </p>
    <p>
      La <NuxtLink to="/regles/statistiques/force">Force</NuxtLink> de la créature est ajoutée aux points de dégâts infligés en maniant une arme improvisée à
      mêlée. Sa <NuxtLink to="/regles/statistiques/precision">Précision</NuxtLink> est ajoutée si l’arme est lancée.
    </p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Équipement", to: "/regles/equipement" },
  { text: "Armes", to: "/regles/equipement/armes" },
];
const title: string = "Armes improvisées";

useSeo({
  title,
  description: "Découvrez les règles sur les armes improvisées, leurs dégâts, leur portée et les talents nécessaires pour les manier efficacement.",
});
</script>
