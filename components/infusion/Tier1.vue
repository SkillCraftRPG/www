<template>
  <div>
    <h2 id="tiers-1" class="h3">Infusions de tiers 1</h2>
    <!-- Armure athlétique -->
    <InfusionInfo armor attunement id="armure-athletique" name="Armure athlétique">
      <p>
        L’<NuxtLink to="/regles/equipement/armures">armure</NuxtLink> est dotée de 6 charges, et récupère 1d6 charges à l’aube. Le porteur peut utiliser une
        charge afin d’ajouter la moitié son <NuxtLink to="/regles/statistiques/stratageme">Stratagème</NuxtLink> à un
        <NuxtLink to="/regles/competences/tests">test</NuxtLink> d’<NuxtLink to="/regles/competences/athletisme">Athlétisme</NuxtLink>. Lorsqu’il est victime
        d’un effet le <NuxtLink to="/regles/combat/conditions/renverse">renversant</NuxtLink>, il peut utiliser une charge en
        <NuxtLink to="/regles/combat/deroulement/tour">réaction</NuxtLink> afin d’éviter d’être renversé.
      </p>
    </InfusionInfo>
    <!-- Balistique -->
    <InfusionInfo attunement id="balistique" name="Balistique" weapon="#Munition">
      <p>
        Confère un bonus (+1) au <NuxtLink to="/regles/competences/tests">test</NuxtLink> des
        <NuxtLink to="/regles/combat/attaque/distance">attaques à distance</NuxtLink> effectuées en maniant cette
        <NuxtLink to="/regles/equipement/armes">arme</NuxtLink>. Si l’arme possède la propriété
        <NuxtLink to="/regles/equipement/armes/proprietes">Chargement</NuxtLink>, alors cette propriété est ignorée. L’arme crée également une
        <NuxtLink to="/regles/equipement/armes/munitions">munition</NuxtLink> si le porteur n’en possède aucune. Cette munition disparaît immédiatement après
        l’<NuxtLink to="/regles/combat/attaque">attaque</NuxtLink>.
      </p>
    </InfusionInfo>
    <!-- Boomerang -->
    <InfusionInfo id="boomerang" name="Boomerang" weapon="#Jet">
      <p>
        Confère un bonus (+1) au <NuxtLink to="/regles/competences/tests">test</NuxtLink> des
        <NuxtLink to="/regles/combat/attaque/distance">attaques à distance</NuxtLink> effectuées en lançant cette
        <NuxtLink to="/regles/equipement/armes">arme</NuxtLink>. L’arme retourne automatiquement dans la main du lanceur immédiatement après l’<NuxtLink
          to="/regles/combat/attaque"
          >attaque</NuxtLink
        >.
      </p>
    </InfusionInfo>
    <!-- Réveil -->
    <InfusionInfo armor="Armure ou robe" id="reveil" name="Réveil">
      <p>
        Le <NuxtLink to="/regles/equipement/general/vetements">vêtement</NuxtLink> est dotée de 4 charges, et récupère 1d4 charges à l’aube. Lorsque son porteur
        échoue un <NuxtLink to="/regles/competences/tests/sauvegarde">jet de sauvegarde</NuxtLink> de
        <NuxtLink to="/regles/competences/discipline">Discipline</NuxtLink> afin de maintenir sa
        <NuxtLink to="/regles/magie/parametres/duree">concentration</NuxtLink>, alors il peut utiliser une charge en
        <NuxtLink to="/regles/combat/deroulement/tour">réaction</NuxtLink> afin de réussir automatiquement.
      </p>
    </InfusionInfo>
    <!-- Serviteur homuncule -->
    <InfusionInfo id="serviteur-homuncule" name="Serviteur homuncule">
      <template #item>
        <InfusionItem icon="fas fa-gem" text="Pierre précieuse" />
      </template>
      <p>
        Le personnage crée un <i>Homunculus</i> en utilisant une gemme, un cristal ou une pierre précieuse d’une valeur supérieure ou égale à
        <NuxtLink to="/regles/equipement/monnaie">100 deniers</NuxtLink> comme cœur pour sa création. Il détermine l’apparence de sa création : celle-ci peut
        prendre l’apparence par exemple d’un oiseau mécanique, d’une fiole ou d’un chaudron doté de bras ou de jambes, etc. La création est
        <NuxtLink to="/regles/aventure/interaction-sociale">amicale</NuxtLink> envers le personnage et ses compagnons, et obéit à ses commandes.
      </p>
      <p>
        En situation de <NuxtLink to="/regles/combat">combat</NuxtLink>, la création possède son propre
        <NuxtLink to="/regles/combat/deroulement/tour">tour</NuxtLink>, qui est effectué immédiatement après celui du personnage. Elle peut
        <NuxtLink to="/regles/combat/activites/deplacement">se déplacer</NuxtLink> et utiliser sa
        <NuxtLink to="/regles/combat/deroulement/tour">réaction</NuxtLink> par elle-même. Si elle ne reçoit aucune commande, elle se place en
        <NuxtLink to="/regles/combat/activites/defense">position défensive</NuxtLink>, sauf si le personnage est
        <NuxtLink to="/regles/combat/conditions/incapable">incapable</NuxtLink>, dans quel cas elle peut
        <NuxtLink to="/regles/combat/activites">agir</NuxtLink> comme bon lui semble. Une fois par tour, par une
        <NuxtLink to="/regles/combat/deroulement/tour">action</NuxtLink>, le personnage peut donner des commandes à la création, qui fera de son mieux pour les
        accomplir pendant son tour.
      </p>
      <p>
        La création disparaît si ses points de <NuxtLink to="/regles/statistiques/vitalite">Vitalité</NuxtLink> chutent à 0, ou si le personnage
        <NuxtLink to="/regles/combat/mort-agonie">meurt</NuxtLink>. Elle ne laisse derrière elle que la pierre précieuse lui ayant servi de cœur. Étant une
        construction, elle ne peut être <NuxtLink to="/regles/combat/degats/soins">soignée</NuxtLink> que par un effet de <i>Réparation</i>, par exemple par le
        <NuxtLink to="/regles/magie/pouvoirs/niveau">niveau 1</NuxtLink> du pouvoir
        <NuxtLink to="/regles/magie/pouvoirs/prestidigitation">Prestidigitation</NuxtLink>. Elle récupère alors un nombre de points de Vitalité égal à 1d10
        additionné à la moitié de la <NuxtLink to="/regles/statistiques/puissance">Puissance</NuxtLink> (minimum&nbsp;1) de la créature ayant
        <NuxtLink to="/regles/magie/pouvoirs/canalisation">canalisé</NuxtLink> l’effet.
      </p>
    </InfusionInfo>
  </div>
</template>
