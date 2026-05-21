<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <RulesBreadcrumb :active="title" :parent="parent" />
    <p>
      Les <NuxtLink to="/regles/talents/astrologie">Astromanciens</NuxtLink> tirent leurs pouvoirs des constellations, des astres organisés en signes
      astrologiques. Ces signes leur sont donc d’une grande importance. La plupart des
      <NuxtLink to="/regles/astromancie/ecole">écoles occultes</NuxtLink> adhèrent à la philosophie des 25 signes : 12 paires de signes opposés, ainsi que le
      signe universel de la <strong>Lune</strong>. Le calendrier astral étant divisé en 12 périodes, chaque période est dominé par un signe différent. Les
      signes opposés s’alternent entre les années paires et impaires. Il existe également des signes astrologiques secrets ou cachés, inconnus de la majorité
      des écoles. Bien que la découverte de ces signes soit très rare, leur usage est souvent interdit, puisqu’ils donnent accès à des pouvoirs peu documentés
      et maîtrisés.
    </p>
    <table class="table table-striped text-center">
      <thead>
        <tr>
          <th scope="col" class="w-25">Signe</th>
          <th scope="col" class="w-25">Opposé</th>
          <th scope="col" class="w-25">Signe</th>
          <th scope="col" class="w-25">Opposé</th>
        </tr>
      </thead>
      <tbody>
        <tr>
          <td>Amphore</td>
          <td>Berceau</td>
          <td>Coquillage</td>
          <td>Sabre</td>
        </tr>
        <tr>
          <td>Archer</td>
          <td>Vipère</td>
          <td>Crabe</td>
          <td>Tortue</td>
        </tr>
        <tr>
          <td>Balance</td>
          <td>Pieuvre</td>
          <td>Destrier</td>
          <td>Lyre</td>
        </tr>
        <tr>
          <td>Capricorne</td>
          <td>Lotus</td>
          <td>Lion</td>
          <td>Serpe</td>
        </tr>
        <tr>
          <td>Chariot</td>
          <td>Arbre</td>
          <td>Poisson</td>
          <td>Aigle</td>
        </tr>
        <tr>
          <td>Coq</td>
          <td>Échelle</td>
          <td>Scorpion</td>
          <td>Caducée</td>
        </tr>
      </tbody>
    </table>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/tar/breadcrumb";

const parent: Breadcrumb[] = [
  { text: "Annexes", to: "/regles/annexes" },
  { text: "Astromancie", to: "/regles/astromancie" },
];
const title: string = "Signes astrologiques";

useSeo({
  title,
  description: "Découvrez les signes astrologiques de l’Astromancie : constellations, oppositions et signes secrets guidant les pouvoirs occultes.",
});
</script>
