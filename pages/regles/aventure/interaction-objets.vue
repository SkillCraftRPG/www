<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>L’action d’un personnage peut cibler un objet. Il peut par exemple actionner un levier, ouvrir une porte ou déplacer un livre dans une bibliothèque.</p>
    <p>
      Le joueur décrit les actions entreprises par son personnage et le maître de jeu explique les résultats de ces actions. Un
      <NuxtLink to="/regles/competences/tests">test</NuxtLink> peut être nécessaire, par exemple un test d’<NuxtLink to="/regles/competences/athletisme"
        >Athlétisme</NuxtLink
      >
      afin de déloger un levier coincé dans son mécanisme.
    </p>
    <p>
      Il est également possible d’endommager volontairement ou involontairement un objet. Généralement, n’importe quel objet destructible peut être endommagé ou
      détruit si on possède suffisamment de temps et les bons outils. Le maître de jeu fait preuve de bon sens pour déterminer si un personnage endommage ou
      brise un objet.
    </p>
    <p>Le maître de jeu peut également attribuer des statistiques à un objet afin déterminer la facilité avec laquelle il peut être endommagé ou détruit.</p>
    <h2 class="h3">Défense</h2>
    <p>
      Les objets étant inanimés, ils ne sont pas dotés d’<NuxtLink to="/regles/statistiques/esquive">Esquive</NuxtLink>. En revanche, ils possèdent une
      <NuxtLink to="/regles/combat/attaque/defense">Défense</NuxtLink> basée sur la dureté de leur matériau de construction. Un
      <NuxtLink to="/regles/competences/tests">test</NuxtLink> d’<NuxtLink to="/regles/combat/attaque">attaque</NuxtLink> doit être supérieur ou égal à la
      Défense de l’objet pour lui infliger des <NuxtLink to="/regles/combat/degats">dégâts</NuxtLink>.
    </p>
    <table class="table table-striped text-center">
      <thead>
        <tr>
          <th scope="col" class="w-third">Matériau</th>
          <th scope="col" class="w-sixth">Défense</th>
          <th scope="col" class="w-third">Matériau</th>
          <th scope="col" class="w-sixth">Défense</th>
        </tr>
      </thead>
      <tbody>
        <tr>
          <td>Coton, lin, papier</td>
          <td>5</td>
          <td>Fonte, platine</td>
          <td>16</td>
        </tr>
        <tr>
          <td>Corde, laine</td>
          <td>6</td>
          <td>Fer antique</td>
          <td>17</td>
        </tr>
        <tr>
          <td>Soie</td>
          <td>7</td>
          <td>Rocaille</td>
          <td>18</td>
        </tr>
        <tr>
          <td>Toile</td>
          <td>8</td>
          <td>Fer forgé</td>
          <td>20</td>
        </tr>
        <tr>
          <td>Bois tendre (pin, sapin, épicéa), étain, glace</td>
          <td>10</td>
          <td>Marbre</td>
          <td>21</td>
        </tr>
        <tr>
          <td>Ossements, plomb</td>
          <td>11</td>
          <td>Granit</td>
          <td>22</td>
        </tr>
        <tr>
          <td>Bois dur (chêne, frêne, hêtre), or, verre</td>
          <td>12</td>
          <td>Acier au creuset</td>
          <td>24</td>
        </tr>
        <tr>
          <td>Argent</td>
          <td>13</td>
          <td>Acier trempé</td>
          <td>27</td>
        </tr>
        <tr>
          <td>Cristal, cuivre</td>
          <td>14</td>
          <td>Mithril</td>
          <td>30</td>
        </tr>
        <tr>
          <td>Bronze, céramique, porcelaine</td>
          <td>15</td>
          <td>Adamantium, diamant</td>
          <td>35</td>
        </tr>
      </tbody>
    </table>
    <h2 class="h3">Résistance</h2>
    <p>
      Les objets n’étant pas vivants, ils ne sont pas dotés de points de <NuxtLink to="/regles/statistiques/vitalite">Vitalité</NuxtLink> ou d’<NuxtLink
        to="/regles/statistiques/energie"
        >Énergie</NuxtLink
      >. Cependant, ils sont dotés de points de Résistance afin de les remplacer. Ceux-ci fonctionnent de la même manière que la Vitalité d’une créature.
    </p>
    <p>
      Lorsque deux objets entrent en contact, c’est généralement l’objet le plus dur qui inflige des <NuxtLink to="/regles/combat/degats">dégâts</NuxtLink> à
      l’autre. Par exemple, une épée forgée en acier trempé infligera des dégâts à une porte en bois dur, mais la porte n’infligera pas de dégâts à l’épée. Le
      tableau précédent présente la dureté de divers matériaux.
    </p>
    <p>
      Lorsqu’un objet subit des points de dégâts, ceux-ci sont soustraits de sa Résistance. Un objet est endommagé lorsqu’il a perdu des points de Résistance.
      Lorsque celle-ci atteint 0, l’objet est détruit.
    </p>
    <p>
      Les objets plus solides possèdent généralement plus de points de Résistance que les objets fragiles. De la même manière, les objets de grande
      <NuxtLink to="/regles/especes/taille">taille</NuxtLink> possèdent également plus de points de Résistance que les objets de petite taille.
    </p>
    <p>
      Les armes normales sont peu efficaces contre les objets de grande taille, par exemple une colonne de pierre ou une statue colossale. Néanmoins, une torche
      peut réduire en cendres une tapisserie, et un tremblement de terre peut réduire un colosse en décombres.
    </p>
    <p>
      Le maître de jeu peut attribuer des points de Résistance supplémentaires aux objets très gros ou très solides. Il peut également répartir ces points de
      Résistance en sections, chacune possédant ses propres points de Résistance. Par exemple, une gigantesque statue en pierre pourrait posséder des points de
      Résistance pour chacune de ses jambes, de ses bras, pour sa tête ainsi que pour son torse. Cette statue pourrait s’effondrer au sol lorsqu’une de ses
      jambes est détruite.
    </p>
    <p>
      Certains objets très gros ou très solides, comme les fortifications d’un château, peuvent avoir un seuil minimal de dégâts à atteindre avant d’être
      endommagés. Ce seuil est retiré aux dégâts reçus par l’objet. Ainsi, une épée pourrait n’infliger aucun point de dégâts à une muraille, même si elle est
      en adamantium.
    </p>
    <p>
      Les objets sont <NuxtLink to="/regles/combat/degats/efficacite">immunisés</NuxtLink> aux dégâts de
      <NuxtLink to="/regles/combat/degats/types">poison</NuxtLink> et aux dégâts <NuxtLink to="/regles/combat/degats/types">psychiques</NuxtLink>. Certains
      <NuxtLink to="/regles/combat/degats/types">types de dégâts</NuxtLink> peuvent être plus ou moins
      <NuxtLink to="/regles/combat/degats/efficacite">efficaces</NuxtLink> contre certains objets. Par exemple, les objets en bois peuvent être
      <NuxtLink to="/regles/combat/degats/efficacite">vulnérables</NuxtLink> au <NuxtLink to="/regles/combat/degats/types">feu</NuxtLink>, alors que les objets
      en pierre y seraient <NuxtLink to="/regles/combat/degats/efficacite">immunisés</NuxtLink>. Le papier pourrait être
      <NuxtLink to="/regles/combat/degats/efficacite">résistant</NuxtLink> aux dégâts <NuxtLink to="/regles/combat/degats/types">contondants</NuxtLink>, mais
      <NuxtLink to="/regles/combat/degats/efficacite">vulnérable</NuxtLink> aux dégâts <NuxtLink to="/regles/combat/degats/types">tranchants</NuxtLink>.
    </p>
    <table class="table table-striped text-center">
      <thead>
        <tr>
          <th scope="col" class="w-20">Taille</th>
          <th scope="col" class="w-40">Exemples</th>
          <th scope="col" class="w-20">Fragile</th>
          <th scope="col" class="w-20">Solide</th>
        </tr>
      </thead>
      <tbody>
        <tr>
          <td>Minuscule</td>
          <td>Bouteille, verrou</td>
          <td>5 (2d4)</td>
          <td>10 (4d4)</td>
        </tr>
        <tr>
          <td>Petite</td>
          <td>Coffre, luth</td>
          <td>7 (2d6)</td>
          <td>21 (6d6)</td>
        </tr>
        <tr>
          <td>Moyenne</td>
          <td>Baril, chandelier</td>
          <td>9 (2d8)</td>
          <td>40 (9d8)</td>
        </tr>
        <tr>
          <td>Grande</td>
          <td>Charrette, fenêtre de 3 mètres par 3 mètres</td>
          <td>11 (2d10)</td>
          <td>60 (11d10)</td>
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

const parent: Breadcrumb[] = [{ text: "Aventure", to: "/regles/aventure" }];
const title: string = "Interaction avec les objets";

useSeo({
  title,
  description: "Découvrez les règles pour cibler, endommager et détruire des objets, avec Défense, Résistance et tableau des matériaux et tailles.",
});
</script>
