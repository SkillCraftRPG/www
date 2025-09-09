<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb active="Propriétés" :parent="parent" />
    <p>La plupart des armes sont dotées d’au moins une propriété.</p>
    <p>Ces propriétés sont décrites ci-dessous, et elles sont toutes compatibles entre elles.</p>
    <ul>
      <li>
        <strong>Allonge.</strong> Les armes dotées d’une allonge ont une portée supplémentaire de 1,5 mètres, permettant au personnage d’atteindre les créatures
        situées à 3 mètres ou moins de sa position.
      </li>
      <li>
        <strong>Barillet.</strong> Le nombre de <NuxtLink to="/regles/equipement/armes/munitions">munitions</NuxtLink> indiquées sont chargées en même temps
        dans l’arme. Chaque munition peut être tirée individuellement avant que l’arme ne doive être rechargée.
      </li>
      <li>
        <strong>Chargement.</strong> L’action <i>Charger une arme</i> doit être utilisée afin d’installer une ou plusieurs munitions dans une arme possédant
        cette propriété.
      </li>
      <li>
        <strong>Deux mains.</strong> Lorsqu’une arme possède cette propriété, elle nécessite d’être maniée à deux mains. La créature ne peut utiliser un
        <NuxtLink to="/regles/equipement/boucliers">bouclier</NuxtLink>, une autre arme ou un objet si elle ne possède pas plus de deux bras et mains.
      </li>
      <li>
        <strong>Dispersion.</strong> L’arme disperse des projectiles dans un cône de longueur égale à sa portée. Toute créature touchée reçoit les points de
        dégâts. Un dé supplémentaire est ajouté aux points de dégâts reçus par une créature touchée se trouvant dans une case adjacente à celle de l’attaquant
        (tir à bout portant).
      </li>
      <li>
        <strong>Finesse.</strong> Si le personnage a acquis le talent <NuxtLink to="/regles/talents/armes-de-finesse">Armes de finesse</NuxtLink>, il peut
        remplacer le <NuxtLink to="/regles/competences/tests">test</NuxtLink> de <NuxtLink to="/regles/competences/melee">Mêlée</NuxtLink> par un test
        d’<NuxtLink to="/regles/competences/orientation">Orientation</NuxtLink> lorsqu’il effectue une attaque avec cette arme. Lorsqu’il procède ainsi, il
        ajoute sa <NuxtLink to="/regles/statistiques/precision">Précision</NuxtLink> plutôt que sa <NuxtLink to="/regles/statistiques/force">Force</NuxtLink>
        aux points de dégâts infligés.
      </li>
      <li>
        <strong>Jet.</strong> Si le personnage a acquis le talent <NuxtLink to="/regles/talents/armes-de-jet">Armes de jet</NuxtLink>, il peut remplacer le test
        d’<NuxtLink to="/regles/competences/orientation">Orientation</NuxtLink> par un test de
        <NuxtLink to="/regles/competences/melee">Mêlée</NuxtLink> lorsqu’il effectue une attaque avec cette arme. Lorsqu’il procède ainsi, il ajoute sa
        <NuxtLink to="/regles/statistiques/force">Force</NuxtLink> plutôt que sa <NuxtLink to="/regles/statistiques/precision">Précision</NuxtLink> aux points
        de dégâts infligés.
      </li>
      <li>
        <strong>Légère.</strong> Permet à un personnage de combattre avec une arme dans chaque main sans subir une pénalité supplémentaire lorsqu’il effectue
        une attaque. Chaque arme doit être dotée de cette propriété.
      </li>
      <li>
        <strong>Lourde.</strong> Les armes lourdes imposent le <NuxtLink to="/regles/competences/tests/avantage-desavantage">désavantage</NuxtLink> aux tests
        d’attaque pour les créatures de <NuxtLink to="/regles/especes/taille">taille petite ou inférieure</NuxtLink>.
      </li>
      <li>
        <strong>Munition. </strong> Une arme à munition nécessite l’utilisation d’une munition afin de pouvoir être utilisée. Ces armes doivent être utilisées
        par l’action <NuxtLink to="/regles/combat/activites/viser-tirer">Viser et tirer</NuxtLink>.
      </li>
      <li><strong>Spéciale.</strong> Ces armes sont gouvernées par des règles spéciales qui sont spécifiques à chaque arme.</li>
      <li>
        <strong>Versatile.</strong> Une arme versatile peut être utilisée à une ou deux mains. Lorsqu’elle est utilisée à deux mains, le nombre potentiel de
        points de dégâts infligés par l’arme augmente.
      </li>
    </ul>
    <h2 class="h3">Portée</h2>
    <p>
      Les armes dotées de la propriété <strong>Jet</strong> ou <strong>Munition</strong> ont deux portées indiquées entre parenthèses après la propriété, par
      exemple <i>Jet (4/12)</i> ou <i>Munition (30/120)</i>.
    </p>
    <p>Ces portées représentent un nombre de cases sur la grille de combat. Chaque case possède généralement une arête de 1,5 mètres.</p>
    <p>Lorsqu’une attaque à distance est effectuée, la distance entre l’attaquant et sa cible est comparée avec ces portées.</p>
    <ul>
      <li>Si la distance est inférieure ou égale à la première (et plus petite) des deux portées, le test de l’attaque est effectué normalement.</li>
      <li>
        Si la distance est supérieure à la première (et plus petite) mais inférieure ou égale à la seconde (et plus grande) des deux portées, le test de
        l’attaque est affligé du
        <NuxtLink to="/regles/competences/tests/avantage-desavantage">désavantage</NuxtLink>.
      </li>
      <li>Si la distance est supérieure à la seconde (et plus grande) des deux portées, le test de l’attaque échoue automatiquement.</li>
    </ul>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Équipement", to: "/regles/equipement" },
  { text: "Armes", to: "/regles/equipement/armes" },
];
const title: string = "Propriétés des armes";

useSeo({
  title,
  description:
    "Découvrez les propriétés d’armes et leurs effets en combat, incluant allonge, finesse, jet, munition, portée, ainsi que leurs interactions tactiques.",
});
</script>
