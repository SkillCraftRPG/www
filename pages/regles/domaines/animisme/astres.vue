<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Les esprits appartenant à ce domaine sont associés aux étoiles et aux astres, excluant le Soleil et la Lune. Les animistes s’identifiant à ce domaine
      observent et cartographient les astres et leurs déplacements. Ils habitent en petites communautés là où ils peuvent facilement observer le ciel nocturne.
    </p>
    <!-- Carte des étoiles (Tiers 0) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Carte des étoiles</h2>
      <div class="h5">
        <TarBadge variant="secondary">Tiers&nbsp;0</TarBadge>
      </div>
    </div>
    <p>
      Le personnage acquiert gratuitement le pouvoir <NuxtLink to="/regles/magie/pouvoirs/flamme-sacree">Flamme sacrée</NuxtLink>. Lorsqu’il utilise ce
      <NuxtLink to="/regles/magie/pouvoirs">pouvoir</NuxtLink>, il tire sa puissance des étoiles plutôt que d’une divinité. Lorsqu’il canalise ce pouvoir et que
      le ciel étoilé nocturne est visible, il ne <NuxtLink to="/regles/magie/pouvoirs/energie">dépense</NuxtLink> que la moitié des points d’<NuxtLink
        to="/regles/statistiques/energie"
        >Énergie</NuxtLink
      >.
    </p>
    <p>
      Afin de <NuxtLink to="/regles/magie/pouvoirs/canalisation">canaliser</NuxtLink> ce pouvoir, il doit posséder une carte des étoiles, qui peut prendre la
      forme d’un parchemin, d’une ardoise, d’une peau de bête ou d’un disque de verre ou de cristal. Il peut fabriquer cette carte en effectuant un rituel d’une
      durée minimale d’une <NuxtLink to="/regles/aventure/temps">heure</NuxtLink>. Il peut effectuer ce rituel à la
      <NuxtLink to="/regles/aventure/repos/halte">halte</NuxtLink>, mais il doit pouvoir voir le ciel étoilé nocturne afin d’effectuer ce rituel.
    </p>
    <!-- Forme étoilée (Tiers 1) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Forme étoilée</h2>
      <div class="h5">
        <TarBadge variant="secondary">Tiers&nbsp;1</TarBadge>
      </div>
    </div>
    <p>
      Plutôt que d’assumer une <NuxtLink to="/regles/specialisations/animiste">forme sauvage</NuxtLink>, le personnage peut altérer sa forme et acquérir des
      pouvoirs astraux. Lorsqu’il en fait ainsi, il choisit une des trois constellations suivantes. Le <NuxtLink to="#">signe astrologique</NuxtLink> associé
      apparaît sur sa peau et se met à briller, émettant de la <NuxtLink to="/regles/aventure/environnement/vision">clarté</NuxtLink> dans un rayon de 3 mètres
      et de la <NuxtLink to="/regles/aventure/environnement/vision">pénombre</NuxtLink> dans un rayon de 3 mètres additionnels. La forme prend fin si le
      personnage réutilise cette capacité, y met fin en <NuxtLink to="/regles/combat/deroulement/tour">action libre</NuxtLink>,
      <NuxtLink to="/regles/combat/mort-agonie">meurt</NuxtLink>, devient <NuxtLink to="/regles/combat/conditions/incapable">incapable</NuxtLink>, ou après
      <NuxtLink to="/regles/aventure/temps">10 minutes</NuxtLink>.
    </p>
    <ul>
      <li>
        <i>Aigle.</i> Lorsque le personnage effectue un <NuxtLink to="/regles/competences/tests">test</NuxtLink> d’une
        <NuxtLink to="/regles/competences">compétence</NuxtLink> associée à l’<NuxtLink to="/regles/attributs/intellect">Intellect</NuxtLink> ou aux
        <NuxtLink to="/regles/attributs/sens">Sens</NuxtLink>, ou un <NuxtLink to="/regles/competences/tests/sauvegarde">jet de sauvegarde</NuxtLink> de
        <NuxtLink to="/regles/competences/discipline">Discipline</NuxtLink> afin de
        <NuxtLink to="/regles/combat/activites/concentration">maintenir sa concentration</NuxtLink>, il peut
        <NuxtLink to="/regles/competences/tests/faire-10">Faire 10</NuxtLink> si la somme des <NuxtLink to="/regles/competences/tests/2d10">dés</NuxtLink> est
        inférieure à 10.
      </li>
      <li>
        <i>Amphore.</i> Lorsque le personnage <NuxtLink to="/regles/magie/pouvoirs/canalisation">canalise</NuxtLink> un
        <NuxtLink to="/regles/magie/pouvoirs">pouvoir</NuxtLink> et qu’une créature <NuxtLink to="/regles/combat/degats/soins">récupère</NuxtLink> des points de
        <NuxtLink to="/regles/statistiques/vitalite">Vitalité</NuxtLink> en raison de ce pouvoir, alors le personnage ou une autre créature de son choix située
        à 9 mètres ou moins de sa position récupère un nombre de points de Vitalité égal à 1d8 additionné à la moitié de la
        <NuxtLink to="/regles/statistiques/puissance">Puissance</NuxtLink> du personnage.
      </li>
      <li>
        <i>Archer.</i> Une fois par <NuxtLink to="/regles/combat/deroulement/tour">tour</NuxtLink>, par une
        <NuxtLink to="/regles/combat/deroulement/tour">action</NuxtLink>, le personnage peut lancer un projectile lumineux en direction d’une créature située à
        18 mètres ou moins de sa position. En cas de réussite, l’<NuxtLink to="/regles/magie/effets/attaque">attaque</NuxtLink> inflige
        <NuxtLink to="/regles/combat/degats/jet">1d8 points de dégâts</NuxtLink>{{ " "
        }}<NuxtLink to="/regles/combat/degats/types">radiants</NuxtLink> additionnés à la moitié de la
        <NuxtLink to="/regles/statistiques/puissance">Puissance</NuxtLink> du personnage.
      </li>
    </ul>
    <!-- Présage cosmique (Tiers 2) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Présage cosmique</h2>
      <div class="h5">
        <TarBadge variant="secondary">Tiers&nbsp;2</TarBadge>
      </div>
    </div>
    <p>
      Une fois par <NuxtLink to="/regles/aventure/temps">jour</NuxtLink>, le personnage peut consulter sa carte des étoiles pendant un
      <NuxtLink to="/regles/aventure/repos">repos</NuxtLink>. Il jette <NuxtLink to="/regles/competences/tests/2d10">2d10</NuxtLink> et note le résultat :
      <i>bonus</i> si le dé d’Espérance est supérieur au dé de Damnation ou si <NuxtLink to="/regles/competences/tests/critique">réussite critique</NuxtLink>,
      <i>pénalité</i> si le dé de Damnation est supérieur au dé d’Espérance ou si <NuxtLink to="/regles/competences/tests/critique">échec critique</NuxtLink>.
      Lorsqu’il <NuxtLink to="/regles/aventure/environnement/vision">voit</NuxtLink> une créature située à 9 mètres ou moins de sa position effectuer un
      <NuxtLink to="/regles/competences/tests">test</NuxtLink>, il peut conférer un bonus ou infliger une pénalité de 1d10 en
      <NuxtLink to="/regles/combat/deroulement/tour">réaction</NuxtLink>, selon le résultat noté. Il peut utiliser cette réaction un nombre de fois égal à ses
      <NuxtLink to="/regles/attributs/sens">Sens</NuxtLink> (minimum&nbsp;1) et perd les réactions non utilisées au prochain lever du Soleil.
    </p>
    <!-- Âme étoilée (Tiers 3) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Âme étoilée</h2>
      <div class="h5">
        <TarBadge variant="secondary">Tiers&nbsp;3</TarBadge>
      </div>
    </div>
    <p>
      Lorsque le personnage assume une <strong>forme étoilé</strong>, son âme et son corps fusionnent et il devient partiellement incorporel. Il devient
      <NuxtLink to="/regles/combat/degats/efficacite">résistant</NuxtLink> aux <NuxtLink to="/regles/combat/degats/types">dégâts physiques</NuxtLink>.
    </p>
    <!-- Constellations scintillantes (Tiers 3) -->
    <div class="d-flex align-items-center gap-3">
      <h2 class="h3">Constellations scintillantes</h2>
      <div class="h5">
        <TarBadge variant="secondary">Tiers&nbsp;3</TarBadge>
      </div>
    </div>
    <p>
      Lorsque le personnage assume une <strong>forme étoilé</strong>, il peut changer de constellation une fois par
      <NuxtLink to="/regles/combat/deroulement/tour">tour</NuxtLink> en <NuxtLink to="/regles/combat/deroulement/tour">action libre</NuxtLink>. Également,
      l’effet de la constellation active est amélioré.
    </p>
    <ul>
      <li>
        <i>Aigle.</i> Le personnage est doté d’une <NuxtLink to="/regles/aventure/mouvement/vitesse">vitesse</NuxtLink> de
        <NuxtLink to="/regles/aventure/mouvement/types">lévitation</NuxtLink> de
        <NuxtLink to="/regles/aventure/mouvement/vitesse">4 points de mouvement</NuxtLink> (1 mètre par seconde).
      </li>
      <li>
        <i>Amphore.</i> La <NuxtLink to="/regles/combat/degats/soins">guérison</NuxtLink> augmente à 2d8 +
        <NuxtLink to="/regles/statistiques/puissance">Puissance</NuxtLink> du personnage.
      </li>
      <li>
        <i>Archer.</i> Les <NuxtLink to="/regles/combat/degats">points de dégâts</NuxtLink> infligés augmentent à 2d8 +
        <NuxtLink to="/regles/statistiques/puissance">Puissance</NuxtLink> du personnage.
      </li>
    </ul>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Annexes", to: "/regles/annexes" },
  { text: "Domaines d’animisme", to: "/regles/domaines/animisme" },
];
const title: string = "Astres";

useSeo({
  title,
  description:
    "Découvrez le domaine d’animisme des Astres, où les constellations guident la magie, les présages et la forme étoilée des observateurs du ciel nocturne.",
});
</script>
