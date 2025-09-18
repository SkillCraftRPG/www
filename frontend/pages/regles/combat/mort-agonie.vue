<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Lorsque vos points de <NuxtLink to="/regles/statistiques/vitalite">Vitalité</NuxtLink> chutent à 0, vous tombez à l’<NuxtLink
        to="/regles/combat/conditions/agonisant"
        >agonie</NuxtLink
      >
      et risquez la <NuxtLink to="/regles/combat/conditions/mort">mort</NuxtLink>.
    </p>
    <p>
      À la discrétion du maître de jeu, un monstre ou un personnage non-joueur peut passer l’agonie et mourir instantanément lorsque ses points de Vitalité
      chutent à 0.
    </p>
    <h2 class="h3">Table des matières</h2>
    <ul>
      <li>
        <a href="#article-mort">À l’article de la mort</a>
        <ul>
          <li>
            <a href="#flamboiement-glorieux">Flamboiement glorieux</a>
          </li>
          <li>
            <a href="#tromper-mort">Tromper la mort</a>
          </li>
          <li>
            <a href="#tout-risquer">Tout risquer</a>
          </li>
        </ul>
      </li>
      <li>
        <a href="#resurrection">Résurrection</a>
      </li>
    </ul>
    <h2 id="article-mort" class="h3">À l’article de la mort</h2>
    <p>Lorsque vous tombez à l’<NuxtLink to="/regles/combat/conditions/agonisant">agonie</NuxtLink>, choisissez une des trois options suivantes.</p>
    <h3 id="flamboiement-glorieux" class="h5"><font-awesome-icon icon="fas fa-trophy" /> Flamboiement glorieux</h3>
    <p>
      Vous accueillez la <NuxtLink to="/regles/combat/conditions/mort">mort</NuxtLink> à bras ouverts, satisfaits des exploits que vous avez accomplis, ou
      ravagés par les remords.
    </p>
    <p>
      Vous effectuez une <NuxtLink to="/regles/combat/activites">activité</NuxtLink> finale, avec l’accord de votre maître de jeu, et obtenez une
      <NuxtLink to="/regles/competences/tests/critique">réussite critique</NuxtLink>.
    </p>
    <p>Votre âme traverse ensuite le voile de la mort, et vous ne pouvez être ramenés à la vie de quelconque manière.</p>
    <h3 id="tromper-mort" class="h5"><font-awesome-icon icon="fas fa-person-running" /> Tromper la mort</h3>
    <p>
      Vous refusez la <NuxtLink to="/regles/combat/conditions/mort">mort</NuxtLink>, car vous avez encore trop d’attaches avec le monde des mortels, d’actes à
      accomplir ou de dettes à repayer.
    </p>
    <p>Vous tombez hors du combat, toujours agonisants mais stables, à l’abri des menaces, et vous serez tirés d’affaire, sauf situation exceptionnelle.</p>
    <p>
      Le maître de jeu raconte comment vous survivez. Si par malheur vous êtes <NuxtLink to="/regles/combat/degats">blessés</NuxtLink>, alors vous redevenez
      instables et devez à nouveau choisir une des trois options.
    </p>
    <p>
      Vous reprenez conscience lorsque vos points de Vitalité remontent à une valeur supérieure à 0, soit lorsque vous recevez
      <NuxtLink to="/regles/combat/degats/soins">soins</NuxtLink>, soit après <NuxtLink to="/regles/aventure/temps">une heure</NuxtLink>.
    </p>
    <p>
      Lorsque vous trompez la mort, votre <NuxtLink to="/regles/competences/esperance-damnation">limite d’Espérance</NuxtLink> est réduite de 1. Vous ne pouvez
      tromper la mort si cette limite est de 0.
    </p>
    <h3 id="tout-risquer" class="h5"><font-awesome-icon icon="fas fa-dice-d20" /> Tout risquer</h3>
    <p>
      Indécis face à la <NuxtLink to="/regles/combat/conditions/mort">mort</NuxtLink>, vous décidez de tout risquer en laissant le destin choisir pour vous.
    </p>
    <p>
      Vous restez agonisants pendant un nombre de <NuxtLink to="/regles/combat/deroulement">rounds</NuxtLink> égal à 1 +
      <NuxtLink to="/regles/attributs/vigueur">Vigueur</NuxtLink>, divisé par 2 (minimum 1 round).
    </p>
    <p>
      Pendant votre agonie, vous pouvez être <NuxtLink to="/regles/combat/activites/stabiliser">stabilisés</NuxtLink>, mais vous pouvez également recevoir le
      <NuxtLink to="/regles/combat/activites/coup-grace">coup de grâce</NuxtLink>.
    </p>
    <p>
      Au début de votre prochain <NuxtLink to="/regles/combat/deroulement/tour">tour</NuxtLink> au cours du round décisif, jetez vos
      <NuxtLink to="/regles/competences/tests/2d10">dés d’Espérance et de Damnation</NuxtLink>. Votre sort est décidé par le résultat.
    </p>
    <ul>
      <li>
        <strong>Réussite critique.</strong> Vous récupérez instantanément 1 point de <NuxtLink to="/regles/statistiques/vitalite">Vitalité</NuxtLink>. Vous
        n’êtes plus à l’<NuxtLink to="/regles/combat/conditions/agonisant">agonie</NuxtLink>, reprenez instantanément conscience, et pouvez jouer votre tour
        normalement.
      </li>
      <li>
        <strong>Réussite.</strong> Votre dé d’Espérance est supérieur à votre dé de Damnation.
        <ul>
          <li>
            Vous tombez hors du combat, toujours agonisants mais stables, à l’abri des menaces, et vous serez tirés d’affaire, sauf situation exceptionnelle.
          </li>
          <li>
            Le maître de jeu raconte comment vous survivez. Si par malheur vous êtes <NuxtLink to="/regles/combat/degats">blessés</NuxtLink>, alors vous
            redevenez instables et devez à nouveau choisir une des trois options.
          </li>
          <li>
            Vous reprenez conscience lorsque vos points de Vitalité remontent à une valeur supérieure à 0, soit lorsque vous recevez
            <NuxtLink to="/regles/combat/degats/soins">soins</NuxtLink>, soit après <NuxtLink to="/regles/aventure/temps">une heure</NuxtLink>.
          </li>
        </ul>
      </li>
      <li><strong>Échec.</strong> Votre dé d’Espérance est inférieur à votre dé de Damnation. Vous mourez, mais pouvez être ressuscités.</li>
      <li>
        <strong>Échec critique.</strong> Vous mourez définitivement, et votre âme traverse le voile de la mort. Celle-ci est trop faible pour être ramenée d’une
        quelconque manière.
      </li>
    </ul>
    <h2 id="resurrection" class="h3">Résurrection</h2>
    <p>Il est possible, quoi que extrêmement difficile, de ramener une créature <NuxtLink to="/regles/combat/conditions/mort">décédée</NuxtLink> à la vie.</p>
    <p>
      Son corps doit posséder ses fonctions vitales (ou celles-ci doivent être restaurées), et l’âme de la créature doit être suffisamment forte et accepter de
      retourner à la vie.
    </p>
    <p>
      Lorsqu’une créature est ressuscitée, elle est instantanément affligée de 5 niveaux de <NuxtLink to="/regles/combat/conditions/fatigue">Fatigue</NuxtLink>.
    </p>
    <button class="btn btn-lg btn-primary position-fixed bottom-0 end-0 m-3 rounded-circle" @click="scrollToTop">
      <font-awesome-icon icon="fas fa-arrow-up" />
    </button>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [{ text: "Combat", to: "/regles/combat" }];
const title: string = "Mort et agonie";

useSeo({
  title,
  description: "Découvrez les règles de mort, d’agonie et de résurrection : options au seuil de la vie et conditions pour revenir d’entre les morts.",
});
</script>
