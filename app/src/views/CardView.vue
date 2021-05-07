<template>
  <base-layout pageTitle="View Employees - Card View">
    <ion-header collapse="condense">
      <ion-toolbar>
        <ion-title size="large">View Employees - Card</ion-title>
      </ion-toolbar>
    </ion-header>
  </base-layout>
</template>

<script lang="ts">
import { IonHeader, IonToolbar, IonTitle } from "@ionic/vue";

export default {
  name: "CardView",
  components: {
    IonHeader,
    IonToolbar,
    IonTitle,
  },
};
</script>
