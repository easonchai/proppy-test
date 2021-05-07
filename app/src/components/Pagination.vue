<template>
  <div class="pagination__container">
    <ion-button :disabled="backDisabled" @click="goPrev">
      <ion-icon slot="icon-only" :icon="chevronBackOutline"></ion-icon>
    </ion-button>
    <h2>Showing result {{ startVal }}-{{ endVal }} of {{ totalItems }}</h2>
    <ion-button :disabled="forwardDisabled" @click="goNext">
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
  emits: ["prev", "next"],
  components: {
    IonIcon,
    IonButton,
  },
  setup(props, { emit }) {
    return {
      chevronBackOutline,
      chevronForwardOutline,
      goNext() {
        emit("next");
      },
      goPrev() {
        emit("prev");
      },
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
    forwardDisabled() {
      if (this.endVal >= this.totalItems) return true;
      return false;
    },
  },
};
</script>

<style scoped>
.pagination__container {
  display: flex;
  flex-direction: row;
  justify-content: space-between;
  align-items: center;
  padding: 2vh 2vw;
}

h2 {
  font-size: 16px;
  color: var(--ion-color-step-250);
  text-align: center;
  padding: 0px 12px;
}
</style>
