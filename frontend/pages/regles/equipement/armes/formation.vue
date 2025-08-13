<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb active="Formation" :parent="parent" />
    <p>
      Lorsqu’un personnage effectue une <strong>attaque</strong>, il doit effectuer un <NuxtLink to="/regles/competences/tests">test</NuxtLink> de
      <NuxtLink to="/regles/competences">compétence</NuxtLink>.
    </p>
    <p>
      Cette compétence dépend de la nature de l’attaque et de l’<NuxtLink to="/regles/equipement/armes">arme</NuxtLink> utilisée. Cette compétence est
      généralement <NuxtLink to="/regles/competences/melee">Mêlée</NuxtLink> ou <NuxtLink to="/regles/competences/orientation">Orientation</NuxtLink>.
    </p>
    <p>
      Si le personnage est formé à manier cette arme, il ajoute le <NuxtLink to="/regles/competences/rang">rang</NuxtLink> de cette compétence au test. Sinon,
      il n’ajoute pas le rang de la compétence au test.
    </p>
    <p>Les talents suivants forment le personnage au maniement de certaines armes :</p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Équipement", to: "/regles/equipement" },
  { text: "Armes", to: "/regles/equipement/armes" },
];
const title: string = "Formation au maniement d’armes";

useSeo({
  title,
  description: "Découvrez comment la formation au maniement d’une arme influence les tests d’attaque et l’utilisation efficace des compétences associées.",
});

/* TODO(fpion): Talents
 * /regles/talents/armes-improvisees
 * /regles/talents/arts-martiaux
 * /regles/talents/formation-martiale
 * /regles/talents/melee
 * /regles/talents/orientation
 * /regles/talents/armes-de-finesse
 * /regles/talents/armes-de-jet
 * /regles/talents/armes-de-tir
 * /regles/talents/distraction
 */
</script>
