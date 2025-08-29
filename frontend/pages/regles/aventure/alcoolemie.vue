<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p class="text-danger">Dans le jeu, l’alcool est représenté par les boissons alcoolisées.</p>
    <p class="text-danger">Celles-ci peuvent être ingérées par les personnages afin d’acquérir les effets de l’ébriété ou pour gagner un concours d’alcool.</p>
    <p class="text-danger">L’ingestion d’alcool inflige des points d’alcoolémie au personnage et risque de le mettre en état d’ébriété.</p>
    <h2 class="h3">Table des matières</h2>
    <ul>
      <li>
        <a href="#points">Points d’alcoolémie</a>
      </li>
      <li>
        <a href="#seuil">Seuil de tolérance</a>
      </li>
      <li>
        <a href="#ebriete">Ébriété</a>
        <ul>
          <li>
            <a href="#phase-1">Phase 1</a>
          </li>
          <li>
            <a href="#phase-2">Phase 2</a>
          </li>
          <li>
            <a href="#phase-3">Phase 3</a>
          </li>
          <li>
            <a href="#coma">Coma éthylique</a>
          </li>
        </ul>
      </li>
    </ul>
    <h2 id="points" class="h3">Points d’alcoolémie</h2>
    <p>
      Lorsqu’un personnage ingère une <NuxtLink to="/regles/equipement/services/gite-couvert">boisson alcoolisée</NuxtLink>, ses points d’alcoolémie augmentent
      en fonction de la quantité d’alcool ingéré.
    </p>
    <p>En règle générale, 100 ml d’alcool pur équivaut à 12 points d’alcoolémie.</p>
    <p>À chaque heure, un personnage perd un point d’alcoolémie jusqu’à ce que ceux-ci retombent à 0.</p>
    <p>Voici des exemples de boissons alcoolisées et des points d’alcoolémie qu’elles octroient :</p>
    <table class="table table-striped text-center">
      <thead>
        <tr>
          <th scope="col" class="w-25">Alcool</th>
          <th scope="col" class="w-25">Volume</th>
          <th scope="col" class="w-25">Concentration</th>
          <th scope="col" class="w-25">Points d’alcoolémie</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="(item, index) in items" :key="index">
          <td>{{ item.name }}</td>
          <td>{{ $n(item.volume, "decimal") }} oz / {{ $n(ozToMl(item.volume), "integer") }} ml</td>
          <td>{{ $n(item.concentration, "percentage") }}</td>
          <td>{{ $n(calculatePoints(item), "integer") }}</td>
        </tr>
      </tbody>
    </table>
    <h2 id="seuil" class="h3">Seuil de tolérance</h2>
    <p>Chaque créature est dotée d’un <strong>seuil de tolérance</strong> représentant la quantité d’alcool qu’elle peut ingérer sans répercussion négative.</p>
    <p>
      Le seuil consiste en un nombre de points d’alcoolémie en fonction de la <NuxtLink to="/regles/attributs/sante">Santé</NuxtLink> de la créature :
      <code>Santé + 5</code> (minimum 1).
    </p>
    <p>Les talents suivants augmentent ce seuil de manière permanente, en plus de conférer des bonus en lien avec l’alcool :</p>
    <div class="row">
      <div v-for="talent in filteredTalents" :key="talent.id" class="col-xs-12 col-sm-6 col-md-4 col-lg-3 mb-4">
        <TalentCard class="d-flex flex-column h-100" :talent="talent" />
      </div>
    </div>
    <h2 class="h3">Ébriété</h2>
    <p>
      Lorsqu’une créature ingère une boisson alcoolisée, elle risque de tomber en état d’ébriété. Si ses points d’alcoolémie sont supérieurs à son seuil de
      tolérance, elle doit effectuer un <NuxtLink to="/regles/competences/tests/sauvegarde">jet de sauvegarde</NuxtLink> de
      <NuxtLink to="/regles/competences/resistance">Résistance</NuxtLink>.
    </p>
    <p>
      Le <NuxtLink to="/regles/competences/tests/difficulte">degré de difficulté</NuxtLink> est égal à l’excédent de points d’alcoolémie multiplié par 2,5
      additionné de 10, le tout arrondi à la baisse. Par exemple, pour un seuil de tolérance de 5 et 7 points d’alcoolémie, le degré de difficulté sera de 15.
    </p>
    <p>
      <code>Difficulté = 10 + (((points d’alcoolémie - seuil de tolérance) × 5) ÷ 2)</code>
    </p>
    <p>
      En cas de réussite, son état est inchangé. En cas d’échec, elle passe à la phase suivante d’ébriété. Lorsqu’une créature passe à une phase d’ébriété
      supérieure, on note les points d’alcoolémie au moment du changement. Elle reste dans cette phase tant que ses points d’alcoolémie sont supérieurs ou égaux
      à ce nombre.
    </p>
    <p>
      Par exemple, si une créature passe à la première phase à 6 points d’alcoolémie et à la seconde phase à 8 points, alors elle reste à la phase 2 tant que
      ses points ne descendent pas à 7, et elle reste à la phase 1 tant que ses points ne descendent pas à 5.
    </p>
    <p class="text-danger">Lorsque le personnage dort en état d’ébriété, sa régénération d’Énergie est réduite de moitié.</p>
    <h3 id="phase-1" class="h5">Phase 1</h3>
    <p>Une créature en phase 1 d’ébriété est affectée par les capacités et pénalités suivantes :</p>
    <ul>
      <li>
        <strong>Effort débridé.</strong> Elle peut se conférer l’<NuxtLink to="/regles/competences/tests/avantage-desavantage">avantage</NuxtLink> à un
        <NuxtLink to="/regles/competences/tests">test</NuxtLink> de <NuxtLink to="/regles/competences/resistance">Résistance</NuxtLink> (sauf contre l’ébriété)
        ou de <NuxtLink to="/regles/attributs/vigueur">Vigueur</NuxtLink> (<NuxtLink to="/regles/competences/athletisme">Athlétisme</NuxtLink> et
        <NuxtLink to="/regles/competences/melee">Mêlée</NuxtLink>). Lorsqu’elle utilise cette capacité, elle dépense 1d10 points d’<NuxtLink
          to="/regles/statistiques/energie"
          >Énergie</NuxtLink
        >. Si elle échoue le test, elle reçoit un nombre égal de points de dégâts non létaux.
      </li>
      <li>Avantage aux jets de sauvegarde de <NuxtLink to="/regles/competences/discipline">Discipline</NuxtLink> contre la <strong>peur</strong>.</li>
      <li>
        <NuxtLink to="/regles/competences/tests/avantage-desavantage">Désavantage</NuxtLink> aux
        <NuxtLink to="/regles/competences/tests">tests</NuxtLink> d’<NuxtLink to="/regles/attributs/adresse">Adresse</NuxtLink> (<NuxtLink
          to="/regles/competences/acrobaties"
          >Acrobaties</NuxtLink
        >, <NuxtLink to="/regles/competences/artisanat">Artisanat</NuxtLink>, <NuxtLink to="/regles/competences/furtivite">Furtivité</NuxtLink>,
        <NuxtLink to="/regles/competences/orientation">Orientation</NuxtLink> et <NuxtLink to="/regles/competences/roublardise">Roublardise</NuxtLink>).
      </li>
    </ul>
    <h3 id="phase-2" class="h5">Phase 2</h3>
    <p>Une créature en phase 2 d’ébriété est affectée par les capacités et pénalités suivantes :</p>
    <ul>
      <li>
        <strong>Effort débridé.</strong> Elle peut encore utiliser cette capacité, mais en dépensant 2d10 points d’<NuxtLink to="/regles/statistiques/energie"
          >Énergie</NuxtLink
        >, et en recevant un nombre égal de points de dégâts non létaux en cas d’échec.
      </li>
      <li>
        <NuxtLink to="/regles/competences/tests/avantage-desavantage">Désavantage</NuxtLink> aux <NuxtLink to="/regles/competences/tests">tests</NuxtLink> de :
        <ul>
          <li>
            <NuxtLink to="/regles/attributs/adresse">Adresse</NuxtLink> (<NuxtLink to="/regles/competences/acrobaties">Acrobaties</NuxtLink>,
            <NuxtLink to="/regles/competences/artisanat">Artisanat</NuxtLink>, <NuxtLink to="/regles/competences/furtivite">Furtivité</NuxtLink>,
            <NuxtLink to="/regles/competences/orientation">Orientation</NuxtLink> et <NuxtLink to="/regles/competences/roublardise">Roublardise</NuxtLink>).
          </li>
          <li>
            <NuxtLink to="/regles/attributs/intellect">Intellect</NuxtLink> (<NuxtLink to="/regles/competences/connaissance">Connaissance</NuxtLink>,
            <NuxtLink to="/regles/competences/investigation">Investigation</NuxtLink>,
            <NuxtLink to="/regles/competences/linguistique">Linguistique</NuxtLink> et <NuxtLink to="/regles/competences/medecine">Médecine</NuxtLink>).
          </li>
          <li>
            <NuxtLink to="/regles/attributs/sens">Sens</NuxtLink> (<NuxtLink to="/regles/competences/intuition">Intuition</NuxtLink>,
            <NuxtLink to="/regles/competences/occultisme">Occultisme</NuxtLink>, <NuxtLink to="/regles/competences/perception">Perception</NuxtLink> et
            <NuxtLink to="/regles/competences/survie">Survie</NuxtLink>).
          </li>
          <li><NuxtLink to="/regles/competences/discipline">Discipline</NuxtLink> (sauf contre la <strong>peur</strong>).</li>
          <li>
            <NuxtLink to="/regles/competences/diplomatie">Diplomatie</NuxtLink>, <NuxtLink to="/regles/competences/representation">Représentation</NuxtLink> et
            <NuxtLink to="/regles/competences/tromperie">Tromperie</NuxtLink>.
          </li>
        </ul>
      </li>
      <li>
        <strong>Titubement.</strong> Lorsque la créature tente de <NuxtLink to="/regles/aventure/mouvement">se déplacer</NuxtLink>, elle doit effectuer un
        <NuxtLink to="/regles/competences/tests/sauvegarde">jet de sauvegarde</NuxtLink> d’<NuxtLink to="/regles/competences/acrobaties">Acrobaties</NuxtLink>
        de <NuxtLink to="/regles/competences/tests/difficulte">difficulté faible</NuxtLink>. En cas d’échec, ses mouvements sont aléatoires, changeant de
        direction tous les 3 mètres.
      </li>
    </ul>
    <h3 id="phase-3" class="h5">Phase 3</h3>
    <p>Une créature en phase 3 d’ébriété est affectée par les pénalités suivantes :</p>
    <ul>
      <li>
        <NuxtLink to="/regles/competences/tests/avantage-desavantage">Désavantage</NuxtLink> à tous ses
        <NuxtLink to="/regles/competences/tests">tests</NuxtLink> (incluant contre la <strong>peur</strong>).
      </li>
      <li>
        <strong>Titubement.</strong> Ses mouvements sont aléatoires, changeant de direction tous les 3 mètres. Cette pénalité est automatique et sans
        <NuxtLink to="/regles/competences/tests/sauvegarde">jet de sauvegarde</NuxtLink>.
      </li>
    </ul>
    <h3 id="coma" class="h5">Coma éthylique</h3>
    <p>
      Une créature en coma éthylique est <strong>inconsciente</strong> et sa vie est en danger. À la fin de chaque heure de coma éthylique, lancez vos
      <NuxtLink to="/regles/competences/tests/2d10">dés d’Espérance et de Damnation</NuxtLink>.
    </p>
    <ul>
      <li>
        <NuxtLink to="/regles/competences/tests/critique">Réussite critique.</NuxtLink> La créature survit, et vous ne lancez pas les dés pour les heures
        subséquentes.
      </li>
      <li><strong>Réussite.</strong> La créature survit.</li>
      <li><strong>Échec.</strong> La créature meurt.</li>
      <li><NuxtLink to="/regles/competences/tests/critique">Échec critique.</NuxtLink> La créature meurt, et ses organes vitaux cèdent.</li>
    </ul>
    <p>
      Si une autre créature prend soin d’elle en lui donnant de l’eau, en l’empêchant de s’étouffer et en surveillant son état pendant cette heure, aucun jet
      n’est nécessaire. La créature survit automatiquement, mais reste inconsciente jusqu’à ce qu’elle retombe en phase 3 d’alcoolémie.
    </p>
    <div class="text-danger">
      <h2 class="h3">Vomir</h2>
      <p>
        Lorsque le personnage échoue le jet de sauvegarde, il peut vomir afin de conserver son état actuel et ainsi éviter de passer à la phase suivante.
        <br />
        Il reçoit un nombre de points de dégâts létaux égal à 1d6 par point d’alcoolémie en excès.
        <br />
        Par exemple, pour 4 points d’alcoolémie et un seuil de tolérance de 2 points, le personnage reçoit 2d6 points de dégâts létaux.
        <br />
        De plus, les pénalités infligées par l’ébriété durent jusqu’à ce que le personnage ait complété une nuit de sommeil.
        <br />
        Si le personnage vomit plus d’une fois avant d’avoir effectué une nuit complète de sommeil, alors il est affligé d’une gueule de bois d’une durée
        minimale de 8 heures.
      </p>
    </div>
    <div class="text-danger">
      <h2 class="h3">Gueule de bois</h2>
      <p>
        Un personnage est affligé d’une gueule de bois lorsqu’il vomit plusieurs fois, qu’il tombe en coma éthylique ou qu’il passe à une phase d’ébriété en
        échouant le second jet de sauvegarde.
        <br />
        Lorsqu’il n’est plus en état d’ébriété, il est affligé d’un niveau de Fatigue.
        <br />
        Il ne récupère aucun niveau de Fatigue lors de sa prochaine nuit de sommeil complétée.
        <br />
        Après deux nuits de sommeil complètes, il récupère ce niveau de fatigue et n’est plus affligé de la gueule de bois.
      </p>
    </div>
    <button class="btn btn-lg btn-primary position-fixed bottom-0 end-0 m-3 rounded-circle" @click="scrollToTop">
      <font-awesome-icon icon="fas fa-arrow-up" />
    </button>
  </main>
