<template>
  <ion-content class="ion-padding">
    <div class="filter__option" v-if="!noItemsPerPage">
      <ion-label>Items Per Page</ion-label>
      <ion-select
        placeholder="Select One"
        v-model="selectedItemsPerPage"
        interface="popover"
        :interface-options="options"
      >
        <ion-select-option :value="10">10</ion-select-option>
        <ion-select-option :value="20">20</ion-select-option>
        <ion-select-option :value="50">50</ion-select-option>
        <ion-select-option :value="100">100</ion-select-option>
      </ion-select>
    </div>
    <hr />
    <div class="filter__option">
      <ion-label>Sort By</ion-label>
      <ion-select
        placeholder="Select One"
        v-model="sortCategory"
        interface="popover"
        :interface-options="options"
      >
        <ion-select-option value="id">ID</ion-select-option>
        <ion-select-option value="name">Name</ion-select-option>
        <ion-select-option value="phone_No">Phone Number</ion-select-option>
        <ion-select-option value="position_Code">Position</ion-select-option>
        <ion-select-option value="email">Email</ion-select-option>
        <ion-select-option value="gender">Gender</ion-select-option>
        <ion-select-option value="salary">Salary</ion-select-option>
        <ion-select-option value="dob">Date of Birth</ion-select-option>
      </ion-select>
    </div>
    <div class="filter__option">
      <ion-label>Sort Order</ion-label>
      <ion-select
        placeholder="Select One"
        v-model="sortOrder"
        interface="popover"
        :interface-options="options"
      >
        <ion-select-option value="asc">Ascending</ion-select-option>
        <ion-select-option value="desc">Descending</ion-select-option>
      </ion-select>
    </div>
    <div class="filter__option">
      <ion-label>Filter By</ion-label>
      <ion-select
        placeholder="Gender"
        v-model="selectedGender"
        interface="popover"
        :interface-options="options"
      >
        <ion-select-option value="M">Male</ion-select-option>
        <ion-select-option value="F">Female</ion-select-option>
      </ion-select>
      <ion-select
        placeholder="Position Code"
        v-model="selectedPosition"
        interface="popover"
        :interface-options="options"
      >
        <ion-select-option
          v-for="position in positionList"
          :key="position.code"
          :value="position.code"
          >{{ position.description }}</ion-select-option
        >
      </ion-select>
      <ion-datetime
        placeholder="Date of Birth"
        display-format="YYYY MMMM"
        value="2012-12-15T13:47:20.789"
        v-model="selectedDOB"
      ></ion-datetime>
    </div>
    <ion-button color="primary" fill="outline" @click="clearAll"
      >Clear All</ion-button
    >
  </ion-content>
</template>

<script>
import {
  IonContent,
  IonLabel,
  IonSelect,
  IonSelectOption,
  IonDatetime,
  IonButton,
} from "@ionic/vue";

export default {
  name: "FilterOptions",
  components: {
    IonContent,
    IonLabel,
    IonSelect,
    IonSelectOption,
    IonDatetime,
    IonButton,
  },
  emits: ["itemsPerPage", "sortBy", "gender", "position", "dob"],
  props: [
    "itemsPerPage",
    "sortBy",
    "gender",
    "position",
    "dob",
    "positionList",
    "noItemsPerPage",
  ],
  watch: {
    selectedItemsPerPage(newVal) {
      this.$emit("itemsPerPage", newVal);
    },
    sortCategory(newVal) {
      this.$emit("sortBy", `${newVal}:${this.sortOrder}`);
    },
    sortOrder(newVal) {
      this.$emit("sortBy", `${this.sortCategory}:${newVal}`);
    },
    selectedGender(newVal) {
      this.$emit("gender", newVal);
    },
    selectedPosition(newVal) {
      this.$emit("position", newVal);
    },
    selectedDOB(newVal) {
      const parsedDate = newVal.toLocaleString().split("T")[0];
      this.$emit("dob", parsedDate);
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
      options: {
        cssClass: "styled_select",
      },
    };
  },
  methods: {
    clearAll() {
      this.selectedItemsPerPage = 10;
      this.sortCategory = "id";
      this.sortOrder = "asc";
      this.selectedGender = "";
      this.selectedPosition = "";
      this.selectedDOB = "";
    },
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

ion-select,
ion-datetime {
  border: 1px solid var(--ion-color-primary);
  border-radius: 4px;
  margin: 4px 0;
  padding: 8px;
  --placeholder-color: var(--ion-color-step-300);
}

/* Popover Interface: set color for the popover using Item's CSS variables */
.styled_select .select-interface-option {
  --color: #333;
  --color-hover: #333;
}
</style>
