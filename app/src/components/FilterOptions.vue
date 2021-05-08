<template>
  <ion-content class="ion-padding">
    <div class="filter__option">
      <ion-label>Items Per Page</ion-label>
      <ion-select placeholder="Select One" v-model="selectedItemsPerPage">
        <ion-select-option :value="10">10</ion-select-option>
        <ion-select-option :value="20">20</ion-select-option>
        <ion-select-option :value="50">50</ion-select-option>
        <ion-select-option :value="100">100</ion-select-option>
      </ion-select>
    </div>
    <hr />
    <div class="filter__option">
      <ion-label>Sort By</ion-label>
      <ion-select placeholder="Select One" v-model="sortCategory">
        <ion-select-option value="id">ID</ion-select-option>
        <ion-select-option value="name">Name</ion-select-option>
        <ion-select-option value="id">Ascending</ion-select-option>
        <ion-select-option value="name">Descending</ion-select-option>
        <ion-select-option value="id">Ascending</ion-select-option>
        <ion-select-option value="name">Descending</ion-select-option>
        <ion-select-option value="id">Ascending</ion-select-option>
        <ion-select-option value="name">Descending</ion-select-option>
      </ion-select>
    </div>
    <div class="filter__option">
      <ion-label>Sort Order</ion-label>
      <ion-select placeholder="Select One" v-model="sortOrder">
        <ion-select-option value="asc">Ascending</ion-select-option>
        <ion-select-option value="desc">Descending</ion-select-option>
      </ion-select>
    </div>
    <div class="filter__option">
      <ion-label>Filter By</ion-label>
      <ion-select placeholder="Gender" v-model="selectedGender">
        <ion-select-option value="M">Male</ion-select-option>
        <ion-select-option value="F">Female</ion-select-option>
      </ion-select>
      <ion-select placeholder="Position Code" v-model="selectedPosition">
        <ion-select-option value="10">10</ion-select-option>
        <ion-select-option value="20">20</ion-select-option>
        <ion-select-option value="50">50</ion-select-option>
        <ion-select-option value="100">100</ion-select-option>
      </ion-select>
      <ion-select placeholder="Position Code" v-model="selectedDOB">
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

export default {
  name: "FilterOptions",
  components: { IonContent, IonLabel, IonSelect, IonSelectOption },
  emits: ["itemsPerPage", "sortBy", "gender", "position", "dob"],
  props: ["itemsPerPage", "sortBy", "gender", "position", "dob"],
  watch: {
    selectedItemsPerPage(newVal) {
      this.$emit("itemsPerPage", newVal);
    },
  },
  data() {
    return {
      selectedItemsPerPage: this.itemsPerPage,
      sortCategory: this.sortBy.split(":")[0],
      sortOrder: this.sortBy.split(":")[1],
      selectedGender: this.gender,
      selectedPosition: this.position,
      selectedDOB: this.dob,
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

.column {
  display: flex;
  flex-direction: row;
}

ion-select {
  border: 1px solid var(--ion-color-primary);
  border-radius: 4px;
  margin: 4px 0;
  padding: 8px;
}
</style>
