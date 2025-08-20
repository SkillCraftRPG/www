<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Lorsqu’un personnage parcourt une grande distance, se déplaçant sur une longue période de <NuxtLink to="/regles/aventure/temps">temps</NuxtLink> (en
      minutes, en heures ou en jours), il adopte une <strong>cadence</strong>. Cette cadence est indépendante de sa
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
          <td>Lente</td>
          <td>{{ $n(25, "integer") }} mètres</td>
          <td>{{ $n(1.6, "decimal") }} km</td>
          <td>{{ $n(12.5, "decimal") }} km</td>
          <td>Possibilité de se <NuxtLink to="/regles/aventure/mouvement/furtif">déplacer furtivement</NuxtLink></td>
        </tr>
        <tr>
          <td>Normale</td>
          <td>{{ $n(50, "integer") }} mètres</td>
          <td>{{ $n(3.2, "decimal") }} km</td>
          <td>{{ $n(25, "decimal") }} km</td>
          <td>
            <span class="text-muted">{{ "—" }}</span>
          </td>
        </tr>
        <tr>
          <td>Rapide</td>
          <td>{{ $n(75, "integer") }} mètres</td>
          <td>{{ $n(4.8, "decimal") }} km</td>
          <td>{{ $n(37.5, "decimal") }} km</td>
          <td>
            Pénalité de 5 aux <NuxtLink to="/regles/competences/tests/passif">tests passifs</NuxtLink> de
            <NuxtLink to="/regles/competences/perception">Perception</NuxtLink>
          </td>
        </tr>
      </tbody>
    </table>
    <h2 class="h3">Lieue</h2>
    <p>
      La lieue est une unité de mesure officialisée en Ouespéro. Elle correspond à la distance qu’un homme normal parcourt à pied en une heure à cadence
      normale, en tenant compte de son équipement et de l’état moyen des routes et sentiers. Cette distance est de
      <strong>{{ $n(3218.68, "decimal") }} mètres</strong>, habituellement arrondie à <strong>{{ $n(3.2, "decimal") }} km</strong>.
    </p>
    <p>Les vitesses d’une créature n’influencent en aucun cas cette distance parcourue.</p>
    <h2 class="h3">Marche forcée</h2>
    <p>
      Une créature peut se déplacer pendant 8 heures par jour sans subir de pénalité. Pour chaque heure supplémentaire de déplacement, une créature tombe en
      situation de <strong>marche&nbsp;forcée</strong>. À la fin de chaque heure de marche forcée, une créature reçoit des
      <strong>points de dégâts non létaux</strong> et doit effectuer un <NuxtLink to="/regles/competences/tests/sauvegarde">jet de sauvegarde</NuxtLink> de
      <NuxtLink to="/regles/competences/resistance">Résistance</NuxtLink>.
    </p>
    <ul>
      <li>Les points de dégâts sont de 2d6 multipliés par heure de marche forcée : 2d6 pour la première heure, 4d6 pour la seconde, et ainsi de suite.</li>
      <li>
        Le <NuxtLink to="/regles/competences/tests/difficulte">degré de difficulté</NuxtLink> du jet de sauvegarde est de 5 par heure de marche forcée,
        additionné de 5 : 10 pour la première heure, 15 pour la seconde, et ainsi de suite.
      </li>
      <li>Si une créature échoue le jet de sauvegarde, elle est affligée d’<strong>un niveau de Fatigue</strong>.</li>
      <li>
        Une créature <NuxtLink to="/regles/equipement/encombrement">encombrée</NuxtLink> ou tirant un
        <NuxtLink to="/regles/equipement/montures-vehicules/terrestres">véhicule terrestre</NuxtLink> doit effectuer le jet de sauvegarde avec
        <NuxtLink to="/regles/competences/tests/avantage-desavantage">désavantage</NuxtLink>.
      </li>
    </ul>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Aventure", to: "/regles/aventure" },
  { text: "Mouvement", to: "/regles/aventure/mouvement" },
];
const title: string = "Cadences";

useSeo({
  title,
  description: "🚧",
});

// TODO(fpion):
// Il est possible de se déplacer plus rapidement à l’aide d’une monture ou d’un véhicule.
// Une monture peut galoper pendant une heure afin de doubler sa vitesse, puis tomber en marche forcée pour chaque heure supplémentaire.

// TODO(fpion): ACTIVITY WHILE TRAVELING:
// Marching Order
// Stealth
// Noticing Threats
// Other Activities
</script>
