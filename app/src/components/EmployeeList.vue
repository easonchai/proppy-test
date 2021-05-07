<template>
  <div class="container">
    <ion-list v-if="employees">
      <ion-item v-for="employee in employees" :key="employee.id">
        <ion-label>{{ employee.name }}</ion-label>
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
      return store.state.employeeList.employees;
    },
  },
  mounted() {
    store.dispatch("employeeList/getAllEmployees", this.params, { root: true });
  },
  watch: {
    employeeList: {
      handler(employeeObj) {
        this.totalItems = employeeObj.totalItems;
        this.employees = employeeObj.items;
      },
      deep: true,
    },
  },
  methods: {
    goNext() {
      this.params.page += 1;
      store.dispatch("employeeList/getAllEmployees", this.params, {
        root: true,
      });
    },
    goPrev() {
      this.params.page -= 1;
      store.dispatch("employeeList/getAllEmployees", this.params, {
        root: true,
      });
    },
  },
};
</script>

<style>
.container {
  padding: 2vh 2vw;
}
</style>
