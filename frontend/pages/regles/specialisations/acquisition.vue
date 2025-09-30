<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb active="Acquisition" :parent="parent" />
    <p>Afin d’acquérir une spécialisation, vous devez acquérir son <NuxtLink to="/regles/specialisations/talent-reserve">talent réservé</NuxtLink>.</p>
    <p>Lorsque vous respectez toutes les conditions ci-dessous, vous pouvez acquérir ce talent.</p>
    <ol>
      <li>
        Vous devez respecter les <strong>Requis</strong> spécifiés. Par exemple, une spécialisation peut requérir l’acquisition d’une spécialisation d’un tiers
        inférieur.
      </li>
      <li>Vous devez avoir acquis tous les <strong>Talents obligatoires</strong> spécifiés.</li>
      <li>
        Vous devez avoir acquis un certain nombre de <NuxtLink to="/regles/talents">talents</NuxtLink>.
        <ul>
          <li>Ce nombre varie en fonction du tiers de la spécialisation convoitée.</li>
          <li>Ce nombre inclut les talents obligatoires.</li>
          <li>
            La balance de talents doit être acquise parmi la liste spécifiée de <strong>Talents optionnels</strong>, ou parmi la liste de
            <NuxtLink to="/regles/magie/pouvoirs">pouvoirs</NuxtLink> associés à cette spécialisation.
          </li>
          <li>
            Les talents et pouvoirs acquis gratuitement (0 <NuxtLink to="/regles/talents/points">point de talent</NuxtLink> dépensé) ne comptent pas dans ce
            nombre de talents.
          </li>
        </ul>
      </li>
    </ol>
    <table class="table table-striped text-center">
      <thead>
        <tr>
          <th scope="col" class="w-50">Tiers de la spécialisation</th>
          <th scope="col" class="w-50">Nombre de talents</th>
        </tr>
      </thead>
      <tbody>
        <tr>
          <td>1</td>
          <td>5</td>
        </tr>
        <tr>
          <td>2</td>
          <td>6</td>
        </tr>
        <tr>
          <td>3</td>
          <td>7</td>
        </tr>
      </tbody>
    </table>
    <h2 class="h3">Exemples</h2>
    <p>Voici des exemples qui vous aideront à comprendre comment fonctionne l’acquisition de spécialisations.</p>
    <h3 class="h5">Clerc</h3>
    <p>Afin d’acquérir la spécialisation <NuxtLink to="/regles/specialisations/clerc">Clerc</NuxtLink>, vous devez :</p>
    <ul>
      <li>
        <NuxtLink to="/regles/talents/acquisition">Acquérir</NuxtLink> le talent <NuxtLink to="/regles/talents/spiritualite">Spiritualité</NuxtLink>{{ " "
        }}<strong>(talent obligatoire)</strong> et sélectionner un <a href="#">domaine divin</a>{{ " " }}<strong>(requis)</strong>.
      </li>
      <li>
        <i>Clerc</i> étant une spécialisation de <NuxtLink to="/regles/personnages/progression/tiers">tiers 1</NuxtLink>, vous devez acquérir un total de 5
        <NuxtLink to="/regles/talents">talents</NuxtLink> ou options.
        <ul>
          <li><i>Spiritualité</i> compte dans ce nombre, même s’il s’agit du talent obligatoire.</li>
          <li><NuxtLink to="/regles/talents/occultisme">Occultisme</NuxtLink>, le talent requis pour <i>Spiritualité</i>, compte également dans ce nombre.</li>
          <li>
            Vous pourriez compléter avec, par exemple, les <strong>talents optionnels</strong>{{ " "
            }}<NuxtLink to="/regles/talents/connaissance">Connaissance</NuxtLink>, <NuxtLink to="/regles/talents/discipline">Discipline</NuxtLink>, et
            <NuxtLink to="/regles/talents/melee">Mêlée</NuxtLink>.
          </li>
        </ul>
      </li>
      <li>
        Lorsque les conditions précédentes sont remplies, vous pouvez acquérir le
        <NuxtLink to="/regles/specialisations/talent-reserve">talent réservé</NuxtLink> <i>Clergé</i> en dépensant
        <NuxtLink to="/regles/talents/points">2 points de talent</NuxtLink> (puisque <i>Clerc</i> est une spécialisation de tiers 1).
      </li>
      <li>Si votre personnage est au tiers 0, alors il augmente au tiers 1.</li>
    </ul>
    <h3 class="h5">Prêtre</h3>
    <p>Afin d’acquérir la spécialisation <NuxtLink to="/regles/specialisations/pretre">Prêtre</NuxtLink>, vous devez :</p>
    <ul>
      <li>Avoir préalablement acquis la spécialisation <i>Clerc</i>{{ " " }}<strong>(requis)</strong>.</li>
      <li>
        Si vous avez acquis la spécialisation <NuxtLink to="/regles/specialisations/champion">Champion</NuxtLink>, vous ne pourrez jamais acquérir la
        spécialisation <i>Prêtre</i>{{ " " }}<strong>(requis)</strong>.
      </li>
      <li>Acquérir le talent <NuxtLink to="/regles/talents/magie-puissante">Magie puissante</NuxtLink>{{ " " }}<strong>(talent obligatoire)</strong>.</li>
      <li>
        <i>Prêtre</i> étant une spécialisation de tiers 2, vous devez acquérir un total de 6 talents ou options.
        <ul>
          <li><i>Magie puissante</i> compte dans ce nombre, même s’il s’agit du talent obligatoire.</li>
          <li>
            Le <NuxtLink to="/regles/magie/pouvoirs">pouvoir</NuxtLink> de tiers 1 obtenu avec la spécialisation <i>Clerc</i> ne compte pas dans ce nombre,
            puisqu’il a été obtenu gratuitement.
          </li>
          <li>
            En revanche, supposons que vous avez acquis deux autres pouvoirs de tiers 1 en dépensant des points de talent. Ceux-ci comptent donc dans ce nombre.
          </li>
          <li>
            Vous pourriez compléter avec, par exemple, les <strong>talents optionnels</strong>{{ " "
            }}<NuxtLink to="/regles/talents/barriere-mentale">Barrière mentale</NuxtLink>, <NuxtLink to="/regles/talents/societe">Société</NuxtLink>, et
            <NuxtLink to="/regles/talents/renvoi-des-morts-vivants">Renvoi des morts-vivants</NuxtLink>.
          </li>
        </ul>
      </li>
      <li>
        Lorsque les conditions précédentes sont remplies, vous pouvez acquérir le talent réservé <i>Prêtrise</i> en dépensant 3 points de talent (puisque
        <i>Prêtre</i> est une spécialisation de tiers 2).
      </li>
      <li>Si votre personnage est au tiers 1, alors il augmente au tiers 2.</li>
    </ul>
    <button class="btn btn-lg btn-primary position-fixed bottom-0 end-0 m-3 rounded-circle" @click="scrollToTop">
      <font-awesome-icon icon="fas fa-arrow-up" />
    </button>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [{ text: "Spécialisations", to: "/regles/specialisations" }];
const title: string = "Acquisition de spécialisation";

useSeo({
  title,
  description: "Découvrez les règles d’acquisition de spécialisations : conditions, talents requis, pouvoirs associés et nombre de talents nécessaires.",
});
</script>
