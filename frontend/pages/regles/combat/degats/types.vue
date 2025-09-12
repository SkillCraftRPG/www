<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb active="Types" :parent="parent" />
    <p>Chaque source de dégâts est associée à un ou plusieurs types.</p>
    <p>
      Les différents types de dégâts n’ont pas de règles spécifiques s’appliquant à chacun. Cependant, certains types de dégâts n’ont pas la même
      <NuxtLink to="/regles/combat/degats/efficacite">efficacité</NuxtLink> contre différents objets ou créatures.
    </p>
    <p>Voici les différents types de dégâts et des exemples pour chaque type.</p>
    <ul class="text-danger">
      <li>Acid: The corrosive spray of a black dragon’s breath and the dissolving enzymes secreted by a Black Pudding deal acid damage.</li>
      <li>Bludgeoning: Blunt force attacks—hammers, falling, constriction, and the like—deal bludgeoning damage.</li>
      <li>Cold: The infernal chill radiating from an Ice Devil’s spear and the frigid blast of a white dragon’s breath deal cold damage.</li>
      <li>Fire: Red dragons breathe fire, and many spells conjure flames to deal fire damage.</li>
      <li>
        Force: Force is pure magical energy focused into a damaging form. Most effects that deal force damage are spells, including magic missile and spiritual
        weapon.
      </li>
      <li>Lightning: A lightning bolt spell and a blue dragon’s breath deal lightning damage.</li>
      <li>Necrotic: Necrotic damage, dealt by certain undead and a spell such as chill touch, withers matter and even the soul.</li>
      <li>Piercing: Puncturing and impaling attacks, including spears and monsters’ bites, deal piercing damage.</li>
      <li>Poison: Venomous stings and the toxic gas of a green dragon’s breath deal poison damage.</li>
      <li>Psychic: Mental abilities such as a mind flayer’s psionic blast deal psychic damage.</li>
      <li>
        Radiant: Radiant damage, dealt by a cleric’s flame strike spell or an angel’s smiting weapon, sears the flesh like fire and overloads the spirit with
        power.
      </li>
      <li>Slashing: Swords, axes, and monsters’ claws deal slashing damage.</li>
      <li>Thunder: A concussive burst of sound, such as the effect of the thunderwave spell, deals thunder damage.</li>
    </ul>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Combat", to: "/regles/combat" },
  { text: "Dégâts", to: "/regles/combat/degats" },
];
const title: string = "Types de dégâts";

useSeo({
  title,
  description: "🚧",
});
</script>
