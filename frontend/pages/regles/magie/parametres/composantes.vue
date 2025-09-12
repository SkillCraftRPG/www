<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Les composantes sont des conditions ou des options influençant la manière dont un pouvoir est
      <NuxtLink to="/regles/magie/pouvoirs/canalisation">canalisé</NuxtLink>.
    </p>
    <ul>
      <li>
        <strong>Focus (F).</strong> Un pouvoir nécessitant un Focus indique un ou plusieurs ingrédients représentant le Focus. Lorsque le pouvoir est canalisé,
        les effets de celui-ci sont générés à partir du Focus. Les ingrédients indiqués ne sont donc pas consommés par la canalisation du pouvoir.
      </li>
      <li>
        <strong>Matériel (M).</strong> Lorsqu’un pouvoir indique cette composante, un ou plusieurs ingrédients sont également mentionnés. La canalisation du
        pouvoir requiert ces ingrédients et consomme ceux-ci, même si le <NuxtLink to="/regles/competences/tests">test</NuxtLink> d’<NuxtLink
          to="/regles/competences/occultisme"
          >Occultisme</NuxtLink
        >
        est échoué.
      </li>
      <li>
        <strong>Somatique (S).</strong> Afin de canaliser un pouvoir requérant cette composante, le personnage doit avoir une main libre afin d’effectuer
        certains gestes. Il ne peut donc pas canaliser un pouvoir requérant cette composante s’il est immobilisé par un quelconque effet.
      </li>
      <li>
        <strong>Verbal (V).</strong> L’<NuxtLink to="/regles/magie/parametres/incantation">incantation</NuxtLink> d’un pouvoir exigeant cette composante est
        effectuée en prononçant certains mots mystiques. Ces mots ne déclenchent pas le pouvoir directement. C’est plutôt l’ensemble des composantes et
        l’intonation utilisée pendant la canalisation qui déclenchent le pouvoir. Une créature ne possédant pas le pouvoir ne peut donc pas canaliser celui-ci
        simplement en répétant les mots mystiques.
      </li>
    </ul>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Magie", to: "/regles/magie" },
  { text: "Paramètres", to: "/regles/magie/parametres" },
];
const title: string = "Composantes";

useSeo({
  title,
  description: "Découvrez les règles des composantes de pouvoirs : focus, matériel, somatique et verbal, et leur impact sur la canalisation magique.",
});
</script>
