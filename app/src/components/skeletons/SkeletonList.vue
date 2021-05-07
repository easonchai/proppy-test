<template>
  <ion-list>
    <ion-list-header>
      <ion-skeleton-text animated style="width: 120px"></ion-skeleton-text>
    </ion-list-header>
    <ion-item v-for="count in 10" :key="count">
      <ion-label>
        <h3>
          <ion-skeleton-text animated style="width: 50%"></ion-skeleton-text>
        </h3>
        <p>
          <ion-skeleton-text animated style="width: 40%"></ion-skeleton-text>
        </p>
        <p>
          <ion-skeleton-text animated style="width: 30%"></ion-skeleton-text>
        </p>
      </ion-label>
    </ion-item>
  </ion-list>
</template>

<script>
import {
  IonList,
  IonItem,
  IonSkeletonText,
  IonListHeader,
  IonLabel,
} from "@ionic/vue";

export default {
  name: "SkeletonList",
  components: {
    IonItem,
    IonList,
    IonSkeletonText,
    IonListHeader,
    IonLabel,
  },
};
</script>

<style></style>
