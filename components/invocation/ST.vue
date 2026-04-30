<template>
  <div>
    <h3 id="sculpteur-chair" class="h5">Sculpteur de la chair</h3>
    <p>
      Le personnage peut canaliser à volonté le <NuxtLink to="/regles/magie/pouvoirs/niveau">niveau 2</NuxtLink> du pouvoir
      <NuxtLink to="/regles/magie/pouvoirs/polymorphisme">Polymorphisme</NuxtLink> en
      <NuxtLink to="/regles/magie/parametres/portee">se désignant comme cible</NuxtLink>. Une fois par jour, il peut également canaliser le niveau 4 du pouvoir
      <NuxtLink to="/regles/magie/pouvoirs/polymorphisme">Polymorphisme</NuxtLink> afin de transformer une créature en bête.
    </p>
    <h3 id="seduction" class="h5">Séduction</h3>
    <p>
      Le personnage se voit conférer un bonus (+5) à ses <NuxtLink to="/regles/competences/tests">tests</NuxtLink> de
      <NuxtLink to="/regles/competences/diplomatie">Diplomatie</NuxtLink>, de <NuxtLink to="/regles/competences/representation">Représentation</NuxtLink> et de
      <NuxtLink to="/regles/competences/tromperie">Tromperie</NuxtLink>.
    </p>
    <h3 id="sortilege-acharne" class="h5">Sortilège acharné</h3>
    <p>
      Lorsque le personnage inflige une malédiction à une créature, par exemple par les
      <NuxtLink to="/regles/magie/pouvoirs/niveau">niveaux 2 et 3</NuxtLink> du pouvoir
      <NuxtLink to="/regles/magie/pouvoirs/benediction">Bénédiction</NuxtLink> (<i>Malédiction</i>), il crée un lien entre lui et cette créature. Ce lien est
      brisé lorsque la malédiction prend fin. Une fois par <NuxtLink to="/regles/combat/deroulement/tour">tour</NuxtLink>, par une
      <NuxtLink to="/regles/combat/deroulement/tour">action</NuxtLink>, il peut se téléporter à 1,5 mètres de la position de cette créature. Afin d’utiliser
      cette capacité, le personnage doit <NuxtLink to="/regles/aventure/environnement/vision">voir</NuxtLink> la créature, et celle-ci doit se trouver à 9
      mètres ou moins de la position du personnage.
    </p>
    <h3 id="talisman" class="h5">Talisman</h3>
    <p>
      Le personnage peut créer un talisman en consacrant une babiole ou un objet de taille <NuxtLink to="/regles/especes/taille">Minuscule</NuxtLink> ou moindre
      par un rituel d’une durée minimale d’<NuxtLink to="/regles/aventure/temps">une heure</NuxtLink> pouvant être effectué à la
      <NuxtLink to="/regles/aventure/repos/halte">halte</NuxtLink>. Si l’objet est <NuxtLink to="/regles/aventure/interaction-objets">brisé</NuxtLink>, le
      talisman est détruit. Si le personnage crée un nouveau talisman, le précédent est détruit : la babiole ou l’objet reste intact, mais il perd les
      propriétés du précédent talisman. Lorsque le personnage ou une créature porte le talisman, ils acquièrent les capacités suivantes :
    </p>
    <ul>
      <li>Le porteur du talisman se voit conférer un bonus (+1d4) à ses <NuxtLink to="/regles/competences/tests/sauvegarde">jets de sauvegarde</NuxtLink>.</li>
      <li>
        Lorsque le porteur du talisman est victime d’une <NuxtLink to="/regles/combat/attaque">attaque</NuxtLink>, si le personnage
        <NuxtLink to="/regles/aventure/environnement/vision">voit</NuxtLink> l’attaquant et qu’une distance d’au plus 9 mètres les sépare, alors le personnage
        peut utiliser sa <NuxtLink to="/regles/combat/deroulement/tour">réaction</NuxtLink> afin d’effectuer un
        <NuxtLink to="/regles/competences/tests">test</NuxtLink> d’<NuxtLink to="/regles/competences/occultisme">Occultisme</NuxtLink> et d’infliger un nombre
        de <NuxtLink to="/regles/combat/degats/types">points de dégâts psychiques</NuxtLink> égal à la moitié de sa
        <NuxtLink to="/regles/statistiques/puissance">Puissance</NuxtLink> (minimum&nbsp;1) à l’attaquant. Si l’attaquant échoue un
        <NuxtLink to="/regles/competences/tests/sauvegarde">jet de sauvegarde</NuxtLink> de
        <NuxtLink to="/regles/competences/discipline">Discipline</NuxtLink> de <NuxtLink to="/regles/competences/tests/difficulte">difficulté</NuxtLink> égale
        au résultat du test, alors il tombe <NuxtLink to="/regles/combat/conditions/renverse">renversé au sol</NuxtLink> ou est repoussé de 3 mètres, au choix
        du personnage.
      </li>
      <li>
        Une fois par <NuxtLink to="/regles/combat/deroulement/tour">tour</NuxtLink>, par une <NuxtLink to="/regles/combat/deroulement/tour">action</NuxtLink>,
        le personnage peut se téléporter à 1,5 mètres ou moins de la position du porteur du talisman s’il
        <NuxtLink to="/regles/aventure/environnement/vision">voit</NuxtLink>
        le porteur du talisman et qu’une distance d’au plus 9 mètres les sépare.
      </li>
    </ul>
  </div>
</template>
