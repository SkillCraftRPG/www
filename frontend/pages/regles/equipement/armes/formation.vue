<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb active="Formation" :parent="parent" />
    <p>
      Lorsqu’un personnage effectue une <strong>attaque</strong>, il doit effectuer un <NuxtLink to="/regles/competences/tests">test</NuxtLink> de
      <NuxtLink to="/regles/competences">compétence</NuxtLink>.
    </p>
    <p>
      Cette compétence varie en fonction de la nature de l’attaque et de l’<NuxtLink to="/regles/equipement/armes">arme</NuxtLink> utilisée. Cette compétence
      est généralement <NuxtLink to="/regles/competences/melee">Mêlée</NuxtLink> ou <NuxtLink to="/regles/competences/orientation">Orientation</NuxtLink>.
    </p>
    <p>
      Si le personnage est formé à manier cette arme, il ajoute le <NuxtLink to="/regles/competences/rang">rang</NuxtLink> de cette compétence au test. Sinon,
      il n’ajoute pas le rang de la compétence au test.
    </p>
    <p>Les talents suivants forment le personnage au maniement de certaines armes :</p>
    <div class="row">
      <div v-for="talent in talents" :key="talent.id" class="col-xs-12 col-sm-6 col-md-4 mb-4">
        <TalentCard class="d-flex flex-column h-100" :talent="talent" />
      </div>
    </div>
  </main>
</template>

<script setup lang="ts">
import { arrayUtils } from "logitar-js";

import type { Breadcrumb } from "~/types/components";
import type { Talent } from "~/types/game";
import { getTalents } from "~/services/talents";

const parent: Breadcrumb[] = [
  { text: "Équipement", to: "/regles/equipement" },
  { text: "Armes", to: "/regles/equipement/armes" },
];
const slugs: Set<string> = new Set([
  "armes-de-finesse",
  "armes-de-jet",
  "armes-de-tir",
  "armes-improvisees",
  "arts-martiaux",
  "distraction",
  "formation-martiale",
  "melee",
  "orientation",
]);
const title: string = "Formation au maniement d’armes";
const { orderBy } = arrayUtils;

const talents = computed<Talent[]>(() =>
  orderBy(
    getTalents({ requiredTalent: true, skill: true })
      .filter(({ slug }) => slugs.has(slug))
      .map((talent) => ({ ...talent, sort: [talent.tier, talent.slug].join("_") })),
    "sort",
  ),
);

useSeo({
  title,
  description: "Découvrez comment la formation au maniement d’une arme influence les tests d’attaque et l’utilisation efficace des compétences associées.",
});
</script>
