<template>
  <div class="container">
    <ion-list>
      <ion-item>
        <ion-label>Pokémon Yellow</ion-label>
      </ion-item>
      <ion-item>
        <ion-label>Mega Man X</ion-label>
      </ion-item>
      <ion-item>
        <ion-label>The Legend of Zelda</ion-label>
      </ion-item>
      <ion-item>
        <ion-label>Pac-Man</ion-label>
      </ion-item>
      <ion-item>
        <ion-label>Super Mario World</ion-label>
      </ion-item>
    </ion-list>
    <pagination
      :page="params.page"
      :itemsPerPage="params.itemsPerPage"
      :totalItems="totalItems"
      @next="goNext"
      @prev="goPrev"
    />
  </div>
</template>

<script>
import store from "../stores";
import { IonList, IonItem, IonLabel } from "@ionic/vue";

export default {
  name: "EmployeeList",
  components: {
    IonItem,
    IonLabel,
    IonList,
  },
  data() {
    return {
      params: {
        page: 1,
        itemsPerPage: 10,
      },
      totalItems: 0,
      employees: [],
    };
  },
  computed: {
    employeeList: function() {
      return store.state.employeeList?.employees;
    },
  },
  mounted() {
    store.dispatch("employeeList/getAllEmployees", { root: true });
  },
  watch: {
    employeeList: {
      handler(employeeObj) {
        this.totalItems = employeeObj.totalItems;
        this.employees = employeeObj.employees;
      },
      deep: true,
    },
  },
  methods: {
    goNext() {
      this.params.page += 1;
    },
    goPrev() {
      this.params.page -= 1;
    },
  },
};
</script>

<style></style>
