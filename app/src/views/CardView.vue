<template>
  <base-layout pageTitle="View Employees - Card View">
    <ion-refresher slot="fixed" @ionRefresh="doRefresh($event)">
      <ion-refresher-content></ion-refresher-content>
    </ion-refresher>
    <CardSlider />
  </base-layout>
</template>

<script lang="ts">
import { IonRefresher, IonRefresherContent } from "@ionic/vue";
import CardSlider from "../components/cardView/CardSlider.vue";

export default {
  name: "CardView",
  components: { CardSlider, IonRefresher, IonRefresherContent },
  methods: {
    doRefresh() {
      this.$router.go();
    },
  },
};
</script>

<style scoped></style>
