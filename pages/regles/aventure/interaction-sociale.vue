<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      L’interaction sociale est un pilier important du jeu. Elle est exprimée par le biais du jeu de rôle, qui invite les joueurs et le maître de jeu à prendre
      la place de leurs personnages, à réfléchir et à agir comme s’ils incarnaient ceux-ci.
    </p>
    <h2 class="h3">Table des matières</h2>
    <ul>
      <li>
        <a href="#jeu-de-role">Jeu de rôle</a>
      </li>
      <li>
        <a href="#attitude">Attitude</a>
      </li>
      <ul>
        <li>
          <a href="#changer-attitude">Changer l’attitude</a>
        </li>
      </ul>
      <li>
        <a href="#competences">Compétences</a>
      </li>
    </ul>
    <h2 id="jeu-de-role" class="h3">Jeu de rôle</h2>
    <p>
      Lorsque vous interprétez les gestes et paroles d’un personnage, vous jouez le rôle de celui-ci. Vous pouvez jouer le rôle d’un personnage de différentes
      manières :
    </p>
    <ul>
      <li>Vous pouvez jouer de manière active en disant exactement les paroles que votre personnage dit.</li>
      <li>Vous pouvez également jouer de manière passive en décrivant les actions que votre personnage entreprend.</li>
    </ul>
    <h2 id="attitude" class="h3">Attitude</h2>
    <p>
      Les personnages non joueurs, généralement joués par le maître de jeu, possèdent une personnalité et des enjeux qui leurs sont propres et qui sont
      différents de ceux des personnages joueurs.
    </p>
    <p>
      Par défaut, la majorité des personnages non joueurs adopteront une attitude <i>Indifférente</i> face aux personnages joueurs avec lesquels ils n’ont aucun
      historique.
    </p>
    <p>Les actions de votre personnage peuvent faire évoluer cette attitude vers une attitude plus ou moins favorable.</p>
    <p>Les attitudes suivantes déterminent les réactions que les personnages non joueurs peuvent adopter envers les personnages joueurs :</p>
    <table class="table table-striped text-center">
      <thead>
        <tr>
          <th scope="col" class="w-25">Attitude</th>
          <th scope="col" class="w-25">Description</th>
          <th scope="col" class="w-50">Exemples</th>
        </tr>
      </thead>
      <tbody>
        <tr>
          <td>Hostile</td>
          <td>Prend des risques pour nuire</td>
          <td>Attaque, gêne, insultes virulentes, fuite</td>
        </tr>
        <tr>
          <td>Inamical</td>
          <td>Souhaite le malheur</td>
          <td>Mensonges, malveillance, surveillance accrue, insultes</td>
        </tr>
        <tr>
          <td>Indifférent</td>
          <td>Sans opinion</td>
          <td>Contact social impersonnel</td>
        </tr>
        <tr>
          <td>Amical</td>
          <td>Souhaite le bien</td>
          <td>Discussion, conseils, aide limitée, soutien verbal</td>
        </tr>
        <tr>
          <td>Serviable</td>
          <td>Prend des risques pour aider</td>
          <td>Protection, soins, assistance</td>
        </tr>
      </tbody>
    </table>
    <h3 id="changer-attitude" class="h5">Changer l’attitude</h3>
    <p>
      Il est possible d’influencer l’attitude d’un personnage non joueur par un <NuxtLink to="/regles/competences/tests">test</NuxtLink> de
      <NuxtLink to="/regles/competences/diplomatie">Diplomatie</NuxtLink>.
    </p>
    <p>
      Il est également possible d’influencer l’attitude d’un personnage non joueur par le <NuxtLink to="/regles/competences/tromperie">mensonge</NuxtLink> ou
      l’<NuxtLink to="/regles/competences/representation">intimidation</NuxtLink>, mais ces actions sont habituellement contre-productives puisqu’elles
      provoquent des répercussions négatives par la suite.
    </p>
    <p>
      La table suivante indique le <NuxtLink to="/regles/competences/tests/difficulte">degré de difficulté</NuxtLink> des tests de compétences effectués afin
      d’influencer l’attitude d’un personnage non joueur.
    </p>
    <table class="table table-striped text-center">
      <thead>
        <tr>
          <th scope="col" class="w-sixth">Attitudes</th>
          <th scope="col" class="w-sixth">Hostile</th>
          <th scope="col" class="w-sixth">Inamical</th>
          <th scope="col" class="w-sixth">Indifférent</th>
          <th scope="col" class="w-sixth">Amical</th>
          <th scope="col" class="w-sixth">Serviable</th>
        </tr>
      </thead>
      <tbody>
        <tr>
          <td>Hostile</td>
          <td>{{ "—" }}</td>
          <td>20</td>
          <td>25</td>
          <td>30</td>
          <td>40</td>
        </tr>
        <tr>
          <td>Inamical</td>
          <td>1</td>
          <td>{{ "—" }}</td>
          <td>15</td>
          <td>25</td>
          <td>35</td>
        </tr>
        <tr>
          <td>Indifférent</td>
          <td>5</td>
          <td>1</td>
          <td>{{ "—" }}</td>
          <td>15</td>
          <td>30</td>
        </tr>
        <tr>
          <td>Amical</td>
          <td>10</td>
          <td>5</td>
          <td>1</td>
          <td>{{ "—" }}</td>
          <td>20</td>
        </tr>
        <tr>
          <td>Serviable</td>
          <td>15</td>
          <td>10</td>
          <td>5</td>
          <td>1</td>
          <td>{{ "—" }}</td>
        </tr>
      </tbody>
    </table>
    <h2 id="competences" class="h3">Compétences</h2>
    <p>Les <NuxtLink to="/regles/competences">compétences</NuxtLink> sociales peuvent être utilisées pendant les interactions sociales.</p>
    <p>
      Elles permettent par exemple de <NuxtLink to="/regles/competences/tromperie">manipuler son interlocuteur</NuxtLink>, de le
      <NuxtLink to="/regles/competences/representation">divertir</NuxtLink>, de le
      <NuxtLink to="/regles/competences/diplomatie">convaincre de ses bonnes intentions ou encore de parler avec distinction</NuxtLink>.
    </p>
    <p>
      Ces <NuxtLink to="/regles/competences/tests">tests</NuxtLink> de compétence comportent toutefois des risques, puisque la cible sait de manière générale
      qu’on a tenté de la manipuler en cas d’échec.
    </p>
    <p>Il devient donc plus difficile voire impossible de réessayer ces tests de compétences.</p>
    <button class="btn btn-lg btn-primary position-fixed bottom-0 end-0 m-3 rounded-circle" @click="scrollToTop">
      <font-awesome-icon icon="fas fa-arrow-up" />
    </button>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [{ text: "Aventure", to: "/regles/aventure" }];
const title: string = "Interaction sociale";

useSeo({
  title,
  description: "Découvrez comment le jeu de rôle et les compétences sociales influencent les attitudes et relations entre personnages.",
});
</script>
