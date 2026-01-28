<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Afin de canaliser un pouvoir, une créature doit réussir un <NuxtLink to="/regles/competences/tests">test</NuxtLink> d’<NuxtLink
        to="/regles/competences/occultisme"
        >Occultisme</NuxtLink
      >.
    </p>
    <p>
      Le <NuxtLink to="/regles/competences/tests/difficulte">degré de difficulté</NuxtLink> du test est égal au nombre de
      <NuxtLink to="/regles/magie/pouvoirs/energie">points d’Énergie dépensés</NuxtLink>.
    </p>
    <p>En cas de réussite, le pouvoir prend effet et les points d’Énergie sont dépensés.</p>
    <p>
      En cas d’échec, le pouvoir n’est pas canalisé, et les composantes <NuxtLink to="/regles/magie/parametres/composantes">Matériel</NuxtLink> ne sont pas
      dépensées. Les conséquences suivantes remplacent les <NuxtLink to="/regles/competences/esperance-damnation">points de Damnation</NuxtLink>.
    </p>
    <ul>
      <li><i>Échec avec Espérance.</i> Aucun point d’Énergie n’est dépensé.</li>
      <li><i>Échec avec Damnation.</i> La moitié des points d’Énergie sont dépensés.</li>
      <li><i>Échec critique.</i> La moitié des points d’Énergie sont dépensés, et la créature subit une <strong>mésaventure magique</strong> aléatoire.</li>
    </ul>
    <p>
      Une créature peut canaliser plusieurs pouvoirs dans un même <NuxtLink to="/regles/combat/deroulement/tour">tour</NuxtLink>. Chaque test d’Occultisme est
      effectué indépendamment, et chaque canalisation engendre une dépense en points d’Énergie. Par exemple, une créature pourrait :
    </p>
    <ul>
      <li>
        Canaliser jusqu’à trois fois un pouvoir dont l’<NuxtLink to="/regles/magie/parametres/incantation">incantation</NuxtLink> est d’une seule
        <NuxtLink to="/regles/combat/deroulement/tour">action</NuxtLink>.
      </li>
      <li>
        Canaliser un pouvoir dont l’incantation est d’une seule action ainsi qu’un pouvoir dont l’incantation est de deux
        <NuxtLink to="/regles/combat/deroulement/tour">actions</NuxtLink>.
      </li>
    </ul>
    <h2 class="h3">Mésaventures magiques</h2>
    <p>La liste suivante présente des mésaventures magiques. Pour déterminer une mésaventure magique aléatoirement, 🚧</p>
    <ol>
      <li>
        Pendant la prochaine <NuxtLink to="/regles/aventure/temps">minute</NuxtLink>, au début de chacun de vos
        <NuxtLink to="/regles/combat/deroulement/tour">tours</NuxtLink>, vous subissez une mésaventure aléatoire. Ignorez ce résultat.
      </li>
      <li class="text-danger">
        Pendant la prochaine minute, vous pouvez <NuxtLink to="/regles/aventure/environnement/vision">voir</NuxtLink> les créatures et objets
        <NuxtLink to="/regles/combat/conditions/invisible">invisibles</NuxtLink>.
      </li>
    </ol>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Magie", to: "/regles/magie" },
  { text: "Pouvoirs", to: "/regles/magie/pouvoirs" },
];
const title: string = "Canalisation";

useSeo({
  title,
  description: "Découvrez comment canaliser un pouvoir via un test d’Occultisme, réussissez ou perdez vos points d’Énergie.",
});
</script>
