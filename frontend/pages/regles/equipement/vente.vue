<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb active="Vente" :parent="parent" />
    <p>
      Au fil de ses aventures, les personnages acquerront probablement des trésors ou des objets qu’ils désireront vendre ou échanger contre d’autres biens.
    </p>
    <p>Par exemple, l’équipement des adversaires vaincus fait très souvent partie du butin.</p>
    <p>La valeur de revente d’un objet varie en fonction de sa nature.</p>
    <ul>
      <li>
        <NuxtLink to="/regles/equipement/armes">Armes</NuxtLink>, <NuxtLink to="/regles/equipement/armures">armures</NuxtLink>,
        <NuxtLink to="/regles/equipement/boucliers">boucliers</NuxtLink> et <NuxtLink to="/regles/equipement/general">équipements</NuxtLink>. Lorsqu’en bonne
        condition, ces objets peuvent être vendus pour la moitié de leur prix d’achat. Lorsqu’ils sont brisés ou en mauvais état, leur valeur de revente est
        moindre, avoisinant le quart de leur prix d’achat, et bien souvent nulle.
      </li>
      <li>
        <strong>Artefacts magiques.</strong> Les artefacts magiques ou uniques n’ont généralement pas de valeur fixe. À moins qu’ils soient fréquents et vendus
        dans les grands centres commerciaux, leur valeur s’élève à ce qu’un acheteur est prêt à débourser pour l’artefact. Trouver un client fortuné à qui
        vendre un artefact magique peut être une tâche ardue.
      </li>
      <li>
        <NuxtLink to="/regles/equipement/marchandise">Marchandises.</NuxtLink> Les ressources brutes, titres de propriété et produits de transformation sont
        considérés comme des marchandises. À l’extérieur des centres urbains, la plupart des transactions sont conclues par le troc. La valeur des marchandises
        varie selon leur difficulté d’accès dans la région dans laquelle elles sont vendues. Cette difficulté d’accès est généralement déterminée par leur
        rareté naturelle ou contrôlée.
      </li>
      <li>
        <strong>Œuvres d’art, bijoux et pierres précieuses.</strong> Les objets de cette nature conservent généralement leur valeur initiale lors de la revente.
        Ils peuvent également être utilisés afin d’effectuer une transaction nécessitant une grande somme d’argent. Ces objets pourraient également être mis en
        enchère afin de réaliser un profit.
      </li>
    </ul>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [{ text: "Équipement", to: "/regles/equipement" }];
const title: string = "Vente d’équipement";

useSeo({
  title,
  description: "Découvrez les règles de revente d’armes, armures, artefacts, marchandises et objets précieux, selon leur état, rareté et valeur marchande.",
});
</script>
