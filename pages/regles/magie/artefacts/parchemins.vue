<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <RulesBreadcrumb active="Parchemins" :parent="parent" />
    <p>
      Un parchemin magique porte les mots d’un seul <NuxtLink to="/regles/magie/pouvoirs/niveau">niveau</NuxtLink> de
      <NuxtLink to="/regles/magie/pouvoirs">pouvoir</NuxtLink>, écrits avec des glyphes mystiques. Si le personnage a acquis le talent
      <NuxtLink to="/regles/talents/occultisme">Occultisme</NuxtLink>, il peut lire le parchemin afin de déterminer quel pouvoir est inscrit sur celui-ci, à
      quel niveau le pouvoir sera <NuxtLink to="/regles/magie/pouvoirs/canalisation">canalisé</NuxtLink>, et quels effets seront produits par son utilisation.
      Sinon, le parchemin est inintelligible.
    </p>
    <p>
      Si le personnage peut lire le parchemin, il peut l’utiliser afin de canaliser le niveau de pouvoir inscrit sur le parchemin en utilisant le temps
      d’<NuxtLink to="/regles/magie/parametres/incantation">incantation</NuxtLink> normal. Le parchemin fournit automatiquement les composantes
      <NuxtLink to="/regles/magie/parametres/composantes">Focus</NuxtLink> ni <NuxtLink to="/regles/magie/parametres/composantes">Matériel</NuxtLink>, et le
      personnage n’a pas besoin de <NuxtLink to="/regles/magie/pouvoirs/energie">dépenser</NuxtLink> de point d’<NuxtLink to="/regles/statistiques/energie"
        >Énergie</NuxtLink
      >.
    </p>
    <p>
      Il doit tout de même réussir le <NuxtLink to="/regles/competences/tests">test</NuxtLink> d’<NuxtLink to="/regles/competences/occultisme"
        >Occultisme</NuxtLink
      >. S’il réussit ou échoue la canalisation, le parchemin est réduit en cendres. Si la canalisation est interrompue, le parchemin n’est pas perdu.
    </p>
    <p>Le tiers du pouvoir détermine sa rareté.</p>
    <table class="table table-striped text-center">
      <thead>
        <tr>
          <th scope="col w-50">Tiers</th>
          <th scope="col w-50">Rareté</th>
        </tr>
      </thead>
      <tbody>
        <tr>
          <td class="w-50">0</td>
          <td class="w-50">Commun</td>
        </tr>
        <tr>
          <td class="w-50">1</td>
          <td class="w-50">Peu fréquent</td>
        </tr>
        <tr>
          <td class="w-50">2</td>
          <td class="w-50">Rare</td>
        </tr>
        <tr>
          <td class="w-50">3</td>
          <td class="w-50">Très rare</td>
        </tr>
      </tbody>
    </table>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/tar/breadcrumb";

const parent: Breadcrumb[] = [
  { text: "Magie", to: "/regles/magie" },
  { text: "Artefacts", to: "/regles/magie/artefacts" },
];
const title: string = "Parchemins magiques";

useSeo({
  title,
  description: "Découvrez les parchemins magiques de SkillCraft, leur fonctionnement, leur rareté et comment canaliser leurs pouvoirs sans dépenser d’Énergie.",
});
</script>
