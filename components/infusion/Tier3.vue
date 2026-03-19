<template>
  <div>
    <h2 id="tiers-3" class="h3">Infusions de tiers 3</h2>
    <!-- Carapace de propulsion -->
    <InfusionInfo armor attunement id="Carapace de propulsion" name="Carapace de propulsion">
      <p>L’<NuxtLink to="/regles/equipement/armures">armure</NuxtLink> confère les capacités suivantes à son porteur.</p>
      <ul>
        <li>Bonus d’un <NuxtLink to="/regles/aventure/mouvement/vitesse">point de mouvement</NuxtLink> (0,25 mètres par seconde).</li>
        <li>L’armure ne peut lui être <NuxtLink>retirée</NuxtLink> sans son consentement.</li>
        <li>L’armure remplace les membres perdus de la cible. Ces membres artificiels fonctionnement exactement comme les membres qu’ils remplacent.</li>
        <li>
          L’armure est munie de gantelets, qui peuvent être utilisée comme une <NuxtLink to="/regles/equipement/armes">arme</NuxtLink> magique lorsqu’ils ne
          tiennent aucun <NuxtLink to="/regles/equipement">objet</NuxtLink>. Le porteur est
          <NuxtLink to="/regles/equipement/armes/formation">formé</NuxtLink> avec ces gantelets, et ceux-ci infligent
          <NuxtLink to="/regles/combat/degats/jet">1d8</NuxtLink> points de <NuxtLink to="/regles/combat/degats">dégâts</NuxtLink> de
          <NuxtLink to="/regles/combat/degats/types">force</NuxtLink>. Ils peuvent être utilisés par une
          <NuxtLink to="/regles/combat/attaque/melee">attaque de mêlée</NuxtLink>. Ils peuvent également être utilisés par une
          <NuxtLink to="/regles/combat/attaque/distance">attaque à distance</NuxtLink>, étant dotés de la propriété&nbsp;<NuxtLink
            to="/regles/equipement/armes/proprietes"
            >Jet&nbsp;(6/18)</NuxtLink
          >. Lorsqu’ils sont utilisés à distance, ils se détachent afin de percuter la cible, puis retournent s’attacher à l’armure.
        </li>
      </ul>
    </InfusionInfo>
    <!-- Casque de conscience -->
    <InfusionInfo armor="Casque" attunement id="casque-de-conscience" name="Casque de conscience">
      <p>
        Lorsque son porteur effectue un test d’<NuxtLink to="/regles/combat/deroulement/initiative">Initiative</NuxtLink>, il peut jeter 2d10 et conserver le dé
        de son choix. Également, il ne peut être <NuxtLink to="/regles/combat/deroulement/surprise">surpris</NuxtLink> s’il n’est pas
        <NuxtLink to="/regles/combat/conditions/incapable">incapable</NuxtLink>.
      </p>
    </InfusionInfo>
    <!-- Réplication d’artefact -->
    <InfusionInfo id="replication-d-artefact" name="Réplication d’artefact">
      <p>
        Le personnage peut apprendre cette infusion plusieurs fois. Chaque fois qu’il en fait ainsi, il choisit un
        <NuxtLink to="/regles/magie/artefacts">artefact magique</NuxtLink> différent (à la discrétion du maître de jeu), et peut répliquer celui-ci en utilisant
        cette infusion. Il ne peut sélectionner une potion ni un parchemin magique. Si l’artefact requiert l’<NuxtLink
          to="/regles/magie/artefacts/harmonisation"
          >harmonisation</NuxtLink
        >, alors l’infusion nécessite également l’harmonisation.
      </p>
    </InfusionInfo>
  </div>
</template>
