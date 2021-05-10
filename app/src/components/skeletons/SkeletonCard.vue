<template>
  <ion-card>
    <div class="image__container">
      <ion-skeleton-text></ion-skeleton-text>
    </div>
    <ion-card-header>
      <ion-skeleton-text animated style="width: 60vw"></ion-skeleton-text>
      <ion-skeleton-text animated style="width: 40vw"></ion-skeleton-text>
    </ion-card-header>
    <ion-card-content>
      <ion-skeleton-text animated style="width: 30vw"></ion-skeleton-text>
      <ion-skeleton-text animated style="width: 40vw"></ion-skeleton-text>
      <ion-skeleton-text animated style="width: 30vw"></ion-skeleton-text>
      <ion-skeleton-text animated style="width: 40vw"></ion-skeleton-text>
      <ion-skeleton-text animated style="width: 30vw"></ion-skeleton-text>
      <ion-skeleton-text animated style="width: 40vw"></ion-skeleton-text>
      <ion-skeleton-text animated style="width: 30vw"></ion-skeleton-text>
      <ion-skeleton-text animated style="width: 40vw"></ion-skeleton-text>
      <ion-skeleton-text animated style="width: 30vw"></ion-skeleton-text>
      <ion-skeleton-text animated style="width: 40vw"></ion-skeleton-text>
    </ion-card-content>
  </ion-card>
</template>

<script>
import {
  IonCard,
  IonCardContent,
  IonCardHeader,
  IonSkeletonText,
} from "@ionic/vue";

export default {
  name: "SkeletonCard",
  components: {
    IonCard,
    IonCardContent,
    IonCardHeader,
    IonSkeletonText,
  },
};
</script>

<style scoped>
ion-card {
  display: flex;
  flex-direction: column;
  align-items: flex-start;
  min-width: 80vw;
}

ion-card-title {
  color: var(--ion-color-step-900);
  font-weight: bold;
  font-size: 24px;
  text-align: left;
}

ion-card-subtitle {
  color: var(--ion-color-step-800);
  font-weight: 600;
  font-size: 18px;
  text-align: left;
}

ion-card-content {
  display: flex;
  flex-direction: column;
  align-items: flex-start;
}

h3 {
  color: var(--ion-color-step-500);
  font-size: 16px;
  margin: 4px 0;
  font-weight: 600;
  flex: 2;
}

h4 {
  color: var(--ion-color-step-500);
  font-size: 16px;
  margin: 4px 0 12px 0;
  flex: 5;
}

.image__container {
  width: 100%;
  height: 30vh;
}
</style>
