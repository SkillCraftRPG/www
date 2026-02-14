<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Les esprits appartenant à ce domaine sont associés aux ancêtres, au passé et à la mémoire de la terre. Les animistes s’identifiant à ce domaine accordent
      de l’importance et protègent ces éléments, et se rencontrent à des endroits anciens et intouchés par la civilisation.
    </p>
    <!-- Veilleur ancestral (Tiers 0) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Veilleur ancestral</h2>
      <div class="h5">
        <TarBadge variant="secondary">Tiers&nbsp;0</TarBadge>
      </div>
    </div>
    <p>
      Le personnage partage les connaissances de ses ancêtres. Il acquiert gratuitement le talent
      <NuxtLink to="/regles/talents/connaissance">Connaissance</NuxtLink> et se voit conférer un bonus aux
      <NuxtLink to="/regles/competences/tests">tests</NuxtLink> de <NuxtLink to="/regles/competences/connaissance">Connaissance</NuxtLink> variant en fonction
      de son <NuxtLink to="/regles/personnages/progression/tiers">tiers</NuxtLink>.
    </p>
    <table class="table table-striped text-center">
      <thead>
        <tr>
          <th scope="col" class="w-25">Tiers</th>
          <th scope="col" class="w-25">Bonus</th>
          <th scope="col" class="w-25">Tiers</th>
          <th scope="col" class="w-25">Bonus</th>
        </tr>
      </thead>
      <tbody>
        <tr>
          <td>0</td>
          <td>+1d4</td>
          <td>2</td>
          <td>+1d8</td>
        </tr>
        <tr>
          <td>1</td>
          <td>+1d6</td>
          <td>3</td>
          <td>+1d10</td>
        </tr>
      </tbody>
    </table>
    <!-- Compagnon ancestral (Tiers 1) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Compagnon ancestral</h2>
      <div class="h5">
        <TarBadge variant="secondary">Tiers&nbsp;1</TarBadge>
      </div>
    </div>
    <p>
      Plutôt que d’assumer une <NuxtLink to="/regles/specialisations/animiste">forme sauvage</NuxtLink>, le personnage peut invoquer une bête ancestrale
      (préhistorique ou primitive) dans un <NuxtLink to="/regles/aventure/mouvement/espace-occupe">espace inoccupé</NuxtLink> de son choix qu’il peut
      <NuxtLink to="/regles/aventure/environnement/vision">voir</NuxtLink> et situé à 9&nbsp;mètres ou moins de sa position. La bête est
      <NuxtLink to="/regles/aventure/interaction-sociale">amicale</NuxtLink> envers le personnage et ses compagnons, et obéit à ses commandes.
    </p>
    <p>
      En situation de <NuxtLink to="/regles/combat">combat</NuxtLink>, la bête possède son propre
      <NuxtLink to="/regles/combat/deroulement/tour">tour</NuxtLink>, qui est effectué immédiatement après celui du personnage. Elle peut
      <NuxtLink to="/regles/combat/activites/deplacement">se déplacer</NuxtLink> et utiliser sa
      <NuxtLink to="/regles/combat/deroulement/tour">réaction</NuxtLink> par elle-même. Si elle ne reçoit aucune commande, elle se place en
      <NuxtLink to="/regles/combat/activites/defense">position défensive</NuxtLink>, sauf si le personnage est
      <NuxtLink to="/regles/combat/conditions/incapable">incapable</NuxtLink>, dans quel cas elle peut
      <NuxtLink to="/regles/combat/activites">agir</NuxtLink> comme bon lui semble. Une fois par tour, par une
      <NuxtLink to="/regles/combat/deroulement/tour">action</NuxtLink>, le personnage peut donner des commandes à la bête, qui fera de son mieux pour les
      accomplir pendant son tour.
    </p>
    <p>
      La bête disparaît si ses points de <NuxtLink to="/regles/statistiques/vitalite">Vitalité</NuxtLink> chutent à 0, ou si le personnage
      <NuxtLink to="/regles/combat/mort-agonie">meurt</NuxtLink>. Elle disparaît également si le personnage réutilise cette capacité. Lorsqu’elle disparaît,
      tout objet tenu ou porté tombe au sol dans l’espace où elle se tenait.
    </p>
    <!-- Canal ancestral (Tiers 2) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Canal ancestral</h2>
      <div class="h5">
        <TarBadge variant="secondary">Tiers&nbsp;2</TarBadge>
      </div>
    </div>
    <p>
      Lorsque le personnage <NuxtLink to="/regles/magie/pouvoirs/canalisation">canalise</NuxtLink> un
      <NuxtLink to="/regles/magie/pouvoirs">pouvoir</NuxtLink> dont la portée n’est pas <NuxtLink to="/regles/magie/parametres/portee">Soi</NuxtLink>, il peut
      le faire au travers de son compagnon ancestral.
    </p>
    <p>
      Également, le compagnon ancestral se voit conférer l’<NuxtLink to="/regles/competences/tests/avantage-desavantage">avantage</NuxtLink> à ses
      <NuxtLink to="/regles/competences/tests/sauvegarde">jets de sauvegarde</NuxtLink> contre les pouvoirs canalisés par le personnage. Si la réussite d’un tel
      jet de sauvegarde réduit de moitié les <NuxtLink to="/regles/combat/degats">points de dégâts</NuxtLink> reçus, alors il ne reçoit aucun point de dégâts en
      cas de réussite, et réduit de moitié les points de dégâts reçus en cas d’échec.
    </p>
    <!-- Fléau ancestral (Tiers 3) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Fléau ancestral</h2>
      <div class="h5">
        <TarBadge variant="secondary">Tiers&nbsp;3</TarBadge>
      </div>
    </div>
    <p>
      Lorsque le personnage donne une commande à son compagnon ancestral, en <NuxtLink to="/regles/combat/deroulement/tour">action libre</NuxtLink>, il peut
      dépenser jusqu’à 7 tranches de 10 points d’<NuxtLink to="/regles/statistiques/energie">Énergie</NuxtLink> afin de lui conférer les capacités suivantes
      pendant la prochaine <NuxtLink to="/regles/aventure/temps">heure</NuxtLink>.
    </p>
    <ul>
      <li>
        <i>Béhémoth.</i> Si l’<NuxtLink to="/regles/aventure/mouvement/espace-occupe">espace</NuxtLink> le permet, la taille de la bête augmente à
        <NuxtLink to="/regles/especes/taille">Énorme</NuxtLink>. Elle se voit également conférer un nombre de
        <NuxtLink to="/regles/combat/degats/temporaire">points de Vitalité temporaires</NuxtLink> égal au nombre de points d’Énergie dépensés.
      </li>
      <li>
        <i>Grand pas.</i> La bête se voit conférer un nombre de <NuxtLink to="/regles/aventure/mouvement/vitesse">points de mouvement</NuxtLink> supplémentaires
        égal au nombre de tranches de points d’Énergie dépensés.
      </li>
      <li>
        <i>Mutilation.</i> La bête inflige un nombre de <NuxtLink to="/regles/combat/degats">points de dégâts</NuxtLink> supplémentaires égal à 3 + 1d12 + le
        nombre de tranches de points d’Énergie dépensés.
      </li>
    </ul>
    <!-- Titan (Tiers 3) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Titan</h2>
      <div class="h5">
        <TarBadge variant="secondary">Tiers&nbsp;3</TarBadge>
      </div>
    </div>
    <p>
      La taille du compagnon ancestrale augmente à <NuxtLink to="/regles/especes/taille">Grande</NuxtLink>, et il est désormais doté d’une
      <NuxtLink to="/regles/aventure/mouvement/vitesse">vitesse</NuxtLink> d’<NuxtLink to="/regles/aventure/mouvement/types">escalade</NuxtLink> ou de
      <NuxtLink to="/regles/aventure/mouvement/types">nage</NuxtLink> égale à sa vitesse de marche, au choix du personnage..
    </p>
    <p>
      Également, une fois par <NuxtLink to="/regles/combat/deroulement/tour">tour</NuxtLink>, lorsque le personnage
      <NuxtLink to="/regles/combat/degats">blesse</NuxtLink> une créature et que son compagnon ancestral est invoqué, il peut tenter d’<NuxtLink
        to="/regles/combat/conditions/apeure"
        >apeurer</NuxtLink
      >
      cette créature. Si la créature <NuxtLink to="/regles/aventure/environnement/vision">voit</NuxtLink> le personnage et son compagnon ancestral, elle
      effectue un <NuxtLink to="/regles/competences/tests/sauvegarde">jet de sauvegarde</NuxtLink> de
      <NuxtLink to="/regles/competences/discipline">Discipline</NuxtLink> de <NuxtLink to="/regles/competences/tests/difficulte">difficulté</NuxtLink> égale au
      résultat du test de l’<NuxtLink to="/regles/combat/attaque">attaque</NuxtLink> ou de la
      <NuxtLink to="/regles/magie/pouvoirs/canalisation">canalisation</NuxtLink> du personnage. En cas d’échec, elle est apeurée par celui-ci jusqu’à la fin du
      prochain tour du personnage.
    </p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Annexes", to: "/regles/annexes" },
  { text: "Domaines d’animisme", to: "/regles/domaines/animisme" },
];
const title: string = "Ancêtres";

useSeo({
  title,
  description: "Découvrez le domaine des Ancêtres, où mémoire, esprits anciens et bêtes primordiales soutiennent l’animiste et prolongent la force du passé.",
});
</script>
