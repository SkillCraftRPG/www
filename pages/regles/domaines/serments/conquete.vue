<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <RulesBreadcrumb active="Conquête" :parent="parent" />
    <p>
      Le Serment de Conquête appelle les inquisiteurs qui cherchent la gloire au combat et la soumission de leurs ennemis. Il ne leur suffit pas d’établir
      l’ordre : ils doivent écraser le chaos. Appelés chevaliers tyrans ou marchands de fer, ceux qui prêtent ce serment se regroupent en ordres austères au
      service de dieux ou de philosophies de la guerre et de la puissance. Certains privilégient la loi à la miséricorde et sombrent dans les ténèbres ;
      d’autres du même serment les combattent avec férocité. Un inquisiteur qui prête ce serment a les préceptes de la conquête gravés sur le haut du bras.
    </p>
    <ul>
      <li>
        <strong>Éteindre la flamme de l’espoir.</strong> Il ne suffit pas de vaincre un ennemi : votre victoire doit être si écrasante que sa volonté de
        combattre est brisée à jamais, car une lame peut mettre fin à une vie, mais la peur peut mettre fin à un empire.
      </li>
      <li>
        <strong>Régner d’une main de fer.</strong> Une fois la conquête accomplie, ne tolérez aucune dissidence : votre parole est loi, ceux qui lui obéissent
        seront favorisés et ceux qui la défient seront châtiés en exemple.
      </li>
      <li>
        <strong>La force avant tout.</strong> Vous régnerez jusqu’à ce qu’un plus fort se lève, alors vous devez devenir plus puissant et relever le défi, ou
        succomber à votre propre ruine.
      </li>
    </ul>
    <h2 class="h3">Frappe guidée</h2>
    <p>
      Lorsqu’il effectue une <NuxtLink to="/regles/combat/attaque">attaque</NuxtLink>, le personnage peut invoquer son pouvoir divin en
      <NuxtLink to="/regles/combat/deroulement/tour">action libre</NuxtLink> et présenter son symbole divin en récitant une courte prière de
      <NuxtLink to="/regles/combat">combat</NuxtLink>. Il se alors voit conférer un bonus (+10) à son <NuxtLink to="/regles/competences/tests">test</NuxtLink>.
      Il peut utiliser cette capacité après avoir jeté les <NuxtLink to="/regles/competences/tests/2d10">dés</NuxtLink>, mais avant de savoir si le test est
      réussi ou échoué.
    </p>
    <h2 class="h3">Présence conquérante</h2>
    <p>
      Par une <NuxtLink to="/regles/combat/deroulement/tour">action</NuxtLink>, le personnage invoque son pouvoir divin et tente d’<NuxtLink
        to="/regles/combat/conditions/apeure"
        >apeurer</NuxtLink
      >
      toute créature de son choix située à 9 mètres ou moins de sa position qu’il peut <NuxtLink to="/regles/aventure/environnement/vision">voir</NuxtLink>. Une
      cible doit réussir un <NuxtLink to="/regles/competences/tests/sauvegarde">jet de sauvegarde</NuxtLink> de
      <NuxtLink to="/regles/competences/discipline">Discipline</NuxtLink> ou être apeurée par le personnage pendant
      <NuxtLink to="/regles/aventure/temps">une minute</NuxtLink>. Une créature apeurée peut répéter le jet de sauvegarde à la fin de chacun de ses
      <NuxtLink to="/regles/combat/deroulement/tour">tours</NuxtLink>. L’effet prend fin pour cette créature en cas de réussite.
    </p>
    <h2 class="h3">Réprimande méprisante</h2>
    <p>
      Lorsque le personnage est victime d’une <NuxtLink to="/regles/combat/attaque">attaque</NuxtLink> et qu’il n’est pas
      <NuxtLink to="/regles/combat/conditions/incapable">incapable</NuxtLink>, l’attaquant reçoit un nombre de
      <NuxtLink to="/regles/combat/degats">points de dégâts</NuxtLink> égal à la <NuxtLink to="/regles/attributs/sante">Santé</NuxtLink> (minimum&nbsp;1) du
      personnage. Le <NuxtLink to="/regles/combat/degats/types">type</NuxtLink> des dégâts varie en fonction de son
      <NuxtLink to="/regles/domaines/divins">domaine divin</NuxtLink>.
    </p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/tar/breadcrumb";

const parent: Breadcrumb[] = [
  { text: "Annexes", to: "/regles/annexes" },
  { text: "Serments sacrés", to: "/regles/domaines/serments" },
];
const title: string = "Serment de Conquête";

useSeo({
  title,
  description:
    "Découvrez le Serment de Conquête de SkillCraft, ses préceptes de domination et de puissance, ainsi que ses pouvoirs pour terrifier et soumettre les ennemis.",
});
</script>
