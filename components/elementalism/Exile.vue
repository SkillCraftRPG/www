<template>
  <div>
    <h3 id="exil-planaire" class="h5">Exil planaire</h3>
    <p>
      Une fois par <NuxtLink to="/regles/combat/deroulement/tour">tour</NuxtLink>, par deux <NuxtLink to="/regles/combat/deroulement/tour">actions</NuxtLink>,
      le personnage peut dépenser 5 points d’<NuxtLink to="/regles/elementarisme/essence">essence élémentaire</NuxtLink> afin de tenter de bannir une créature
      qu’il peut voir et située à 18 mètres ou moins de sa position dans la dimension élémentaire associée à sa
      <NuxtLink to="/regles/specialisations/elementariste">spécialité</NuxtLink>. Cette capacité échoue si la cible se trouve déjà dans la dimension
      élémentaire.
    </p>
    <p>
      Si la cible n’est pas consentante, le personnage effectue un <NuxtLink to="/regles/competences/tests">test</NuxtLink> d’<NuxtLink
        to="/regles/competences/occultisme"
        >Occultisme</NuxtLink
      >, et la cible effectue un <NuxtLink to="/regles/competences/tests/sauvegarde">jet de sauvegarde</NuxtLink> de
      <NuxtLink to="/regles/competences/discipline">Discipline</NuxtLink> de <NuxtLink to="/regles/competences/tests/difficulte">difficulté</NuxtLink> égale au
      résultat du test. Le jet de sauvegarde est affligé du <NuxtLink to="/regles/competences/tests/avantage-desavantage">désavantage</NuxtLink> si la cible
      provient de la dimension élémentaire. En cas d’échec, la cible est bannie dans la dimension élémentaire pendant
      <NuxtLink to="/regles/aventure/temps">une minute</NuxtLink>. Le personnage doit
      <NuxtLink to="/regles/combat/activites/concentration">se concentrer</NuxtLink> sur cette capacité, comme s’il s’agissait d’un
      <NuxtLink to="/regles/magie/pouvoirs">pouvoir</NuxtLink>. La capacité prend fin si le personnage perd la
      <NuxtLink to="/regles/magie/parametres/duree">concentration</NuxtLink>. La destination est inoffensive envers la cible, et celle-ci est
      <NuxtLink to="/regles/combat/conditions/incapable">incapable</NuxtLink> pendant la durée de cette capacité.
    </p>
    <p>
      Si la cible n’est pas originaire de la dimension élémentaire, ou si la capacité prend fin avant la fin de la minute, alors la cible réapparaît dans
      l’espace où elle se trouvait, ou dans l’<NuxtLink to="/regles/aventure/mouvement/espace-occupe">espace inoccupé</NuxtLink> le plus proche. Si la cible est
      originaire de la dimension élémentaire et que la capacité prend prend fin après une minute, alors la cible est libérée de la capacité, mais elle reste
      dans la dimension élémentaire.
    </p>
  </div>
</template>
