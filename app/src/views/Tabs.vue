<template>
  <ion-page>
    <ion-tabs>
      <ion-tab-bar slot="bottom">
        <ion-tab-button tab="list" href="/admin/employee/list">
          <ion-icon :icon="listOutline" />
          <ion-label>Employees (List)</ion-label>
        </ion-tab-button>

        <ion-tab-button tab="card" href="/admin/employee/card">
          <ion-icon :icon="gridOutline" />
          <ion-label>Employees (Card)</ion-label>
        </ion-tab-button>

        <ion-tab-button tab="add" href="/admin/employee/add">
          <ion-icon :icon="addCircle" />
          <ion-label>Add Employee</ion-label>
        </ion-tab-button>
      </ion-tab-bar>
    </ion-tabs>
  </ion-page>
</template>

<script lang="ts">
import {
  IonTabBar,
  IonTabButton,
  IonTabs,
  IonLabel,
  IonIcon,
  IonPage,
} from "@ionic/vue";
import { listOutline, gridOutline, addCircle } from "ionicons/icons";

export default {
  name: "Tabs",
  components: { IonLabel, IonTabs, IonTabBar, IonTabButton, IonIcon, IonPage },
  setup() {
    return {
      listOutline,
      gridOutline,
      addCircle,
    };
  },
};
</script>
