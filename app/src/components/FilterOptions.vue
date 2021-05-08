<template>
  <ion-content class="ion-padding">
    <div class="filter__option">
      <ion-label>Items Per Page</ion-label>
      <ion-select placeholder="Select One" v-model="itemsPerPage">
        <ion-select-option value="10">10</ion-select-option>
        <ion-select-option value="20">20</ion-select-option>
        <ion-select-option value="50">50</ion-select-option>
        <ion-select-option value="100">100</ion-select-option>
      </ion-select>
    </div>
    <div class="filter__option">
      <ion-label>Sort By</ion-label>
      <ion-select placeholder="Select One" v-model="sortBy">
        <ion-select-option value="asc">Ascending</ion-select-option>
        <ion-select-option value="desc">Descending</ion-select-option>
      </ion-select>
    </div>
    <div class="filter__option">
      <ion-label>Filter By</ion-label>
      <ion-select placeholder="Select One" v-model="filterBy">
        <ion-select-option value="10">10</ion-select-option>
        <ion-select-option value="20">20</ion-select-option>
        <ion-select-option value="50">50</ion-select-option>
        <ion-select-option value="100">100</ion-select-option>
      </ion-select>
    </div>
  </ion-content>
</template>

<script>
import { IonContent, IonLabel, IonSelect, IonSelectOption } from "@ionic/vue";
import { watch, ref } from "vue";

export default {
  name: "FilterOptions",
  components: { IonContent, IonLabel, IonSelect, IonSelectOption },
  emits: ["itemsPerPage", "sortBy", "filterBy"],
  setup(props, { emit }) {
    const itemsPerPage = ref("");
    const sortBy = ref("");
    const filterBy = ref("");

    watch(itemsPerPage, (newVal) => {
      emit("itemsPerPage", newVal);
    });

    watch(sortBy, (newVal) => {
      emit("sortBy", newVal);
    });

    watch(filterBy, (newVal) => {
      emit("filterBy", newVal);
    });

    return {
      itemsPerPage,
      sortBy,
      filterBy,
    };
  },
};
</script>

<style scoped>
.filter__option {
  display: flex;
  flex-direction: column;
  margin-bottom: 12px;
}
</style>
