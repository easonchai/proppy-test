<template>
  <ion-page>
    <ion-header>
      <ion-toolbar>
        <ion-title>Add Employee</ion-title>
      </ion-toolbar>
    </ion-header>
    <ion-content :fullscreen="true">
      <ion-header collapse="condense">
        <ion-toolbar>
          <ion-title size="large">Add Employee</ion-title>
        </ion-toolbar>
      </ion-header>

      <AddEmployee />
    </ion-content>
  </ion-page>
</template>

<script lang="ts">
import {
  IonPage,
  IonHeader,
  IonToolbar,
  IonTitle,
  IonContent,
} from "@ionic/vue";
import AddEmployee from "@/components/AddEmployee.vue";

export default {
  name: "Tab3",
  components: {
    AddEmployee,
    IonHeader,
    IonToolbar,
    IonTitle,
    IonContent,
    IonPage,
  },
};
</script>
