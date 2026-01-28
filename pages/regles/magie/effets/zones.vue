<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb active="Zones" :parent="parent" />
    <p>Certains pouvoirs affectent toutes les créatures se trouvant dans une zone d’effet.</p>
    <p>L’origine de la zone d’effet correspond généralement à la cible du pouvoir, soit le personnage, une créature, ou un point dans l’espace.</p>
    <p>Les différentes zones d’effet sont décrites ci-dessous.</p>
    <ul>
      <li>
        <strong>Cône.</strong> Un cône s’étend vers la direction désignée à partir de la cible. La longueur du cône correspond à la distance entre l’origine de
        l’effet et le point atteint le plus éloigné.
      </li>
      <li><strong>Cube.</strong> Un cube dont la taille correspond à la longueur de ses arêtes. L’origine correspond à un des sommets du cube.</li>
      <li>
        <strong>Cylindre.</strong> L’origine correspond au centre d’une des deux faces circulaires du cylindre. Le cylindre s’étend vers la direction désignée.
        Sa longueur correspond à la distance entre l’origine de l’effet et le point atteint le plus éloigné.
      </li>
      <li>
        <strong>Ligne.</strong> Une ligne d’une largeur quelconque s’étend vers la direction désignée à partir de la cible. La longueur de la ligne correspond à
        la distance entre l’origine de l’effet et le point atteint le plus éloigné.
      </li>
      <li>
        <strong>Sphère.</strong> Une sphère s’étend dans toutes les directions depuis la cible. Le rayon de la sphère correspond à la distance entre l’origine
        et le point atteint le plus éloigné.
      </li>
    </ul>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Magie", to: "/regles/magie" },
  { text: "Effets", to: "/regles/magie/effets" },
];
const title: string = "Zones d’effet";

useSeo({
  title,
  description:
    "Découvrez les différentes zones d’effet des pouvoirs : cône, cube, cylindre, ligne ou sphère, et comment elles influencent la portée des sorts.",
});
</script>
