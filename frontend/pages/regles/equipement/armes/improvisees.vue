<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>Lorsqu’une créature effectue une attaque en utilisant un objet qui n’est pas une arme, alors l’objet est alors considéré comme une arme improvisée.</p>
    <p>
      Une arme brisée, ou une arme lancée ne possédant pas la propriété <NuxtLink to="/regles/equipement/armes/proprietes">Jet</NuxtLink>, est aussi considérée
      comme une arme improvisée.
    </p>
    <h2 class="h3">Formation</h2>
    <p>
      Comme toute autre arme, une <NuxtLink to="/regles/equipement/armes/formation">formation</NuxtLink> est nécessaire afin d’utiliser efficacement une arme
      improvisée.
    </p>
    <p>Le talent <NuxtLink to="/regles/talents/armes-improvisees">Armes improvisées</NuxtLink> forme une créature à manier une arme improvisée.</p>
    <h2 class="h3">Attaque</h2>
    <p>
      La créature effectue un <NuxtLink to="/regles/competences/tests">test</NuxtLink> de <NuxtLink to="/regles/competences/melee">Mêlée</NuxtLink> si elle
      utilise l’objet en mêlée, ou un test d’<NuxtLink to="/regles/competences/orientation">Orientation</NuxtLink> si elle lance l’objet.
    </p>
    <p>La <NuxtLink to="/regles/equipement/armes/proprietes">portée</NuxtLink> d’une arme improvisée lancée est de 4/12.</p>
    <p>
      Les armes improvisées peuvent conférer un bonus à l’<NuxtLink to="/regles/equipement/armes/attaque">Attaque</NuxtLink>, à la discrétion du maître de jeu.
    </p>
    <p>
      Certaines armes improvisées peuvent être dotées de <NuxtLink to="/regles/equipement/armes/proprietes">propriétés</NuxtLink> normalement réservées aux
      armes conventionnelles. Ces armes improvisées peuvent alors interagir avec certains talents et capacités, par exemple
      <NuxtLink to="/regles/talents/armes-de-finesse">Armes de finesse</NuxtLink> et <NuxtLink to="/regles/talents/armes-de-jet">Armes de jet</NuxtLink>.
    </p>
    <h2 class="h3">Dégâts</h2>
    <p>
      Les points de dégâts infligés et leur létalité dépendent de la nature de l’objet. Si l’objet se rapproche d’une arme conventionnelle, il peut infliger les
      mêmes points de dégâts, ou légèrement moins. Ces paramètres sont laissés à la discrétion du maître de jeu.
    </p>
    <p>
      La <NuxtLink to="/regles/statistiques/force">Force</NuxtLink> de la créature est ajoutée aux points de dégâts infligés en maniant une arme improvisée à
      mêlée. Sa <NuxtLink to="/regles/statistiques/precision">Précision</NuxtLink> est ajoutée si l’arme est lancée.
    </p>
    <p>
      Une arme brisée inflige 1d4 points de dégâts si son dé de dégâts était supérieur (par exemple, la
      <NuxtLink to="/regles/equipement/armes/martiales">rapière</NuxtLink>, 1d8), ou 1d2 sinon (par exemple, la
      <NuxtLink to="/regles/equipement/armes/simples">dague</NuxtLink>, 1d4).
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
