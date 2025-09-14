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
    <h2 class="h3">Exemple</h2>
    <p>🚧</p>
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
