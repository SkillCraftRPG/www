<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Afin d’<NuxtLink to="/regles/magie/artefacts/port-maniement">utiliser</NuxtLink> ses propriétés, un artefact magique doit être porté ou manié de manière
      appropriée. Les bottes vont aux pieds, les gants aux mains, les chapeaux et casques sur la tête, une cape fixée aux épaules, les anneaux aux doigts. Une
      armure doit être enfilée, un bouclier attaché au bras, et une arme doit être tenue afin d’être utilisée.
    </p>
    <h2 class="h3">Compatibilité</h2>
    <p>
      La majorité des artefacts magiques conçus afin d’être portés s’ajustent automatiquement à la <NuxtLink to="/regles/especes/taille">taille</NuxtLink> ou à
      la morphologie de la créature qui les enfile. Certains sont dotés de sangles, de boucles ou de tissus extensibles ; d’autres se modèlent magiquement au
      porteur.
    </p>
    <p>
      Lorsqu’un artefact fait exception, il est explicitement spécifié. L’artefact ne peut alors fonctionner que pour des créatures d’une certaine taille ou
      d’une forme particulière.
    </p>
    <p>
      Lorsqu’une créature non humanoïde tente de porter un artefact magique, il revient au maître de jeu de déterminer s’il peut fonctionner normalement. Un
      anneau glissé sur un tentacule peut être valide, mais une créature serpentiforme incapable d’enfiler des bottes ne pourra pas utiliser leurs propriétés.
    </p>
    <h2 class="h3">Plusieurs artefacts d’un même type</h2>
    <p>
      Un personnage ne peut pas porter plusieurs artefacts appartement à un même type. Il ne peut normalement pas porter plus d’une paire de bottes, d’une paire
      de gants ou de gantelets, d’une paire de brassards, d’un ensemble d’armure, d’un couvre-chef, d’une cape, etc.
    </p>
    <p>
      Le maître de jeu peut autoriser des exceptions raisonnables (un diadème porté sous un casque, deux couches de capes, etc.) si l’ensemble de l’œuvre lui
      semble logique.
    </p>
    <h2 class="h3">Artefacts en paires</h2>
    <p>
      Les artefacts conçus pour être portés par paire, par exemple bottes, brassards, gants et, gantelets, n’accordent leurs bénéfices que si les deux éléments
      sont portés simultanément.
    </p>
    <p>Un personnage portant deux bottes désappariées ne bénéficie des propriétés d’aucune des deux.</p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Magie", to: "/regles/magie" },
  { text: "Artefacts", to: "/regles/magie/artefacts" },
];
const title: string = "Port et maniement";

useSeo({
  title,
  description:
    "Découvrez les règles de port et maniement des artefacts magiques, leur compatibilité, leurs limites d’usage et les conditions pour bénéficier pleinement de leurs effets.",
});
</script>
