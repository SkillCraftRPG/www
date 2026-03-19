<template>
  <div>
    <h2 id="tiers-2" class="h3">Infusions de tiers 2</h2>
    <!-- Amplificateur magique -->
    <InfusionInfo attunement id="amplificateur-magique" name="Amplificateur magique" weapon="Baguette ou sceptre">
      <p>
        L’objet confère à son porteur un bonus (+1) à ses <NuxtLink to="/regles/competences/tests">tests</NuxtLink> d’<NuxtLink
          to="/regles/competences/occultisme"
          >Occultisme</NuxtLink
        >. Ce bonus augmente à +2 lorsque le personnage atteint le <NuxtLink to="/regles/personnages/progression/tiers">tiers 3</NuxtLink>. Les
        <NuxtLink to="/regles/magie/pouvoirs/canalisation">pouvoirs canalisés</NuxtLink> par l’entremise de cet objet ignorent le
        <NuxtLink to="/regles/combat/attaque/abri">demi-abri</NuxtLink>.
      </p>
    </InfusionInfo>
    <!-- Anneau énergétique -->
    <InfusionInfo attunement id="anneau-energetique" name="Anneau énergétique">
      <template #item>
        <InfusionItem icon="fas fa-ring" text="Anneau" />
      </template>
      <p>
        Une fois par jour, le porteur peut utiliser l’objet afin de <NuxtLink to="/regles/magie/pouvoirs/canalisation">canaliser</NuxtLink> un
        <NuxtLink to="/regles/magie/pouvoirs">pouvoir</NuxtLink> de tiers 1 ou moins sans
        <NuxtLink to="/regles/magie/pouvoirs/energie">dépenser d’Énergie</NuxtLink>. Il doit tout de même réussir le
        <NuxtLink to="/regles/competences/tests">test</NuxtLink> d’<NuxtLink to="/regles/competences/occultisme">Occultisme</NuxtLink> et fournir les
        <NuxtLink to="/regles/magie/parametres/composantes">composantes</NuxtLink> nécessaires. L’anneau récupère cette capacité à l’aube.
      </p>
    </InfusionInfo>
    <!-- Arme étincelante -->
    <InfusionInfo attunement id="arme-etincelante" name="Arme étincelante" weapon>
      <p>
        Confère un bonus (+1) au <NuxtLink to="/regles/competences/tests">test</NuxtLink> des
        <NuxtLink to="/regles/combat/attaque">attaques</NuxtLink> effectuées en maniant cette <NuxtLink to="/regles/equipement/armes">arme</NuxtLink> ainsi
        qu’aux <NuxtLink to="/regles/combat/degats">points de dégâts</NuxtLink> infligés par celle-ci. Une fois par
        <NuxtLink to="/regles/combat/deroulement/tour">tour</NuxtLink>, par une <NuxtLink to="/regles/combat/deroulement/tour">action</NuxtLink>, son porteur
        peut faire briller l’arme. Celle-ci dégage de la <NuxtLink to="/regles/aventure/environnement/vision">clarté</NuxtLink> dans un rayon de 9 mètres, et de
        la <NuxtLink to="/regles/aventure/environnement/vision">pénombre</NuxtLink> dans un rayon de 9 mètres additionnels. Le porteur peut éteindre l’arme par
        une action.
      </p>
      <p>
        L’arme est dotée de 4 charges et récupère 1d4 charges à l’aube. Immédiatement après avoir été touché par une
        <NuxtLink to="/regles/combat/attaque/melee">attaque de mêlée</NuxtLink>, son porteur peut utiliser une charge en
        <NuxtLink to="/regles/combat/deroulement/tour">réaction</NuxtLink> afin de faire scintiller vivement l’arme. Si l’attaquant échoue un
        <NuxtLink to="/regles/competences/tests/sauvegarde">jet de sauvegarde</NuxtLink> de
        <NuxtLink to="/regles/competences/resistance">Résistance</NuxtLink> de <NuxtLink to="/regles/competences/tests/difficulte">difficulté</NuxtLink> égale
        au <NuxtLink to="/regles/competences/tests/passif">test passif</NuxtLink> d’<NuxtLink to="/regles/competences/occultisme">Occultisme</NuxtLink> du
        personnage, alors il est <NuxtLink to="/regles/combat/conditions/aveugle">aveuglé</NuxtLink> jusqu’à la fin de son prochain tour.
      </p>
    </InfusionInfo>
    <!-- Armement formidable -->
    <InfusionInfo id="armement-formidable" name="Armement formidable" weapon>
      <p>
        Confère un bonus (+1) au <NuxtLink to="/regles/competences/tests">test</NuxtLink> des
        <NuxtLink to="/regles/combat/attaque">attaques</NuxtLink> effectuées en maniant cette <NuxtLink to="/regles/equipement/armes">arme</NuxtLink> ainsi
        qu’aux <NuxtLink to="/regles/combat/degats">points de dégâts</NuxtLink> infligés par celle-ci. Le bonus augmente à +2 lorsque le personnage atteint le
        <NuxtLink to="/regles/personnages/progression/tiers">tiers 3</NuxtLink>.
      </p>
    </InfusionInfo>
    <!-- Armure de résistance -->
    <InfusionInfo armor attunement id="armure-de-resistance" name="Armure de résistance">
      <p>
        Cette <NuxtLink to="/regles/equipement/armures">armure</NuxtLink> confère à son porteur la
        <NuxtLink to="/regles/combat/degats/efficacite">résistance</NuxtLink> aux <NuxtLink to="/regles/combat/degats/types">dégâts</NuxtLink> d’un des
        <NuxtLink to="/regles/combat/degats/types">types</NuxtLink> suivants, sélectionné au moment où l’infusion est créée : acide, électricité, feu, force,
        froid, nécrotique, poison, psychique, radiant, tonnerre.
      </p>
    </InfusionInfo>
    <!-- Bottes rembobineuses -->
    <InfusionInfo attunement id="bottes-rembobineuses" name="Bottes rembobineuses">
      <template #item>
        <InfusionItem icon="fas fa-shoe-prints" text="Bottes" />
      </template>
      <p>
        Une fois par <NuxtLink to="/regles/combat/deroulement/tour">tour</NuxtLink>, par une <NuxtLink to="/regles/combat/deroulement/tour">action</NuxtLink>,
        leur porteur peut se téléporter dans un <NuxtLink to="/regles/aventure/mouvement/espace-occupe">espace inoccupé</NuxtLink> qu’il a traversé pendant son
        tour, qu’il peut <NuxtLink to="/regles/aventure/environnement/vision">voir</NuxtLink> et qui est situé à 4,5 mètres ou moins de sa position.
      </p>
    </InfusionInfo>
    <!-- Bouclier de répulsion -->
    <InfusionInfo armor="Bouclier" attunement id="bouclier-de-repulsion" name="Bouclier de répulsion">
      <p>
        Confère un bonus (+1) à la <NuxtLink to="/regles/combat/attaque/defense">Défense</NuxtLink> de son porteur. Le
        <NuxtLink to="/regles/equipement/boucliers">bouclier</NuxtLink> est doté de 4 charges et récupère 1d4 charges à l’aube. Immédiatement après avoir été
        touché par une <NuxtLink to="/regles/combat/attaque/melee">attaque de mêlée</NuxtLink>, son porteur peut utiliser une charge en
        <NuxtLink to="/regles/combat/deroulement/tour">réaction</NuxtLink> afin de repousser l’attaquant de 4,5 mètres.
      </p>
    </InfusionInfo>
    <!-- Protection merveilleuse -->
    <InfusionInfo armor="Armure ou bouclier" id="protection-merveilleuse" name="Protection merveilleuse">
      <p>
        Confère un bonus (+1) à la <NuxtLink to="/regles/combat/attaque/defense">Défense</NuxtLink> de son porteur. Le bonus augmente à +2 lorsque le personnage
        atteint le <NuxtLink to="/regles/personnages/progression/tiers">tiers 3</NuxtLink>.
      </p>
    </InfusionInfo>
  </div>
</template>
