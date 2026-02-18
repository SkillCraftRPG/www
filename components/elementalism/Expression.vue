<template>
  <div>
    <h3 id="expression" class="h5">Expression élémentaire</h3>
    <p>
      Une fois par <NuxtLink to="/regles/combat/deroulement/tour">tour</NuxtLink>, par une <NuxtLink to="/regles/combat/deroulement/tour">action</NuxtLink>, le
      personnage peut dépenser 4 points d’<NuxtLink to="/regles/elementarisme/essence">essence élémentaire</NuxtLink> afin d’invoquer une bête élémentaire de
      niveau 3 et moins dans un <NuxtLink to="/regles/aventure/mouvement/espace-occupe">espace inoccupé</NuxtLink> de son choix qu’il peut
      <NuxtLink to="/regles/aventure/environnement/vision">voir</NuxtLink> et situé à 9 mètres ou moins de sa position. La bête est
      <NuxtLink to="/regles/aventure/interaction-sociale">amicale</NuxtLink> envers le personnage et ses compagnons, et obéit à ses commandes. La bête partage
      ses <NuxtLink to="/regles/competences/perception">sens</NuxtLink> avec ceux du personnage, et lorsque celui-ci
      <NuxtLink to="/regles/magie/pouvoirs/canalisation">canalise</NuxtLink> un <NuxtLink to="/regles/magie/pouvoirs">pouvoir</NuxtLink> dont la portée n’est
      pas <NuxtLink to="/regles/magie/parametres/portee">Soi</NuxtLink>, il peut le faire au travers de la bête.
    </p>
    <p>
      En situation de <NuxtLink to="/regles/combat">combat</NuxtLink>, la bête possède son propre tour, qui est effectué immédiatement après celui du
      personnage. Elle peut <NuxtLink to="/regles/combat/activites/deplacement">se déplacer</NuxtLink> et utiliser sa
      <NuxtLink to="/regles/combat/deroulement/tour">réaction</NuxtLink> par elle-même. Si elle ne reçoit aucune commande, elle se place en
      <NuxtLink to="/regles/combat/activites/defense">position défensive</NuxtLink>, sauf si le personnage est
      <NuxtLink to="/regles/combat/conditions/incapable">incapable</NuxtLink>, dans quel cas elle peut
      <NuxtLink to="/regles/combat/activites">agir</NuxtLink> comme bon lui semble. Une fois par tour, par une action, le personnage peut donner des commandes à
      la bête, qui fera de son mieux pour les accomplir pendant son tour. En réaction, lorsque le personnage reçoit des
      <NuxtLink to="/regles/combat/degats">points de dégâts</NuxtLink>, la bête peut s’interposer entre le personnage la source des dégâts. En se déplaçant à la
      moitié de sa <NuxtLink to="/regles/aventure/mouvement/vitesse">vitesse</NuxtLink>, si elle peut traverser l’espace du personnage, puis terminer son
      <NuxtLink to="/regles/aventure/mouvement">déplacement</NuxtLink> dans un espace inoccupé, alors elle reçoit tous les points de dégâts et le personnage
      n’en reçoit aucun.
    </p>
    <p>
      L’invocation dure une minute, et le personnage doit <NuxtLink to="/regles/combat/activites/concentration">se concentrer</NuxtLink> sur celle-ci, comme
      s’il se <NuxtLink to="/regles/magie/parametres/duree">concentrait</NuxtLink> sur un pouvoir. La bête disparaît après cette période de
      <NuxtLink to="/regles/aventure/temps">temps</NuxtLink>, si le personnage perd la concentration, si les points de
      <NuxtLink to="/regles/statistiques/vitalite">Vitalité</NuxtLink> de la bête chutent à 0, ou si la distance séparant le personnage et la bête dépasse 18
      mètres.
    </p>
  </div>
</template>
