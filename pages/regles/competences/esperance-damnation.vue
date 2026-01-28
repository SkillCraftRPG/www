<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>L’Espérance et la Damnation sont des ressources permettant aux joueurs et au maître de jeu d’influencer l’histoire.</p>
    <h2 class="h3">Table des matières</h2>
    <ul>
      <li>
        <a href="#esperance">Espérance</a>
        <ul>
          <li>
            <a href="#esperance-acquisition">Acquisition</a>
          </li>
          <li>
            <a href="#esperance-limite">Quantité limitée</a>
          </li>
        </ul>
      </li>
      <li>
        <a href="#damnation">Damnation</a>
        <ul>
          <li>
            <a href="#damnation-acquisition">Acquisition</a>
          </li>
          <li>
            <a href="#damnation-limite">Illimités mais éphémères</a>
          </li>
        </ul>
      </li>
      <li>
        <a href="#momentum">Momentum</a>
      </li>
      <li>
        <a href="#depense">Dépense</a>
      </li>
    </ul>
    <h2 id="esperance" class="h3">Espérance</h2>
    <p>Les points d’Espérance permettent aux joueurs de prendre davantage un rôle de narration en tournant une situation en leur faveur ou à leur avantage.</p>
    <h3 id="esperance-acquisition" class="h5">Acquisition</h3>
    <p>
      Des points d’Espérance peuvent être attribués à un joueur lorsque celui-ci réussit un
      <NuxtLink to="/regles/competences/tests/2d10">test avec Espérance</NuxtLink> ou obtient une
      <NuxtLink to="/regles/competences/tests/critique">réussite critique</NuxtLink>.
    </p>
    <p>L’échec d’un test avec Espérance peut octroyer une conséquence positive au personnage, mais ne génère jamais de point d’Espérance.</p>
    <p>
      Lorsqu’une créature ennemie contrôlée par le maître de jeu génère des points de Damnation, ceux-ci sont convertis en points d’Espérance et octroyés aux
      joueurs.
    </p>
    <p>
      Un joueur peut également « emprunter » des points d’Espérance lorsqu’il en a besoin, mais qu’il n’en possède aucun et que la
      <a href="#momentum">réserve</a> est vide.
    </p>
    <ul>
      <li>Il peut créer un point d’Espérance et l’utiliser immédiatement, en générant toutefois 2 points de Damnation.</li>
      <li>Il peut créer 2 points d’Espérance et les utiliser immédiatement, en générant toutefois 3 points de Damnation.</li>
    </ul>
    <h3 id="esperance-limite" class="h5">Quantité limitée</h3>
    <p>
      Un personnage peut accumuler jusqu’à 3 points d’Espérance. Ces points sont conservés entre les séances de jeu : le joueur doit donc en garder trace sur sa
      fiche de personnage.
    </p>
    <p>
      Cette limite ne peut pratiquement jamais être augmentée, mais elle peut être
      <NuxtLink to="/regles/combat/mort-agonie">réduite sous certaines conditions</NuxtLink>.
    </p>
    <p>Lorsque cette limite est atteinte et que le personnage génère un point d’Espérance, ce point est placé dans la <a href="#momentum">réserve</a>.</p>
    <h2 id="damnation" class="h3">Damnation</h2>
    <p>
      Les points de Damnation permettent au maître de jeu d’accroître la difficulté en conférant des bonus aux ennemis des joueurs, ou en infligeant une
      pénalité aux personnages joueurs.
    </p>
    <h3 id="damnation-acquisition" class="h5">Acquisition</h3>
    <p>
      Des points de Damnation sont générés lorsqu’un joueur échoue un <NuxtLink to="/regles/competences/tests/2d10">test avec Damnation</NuxtLink> ou obtient un
      <NuxtLink to="/regles/competences/tests/critique">échec critique</NuxtLink>.
    </p>
    <p>La réussite d’un test avec Damnation peut infliger une conséquence négative à un personnage, mais ne génère jamais de points de Damnation.</p>
    <p>
      Lorsqu’une créature ennemie contrôlée par le maître de jeu génère des points d’Espérance, ceux-ci sont convertis en points de Damnation et octroyés au
      maître de jeu.
    </p>
    <p>
      Le maître de jeu peut également « emprunter » des points de Damnation en générant des points d’Espérance aux joueurs (tel que décrit ci-dessus), mais
      cette action est fortement déconseillée et généralement réservée aux joueurs.
    </p>
    <h3 id="damnation-limite" class="h5">Illimités mais éphémères</h3>
    <p>
      En règle générale, le maître de jeu peut accumuler un nombre illimité de points de Damnation. Néanmoins, ils sont temporaires et perdus à la fin de la
      séance de jeu s’ils n’ont pas été utilisés.
    </p>
    <p>
      Une exception notable à cette règle survient lorsque la séance de jeu se termine sur un <NuxtLink to="/regles/combat">combat</NuxtLink> non complété : le
      maître de jeu est alors invité à conserver ces points de Damnation jusqu’à la fin du combat, puis à se débarrasser des points générés lors de la séance
      précédente lorsque le combat est terminé.
    </p>
    <h2 id="momentum" class="h3">Momentum</h2>
    <p>La règle du momentum décrit la réserve de points d’Espérance temporaires partagés par le groupe.</p>
    <p>Lorsqu’un personnage génère de l’Espérance en ayant atteint sa limite, ces nouveaux points sont placés dans cette réserve.</p>
    <p>Les joueurs peuvent piger dans cette réserve librement, tant qu’il y reste des points.</p>
    <p>À la fin de la séance de jeu, cette réserve est vidée et les points non utilisés sont perdus.</p>
    <p>
      Une exception notable à cette règle survient lorsque la séance de jeu se termine sur un <NuxtLink to="/regles/combat">combat</NuxtLink> non complété : les
      joueurs sont alors invités à converver ces points d’Espérance jusqu’à la fin du combat, puis à se débarrasser des points générés lors de la séance
      précédente lorsque le combat est terminé.
    </p>
    <h2 id="depense" class="h3">Dépense</h2>
    <p>La table ci-dessous répertorie des exemples de dépense de points d’Espérance et de Damnation.</p>
    <p>
      Toute dépense peut se faire avant ou pendant un test ou un jet de <NuxtLink to="/regles/combat/degats">dégâts</NuxtLink>, mais jamais après l’annonce du
      résultat final.
    </p>
    <p>Le maître de jeu peut refuser une dépense de points d’Espérance, mais il lui est fortement conseillé d’atteindre plutôt un compromis.</p>
    <table class="table table-striped text-center">
      <thead>
        <tr>
          <th scope="col" class="w-75">Effet</th>
          <th scope="col" class="w-25">Points</th>
        </tr>
      </thead>
      <tbody>
        <tr>
          <td>Réduire de moitié le temps nécessaire afin d’accomplir une tâche hors-combat.</td>
          <td>1</td>
        </tr>
        <tr>
          <td>
            Relancer un des d10 et utiliser le nouveau résultat.
            <br />
            Relancer les deux d10 et utiliser le nouveau résultat.
          </td>
          <td>
            1
            <br />
            2
          </td>
        </tr>
        <tr>
          <td>
            Ajouter un bonus (+2) à un test ou infliger une pénalité (-2).
            <br />
            ±5
            <br />
            ±10
          </td>
          <td>
            1
            <br />
            2
            <br />
            4
          </td>
        </tr>
        <tr>
          <td>Réussir automatiquement une action. Introduire un élément dans l’histoire.</td>
          <td>5</td>
        </tr>
        <tr>
          <td>Obtenir des indices à propos de la situation actuelle.</td>
          <td>1 par indice</td>
        </tr>
        <tr>
          <td>Ajouter des dés de dégâts à une attaque (maximum d’un dé par tiers de personnage).</td>
          <td>1 par dé</td>
        </tr>
        <tr>
          <td>Ne pas générer de points de Damnation à la suite d’un test.</td>
          <td>2 par point</td>
        </tr>
      </tbody>
    </table>
    <button class="btn btn-lg btn-primary position-fixed bottom-0 end-0 m-3 rounded-circle" @click="scrollToTop">
      <font-awesome-icon icon="fas fa-arrow-up" />
    </button>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [{ text: "Compétences", to: "/regles/competences" }];
const title: string = "Espérance et Damnation";

useSeo({
  title,
  description: "Découvrez comment l’Espérance et la Damnation influencent l’histoire, avec leurs règles d’acquisition, de dépense et la réserve de momentum.",
});
</script>
