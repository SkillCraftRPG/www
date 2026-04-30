<template>
  <div>
    <h3 id="liaison-mentale" class="h5">Liaison mentale</h3>
    <p>
      Une fois par <NuxtLink to="/regles/combat/deroulement/tour">tour</NuxtLink>, par une <NuxtLink to="/regles/combat/deroulement/tour">action</NuxtLink>, le
      personnage peut toucher un humanoïde consentant afin de lier sa psyché à celle de la cible, ce qui lui permet de
      <NuxtLink to="/regles/competences/perception">percevoir</NuxtLink> par les sens de celle-ci jusqu’à la fin de son prochain tour. Pendant qu’il perçoit par
      les sens de la cible, il bénéficie des <NuxtLink to="/regles/aventure/environnement/vision">sens spéciaux</NuxtLink> qu’elle possède, mais il est
      <NuxtLink to="/regles/combat/conditions/aveugle">aveugle</NuxtLink> et <NuxtLink to="/regles/combat/conditions/assourdi">sourd</NuxtLink> à son propre
      <NuxtLink to="/regles/aventure/environnement">environnement</NuxtLink>. Au début de ses tours subséquents, il peut utiliser une action afin de maintenir
      la liaison jusqu’à la fin de son prochain tour. La liaison est rompue si le personnage ou la cible ne sont plus dans la même dimension.
    </p>
    <h3 id="maitre-cadences" class="h5">Maître des cadences</h3>
    <p>
      Le personnage peut canaliser à volonté le <NuxtLink to="/regles/magie/pouvoirs/niveau">niveau 2</NuxtLink> du pouvoir
      <NuxtLink to="/regles/magie/pouvoirs/temporalite">Temporalité</NuxtLink>. Une fois par jour, il peut également canaliser le pouvoir
      <NuxtLink to="/regles/magie/pouvoirs/temporalite">Temporalité</NuxtLink> à un niveau supérieur. S’il canalise le niveau 3 sans fournir la composante
      <NuxtLink to="/regles/magie/parametres/composantes">Focus</NuxtLink>, la portée est réduite à
      <NuxtLink to="/regles/magie/parametres/portee">Toucher</NuxtLink>, et la durée est réduite à 1d4
      <NuxtLink to="/regles/combat/deroulement">rounds</NuxtLink>. S’il canalise le niveau 4 sans fournir la composante
      <NuxtLink to="/regles/magie/parametres/composantes">Focus</NuxtLink>, alors il ne peut cibler qu’une seule créature.
    </p>
    <p class="text-danger"></p>
    <h3 id="malefice" class="h5">Maléfice</h3>
    <p>
      Lorsque le personnage inflige une malédiction à une créature, par exemple par les
      <NuxtLink to="/regles/magie/pouvoirs/niveau">niveaux 2 et 3</NuxtLink> du pouvoir
      <NuxtLink to="/regles/magie/pouvoirs/benediction">Bénédiction</NuxtLink> (<i>Malédiction</i>), il crée un lien entre lui et cette créature. Ce lien est
      brisé lorsque la malédiction prend fin. Une fois par <NuxtLink to="/regles/combat/deroulement/tour">tour</NuxtLink>, par une
      <NuxtLink to="/regles/combat/deroulement/tour">action</NuxtLink>, il peut infliger un nombre de
      <NuxtLink to="/regles/combat/degats/types">points de dégâts psychiques</NuxtLink> égal à la moitié de sa
      <NuxtLink to="/regles/statistiques/puissance">Puissance</NuxtLink> (minimum&nbsp;1) à cette créature ainsi qu’à toute créature de son choix située à 1,5
      mètres ou moins de la position de la cible. Afin d’utiliser cette capacité, le personnage doit
      <NuxtLink to="/regles/aventure/environnement/vision">voir</NuxtLink> la créature, et celle-ci doit se trouver à 9 mètres ou moins de la position du
      personnage.
    </p>
    <h3 id="mille-visages" class="h5">Mille-visages</h3>
    <p>
      Le personnage peut canaliser à volonté le <NuxtLink to="/regles/magie/pouvoirs/niveau">niveau 2</NuxtLink> du pouvoir
      <NuxtLink to="/regles/magie/pouvoirs/hallucination">Hallucination</NuxtLink> (<i>🚧Disguise Self</i>).
    </p>
    <h3 id="murmure-cimetieres" class="h5">Murmure des cimetières</h3>
    <p>
      Le personnage peut canaliser à volonté le <NuxtLink to="/regles/magie/pouvoirs/niveau">niveau 3</NuxtLink> du pouvoir
      <NuxtLink to="/regles/magie/pouvoirs/danse-macabre">Danse macabre</NuxtLink> (<i>🚧Speak with Dead</i>).
    </p>
  </div>
</template>

<script setup lang="ts">
// TODO(fpion): Disguise Self
// TODO(fpion): Speak with Dead
</script>
