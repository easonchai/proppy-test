<template>
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
</template>

<script>
import { IonSlides, IonSlide } from "@ionic/vue";
import EmployeeCard from "@/components/EmployeeCard.vue";
import { filterCircleOutline } from "ionicons/icons";
import store from "../stores";

export default {
  name: "CardSlider",
  components: { IonSlides, IonSlide, EmployeeCard },
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
</style>
