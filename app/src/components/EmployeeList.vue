<template>
  <div class="container">
    <ion-list v-if="employees.length > 0">
      <ion-list-header class="list__header">Employees</ion-list-header>
      <ion-item
        v-for="employee in employees"
        :key="employee.id"
        class="list__item"
      >
        <ion-label>
          <h2 class="main__title">
            {{ employee.name }}
          </h2>
          <h3 class="sub__title">
            {{ employee.phone_No }}
          </h3>
          <p>RM {{ employee.salary }}</p>
        </ion-label>
      </ion-item>
    </ion-list>
    <ion-list v-else>
      <ion-list-header>
        <ion-skeleton-text animated style="width: 120px"></ion-skeleton-text>
      </ion-list-header>
      <ion-label>
        <h3>
          <ion-skeleton-text animated style="width: 80%"></ion-skeleton-text>
        </h3>
        <p>
          <ion-skeleton-text animated style="width: 60%"></ion-skeleton-text>
        </p>
        <p>
          <ion-skeleton-text animated style="width: 30%"></ion-skeleton-text>
        </p>
      </ion-label>
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
import {
  IonList,
  IonItem,
  IonLabel,
  IonSkeletonText,
  IonListHeader,
} from "@ionic/vue";

export default {
  name: "EmployeeList",
  components: {
    IonItem,
    IonLabel,
    IonList,
    IonSkeletonText,
    IonListHeader,
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
        console.log(this.employees);
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

<style scoped>
.container {
  padding: 0 2vw;
}

.list__header {
  font-weight: bold;
  font-size: 18px;
}

.list__item {
  display: flex;
  flex-direction: column;
}
</style>
