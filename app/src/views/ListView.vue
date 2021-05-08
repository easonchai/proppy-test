<template>
  <base-layout pageTitle="View Employees - List View">
    <ion-refresher slot="fixed" @ionRefresh="doRefresh($event)">
      <ion-refresher-content></ion-refresher-content>
    </ion-refresher>
    <EmployeeList />
  </base-layout>
</template>

<script>
import { IonRefresher, IonRefresherContent } from "@ionic/vue";
import EmployeeList from "../components/listView/EmployeeList.vue";

export default {
  name: "ListView",
  components: {
    EmployeeList,
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
