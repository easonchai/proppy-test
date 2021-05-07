<template>
  <base-layout pageTitle="View Employees - List View">
    <ion-header collapse="condense">
      <ion-toolbar>
        <ion-title size="large">View Employees - List</ion-title>
      </ion-toolbar>
    </ion-header>

    <ExploreContainer name="View Employees - List page" />
  </base-layout>
</template>

<script lang="ts">
import { IonHeader, IonToolbar, IonTitle } from "@ionic/vue";
import ExploreContainer from "@/components/ExploreContainer.vue";

export default {
  name: "Tab1",
  components: {
    ExploreContainer,
    IonHeader,
    IonToolbar,
    IonTitle,
  },
};
</script>
