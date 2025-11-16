<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>Certains artefacts magiques exigent une action particulière afin d’être utilisés, comme les tenir en main ou prononcer une formule dédiée.</p>
    <p>Chaque artefact ou famille d’artefact précise la manière dont il doit être utilisé.</p>
    <p>
      Un artefact nécessite toujours au moins une <NuxtLink to="/regles/combat/deroulement/tour">action</NuxtLink> afin d’être utilisé, et il ne peut être
      utilisé qu’une seule fois par <NuxtLink to="/regles/combat/deroulement/tour">tour</NuxtLink>, sauf si indication contraire.
    </p>
    <h2 class="h3">Mot de commande</h2>
    <p>Un <strong>mot de commande</strong> est une formule verbale qui doit être prononcée afin d’activer un artefact.</p>
    <p>Un artefact reposant sur un mot de commande ne peut pas être utilisé dans une zone où le son est supprimé, comme sous un effet de silence.</p>
    <h2 class="h3">Consommables</h2>
    <p>Certains artefacts sont conçus pour être consommés lors de leur utilisation.</p>
    <p>Les potions et élixirs doivent être bus, les huiles appliquées sur le corps, et les parchemins se consument en effaçant leur écriture lorsque lus.</p>
    <p>Une fois utilisés, ces artefacts perdent définitivement leur magie s’ils ne sont pas détruits.</p>
    <h2 class="h3">Charges</h2>
    <p>Certains artefacts possèdent un nombre limité de charges nécessaires à l’utilisation de leurs propriétés.</p>
    <p>
      Le nombre de charges restantes est révélé par un l’<NuxtLink to="#">Identification</NuxtLink> ou lorsqu’un personnage s’<NuxtLink
        to="/regles/magie/artefacts/harmonisation"
        >harmonise</NuxtLink
      >
      avec l’artefact.
    </p>
    <p>Lorsqu’un artefact perd ou gagne des charges, la créature harmonisée en est automatiquement informée.</p>
    <h2 class="h3">Pouvoir</h2>
    <p>Certains artefacts permettent à leur porteur d’utiliser un <NuxtLink to="/regles/magie/pouvoirs">pouvoir</NuxtLink> directement depuis l’artefact.</p>
    <p>
      Ce pouvoir est <NuxtLink to="/regles/magie/pouvoirs/canalisation">canalisé</NuxtLink> au
      <NuxtLink to="/regles/magie/pouvoirs/niveau">niveau</NuxtLink> indiqué, n’engendre aucune
      <NuxtLink to="/regles/magie/pouvoirs/energie">dépense d’Énergie</NuxtLink>, et ne nécessite aucune composante
      <NuxtLink to="/regles/magie/parametres/composantes">Focus</NuxtLink> ni <NuxtLink to="/regles/magie/parametres/composantes">Matériel</NuxtLink>, sauf
      indication contraire.
    </p>
    <p>
      Il conserve son <NuxtLink to="/regles/magie/parametres/incantation">incantation</NuxtLink>, sa
      <NuxtLink to="/regles/magie/parametres/duree">durée</NuxtLink> (incluant la
      <NuxtLink to="/regles/combat/activites/concentration">Concentration</NuxtLink>) et sa
      <NuxtLink to="/regles/magie/parametres/portee">portée</NuxtLink> habituelle, sauf si indication contraire.
    </p>
    <p>Plusieurs artefacts, telles certaines potions, ne déclenchent pas exactement un pouvoir mais en confèrent directement les effets.</p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Magie", to: "/regles/magie" },
  { text: "Artefacts", to: "/regles/magie/artefacts" },
];
const title: string = "Utilisation";

useSeo({
  title,
  description:
    "Découvrez les règles d’utilisation des artefacts magiques : actions requises, mots de commande, charges, consommables et fonctionnement des pouvoirs.",
});
</script>
