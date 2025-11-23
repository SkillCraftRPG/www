<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Au contraire des <NuxtLink to="/regles/herboristerie/remedes">remèdes</NuxtLink>, le rôle des poisons est d’infliger une certaine
      <NuxtLink to="/regles/combat/degats">douleur</NuxtLink>, une nuisance, ou même d’apporter la <NuxtLink to="/regles/combat/mort-agonie">mort</NuxtLink> à
      leurs victimes. Ils sont considérés comme une source naturelle, ils peuvent donc être guéris par les remèdes.
    </p>
    <h2 class="h3">Poisons de base</h2>
    <p>Le talent <NuxtLink to="/regles/talents/herboristerie">Herboristerie</NuxtLink> permet d’apprendre les poisons de base.</p>
    <ul>
      <li>
        <strong>Graisse allergène (contact).</strong> Au contact de cette graisse, une créature doit effectuer un
        <NuxtLink to="/regles/competences/tests/sauvegarde">jet de sauvegarde</NuxtLink> de <NuxtLink to="/regles/competences/resistance">Résistance</NuxtLink>.
        Si le résultat est inférieur à 20, le corps de la créature enfle et elle est
        <NuxtLink to="/regles/combat/conditions/empoisonne">empoisonnée</NuxtLink> pendant 1d4 heures. De plus, si le résultat est inférieur à 15, les tympans
        de la cible enflent également, ce qui la rend <NuxtLink to="/regles/combat/conditions/assourdi">sourde</NuxtLink> pendant la durée du poison et lui
        inflige <NuxtLink to="/regles/combat/degats/jet">4d4 points de dégâts</NuxtLink>{{ " "
        }}<NuxtLink to="/regles/combat/degats/types">psychiques</NuxtLink> au début de chaque heure. Il est obtenu à partir de sumac vénéneux, d’ortie commune
        ou de dentelaire, et d’un corps graisseux, par exemple de la graisse animale ou encore du miel.
      </li>
      <li>
        <strong>Malice (inhalation).</strong> Une créature qui inhale ce poison doit effectuer un
        <NuxtLink to="/regles/competences/tests/sauvegarde">jet de sauvegarde</NuxtLink> de <NuxtLink to="/regles/competences/resistance">Résistance</NuxtLink>.
        Si le résultat est inférieur à 15, la créature est <NuxtLink to="/regles/combat/conditions/aveugle">aveuglée</NuxtLink> pendant 1d4 heures. De plus, si
        le résultat est inférieur à 20, elle est également <NuxtLink to="/regles/combat/conditions/empoisonne">empoisonnée</NuxtLink> pendant la durée du
        poison. Il peut être obtenu à partir de panais sauvage ou de ricin commun réduit en poudre.
      </li>
      <li>
        <strong>Sang d’assassin (ingestion).</strong> Une créature qui ingère ce poison doit effectuer un
        <NuxtLink to="/regles/competences/tests/sauvegarde">jet de sauvegarde</NuxtLink> de <NuxtLink to="/regles/competences/resistance">Résistance</NuxtLink>.
        Si le résultat est inférieur à 10, la créature tombe <NuxtLink to="/regles/combat/conditions/inconscient">inconsciente</NuxtLink> pendant une heure. Si
        le résultat est inférieur à 15, la créature reçoit <NuxtLink to="/regles/combat/degats/jet">1d6+1d12 points de dégâts</NuxtLink> de
        <NuxtLink to="/regles/combat/degats/types">poison</NuxtLink> et est <NuxtLink to="/regles/combat/conditions/empoisonne">empoisonnée</NuxtLink> pendant
        24 heures. Si le résultat est supérieur ou égal à 20, la créature ne subit que la moitié des
        <NuxtLink to="/regles/combat/degats">points de dégâts</NuxtLink> et ne sait pas qu’elle a été empoisonnée. Une créature endormie par ce poison peut être
        réveillée en utilisant une <NuxtLink to="/regles/combat/deroulement/tour">action</NuxtLink>. Elle se réveille si elle reçoit des
        <NuxtLink to="/regles/combat/degats">points de dégâts</NuxtLink> quelconques. Il est produit à partir de mildiou, un champignon associé à la pomme de
        terre.
      </li>
      <li>
        <strong>Venin de serpent (blessure).</strong> Ce venin est extrait d’un serpent venimeux mort ou incapable, par exemple une vipère ou un cobra. Une
        créature <NuxtLink to="/regles/combat/degats">blessée</NuxtLink> par ce venin doit effectuer un
        <NuxtLink to="/regles/competences/tests/sauvegarde">jet de sauvegarde</NuxtLink> de <NuxtLink to="/regles/competences/resistance">Résistance</NuxtLink>.
        Si le résultat est inférieur à 20, la créature reçoit <NuxtLink to="/regles/combat/degats/jet">3+4d6 points de dégâts</NuxtLink> de
        <NuxtLink to="/regles/combat/degats/types">poison</NuxtLink>. Elle ne reçoit que la moitié des points de dégâts si le résultat est supérieur ou égal à
        20. Également, si le résultat est inférieur à 15, la créature est <NuxtLink to="/regles/combat/conditions/paralyse">paralysée</NuxtLink> pendant 4+1d6
        <NuxtLink to="/regles/combat/deroulement">rounds</NuxtLink>. Après 5 rounds, elle peut répéter le jet de sauvegarde au début de chaque
        <NuxtLink to="/regles/combat/deroulement/tour">tour</NuxtLink> afin de ne plus être paralysée.
      </li>
    </ul>
    <h2 class="h3">Poisons avancés</h2>
    <p>Le talent <NuxtLink to="/regles/talents/toxicologie">Toxicologie</NuxtLink> permet d’apprendre les poisons avancés.</p>
    <ul>
      <li>
        <strong>Fausse oronge (inhalation).</strong> Les spores de ce champignon provoquent une puissante furie incontrôlable. Une créature qui en inhale les
        spores doit effectuer un <NuxtLink to="/regles/competences/tests/sauvegarde">jet de sauvegarde</NuxtLink> de
        <NuxtLink to="/regles/competences/resistance">Résistance</NuxtLink>. Si le résultat est inférieur à 25, elle est seulement
        <NuxtLink to="/regles/combat/conditions/empoisonne">empoisonnée</NuxtLink> pendant 6d10 minutes. Si le résultat est inférieur à 20, elle n’est pas
        empoisonnée, mais elle tombe dans une rage meurtrière. Pendant cette durée, elle doit <NuxtLink to="/regles/combat/attaque">attaquer</NuxtLink> toute
        créature qu’elle <NuxtLink to="/regles/aventure/environnement/vision">voit</NuxtLink>, alliée et ennemie, en commençant par la créature la plus proche.
        Elle se voit conférer l’<NuxtLink to="/regles/competences/tests/avantage-desavantage">avantage</NuxtLink> à ses tests d’<NuxtLink
          to="/regles/competences/athletisme"
          >Athlétisme</NuxtLink
        >
        et de <NuxtLink to="/regles/competences/melee">Mêlée</NuxtLink>, ajoute un <NuxtLink to="/regles/combat/degats/jet">dé de dégâts</NuxtLink> à toute
        attaque physique réussie, et devient <NuxtLink to="/regles/combat/degats/efficacite">résistante</NuxtLink> aux points de dégâts physiques. Elle ne peut
        <NuxtLink to="/regles/combat/activites/canaliser">canaliser</NuxtLink> de pouvoir et perd instantanément sa
        <NuxtLink to="/regles/magie/parametres/duree">concentration</NuxtLink> sur ses pouvoirs actifs. La rage cesse si la créature tombe
        <NuxtLink to="/regles/combat/conditions/agonisant">agonisante</NuxtLink> ou
        <NuxtLink to="/regles/combat/conditions/inconscient">inconsciente</NuxtLink>. Elle devient ensuite léthargique pendant la prochaine heure, ce qui réduit
        sa <NuxtLink to="/regles/aventure/mouvement/vitesse">vitesse</NuxtLink> de moitié, elle ne peut effectuer de
        <NuxtLink to="/regles/combat/deroulement/tour">réaction</NuxtLink> et ne peut effectuer qu’une seule
        <NuxtLink to="/regles/combat/deroulement/tour">action</NuxtLink> par <NuxtLink to="/regles/combat/deroulement/tour">tour</NuxtLink>.
      </li>
      <li>
        <strong>Larmes de minuit (ingestion).</strong> Lorsque ingéré, ce poison ne provoque aucun effet jusqu’à minuit. Si le poison n’a pas été neutralisé
        d’ici-là, la créature doit effectuer un <NuxtLink to="/regles/competences/tests/sauvegarde">jet de sauvegarde</NuxtLink> de
        <NuxtLink to="/regles/competences/resistance">Résistance</NuxtLink>. Si le résultat est inférieur à 25, elle reçoit
        <NuxtLink to="/regles/combat/degats/jet">3+13d6 points de dégâts</NuxtLink> de <NuxtLink to="/regles/combat/degats/types">poison</NuxtLink>. Elle reçoit
        seulement la moitié des <NuxtLink to="/regles/combat/degats">points de dégâts</NuxtLink> si le résultat est supérieur ou égal à 25. Sa
        <NuxtLink to="/regles/statistiques/vitalite">Vitalité</NuxtLink> maximale est également réduite de ce nombre pendant les 24 prochaines heures. Une
        créature tombant <NuxtLink to="/regles/combat/conditions/agonisant">agonisante</NuxtLink> à cause de ce poison
        <NuxtLink to="/regles/combat/mort-agonie">meurt</NuxtLink> instantanément. Ce venin doit être extrait d’un animal mort ou inconscient, telle la
        méduse-boîte, la pieuvre à anneaux bleus, l’escargot cône marin, un serpent (elapidae ou cobra royal), scorpion (rôdeur mortel) ou une araignée
        (atracidae ou veuve noire) très venimeuse, le poisson-pierre, la rascasse ou la raie pastenague à taches bleues.
      </li>
      <li>
        <strong>Réduction naturelle (contact).</strong> Ce poison prend la forme d’un baume qui doit être appliqué sur la peau. Un ingrédient entre dans sa
        composition, choisi par l’empoisonneur selon l’effet désire. Cet ingrédient est un fluide d’un animal ou d’une créature et détermine l’<NuxtLink
          to="/regles/attributs"
          >attribut</NuxtLink
        >
        affecté, tel que décrit par le <NuxtLink to="/regles/magie/pouvoirs/niveau">niveau 2</NuxtLink> du pouvoir
        <NuxtLink to="/regles/magie/pouvoirs/augmentation-naturelle">Augmentation naturelle</NuxtLink>. Au contact de ce poison, une créature doit effectuer un
        <NuxtLink to="/regles/competences/tests/sauvegarde">jet de sauvegarde</NuxtLink> de <NuxtLink to="/regles/competences/resistance">Résistance</NuxtLink>.
        Si le résultat est inférieur à 25, elle subit une pénalité de -2 à l’attribut sélectionné pendant les 24 prochaines heures.
      </li>
      <li>
        <strong>Torpeur (ingestion).</strong> Une créature qui ingère ce poison doit effectuer un
        <NuxtLink to="/regles/competences/tests/sauvegarde">jet de sauvegarde</NuxtLink> de <NuxtLink to="/regles/competences/resistance">Résistance</NuxtLink>.
        Si le résultat est inférieur à 25, elle est <NuxtLink to="/regles/combat/conditions/empoisonne">empoisonnée</NuxtLink> pendant 4d6 heures. De plus, si
        le résultat est inférieur à 20, la créature tombe <NuxtLink to="/regles/combat/conditions/incapable">incapable</NuxtLink> pendant la durée du poison. Ce
        poison est concocté à partir de toxines végétales hautement toxiques, par exemple celle de l’abrus à chapelet, l’Agératine élevée, de la cicutaire ou
        encore du laurier-rose.
      </li>
      <li>
        <strong>Vapeur de vérité (inhalation).</strong> Lorsqu’une créature inhale ce poison, elle doit effectuer un
        <NuxtLink to="/regles/competences/tests/sauvegarde">jet de sauvegarde</NuxtLink> de <NuxtLink to="/regles/competences/resistance">Résistance</NuxtLink>.
        Si le résultat est inférieur à 25, il lui est impossible de mentir pendant la prochaine heure. Si le résultat est inférieur à 20, la créature est
        également <NuxtLink to="/regles/combat/conditions/empoisonne">empoisonnée</NuxtLink> pendant la durée du poison. Elle est produite à partir d’alcool et
        de solanacées, par exemple la jusquiame noire, le stramoine (datura) ou la belladone.
      </li>
      <li>
        <strong>Venin de vouivre (blessure).</strong> Ce venin est extrait d’une vouivre morte ou incapable. Une créature blessée par ce venin doit effectuer un
        <NuxtLink to="/regles/competences/tests/sauvegarde">jet de sauvegarde</NuxtLink> de <NuxtLink to="/regles/competences/resistance">Résistance</NuxtLink>.
        Si le résultat est inférieur à 20, elle reçoit <NuxtLink to="/regles/combat/degats/jet">12d6 points de dégâts</NuxtLink> de
        <NuxtLink to="/regles/combat/degats/types">poison</NuxtLink>. Elle ne reçoit que la moitié des
        <NuxtLink to="/regles/combat/degats">points de dégâts</NuxtLink> si le résultat est supérieur ou égal à 20. En cas d’échec, la créature est également
        <NuxtLink to="/regles/combat/conditions/paralyse">paralysée</NuxtLink> pendant 4+1d6 <NuxtLink to="/regles/combat/deroulement">rounds</NuxtLink>. Après
        5 rounds, elle peut répéter le jet de sauvegarde au début de chaque <NuxtLink to="/regles/combat/deroulement/tour">tour</NuxtLink> afin de ne plus être
        paralysée.
      </li>
    </ul>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [{ text: "Herboristerie", to: "/regles/herboristerie" }];
const title: string = "Poisons";

useSeo({
  title,
  description:
    "Découvrez les poisons de base et avancés : toxines de contact, ingestion ou inhalation infligeant douleur, paralysie, folie ou mort, et leurs effets détaillés.",
});
</script>
