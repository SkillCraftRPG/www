<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <RulesBreadcrumb :active="title" :parent="parent" />
    <p>
      C’est par le <strong>jeu de rôle</strong> que le joueur donne vie aux actions et paroles de son personnage. Le maître de jeu aussi joue un ou plusieurs
      rôles, lorsqu’il anime par exemple les créatures ennemies ou les personnages non-joueur qui aideront ou nuiront aux joueurs. Il existe plusieurs types de
      jeu rôle : cette annexe aborde le schéma classique et le jeu de rôle proactif.
    </p>
    <h2 class="h3">Table des matières</h2>
    <ul>
      <li>
        <a href="#classique">Schéma classique</a>
      </li>
      <li>
        <a href="#proactif">Jeu de rôle proactif</a>
        <ul>
          <li>
            <a href="#reve">Rêve</a>
          </li>
          <li>
            <a href="#quete">Quête</a>
          </li>
          <li>
            <a href="#tache">Tâche</a>
          </li>
          <li>
            <a href="#marche-suivre">Marche à suivre</a>
          </li>
        </ul>
      </li>
      <li>
        <a href="#comparaison">Comparaison des types de jeu de rôle</a>
      </li>
    </ul>
    <h2 id="classique" class="h3">Schéma classique</h2>
    <p>Le schéma classique de jeu correspond à la structure générale d’un récit narratif.</p>
    <ol>
      <li>
        D’abord, les personnages vaquent à leurs occupations. Il s’agit de la <strong>situation initiale</strong> qui se déroule avant le début de l’aventure.
      </li>
      <li>Ensuite survient un <strong>élément déclencheur</strong>. Cet élément démarre l’intrigue et attache les joueurs au sein d’un même groupe.</li>
      <li>
        Une ou plusieurs <strong>péripéties</strong> se produiront. Ces péripéties sont des tentatives des joueurs de résoudre la situation introduite par
        l’élément déclencheur, ou des événements importants qui se produiront pendant l’aventure, telles des quêtes et des embûches.
      </li>
      <li>
        Le <strong>dénouement</strong> mettra fin à la situation causée par l’élément déclencheur. Le dénouement survient lorsque les joueurs accomplissent tous
        les objectifs, qu’ils perdent tous la vie, ou que le groupe se dissout parce que les joueurs ne partagent plus d’intérêts communs.
      </li>
      <li>
        Lorsque les personnages retournent à leur vie ou poursuivent leurs aventures vers d’autres lendemains, c’est la <strong>situation finale</strong>. De
        manière générale, lorsque l’intrigue est bouclée et que la situation finale advient, les joueurs ne jouent plus un rôle actif dans l’histoire. Ils
        peuvent conseiller le maître de jeu sur les actions que leurs personnages pourraient entreprendre, mais ils passent généralement à une autre histoire
        avec de nouveaux personnages.
      </li>
    </ol>
    <p>
      Tout au long de ce récit narratif, les joueurs participent à l’histoire inventée par le maître de jeu. Cette histoire peut suivre une ligne directrice ou
      avoir des fourches (choix influencés par l’histoire), mais elle transite toujours vers la direction préparée par le maître de jeu tel un système
      ferroviaire. Dans ce schéma de jeu, c’est le maître de jeu qui impose les situations et les joueurs occupent un rôle réactif.
    </p>
    <h2 id="proactif" class="h3">Jeu de rôle proactif</h2>
    <p>
      Le <strong>jeu de rôle proactif</strong> se distingue du schéma classique par le fait qu’il est beaucoup plus libre et moins organisé. Le maître de jeu ne
      doit pas prédire toutes les possibilités ni limiter les choix des joueurs afin de ne pas déroger de la ou les lignes directrices. Dans ce schéma de jeu,
      c’est le maître de jeu qui occupe un rôle réactif. Également, dans ce schéma de jeu, les joueurs et l’univers dans lequel ils se trouvent peuvent évoluer
      de manière indépendante, ce qui est bien plus réaliste. Les personnages n’influenceront l’univers que lorsque leur histoire rencontrera celle d’autres
      éléments de l’univers.
    </p>
    <p>
      L’implication des joueurs dans l’histoire est bien plus importante, puisque sans cette implication, l’histoire tournera en rond et rien ne se produira.
      Cette implication nécessite une plus grande planification entre les séances de jeu. Cette préparation consiste à établir un ou plusieurs objectifs pour
      leur personnage, et à discuter de ces objectifs avec le maître de jeu. Optionnellement, les joueurs peuvent également établir leurs objectifs ensemble
      afin de s’assurer une certaine cohérence. Pour y arriver, les joueurs devront établir trois types d’objectifs définis ci-dessous : un rêve, une ou
      plusieurs quêtes et des étapes. La responsabilité d’établir incombe bien évidemment aux joueurs et non pas au maître de jeu.
    </p>
    <h3 id="reve" class="h5">Rêve</h3>
    <p>
      Le <strong>rêve</strong> est l’objectif d’une vie pour un personnage. Bien qu’il puisse être réaliste et atteignable à long terme, il n’est pas contraint
      par les mêmes règles que les autres types d’objectifs. Il reste néanmoins important puisqu’il motive le personnage à rester en vie et donne naissance à
      ses quêtes.
    </p>
    <h3 id="quete" class="h5">Quête</h3>
    <p>
      Une <strong>quête</strong> est un objectif important dans la vie d’un personnage. Il s’agit d’un objectif atteignable à moyen-terme (3 à 5 séances de
      jeu). L’objectif doit être plaisant à accomplir pour le joueur ; avant tout, cela reste un jeu. Également, une quête doit imposer une ou plusieurs
      conséquences en cas d’échec. Cela augmentera l’implication et la motivation du personnage à réussir sa quête. Une bonne quête respecte les critères d’un
      objectif SMART.
    </p>
    <ul>
      <li>
        <strong>Spécifique.</strong> L’objectif est clair et précis, non ambigu. Il est décomposable en sous-objectifs et un seul critère permet de valider son
        atteinte.
      </li>
      <li>
        <strong>Mesurable.</strong> Il existe une manière de mesurer l’atteinte de l’objectif. Cette progression peut être mesurée en pourcentages, en nombre de
        sous-objectifs, ou simplement en oui/non.
      </li>
      <li>
        <strong>Atteignable.</strong> L’objectif est réaliste et possible à atteindre. Il est cohérent avec l’objectif des autres personnages du groupe et avec
        l’univers de jeu.
      </li>
      <li>
        <strong>Réaliste.</strong> Un objectif réaliste est pertinent pour le personnage. Si l’objectif ne permet pas au personnage d’atteindre ou d’avancer en
        direction de son rêve, il n’est pas réaliste.
      </li>
      <li>
        <strong>Temporel.</strong> L’objectif doit être atteint en un temps imparti. Ce temps correspond à environ 4 séances de jeu. S’il n’est pas atteint, il
        est échoué et une ou plusieurs conséquences surviennent.
      </li>
    </ul>
    <h3 id="tache" class="h5">Tâche</h3>
    <p>
      La <strong>tâche</strong> est une étape ou un sous-objectif composant une quête. Elle est atteignable à court terme (maximum 1 séance de jeu). Au fil des
      séances de jeu, le maître de jeu et les joueurs discutent des étapes nécessaires afin d’accomplir leurs quêtes. Le maître de jeu utilisera les étapes de
      tous les joueurs afin de préparer une séance de jeu. Elles doivent donc être discutés entre celles-ci, et donner un délai raisonnable au maître de jeu
      pour préparer la prochaine séance. Une tâche devrait également correspondre à un objectif SMART mais dont la portée est beaucoup plus petite.
    </p>
    <h3 id="marche-suivre" class="h5">Marche à suivre</h3>
    <p>Voici une marche à suivre pour le maître de jeu et les joueurs afin d’établir des objectifs pour le jeu de rôle proactif.</p>
    <ol>
      <li>Le joueur détermine le ou les rêves de son personnage.</li>
      <li>
        Le joueur réfléchit à la personnalité et à l’historique de son personnage. Il définit un ou plusieurs quêtes pour son personnage. Le maître de jeu
        s’assure que les quêtes respectent les critères SMART, qu’elles sont plaisantes à accomplir, et que des conséquences sont imposables en cas d’échec de
        ces quêtes. Le joueur retravaille ses quêtes au besoin.
      </li>
      <li>
        Les joueurs du même groupe partagent la ou les quêtes de leur personnage. Ils discutent des éléments communs et des points de friction. Le maître de jeu
        s’assure que les quêtes sont compatibles entre elles. Les joueurs retravaillent leurs quêtes au besoin.
      </li>
      <li>
        Pour chacune de ses quêtes, le joueur crée une ou deux tâches menant vers l’accomplissement de ces quêtes. Le maître de jeu s’assure que les tâches
        respectent les critères SMART, qu’elles sont plaisantes à effectuer, et que des conséquences sont imposables en cas d’échec de ces quêtes. Le joueur
        retravaille ses tâches au besoin.
      </li>
      <li>
        Les joueurs du même groupe partagent les tâches associées à leurs quêtes. Le maître de jeu s’assure que les tâches sont compatibles entre elles. Les
        joueurs retravaillent leurs tâches au besoin.
      </li>
    </ol>
    <p>
      Le partage des quêtes et tâches est optionnel. Si le maître de jeu connaît bien ses joueurs, il peut décider de ne pas exposer ces détails avant leur
      accomplissement, ce qui permet de préserver l’élément de surprise. Bien entendu, son bon jugement est de mise, et il doit toujours s’assurer de la
      compatibilité entre les quêtes et les tâches des différents joueurs d’un même groupe.
    </p>
    <h2 id="comparaison" class="h3">Comparaison des types de jeu de rôle</h2>
    <p>
      Le tableau ci-dessous présente un comparatif des types de jeu de rôle, mentionnant notamment leurs différences, avantages et inconvénients. Évidemment,
      d’autres types existent, mais ne sont pas inclus dans cet ouvrage puisqu’ils sont utilisés plus rarement.
    </p>
    <table class="table table-striped text-center">
      <thead>
        <tr>
          <th scope="col" class="w-50">Schéma classique</th>
          <th scope="col" class="w-50">Jeu de rôle proactif</th>
        </tr>
      </thead>
      <tbody>
        <tr>
          <td>Le maître de jeu prépare l’histoire et les joueurs réagissent à celle-ci.</td>
          <td>Les joueurs déterminent les objectifs de leur personnage et le maître de jeu prépare l’univers à accueillir ces objectifs.</td>
        </tr>
        <tr>
          <td>L’histoire se termine lorsque les personnages atteignent ou échouent les objectifs établis par le maître de jeu.</td>
          <td>L’histoire se termine lorsque les joueurs sentent qu’ils ont atteint une quantité d’objectifs pertinents.</td>
        </tr>
        <tr>
          <td>Convient mieux à un maître de jeu préférant suivre une ou plusieurs lignes directrices.</td>
          <td>Convient mieux à un maître de jeu créatif et ouvert d’esprit.</td>
        </tr>
        <tr>
          <td>
            Convient mieux à des joueurs qui n’ont pas le temps ni l’intérêt de s’investir dans l’histoire, préférant vivre celle-ci comme en lisant un roman,
            en visionnant un film ou en jouant à un jeu vidéo.
          </td>
          <td>Convient mieux à des joueurs désirant s’impliquer dans l’histoire et participer au processus créatif de l’intrigue.</td>
        </tr>
        <tr>
          <td>
            Plus facile à mettre en œuvre, car les joueurs travaillent à l’accomplissement d’un ou de plusieurs buts communs plutôt que d’objectifs personnels.
          </td>
          <td>
            Nécessite un effort collaboratif du maître de jeu et de tous les joueurs afin de mettre en commun des objectifs différents et de permettre
            l’accomplissement de ceux-ci.
          </td>
        </tr>
        <tr>
          <td>Réduit la quantité de chaos, mais le chaos est moins contrôlé et plus aléatoire.</td>
          <td>
            Le chaos est omniprésent puisqu’il est constamment introduit par les choix des joueurs. Cependant, il est plus contrôlé puisqu’il se produit afin
            d’atteindre des buts.
          </td>
        </tr>
        <tr>
          <td>L’intrigue est plus surprenante pour les joueurs car ils n’ont aucune idée de ce qui se déroulera.</td>
          <td>
            Les joueurs peuvent participer aux surprises en introduisant des éléments par leurs objectifs. Ils seront moins surpris par leur propre intrigue,
            mais pourront surprendre les autres joueurs du groupe.
          </td>
        </tr>
        <tr>
          <td>
            L’histoire de l’univers et des joueurs évolue généralement ensemble. L’impact des joueurs peut être plus grand sur l’univers, ce qui peut être plus
            intéressant, mais moins réaliste et moins cohérent.
          </td>
          <td>L’histoire de l’univers et des joueurs évoluent de manière indépendante et distincte. La cohérence et le réalisme sont supérieurs.</td>
        </tr>
      </tbody>
    </table>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/tar/breadcrumb";

const parent: Breadcrumb[] = [{ text: "Annexes", to: "/regles/annexes" }];
const title: string = "Jeu de rôle";

useSeo({
  title,
  description: "Découvrez le jeu de rôle dans SkillCraft : schéma classique, jeu proactif, rêves, quêtes et tâches pour structurer les aventures.",
});
</script>
