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
    <div class="row">
      <div v-for="(pair, index) in pairs" :key="index" class="col-xs-12 col-sm-6 col-md-4 mb-4">
        <TarCard class="h-100">
          <div class="d-flex justify-content-around align-items-center text-center gap-3">
            <div v-for="sign in pair" :key="sign">
              <div class="sign-glyph">
                <IconSign :sign="sign" />
              </div>
              <div>{{ sign }}</div>
            </div>
          </div>
        </TarCard>
      </div>
      <div class="col-12 mb-4">
        <TarCard class="h-100">
          <div class="text-center">
            <div class="sign-glyph">
              <IconSign sign="Lune" />
            </div>
            <div>Lune</div>
          </div>
        </TarCard>
      </div>
    </div>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/tar/breadcrumb";

const parent: Breadcrumb[] = [
  { text: "Annexes", to: "/regles/annexes" },
  { text: "Astromancie", to: "/regles/astromancie" },
];
const title: string = "Signes astrologiques";

const pairs: [string, string][] = [
  ["Amphore", "Berceau"],
  ["Archer", "Vipère"],
  ["Balance", "Pieuvre"],
  ["Capricorne", "Lotus"],
  ["Chariot", "Arbre"],
  ["Coq", "Échelle"],
  ["Coquillage", "Sabre"],
  ["Crabe", "Tortue"],
  ["Destrier", "Lyre"],
  ["Lion", "Serpe"],
  ["Poisson", "Aigle"],
  ["Scorpion", "Caducée"],
];

useSeo({
  title,
  description: "Découvrez les signes astrologiques de l’Astromancie : constellations, oppositions et signes secrets guidant les pouvoirs occultes.",
});
</script>

<style scoped>
.sign-glyph {
  font-size: 4rem;
  line-height: 1;
  margin-bottom: 0.5rem;
}
</style>
