<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>Montures et véhicules pour voyager, transporter des charges ou se préparer à la guerre.</p>
    <div class="row">
      <div v-for="(item, index) in items" :key="index" class="col-xs-12 col-sm-6 mb-4">
        <LinkCard class="d-flex flex-column h-100" :text="item.description" :title="item.title" :to="item.path" />
      </div>
    </div>
    <h2 class="h3">Bêtes</h2>
    <p>
      Les bêtes sont dotées d’une <NuxtLink to="/regles/statistiques/charge">Charge</NuxtLink>, comme toute créature. Elles sont assujetties aux mêmes règles
      d’<NuxtLink to="/regles/equipement/encombrement">encombrement</NuxtLink> que toute autre créature. Leurs
      <NuxtLink to="/regles/aventure/mouvement/voyage">cadences de voyage</NuxtLink> sont également les mêmes que celles du commun des mortels.
    </p>
    <ItemMountList :items="mounts" />
    <h3 id="accessoires" class="h5">Accessoires</h3>
    <p>Des accessoires indispensables pour équiper, contrôler et transporter avec vos montures.</p>
    <ItemMountAccessoryList :items="mountAccessories" />
    <button class="btn btn-lg btn-primary position-fixed bottom-0 end-0 m-3 rounded-circle" @click="scrollToTop">
      <font-awesome-icon icon="fas fa-arrow-up" />
    </button>
  </main>
</template>

<script setup lang="ts">
import { arrayUtils } from "logitar-js";

import type { Breadcrumb } from "~/types/components";
import type { Mount, MountAccessory } from "~/types/items";
import { getMountAccessories, getMounts } from "~/services/items";

const parent: Breadcrumb[] = [{ text: "Équipement", to: "/regles/equipement" }];
const title: string = "Montures et véhicules";
const { orderBy } = arrayUtils;

type MenuItem = {
  path: string;
  title: string;
  description: string;
};
const items: MenuItem[] = [
  {
    path: "/regles/equipement/montures-vehicules/terrestres",
    title: "Véhicules terrestres",
    description: "Chars, chariots, charrettes et traîneaux pour transport et déplacements.",
  },
  {
    path: "/regles/equipement/montures-vehicules/navires",
    title: "Navires",
    description: "Canots, drakkars, galères et voiliers : navires pour guerre, voyage et commerce.",
  },
];

const mountAccessories = ref<MountAccessory[]>(orderBy(getMountAccessories(), "slug"));
const mounts = ref<Mount[]>(orderBy(getMounts(), "slug"));

useSeo({
  title,
  description: "Découvrez les montures, accessoires et véhicules : ânes, chevaux, éléphants, chars et selles pour le transport, le combat et l’aventure.",
});
</script>
