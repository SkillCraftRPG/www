<template>
  <div>
    <h2 id="tiers-1" class="h3">Infusions de tiers 1</h2>
    <h3 id="armure-athletique" class="h5">Armure athlétique</h3>
    <div class="mb-2">
      <InfusionArmor />
      <InfusionAttunement class="ms-2" />
    </div>
    <p>
      L’<NuxtLink to="/regles/equipement/armures">armure</NuxtLink> est dotée de 6 charges, et récupère 1d6 charges à l’aube. Le porteur peut utiliser une
      charge afin d’ajouter la moitié son <NuxtLink to="/regles/statistiques/stratageme">Stratagème</NuxtLink> à un
      <NuxtLink to="/regles/competences/tests">test</NuxtLink> d’<NuxtLink to="/regles/competences/athletisme">Athlétisme</NuxtLink>. Lorsqu’il est victime d’un
      effet le <NuxtLink to="/regles/combat/conditions/renverse">renversant</NuxtLink>, il peut utiliser une charge en
      <NuxtLink to="/regles/combat/deroulement/tour">réaction</NuxtLink> afin d’éviter d’être renversé.
    </p>
    <h3 id="balistique" class="h5">Balistique</h3>
    <div class="mb-2">
      <InfusionWeapon property="Munition" />
      <InfusionAttunement class="ms-2" />
    </div>
    <p>
      Confère un bonus (+1) au <NuxtLink to="/regles/competences/tests">test</NuxtLink> des
      <NuxtLink to="/regles/combat/attaque/distance">attaques à distance</NuxtLink> effectuées en maniant cette
      <NuxtLink to="/regles/equipement/armes">arme</NuxtLink>. Si l’arme possède la propriété
      <NuxtLink to="/regles/equipement/armes/proprietes">Chargement</NuxtLink>, alors cette propriété est ignorée. L’arme crée également une
      <NuxtLink to="/regles/equipement/armes/munitions">munition</NuxtLink> si le porteur n’en possède aucune. Cette munition disparaît immédiatement après
      l’<NuxtLink to="/regles/combat/attaque">attaque</NuxtLink>.
    </p>
    <h3 id="boomerang" class="h5">Boomerang</h3>
    <div class="mb-2">
      <InfusionWeapon property="Jet" />
    </div>
    <p>
      Confère un bonus (+1) au <NuxtLink to="/regles/competences/tests">test</NuxtLink> des
      <NuxtLink to="/regles/combat/attaque/distance">attaques à distance</NuxtLink> effectuées en lançant cette
      <NuxtLink to="/regles/equipement/armes">arme</NuxtLink>. L’arme retourne automatiquement dans la main du lanceur immédiatement après l’<NuxtLink
        to="/regles/combat/attaque"
        >attaque</NuxtLink
      >.
    </p>
    <h3 id="reveil" class="h5">Réveil</h3>
    <div class="mb-2">
      <InfusionArmor text="Armure ou robe" />
    </div>
    <p>
      Le <NuxtLink to="/regles/equipement/general/vetements">vêtement</NuxtLink> est dotée de 4 charges, et récupère 1d4 charges à l’aube. Lorsque son porteur
      échoue un <NuxtLink to="/regles/competences/tests/sauvegarde">jet de sauvegarde</NuxtLink> de
      <NuxtLink to="/regles/competences/discipline">Discipline</NuxtLink> afin de maintenir sa
      <NuxtLink to="/regles/magie/parametres/duree">concentration</NuxtLink>, alors il peut utiliser une charge en
      <NuxtLink to="/regles/combat/deroulement/tour">réaction</NuxtLink> afin de réussir automatiquement.
    </p>
  </div>
</template>
