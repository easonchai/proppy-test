<template>
  <ion-content>
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
    <ion-slides
      pager="true"
      :options="slideOpts"
      class="card__container"
      v-if="employees"
    >
      <ion-slide v-for="employee in employees" :key="employee.id">
        <EmployeeCard :employee="employee" />
      </ion-slide>
    </ion-slides>
  </ion-content>
</template>

<script>
import {
  IonSlides,
  IonSlide,
  IonIcon,
  IonButton,
  IonContent,
} from "@ionic/vue";
import EmployeeCard from "@/components/cardView/EmployeeCard";
import { filterCircleOutline } from "ionicons/icons";
import store from "../../stores";

export default {
  name: "CardSlider",
  components: {
    IonSlides,
    IonSlide,
    EmployeeCard,
    IonIcon,
    IonButton,
    IonContent,
  },
  setup() {
    const slideOpts = {
      initialSlide: 0,
      speed: 400,
    };
    return { slideOpts, filterCircleOutline };
  },
  data() {
    return {
      params: {
        page: 1,
        itemsPerPage: 0, // Will retrieve all
        sortBy: "",
        gender: "",
        dob: "",
        position: "",
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
};
</script>

<style scoped>
.card__container {
  padding: 0 2vw 4vh 2vw;
}

.container {
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  width: 80vw;
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
