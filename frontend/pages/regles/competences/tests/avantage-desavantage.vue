<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Certaines habiletés ou situations peuvent conférer l’avantage ou infliger le désavantage à un <NuxtLink to="/regles/competences/tests">test</NuxtLink>.
    </p>
    <p>L’avantage augmente vos chances de réussir l’action entreprise, au contraire du désavantage, qui diminue ces chances.</p>
    <ul>
      <li>
        <strong>Avantage.</strong> Relancez votre <NuxtLink to="/regles/competences/tests/2d10">dé d’Espérance ou de Damnation</NuxtLink> (au choix) et
        conservez le résultat le plus élevé entre l’ancien et le nouveau résultat.
      </li>
      <li>
        <strong>Désavantage.</strong> Relancez votre dé le plus élevé entre votre dé d’Espérance ou de Damnation et conservez le résultat le plus faible entre
        l’ancien et le nouveau résultat.
      </li>
    </ul>
    <h2 class="h3">Plusieurs avantages et désavantages</h2>
    <p>
      Plusieurs avantages et désavantages peuvent s’appliquer à un même test. Lorsque cette situation se produit, retirez le nombre le moins élevé du nombre le
      plus élevé puis appliquez le résultat. En cas d’égalité, aucun avantage ni désavantage n’est appliqué.
    </p>
    <p>Vous pouvez cumuler au maximum 2 avantages ou 2 désavantages. Chacun s’applique à un dé différent.</p>
    <h3 class="h5">Exemples</h3>
    <ul>
      <li>Vous cumulez 3 avantages. Vous appliquez 2 avantages afin d’honorer la limite, et chaque avantage s’applique obligatoirement à un dé différent.</li>
      <li>
        Vous cumulez 3 avantages ainsi que 2 désavantages. Retirez les désavantages aux avantages : vous n’appliquez donc qu’un seul avantage à un seul dé.
      </li>
      <li>
        Vous cumulez un avantage et 4 désavantages. Retirez l’avantage aux désavantages : vous êtes affligés de 2 désavantages, puis que le résultat (
        <code>4 - 1 = 3</code>
        ) est supérieur à la limite&nbsp;de&nbsp;2. Appliquez chaque désavantage à un dé différent.
      </li>
      <li>Vous cumulez un avantage et un désavantage (égalité). Vous effectuez le test sans avantage ni désavantage.</li>
    </ul>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Compétences", to: "/regles/competences" },
  { text: "Tests", to: "/regles/competences/tests" },
];
const title: string = "Avantage et Désavantage";

useSeo({
  title,
  description: "Découvrez le fonctionnement de l’avantage et du désavantage dans le système 2d10 de SkillCraft, et comment gérer leur cumul dans un même test.",
});
</script>
