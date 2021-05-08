<template>
  <base-layout pageTitle="Employee Details">
    <ion-refresher slot="fixed" @ionRefresh="doRefresh($event)">
      <ion-refresher-content></ion-refresher-content>
    </ion-refresher>
    <EmployeeCardFull />
  </base-layout>
</template>

<script lang="ts">
import { IonRefresher, IonRefresherContent } from "@ionic/vue";
import EmployeeCardFull from "../components/fullView/EmployeeCardFull.vue";

export default {
  name: "DetailsView",
  components: {
    EmployeeCardFull,
    IonRefresher,
    IonRefresherContent,
  },
  methods: {
    doRefresh() {
      this.$router.go();
    },
  },
};
</script>
