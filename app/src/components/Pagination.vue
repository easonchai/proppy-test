<template>
  <div class="pagination__container">
    <ion-button :disabled="backDisabled">
      <ion-icon slot="icon-only" :icon="chevronBackOutline"></ion-icon>
    </ion-button>
    <h2>Showing result {{ startVal }}-{{ endVal }} of {{ totalItems }}</h2>
    <ion-button>
      <ion-icon slot="icon-only" :icon="chevronForwardOutline"></ion-icon>
    </ion-button>
  </div>
</template>

<script>
import { chevronBackOutline, chevronForwardOutline } from "ionicons/icons";
import { IonIcon, IonButton } from "@ionic/vue";

export default {
  name: "Pagination",
  props: ["page", "itemsPerPage", "totalItems"],
  components: {
    IonIcon,
    IonButton,
  },
  setup() {
    return {
      chevronBackOutline,
      chevronForwardOutline,
    };
  },
  data() {
    return {};
  },
  computed: {
    startVal() {
      const startVal = (this.page - 1) * this.itemsPerPage + 1;
      if (startVal > this.totalItems) return this.totalItems;
      return startVal;
    },
    endVal() {
      const endVal = this.startVal + this.itemsPerPage - 1;
      if (endVal > this.totalItems) return this.totalItems;
      return endVal;
    },
    backDisabled() {
      if (this.page === 1) return true;
      return false;
    },
  },
};
</script>

<style>
.pagination__container {
  display: flex;
  flex-direction: row;
  justify-content: space-between;
  padding: 2vh;
}

h2 {
  font-size: 16px;
}
</style>
