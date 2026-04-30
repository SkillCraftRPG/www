<template>
  <div>
    <h3 id="oeil-distant" class="h5">Œil distant</h3>
    <p>
      Une fois par jour, le personnage peut canaliser le <NuxtLink to="/regles/magie/pouvoirs/niveau">niveau 4</NuxtLink> du pouvoir
      <NuxtLink to="/regles/magie/pouvoirs/clairvoyance">Clairvoyance</NuxtLink>. Il peut également discerner la forme réelle de toute créature assumant une
      forme différente ou altérée par une illusion. Afin d’utiliser cette capacité, il doit
      <NuxtLink to="/regles/aventure/environnement/vision">voir</NuxtLink> cette créature, et celle-ci doit se trouver à 9 mètres ou moins de la position du
      personnage.
    </p>
    <h3 id="paroles-envouteuses" class="h5">Paroles envoûteuses</h3>
    <p>
      Une fois par jour, le personnage peut canaliser le <NuxtLink to="/regles/magie/pouvoirs/niveau">niveau 4</NuxtLink> du pouvoir
      <NuxtLink to="/regles/magie/pouvoirs/obligation">Obligation</NuxtLink> (<i>🚧Compulsion</i>) en fredonnant une mélodie énigmatique.
    </p>
    <h3 id="pestilence" class="h5">Pestilence</h3>
    <p>
      Une fois par <NuxtLink to="/regles/combat/deroulement/tour">tour</NuxtLink>, par une <NuxtLink to="/regles/combat/deroulement/tour">action</NuxtLink>, le
      personnage peut s’entourer d’une aura fétide ressemblant à des mouches qui bourdonnent. La portée de l’aura est de 1,5 mètres, et elle ne traverse pas
      l’<NuxtLink to="/regles/combat/attaque/abri">abri total</NuxtLink>. L’aura prend fin si le personnage tombe
      <NuxtLink to="/regles/combat/conditions/incapable">incapable</NuxtLink> ou s’il y met fin par une action. Elle confère l’<NuxtLink
        to="/regles/competences/tests/avantage-desavantage"
        >avantage</NuxtLink
      >
      aux <NuxtLink to="/regles/competences/tests">tests</NuxtLink> de <NuxtLink to="/regles/competences/representation">Représentation</NuxtLink> du personnage
      effectués afin d’intimider une ou plusieurs créatures, mais afflige du
      <NuxtLink to="/regles/competences/tests/avantage-desavantage">désavantage</NuxtLink> ses autres tests de Représentation ainsi que ses tests de
      <NuxtLink to="/regles/competences/diplomatie">Diplomatie</NuxtLink> et de <NuxtLink to="/regles/competences/tromperie">Tromperie</NuxtLink>. Toute
      créature débutant son tour dans la portée de l’aura reçoit un nombre de <NuxtLink to="/regles/combat/degats">points de dégâts</NuxtLink> de
      <NuxtLink to="/regles/combat/degats/types">poison</NuxtLink> égal à la moitié de la
      <NuxtLink to="/regles/statistiques/puissance">Puissance</NuxtLink> (minimum&nbsp;1) du personnage. Le personnage doit faire
      <NuxtLink to="/regles/aventure/repos/halte">halte</NuxtLink> ou compléter une
      <NuxtLink to="/regles/aventure/repos/sommeil">nuit de sommeil</NuxtLink> afin de réutiliser cette capacité.
    </p>
  </div>
</template>

<script setup lang="ts">
// TODO(fpion): Compulsion
</script>