</template>

<script setup lang="ts">
import { arrayUtils } from "logitar-js";

import { getTalents } from "~/services/talents";
import type { Breadcrumb } from "~/types/components";
import type { Talent } from "~/types/game";

const parent: Breadcrumb[] = [{ text: "Aventure", to: "/regles/aventure" }];
const title: string = "Alcoolémie";
const { orderBy } = arrayUtils;

type Alcohol = {
  name: string;
  volume: number;
  concentration: number;
};
const items = ref<Alcohol[]>([
  {
    name: "Absinthe",
    volume: 1,
    concentration: 0.68,
  },
  {
    name: "Cervoise",
    volume: 16,
    concentration: 0.035,
  },
  {
    name: "Cidre",
    volume: 10,
    concentration: 0.06,
  },
  {
    name: "Eau-de-vie",
    volume: 1,
    concentration: 0.35,
  },
  {
    name: "Hydromel",
    volume: 5,
    concentration: 0.11,
  },
  {
    name: "Piquette",
    volume: 10,
    concentration: 0.03,
  },
  {
    name: "Poiré",
    volume: 8,
    concentration: 0.07,
  },
  {
    name: "Saké",
    volume: 4,
    concentration: 0.15,
  },
  {
    name: "Vin",
    volume: 5,
    concentration: 0.12,
  },
  {
    name: "Vin fortifié",
    volume: 5,
    concentration: 0.18,
  },
]);

const talents = ref<Talent[]>(getTalents({ requiredTalent: true }));

const filteredTalents = computed<Talent[]>(() =>
  orderBy(
    talents.value.filter(({ slug }) => slug.includes("alcool")).map((talent) => ({ ...talent, sort: [talent.tier, talent.slug].join("_") })),
    "sort",
  ),
);

function calculatePoints(item: Alcohol): number {
  return ((ozToMl(item.volume) * item.concentration) / 100) * 12;
}

useSeo({
  title,
  description: "🚧",
});
</script>
