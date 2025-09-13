<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Lorsqu’un personnage parcourt une grande distance, se déplaçant sur une longue période de <NuxtLink to="/regles/aventure/temps">temps</NuxtLink> (en
      minutes, en heures ou en jours), on parle d’un voyage plutôt que d’un déplacement.
    </p>
    <h2 class="h3">Table des matières</h2>
    <ul>
      <li>
        <a href="#cadences">Cadences</a>
      </li>
      <li>
        <a href="#lieue">Lieue</a>
      </li>
      <li>
        <a href="#marche-forcee">Marche forcée</a>
      </li>
      <li>
        <a href="#ordre-marche">Ordre de marche</a>
      </li>
      <li>
        <a href="#horaire">Horaire</a>
      </li>
      <li>
        <a href="#activites">Activités</a>
      </li>
    </ul>
    <h2 id="cadences" class="h3">Cadences</h2>
    <p>
      Un personnage adopte une <strong>cadence</strong> lorsqu’il voyage. Cette cadence est indépendante de sa
      <NuxtLink to="/regles/aventure/mouvement/vitesse">vitesse de déplacement</NuxtLink>.
    </p>
    <p>
      La table ci-dessous présente les cadences, les distances parcourues ainsi que les effets de chaque cadence. Une journée correspond à 8 heures entrecoupées
      de pauses et de repas.
    </p>
    <table class="table table-striped text-center">
      <thead>
        <tr>
          <th scope="col" class="w-15">Cadence</th>
          <th scope="col" class="w-15">Distance (minute)</th>
          <th scope="col" class="w-15">Distance (heure)</th>
          <th scope="col" class="w-15">Distance (jour)</th>
          <th scope="col" class="w-40">Effets</th>
        </tr>
      </thead>
      <tbody>
        <tr>
          <td>Prudente</td>
          <td>{{ $n(50, "integer") }} mètres</td>
          <td>{{ $n(3.2, "decimal") }} km</td>
          <td>{{ $n(25, "decimal") }} km</td>
          <td>Permet de se <NuxtLink to="/regles/aventure/mouvement/furtif">déplacer furtivement</NuxtLink>.</td>
        </tr>
        <tr>
          <td>Normale</td>
          <td>{{ $n(75, "integer") }} mètres</td>
          <td>{{ $n(4.8, "decimal") }} km</td>
          <td>{{ $n(37.5, "decimal") }} km</td>
          <td>
            <span class="text-muted">{{ "—" }}</span>
          </td>
        </tr>
        <tr>
          <td>Hâtive</td>
          <td>{{ $n(100, "integer") }} mètres</td>
          <td>{{ $n(6.4, "decimal") }} km</td>
          <td>{{ $n(50, "decimal") }} km</td>
          <td>
            Pénalité (-5) aux <NuxtLink to="/regles/competences/tests/passif">tests passifs</NuxtLink> de
            <NuxtLink to="/regles/competences/perception">Perception</NuxtLink> en <NuxtLink to="/regles/aventure/mouvement/attentif">déplacement</NuxtLink>.
          </td>
        </tr>
      </tbody>
    </table>
    <h2 id="lieue" class="h3">Lieue</h2>
    <p>
      La lieue est une unité de mesure officialisée en Ouespéro. Elle correspond à la distance qu’un homme normal parcourt à pied en une heure à cadence
      normale, en tenant compte de son équipement et de l’état moyen des routes et sentiers. Cette distance est de
      <strong>{{ $n(4828, "integer") }} mètres</strong>, habituellement arrondie à <strong>{{ $n(4.8, "decimal") }} km</strong>.
    </p>
    <p>Les vitesses d’une créature n’influencent en aucun cas cette distance parcourue.</p>
    <h2 id="marche-forcee" class="h3">Marche forcée</h2>
    <p>
      Une créature peut se déplacer pendant 8 heures par jour sans subir de pénalité. Pour chaque heure supplémentaire de déplacement, une créature tombe en
      situation de <strong>marche&nbsp;forcée</strong>. À la fin de chaque heure de marche forcée, une créature reçoit des
      <NuxtLink to="/regles/combat/degats/letalite">points de dégâts non létaux</NuxtLink> et doit effectuer un
      <NuxtLink to="/regles/competences/tests/sauvegarde">jet de sauvegarde</NuxtLink> de <NuxtLink to="/regles/competences/resistance">Résistance</NuxtLink>.
    </p>
    <ul>
      <li>Les points de dégâts sont de 2d6 multipliés par heure de marche forcée : 2d6 pour la première heure, 4d6 pour la seconde, et ainsi de suite.</li>
      <li>
        Le <NuxtLink to="/regles/competences/tests/difficulte">degré de difficulté</NuxtLink> du jet de sauvegarde est de 5 par heure de marche forcée,
        additionné de 5 : 10 pour la première heure, 15 pour la seconde, et ainsi de suite.
      </li>
      <li>
        Si une créature échoue le jet de sauvegarde, elle est affligée d’<NuxtLink to="/regles/combat/conditions/fatigue">un niveau de Fatigue</NuxtLink>.
      </li>
      <li>
        Une créature <NuxtLink to="/regles/equipement/encombrement">encombrée</NuxtLink> ou tirant un
        <NuxtLink to="/regles/equipement/montures-vehicules/terrestres">véhicule terrestre</NuxtLink> doit effectuer le jet de sauvegarde avec
        <NuxtLink to="/regles/competences/tests/avantage-desavantage">désavantage</NuxtLink>.
      </li>
    </ul>
    <h2 id="ordre-marche" class="h3">Ordre de marche</h2>
    <p>
      Lorsque plusieurs personnages voyagent, ils établissent un ordre de marche. Ils se répartissent dans un nombre de rangs compris entre un et le nombre
      d’individus dans le groupe.
    </p>
    <ul>
      <li>Les individus ouvrant la marche peuvent plus facilement détecter les pièges et embuscades, mais ils sont les premiers affectés par ceux-ci.</li>
      <li>
        Les individus au centre sont généralement mieux protégés, et peuvent se concentrer sur des tâches plus complexes, par exemple examiner un artefact ou se
        plonger dans un bouquin.
      </li>
      <li>Les individus fermant la marche peuvent assurer les arrières du groupe et s’assurer qu’ils ne sont pas suivis.</li>
    </ul>
    <h2 id="horaire" class="h3">Horaire</h2>
    <p>
      Le groupe établit un horaire afin de simplifier le voyage. Cette formule peut ensuite être répétée de jour en jour, ce qui permet de réduire les prises de
      décisions récurrentes. Voici un exemple d’un horaire de voyage :
    </p>
    <ol>
      <li>Les personnages se lèvent en même temps que le Soleil.</li>
      <li>La première heure de leur journée est dédiée à un repas matinal, au démontage du camp et à la préparation du voyage.</li>
      <li>Les personnages voyagent ensuite pendant 4 heures, puis s’arrêtent une heure pour reprendre leur souffle et prendre un deuxième repas.</li>
      <li>Ils voyagent ensuite pendant 4 heures.</li>
      <li>
        Les personnages trouvent un endroit pour monter un campement. Ils localisent les ressources à proximité, et sécurisent les lieux en repérant ou en
        éliminant les menaces.
      </li>
      <li>
        Ils terminent leur journée par des activités légères : ils montent un camp, prennent un troisième repas et se couchent en même temps que le Soleil.
      </li>
      <li>Ils séparent les 8 heures que dure la nuit en quatre tours de garde 2 heures chacun.</li>
    </ol>
    <h2 id="activites" class="h3">Activités</h2>
    <p>
      Un personnage se concentrer sur des tâches plus complexes en voyageant. Lorsqu’il en fait ainsi, il n’est pas attentif à son environnement, il ne peut
      donc pas effectuer de <NuxtLink to="/regles/competences/tests/passif">test passif</NuxtLink> de
      <NuxtLink to="/regles/competences/perception">Perception</NuxtLink>. Voici des exemples d’activités qu’il peut néanmoins accomplir en détournant son
      attention, à la discrétion du maître de jeu :
    </p>
    <ul>
      <li>
        <strong>Cartographie.</strong> Le personnage dessine une carte enregistrant le progrès du groupe et permettant au groupe de se retrouver s’il se perd.
      </li>
      <li>
        <strong>Navigation.</strong> Le personnage empêche son groupe de se perdre par un ou plusieurs
        <NuxtLink to="/regles/competences/tests">tests</NuxtLink> de <NuxtLink to="/regles/competences/survie">Survie</NuxtLink>.
      </li>
      <li><strong>Pistage.</strong> Le personnage suite la piste d’une autre créature par un ou plusieurs tests de Survie.</li>
      <li>
        <strong>Recherche de nourriture.</strong> Le personnage reste attentif aux sources de nourriture et d’eau potable à proximité par un ou plusieurs tests
        de Survie.
      </li>
    </ul>
  </main>
  <button class="btn btn-lg btn-primary position-fixed bottom-0 end-0 m-3 rounded-circle" @click="scrollToTop">
    <font-awesome-icon icon="fas fa-arrow-up" />
  </button>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Aventure", to: "/regles/aventure" },
  { text: "Mouvement", to: "/regles/aventure/mouvement" },
];
const title: string = "Voyage";

useSeo({
  title,
  description: "Découvrez les règles du voyage : cadences, lieue, marche forcée, ordre de marche, horaires et activités possibles pour vos personnages.",
});
</script>
