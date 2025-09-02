<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Les armes à feu sont une technologie avancée permettant de tirer des <NuxtLink to="/regles/equipement/armes/munitions">projectiles</NuxtLink> à grande
      vitesse grâce à une explosion produite avec de la poudre à canon.
    </p>
    <p>
      Un personnage peut fabriquer une arme à feu s’il est formé avec les
      <NuxtLink to="/regles/equipement/outils">outils de bricoleur, de forgeron et de sculpteur sur bois</NuxtLink>. Il doit posséder tous ces outils et doit
      pouvoir les utiliser. La fabrication d’une arme à feu est généralement complexe, longue et coûteuse.
    </p>
    <h2 class="h3">Table des matières</h2>
    <ul>
      <li>
        <a href="#defectuosite">Défectuosité</a>
      </li>
      <li>
        <a href="#simples">Armes simples</a>
      </li>
      <li>
        <a href="#martiales">Armes martiales</a>
      </li>
    </ul>
    <h2 id="defectuosite" class="h3">Défectuosité</h2>
    <p>
      Lorsqu’une arme à feu est endommagée, les probabilités qu’elle se bloque sont de ⅓ ({{ $n(1 / 3, "percentage") }}). Elle se bloque automatiquement en cas
      d’<NuxtLink to="/regles/competences/tests/critique">échec critique</NuxtLink>.
    </p>
    <p>
      Une arme bloquée ne peut être utilisée tant qu’elle n’est pas débloquée. Elle peut être débloquée par l’action <strong>Objet</strong>, en utilisant des
      <NuxtLink to="/regles/equipement/outils">outils de bricoleur</NuxtLink> et en réussissant un
      <NuxtLink to="/regles/competences/tests">test</NuxtLink> d’<NuxtLink to="/regles/competences/artisanat">Artisanat</NuxtLink> de
      <NuxtLink to="/regles/competences/tests/difficulte">difficulté moyenne</NuxtLink>.
    </p>
    <p>
      Lorsqu’une arme à feu brise, les probabilités qu’elle explose sont de ⅓ ({{ $n(1 / 3, "percentage") }}). Elle explose automatiquement en cas d’<NuxtLink
        to="/regles/competences/tests/critique"
        >échec critique</NuxtLink
      >. L’explosion inflige 9 + 1d6 points de dégâts de feu au personnage tenant l’arme.
    </p>
    <p>
      Toute créature située dans une case adjacente à celle du personnage doit effectuer un
      <NuxtLink to="/regles/competences/tests/sauvegarde">jet de sauvegarde</NuxtLink> d’<NuxtLink to="/regles/competences/acrobaties">Acrobaties</NuxtLink> de
      <NuxtLink to="/regles/competences/tests/difficulte">difficulté moyenne</NuxtLink>. En cas d’échec, la créature reçoit également les points de dégâts.
    </p>
    <h2 id="simples" class="h3">Armes simples</h2>
    <p>Armes simples à feu accessibles, pratiques mais limitées en portée et en puissance.</p>
    <ItemWeaponList :items="simple" multiple />
    <h2 id="martiales" class="h3">Armes martiales</h2>
    <p>Armes martiales à feu puissantes et variées, exigeant entraînement et maîtrise.</p>
    <ItemWeaponList :items="martial" multiple />
    <!-- TODO(fpion): explosifs -->
    <button class="btn btn-lg btn-primary position-fixed bottom-0 end-0 m-3 rounded-circle" @click="scrollToTop">
      <font-awesome-icon icon="fas fa-arrow-up" />
    </button>
  </main>
</template>

<script setup lang="ts">
import { arrayUtils } from "logitar-js";

import type { Breadcrumb } from "~/types/components";
import type { Weapon } from "~/types/items";
import { getFirearms } from "~/services/items";

const parent: Breadcrumb[] = [
  { text: "Équipement", to: "/regles/equipement" },
  { text: "Armes", to: "/regles/equipement/armes" },
];
const title: string = "Armes à feu";
const { orderBy } = arrayUtils;

const firearms = ref<Weapon[]>(getFirearms());

const simple = computed<Weapon[]>(() =>
  orderBy(
    firearms.value.filter(({ category }) => category === "Simple"),
    "slug",
  ),
);
const martial = computed<Weapon[]>(() =>
  orderBy(
    firearms.value.filter(({ category }) => category === "Martial"),
    "slug",
  ),
);

useSeo({
  title,
  description: "🚧",
});
</script>
