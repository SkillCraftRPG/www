<template>
  <main class="container">
    <h1>Calendrier</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <ul>
      <li>Date : {{ date }}</li>
      <li>Année : {{ year }}</li>
      <li>Mois : {{ month }}</li>
      <li>Jour du mois : {{ monthDay }}</li>
      <li>Année paire : {{ isEvenYear }}</li>
      <li>Index de l’année : {{ yearIndex }}</li>
      <li>Année bissextile : {{ isLeapYear }}</li>
      <li>Nombre de jours dans l'année : {{ daysInYear }}</li>
      <li>Nombre de jours dans le mois : {{ daysInMonth }}</li>
      <li>Plante : {{ plant }}</li>
      <li>Signe astrologique : {{ astrologicalSign }}</li>
    </ul>
  </main>
</template>

<script setup lang="ts">
import { parsingUtils } from "logitar-js";

import type { Breadcrumb } from "~/types/components";

const { parseNumber } = parsingUtils;

const parent: Breadcrumb[] = [];
const title: string = "Niveau";

const astrologicalSigns: string[] = [
  "Amphore",
  "Archer",
  "Balance",
  "Capricorne",
  "Chariot",
  "Coq",
  "Coquillage",
  "Crabe",
  "Destrier",
  "Lion",
  "Poisson",
  "Scorpion",
  "Berceau",
  "Vipère",
  "Pieuvre",
  "Lotus",
  "Arbre",
  "Échelle",
  "Sabre",
  "Tortue",
  "Lyre",
  "Serpe",
  "Aigle",
  "Caducée",
  "Lune",
];
const plants: string[] = [
  "Moly",
  "Chêne",
  "Bouleau",
  "Saule",
  "Tilleul",
  "Orme",
  "Pin",
  "Genévrier",
  "Frêne",
  "Aubépine",
  "Églantier",
  "Lavande",
  "Menthe",
  "Sauge",
  "Origan",
  "Fenouil",
  "Thym",
  "Romarin",
  "Camomille",
  "Millepertuis",
  "Ortie",
];

const date = ref<string>("1003-11-10");

const year = computed<number>(() => {
  const parts: string[] = date.value.split("-");
  let year: number | undefined;
  if (parts.length === 3) {
    year = parseNumber(parts[0]);
  }
  if (!year || year < 1) {
    throw new Error(`The date '${date.value}' or year '${year}' is not valid.`);
  }
  return year;
});
const month = computed<number>(() => {
  const parts: string[] = date.value.split("-");
  let month: number | undefined;
  if (parts.length === 3) {
    month = parseNumber(parts[1]);
  }
  if (!month || month < 1 || month > 12) {
    throw new Error(`The date '${date.value}' or month '${month}' is not valid.`);
  }
  return month;
});
const monthDay = computed<number>(() => {
  const parts: string[] = date.value.split("-");
  let monthDay: number | undefined;
  if (parts.length === 3) {
    monthDay = parseNumber(parts[2]);
  }
  if (!monthDay || monthDay < 1 || monthDay > 31) {
    // TODO(fpion): validate upper boundary
    throw new Error(`The date '${date.value}' or month day '${monthDay}' is not valid.`);
  }
  return monthDay;
});

const yearIndex = computed<number>(() => year.value % 21);
const isEvenYear = computed<boolean>(() => year.value % 2 === 0);
const isLeapYear = computed<boolean>(() => yearIndex.value < 20 && yearIndex.value % 4 === 0);
const daysInYear = computed<number>(() => (isLeapYear.value ? 366 : 365));
const daysInMonth = computed<number>(() => {
  if (month.value < 10 || isLeapYear.value) {
    return month.value % 2 ? 30 : 31;
  }
  return month.value === 11 ? 31 : 30;
});

const plant = computed<string>(() => plants[yearIndex.value] ?? "");
const astrologicalSign = computed<string>(() => {
  let index: number = month.value - 1;
  if (isEvenYear.value) {
    index += 12;
  }
  return astrologicalSigns[index] ?? "";
});

// TODO(fpion): numéro du jour dans l'année
// TODO(fpion): équinoxes & solstices

// TODO(fpion): # du cycle lunaire & animal associé
// TODO(fpion): jour de la semaine (lundi-dimanche)
// TODO(fpion): # de la semaine & élément
// TODO(fpion): pictogramme de la phase lunaire

// TODO(fpion): pierre de naissance ?

// TODO(fpion): liste des événements [WHERE (year IS NULL OR year = :year) AND month = :month AND day = :day]

useSeo({
  title,
  description: "🚧",
});
</script>
