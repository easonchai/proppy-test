<template>
  <base-layout pageTitle="View Employees - Card View">
    <div class="container">
      <div class="grid__container">
        <div class="column is_left">
          <h1>Employees</h1>
        </div>
        <div class="column is_right">
          <ion-button>
            <ion-icon slot="icon-only" :icon="filterCircleOutline"></ion-icon>
          </ion-button>
        </div>
      </div>
    </div>
    <CardSlider />
  </base-layout>
</template>

<script lang="ts">
import CardSlider from "@/components/CardSlider.vue";
import { filterCircleOutline } from "ionicons/icons";
import { IonIcon, IonButton } from "@ionic/vue";

export default {
  name: "CardView",
  components: { CardSlider, IonIcon, IonButton },
  setup() {
    return {
      filterCircleOutline,
    };
  },
};
</script>

<style scoped>
.container {
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
}

.grid__container {
  display: flex;
  flex-direction: row;
  align-items: center;
  justify-content: space-between;
  width: 100%;
  padding: 1vh 4vw;
}

.column {
  flex: 1;
  width: 100%;
}

.is_left {
  display: flex;
  flex-direction: column;
  align-items: flex-start;
}

.is_right {
  display: flex;
  flex-direction: column;
  align-items: flex-end;
}

h1 {
  font-weight: bold;
  font-size: 20px;
  color: var(--ion-color-step-100);
  margin: 0;
}
</style>
