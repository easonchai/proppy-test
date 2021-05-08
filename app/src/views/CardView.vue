<template>
  <base-layout pageTitle="View Employees - Card View">
    <ion-slides pager="true" :options="slideOpts" class="card__container">
      <ion-slide>
        <EmployeeCard />
      </ion-slide>
      <ion-slide>
        <h1>Slide 1</h1>
      </ion-slide>
      <ion-slide>
        <h1>Slide 2</h1>
      </ion-slide>
      <ion-slide>
        <h1>Slide 3</h1>
      </ion-slide>
    </ion-slides>
  </base-layout>
</template>

<script lang="ts">
import { IonSlides, IonSlide } from "@ionic/vue";
import EmployeeCard from "@/components/EmployeeCard.vue";

export default {
  name: "CardView",
  components: { IonSlides, IonSlide, EmployeeCard },
  setup() {
    const slideOpts = {
      initialSlide: 0,
      speed: 400,
    };
    return { slideOpts };
  },
};
</script>

<style scoped>
.card__container {
  padding: 4vh 2vw;
}
</style>
