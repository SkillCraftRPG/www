<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb active="Professionnels" :parent="parent" />
    <p>🚧</p>
    <table class="table table-striped text-center">
      <thead>
        <tr>
          <th scope="col" class="w-20">Service</th>
          <th scope="col" class="w-10">Prix (deniers)</th>
          <th scope="col" class="w-70">Description</th>
        </tr>
      </thead>
      <tbody>
        <tr>
          <td colspan="3">
            <i>Cabriolet</i>
          </td>
        </tr>
        <tr>
          <td>Au sein d’une cité</td>
          <td>{{ $n(0.01, "price") }}</td>
          <td>Transport dans un véhicule tiré par des chevaux entre deux emplacements dans la même cité.</td>
        </tr>
        <tr>
          <td>Entre deux cités (1 lieue)</td>
          <td>{{ $n(0.1, "price") }}</td>
          <td>Transport entre deux cités, sur une route pavée, dégagée et sans danger.</td>
        </tr>
        <tr>
          <td colspan="3">
            <i>Médecine</i>
          </td>
        </tr>
        <tr>
          <td>Guérisseur (1 charge)</td>
          <td>{{ $n(1, "price") }}</td>
          <td>
            Le prix des soins reçus peut varier grandement en fonction de la rareté d’une trousse de premiers soins et des matériaux requis afin de prodiguer
            ces soins.
          </td>
        </tr>
        <tr>
          <td>Hippiatre (2 charges)</td>
          <td>{{ $n(3, "price") }}</td>
          <td>
            Des soins adaptés à une monture, typiquement un cheval. Le prix peut être supérieur pour une monture exotique tel un éléphant. Ce service est
            parfois offert aux écuries.
          </td>
        </tr>
        <tr>
          <td colspan="3">
            <i>Mercenaires</i>
          </td>
        </tr>
        <tr>
          <td>Sans formation (1 journée)</td>
          <td>{{ $n(0.2, "price") }}</td>
          <td rowspan="2">
            Les mercenaires sont généralement utilisés afin d’accomplir des sales besognes. Leur prix varie en fonction du niveau de qualification nécessaire à
            l’accomplissement de ces labeurs.
          </td>
        </tr>
        <tr>
          <td>Qualifié (1 journée)</td>
          <td>{{ $n(2, "price") }}</td>
        </tr>
        <tr>
          <td colspan="3">
            <i>Palefrenier</i>
          </td>
        </tr>
        <tr>
          <td>Écuries (1 journée)</td>
          <td>{{ $n(0.5, "price") }}</td>
          <td>
            L’écurie est l’équivalent de l’auberge pour les montures. Le prix peut être largement supérieur pour une monture exotique tel un éléphant. Un
            palefrenier peut également refuser de s’occuper d’une monture exotique. De manière générale, les auberges modestes ou ayant un coût supérieur sont
            dotées d’écuries. Le prix inclut un toilettage, la nourriture pour une monture ainsi qu’une stalle individuelle. Il peut varier en fonction du prix
            du service de gîte de l’auberge.
          </td>
        </tr>
        <tr>
          <td>Toilettage</td>
          <td>{{ $n(0.05, "price") }}</td>
          <td>
            Un pansage de base pour une monture : nettoyage des sabots, étrillage et peignage de la crinière. Le prix peut être largement supérieure pour une
            monture exotique tel un éléphant. Il peut varier en fonction du prix de service d’écuries. Un palefrenier peut également refuser de s’occuper d’une
            monture exotique.
          </td>
        </tr>
        <tr>
          <td colspan="3">
            <i>Divers</i>
          </td>
        </tr>
        <tr>
          <td>Coursier (1 lieue)</td>
          <td>{{ $n(0.06, "price") }}</td>
          <td>
            Un messager traversant rapidement une grande distance afin de délivrer un message. Il utilise des chevaux de traits disponibles à plusieurs arrêts
            sur son trajet. Le prix peut varier en fonction du niveau de danger du trajet. Un coursier peut refuser un trajet trop lointain ou périlleux.
          </td>
        </tr>
        <tr>
          <td>Péage</td>
          <td>{{ $n(0.01, "price") }}</td>
          <td>
            Le prix afin de traverser un pont ou un portal gardé. Le péage peut également être nécessaire afin d’emprunter une route pavée, dégagée et sans
            danger. Le prix peut varier en fonction des dangers de la région, et du niveau de risque associé aux voyageurs.
          </td>
        </tr>
      </tbody>
    </table>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Équipement", to: "/regles/equipement" },
  { text: "Services", to: "/regles/equipement/services" },
];
const title: string = "Services professionnels";

useSeo({
  title,
  description: "🚧",
});
</script>
