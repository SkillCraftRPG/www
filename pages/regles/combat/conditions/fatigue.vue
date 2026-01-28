<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>Certaines capacités ou situations peuvent affliger une créature d’un ou plusieurs niveaux de Fatigue.</p>
    <p>
      La <NuxtLink to="/regles/aventure/environnement/alimentation">soif et la sécheresse</NuxtLink>, le
      <NuxtLink to="/regles/aventure/repos/sommeil">manque de sommeil</NuxtLink> ou la
      <NuxtLink to="/regles/aventure/mouvement/voyage">marche forcée</NuxtLink> sont des exemples de situations pouvant infliger un niveau de Fatigue à une
      créature.
    </p>
    <p>
      Le niveau de Fatigue d’une créature varie entre 0 et 5. Lorsqu’elle est affligée d’un niveau, son niveau actuel augmente. Lorsque son niveau de Fatigue
      dépasse 5, elle <NuxtLink to="/regles/combat/conditions/mort">meurt</NuxtLink>.
    </p>
    <p>
      Lorsqu’une créature complète une <NuxtLink to="/regles/aventure/repos/sommeil">nuit de sommeil</NuxtLink>, sa Fatigue diminue d’un niveau. Certaines
      capacités permettent également de diminuer le niveau de Fatigue.
    </p>
    <p>Chaque niveau de Fatigue inflige des pénalités à une créature. Les effets des différents niveaux sont cumulables entre eux.</p>
    <table class="table table-striped text-center">
      <thead>
        <tr>
          <th scope="col" class="w-20">Niveau</th>
          <th scope="col" class="w-80">Effets</th>
        </tr>
      </thead>
      <tbody>
        <tr>
          <td>1</td>
          <td>
            <NuxtLink to="/regles/competences/tests/avantage-desavantage">Désavantage</NuxtLink> aux <NuxtLink to="/regles/competences/tests">tests</NuxtLink>,
            à l’exception des <NuxtLink to="/regles/combat/attaque">attaques</NuxtLink> et
            <NuxtLink to="/regles/competences/tests/sauvegarde">jets de sauvegarde</NuxtLink>
          </td>
        </tr>
        <tr>
          <td>2</td>
          <td><NuxtLink to="/regles/aventure/mouvement/vitesse">Vitesses</NuxtLink> de déplacement réduites de moitié</td>
        </tr>
        <tr>
          <td>3</td>
          <td>
            <NuxtLink to="/regles/competences/tests/avantage-desavantage">Désavantage</NuxtLink> au <NuxtLink to="/regles/competences/tests">test</NuxtLink> des
            <NuxtLink to="/regles/combat/attaque">attaques</NuxtLink> et aux
            <NuxtLink to="/regles/competences/tests/sauvegarde">jets de sauvegarde</NuxtLink>
          </td>
        </tr>
        <tr>
          <td>4</td>
          <td>
            Points de <NuxtLink to="/regles/statistiques/vitalite">Vitalité</NuxtLink> et d’<NuxtLink to="/regles/statistiques/energie">Énergie</NuxtLink>
            réduits de moitié (valeur courante et maximale)
          </td>
        </tr>
        <tr>
          <td>5</td>
          <td><NuxtLink to="/regles/aventure/mouvement/vitesse">Vitesses</NuxtLink> de déplacement réduites à 0 (incapacité à se déplacer)</td>
        </tr>
      </tbody>
    </table>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Combat", to: "/regles/combat" },
  { text: "Conditions", to: "/regles/combat/conditions" },
];
const title: string = "Fatigue";

useSeo({
  title,
  description: "Découvrez la condition Fatigue : niveaux cumulatifs causant désavantages, réduction de vitesse, vitalité et énergie, jusqu’à la mort.",
});
</script>
