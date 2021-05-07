<template>
  <base-layout pageTitle="View Employees - Card View">
    <ion-header collapse="condense">
      <ion-toolbar>
        <ion-title size="large">View Employees - Card</ion-title>
      </ion-toolbar>
    </ion-header>

    <ExploreContainer name="View Employees - Card page" />
  </base-layout>
</template>

<script lang="ts">
import { IonHeader, IonToolbar, IonTitle } from "@ionic/vue";
import ExploreContainer from "@/components/ExploreContainer.vue";

export default {
  name: "Tab2",
  components: {
    ExploreContainer,
    IonHeader,
    IonToolbar,
    IonTitle,
  },
};
</script>
