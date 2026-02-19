<template>
  <div>
    <h3 id="expulsion-planaire" class="h5">Expulsion planaire</h3>
    <p>
      Une fois par <NuxtLink to="/regles/combat/deroulement/tour">tour</NuxtLink>, par une <NuxtLink to="/regles/combat/deroulement/tour">action</NuxtLink>, le
      personnage peut dépenser un point d’<NuxtLink to="/regles/elementarisme/essence">essence élémentaire</NuxtLink> afin de tenter d’expulser une créature
      qu’il peut voir et située à 9 mètres ou moins de sa position à la frontière entre le monde matériel et une dimension élémentaire, dans la dimension
      spirituelle. La cible doit se trouver dans le monde matériel ou dans une dimension élémentaire.
    </p>
    <p>
      Si la cible n’est pas consentante, le personnage effectue un <NuxtLink to="/regles/competences/tests">test</NuxtLink> d’<NuxtLink
        to="/regles/competences/occultisme"
        >Occultisme</NuxtLink
      >, et la cible effectue un <NuxtLink to="/regles/competences/tests/sauvegarde">jet de sauvegarde</NuxtLink> de
      <NuxtLink to="/regles/competences/discipline">Discipline</NuxtLink> de <NuxtLink to="/regles/competences/tests/difficulte">difficulté</NuxtLink> égale au
      résultat du test. Le jet de sauvegarde est affligé du <NuxtLink to="/regles/competences/tests/avantage-desavantage">désavantage</NuxtLink> si la cible
      provient de la dimension élémentaire. En cas d’échec, la cible est transportée dans la dimension spirituelle jusqu’au début du prochain tour du
      personnage. L’emplacement est inoffensif envers celle-ci, et elle est <NuxtLink to="/regles/combat/conditions/incapable">incapable</NuxtLink> pendant
      qu’elle s’y trouve. La cible réapparaît dans l’espace où elle se trouvait, ou dans l’<NuxtLink to="/regles/aventure/mouvement/espace-occupe"
        >espace inoccupé</NuxtLink
      >
      le plus proche.
    </p>
  </div>
</template>
