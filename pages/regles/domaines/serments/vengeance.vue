<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <RulesBreadcrumb active="Vengeance" :parent="parent" />
    <p>
      Le Serment de Vengeance est un engagement solennel à châtier ceux qui ont commis un péché grave. Lorsque le mal massacre des innocents, qu’un peuple se
      détourne des dieux, qu’une guilde devient trop violente ou qu’un dragon sème la terreur, des paladins se lèvent et prêtent ce serment. Pour ces vengeurs
      ou chevaliers noirs, la pureté importe moins que la justice : ils châtient les malfaiteurs par tous les moyens nécessaires, quitte à sacrifier leur propre
      droiture.
    </p>
    <ul>
      <li><strong>Combattre le plus grand mal.</strong> Face au choix entre ses ennemis jurés et un mal moindre, il choisit le plus grand mal.</li>
      <li><strong>Pas de pitié pour les impies.</strong> Des adversaires ordinaires peuvent gagner sa clémence, mais pas ses ennemis jurés.</li>
      <li><strong>Par tous les moyens nécessaires.</strong> Ses scrupules ne doivent pas faire obstacle à l’extermination de ses ennemis.</li>
      <li>
        <strong>Réparation.</strong> Si ses ennemis répandent la ruine, c’est qu’il a échoué à les arrêter : il doit aider ceux que leurs méfaits ont blessés.
      </li>
    </ul>
    <h2 class="h3">Âme de vengeance</h2>
    <p>
      Une créature déclenche une <NuxtLink to="/regles/combat/attaque/opportunite">attaque d’opportunité</NuxtLink> de la part du personnage lorsqu’elle
      effectue une <NuxtLink to="/regles/combat/attaque">attaque</NuxtLink>.
    </p>
    <h2 class="h3">Terreur divine</h2>
    <p>
      Par une <NuxtLink to="/regles/combat/deroulement/tour">action</NuxtLink>, le personnage invoque son pouvoir divin contre une créature située à 18 mètres
      ou moins de sa position qu’il peut <NuxtLink to="/regles/aventure/environnement/vision">voir</NuxtLink> et effectue un
      <NuxtLink to="/regles/competences/tests">test</NuxtLink> d’<NuxtLink to="/regles/competences/occultisme">Occultisme</NuxtLink>. La cible doit effectuer un
      <NuxtLink to="/regles/competences/tests/sauvegarde">jet de sauvegarde</NuxtLink> de <NuxtLink to="/regles/competences/discipline">Discipline</NuxtLink> de
      <NuxtLink to="/regles/competences/tests/difficulte">difficulté</NuxtLink> égale au résultat du test. Une créature immunisée à la
      <NuxtLink to="/regles/combat/conditions/apeure">peur</NuxtLink> n’est pas affectée par cette capacité. Le jet de sauvegarde est affligé du désavantage si
      la cible appartient à un des types de créature suivants : aberration, célestiel, élémentaire, fée, infernal et mort-vivant.
    </p>
    <p>
      En cas d’échec, la cible est apeurée, sa <NuxtLink to="/regles/aventure/mouvement/vitesse">vitesse</NuxtLink> chute à 0 et elle ne bénéficie d’aucun bonus
      à sa vitesse. En cas de réussite, la cible n’est pas apeurée et sa vitesse est réduite de moitié. L’effet prend fin après
      <NuxtLink to="/regles/aventure/temps">une minute</NuxtLink> ou si la cible est <NuxtLink to="/regles/combat/degats">blessée</NuxtLink>.
    </p>
    <h2 class="h3">Vœu d’inimitié</h2>
    <p>
      Par une <NuxtLink to="/regles/combat/deroulement/tour">action</NuxtLink>, le personnage invoque son pouvoir divin contre une créature située à 3 mètres ou
      moins de sa position qu’il peut <NuxtLink to="/regles/aventure/environnement">voir</NuxtLink>. Le
      <NuxtLink to="/regles/competences/tests">test</NuxtLink> de ses <NuxtLink to="/regles/combat/attaque">attaques</NuxtLink> dirigées contre la cible se voit
      conférer l’<NuxtLink to="/regles/competences/tests/avantage-desavantage">avantage</NuxtLink> pendant
      <NuxtLink to="/regles/aventure/temps">une minute</NuxtLink> ou jusqu’à ce que ses points de
      <NuxtLink to="/regles/statistiques/vitalite">Vitalité</NuxtLink> chutent à 0.
    </p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/tar/breadcrumb";

const parent: Breadcrumb[] = [
  { text: "Annexes", to: "/regles/annexes" },
  { text: "Serments sacrés", to: "/regles/domaines/serments" },
];
const title: string = "Serment de Vengeance";

useSeo({
  title,
  description:
    "Découvrez le Serment de Vengeance de SkillCraft, ses préceptes de justice implacable et ses pouvoirs divins pour traquer et châtier les ennemis jurés.",
});
</script>
