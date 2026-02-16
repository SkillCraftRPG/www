<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Les esprits appartenant à ce domaine sont associés au feu, à la destruction et au renouveau apporté par cette destruction. Les animistes s’identifiant à
      ce domaine considèrent le feu comme un élément sacré, et se rencontrent parfois aux endroits ravagés par un incendie ou un feu de forêt.
    </p>
    <!-- Adepte des flammes (Tiers 0) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Adepte des flammes</h2>
      <div class="h5">
        <TarBadge variant="secondary">Tiers&nbsp;0</TarBadge>
      </div>
    </div>
    <p>Le personnage acquiert gratuitement le talent <NuxtLink to="/regles/talents/elementarisme">Élémentarisme</NuxtLink> pour l’élément <i>Feu</i>.</p>
    <!-- Invocation incendiaire (Tiers 1) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Invocation incendiaire</h2>
      <div class="h5">
        <TarBadge variant="secondary">Tiers&nbsp;1</TarBadge>
      </div>
    </div>
    <p>
      Plutôt que d’assumer une <NuxtLink to="/regles/specialisations/animiste">forme sauvage</NuxtLink>, le personnage peut invoquer un esprit incendiaire dans
      un <NuxtLink to="/regles/aventure/mouvement/espace-occupe">espace inoccupé</NuxtLink> de son choix qu’il peut
      <NuxtLink to="/regles/aventure/environnement/vision">voir</NuxtLink> et situé à 9 mètres ou moins de sa position. L’esprit est
      <NuxtLink to="/regles/aventure/interaction-sociale">amical</NuxtLink> envers le personnage et ses compagnons, et obéit à ses commandes. Le personnage
      détermine l’apparence de l’esprit : certains prennent la forme d’une silhouette humanoïde faite de branches noueuses embrasées, tandis que d’autres
      ressemblent à des bêtes entourées de flammes.
    </p>
    <p>
      Le personnage effectue un <NuxtLink to="/regles/competences/tests">test</NuxtLink> d’<NuxtLink to="/regles/competences/occultisme">Occultisme</NuxtLink>,
      et toute autre créature située à 3 mètres ou moins de l’esprit au moment de son apparition doit effectuer un
      <NuxtLink to="/regles/competences/tests/sauvegarde">jet de sauvegarde</NuxtLink> d’<NuxtLink to="/regles/competences/acrobaties">Acrobaties</NuxtLink> de
      <NuxtLink to="/regles/competences/tests/difficulte">difficulté</NuxtLink> égale au résultat du test du personnage. En cas d’échec, une créature reçoit
      <NuxtLink to="/regles/combat/degats/jet">2d6 points de dégâts</NuxtLink> de <NuxtLink to="/regles/combat/degats/types">feu</NuxtLink> additionnés à la
      moitié de la <NuxtLink to="/regles/statistiques/puissance">Puissance</NuxtLink> du personnage.
    </p>
    <p>
      En situation de <NuxtLink to="/regles/combat">combat</NuxtLink>, l’esprit possède son propre
      <NuxtLink to="/regles/combat/deroulement/tour">tour</NuxtLink>, qui est effectué immédiatement après celui du personnage. Il peut
      <NuxtLink to="/regles/combat/activites/deplacement">se déplacer</NuxtLink> et utiliser sa
      <NuxtLink to="/regles/combat/deroulement/tour">réaction</NuxtLink> par lui-même. S’il ne reçoit aucune commande, il se place en
      <NuxtLink to="/regles/combat/activites/defense">position défensive</NuxtLink>, sauf si le personnage est
      <NuxtLink to="/regles/combat/conditions/incapable">incapable</NuxtLink>, dans quel cas il peut
      <NuxtLink to="/regles/combat/activites">agir</NuxtLink> comme bon lui semble. Une fois par tour, par une
      <NuxtLink to="/regles/combat/deroulement/tour">action</NuxtLink>, le personnage peut donner des commandes à l’esprit, qui fera de son mieux pour les
      accomplir pendant son tour.
    </p>
    <p>
      L’esprit disparaît après <NuxtLink to="/regles/aventure/temps">une heure</NuxtLink>, si ses points de
      <NuxtLink to="/regles/statistiques/vitalite">Vitalité</NuxtLink> chutent à 0, ou si le personnage
      <NuxtLink to="/regles/combat/mort-agonie">meurt</NuxtLink>. Il disparaît également si le personnage réutilise cette capacité.
    </p>
    <!-- Connexion incendiaire (Tiers 2) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Connexion incendiaire</h2>
      <div class="h5">
        <TarBadge variant="secondary">Tiers&nbsp;2</TarBadge>
      </div>
    </div>
    <p>
      Lorsque le personnage <NuxtLink to="/regles/magie/pouvoirs/canalisation">canalise</NuxtLink> un
      <NuxtLink to="/regles/magie/pouvoirs">pouvoir</NuxtLink> dont la portée n’est pas <NuxtLink to="/regles/magie/parametres/portee">Soi</NuxtLink>, il peut
      le faire au travers de son esprit incendiaire.
    </p>
    <p>
      Également, lorsqu’il canalise un pouvoir prodiguant des <NuxtLink to="/regles/combat/degats/soins">soins</NuxtLink> ou infligeant des
      <NuxtLink to="/regles/combat/degats">points de dégâts</NuxtLink> de <NuxtLink to="/regles/combat/degats/types">feu</NuxtLink>, il peut ajouter 1d12 aux
      soins prodigués ou points de dégâts infligés à une créature.
    </p>
    <!-- Cautérisation (Tiers 3) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Cautérisation</h2>
      <div class="h5">
        <TarBadge variant="secondary">Tiers&nbsp;3</TarBadge>
      </div>
    </div>
    <p>
      Lorsqu’une créature de taille <NuxtLink to="/regles/especes/taille">Petite</NuxtLink> ou supérieure
      <NuxtLink to="/regles/combat/mort-agonie">meurt</NuxtLink> en étant située à 9 mètres ou moins du personnage ou de son esprit incendiaire, une flamme
      spectrale inoffensive s’élève dans cet <NuxtLink to="/regles/aventure/mouvement/espace-occupe">espace</NuxtLink> et y scintille pendant
      <NuxtLink to="/regles/aventure/temps">une minute</NuxtLink>. Lorsque le personnage
      <NuxtLink to="/regles/aventure/environnement/vision">voit</NuxtLink> une créature entrer dans cet espace, il peut utiliser sa
      <NuxtLink to="/regles/combat/deroulement/tour">réaction</NuxtLink> afin d’éteindre la flamme, prodiguant des
      <NuxtLink to="/regles/combat/degats/soins">soins</NuxtLink> ou infligeant des <NuxtLink to="/regles/combat/degats">points de dégâts</NuxtLink> de
      <NuxtLink to="/regles/combat/degats/types">feu</NuxtLink> à la créature. Le nombre de points de
      <NuxtLink to="/regles/statistiques/vitalite">Vitalité</NuxtLink> récupérés ou de points de dégâts infligés est égal à 2d10 additionnés à la
      <NuxtLink to="/regles/statistiques/puissance">Puissance</NuxtLink> du personnage. Le personnage dépense un nombre de points d’<NuxtLink
        to="/regles/statistiques/energie"
        >Énergie</NuxtLink
      >
      égal à la moitié de ce nombre.
    </p>
    <!-- Renouveau ardent (Tiers 3) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Renouveau ardent</h2>
      <div class="h5">
        <TarBadge variant="secondary">Tiers&nbsp;3</TarBadge>
      </div>
    </div>
    <p>
      Lorsque les points de <NuxtLink to="/regles/statistiques/vitalite">Vitalité</NuxtLink> du personnage chutent à 0 et qu’il se trouve à 36 mètres ou moins
      de la position de son esprit incendiaire, l’esprit transfert sa Vitalité courante au personnage, sans dépasser la Vitalité maximale du personnage. Le
      personnage doit compléter une <NuxtLink to="/regles/aventure/repos/sommeil">nuit de sommeil</NuxtLink> afin de réutiliser cette capacité.
    </p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Annexes", to: "/regles/annexes" },
  { text: "Domaines d’animisme", to: "/regles/domaines/animisme" },
];
const title: string = "Feu";

useSeo({
  title,
  description: "Découvrez le domaine d’animisme du Feu, où destruction et renouveau s’incarnent dans un esprit incendiaire lié à la puissance élémentaire.",
});
</script>
