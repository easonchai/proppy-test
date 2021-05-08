<template>
  <ion-content>
    <div class="grid__container">
      <div class="column is_left">
        <h1>Employees</h1>
      </div>
      <div class="column is_right">
        <ion-button @click="setOpen(true, $event)">
          <ion-icon slot="icon-only" :icon="filterCircleOutline"></ion-icon>
        </ion-button>
      </div>
    </div>
    <ion-slides
      pager="true"
      :options="slideOpts"
      class="card__container"
      v-if="employees.length > 0 && employeesRetrieved"
    >
      <ion-slide v-for="employee in employees" :key="employee.id">
        <EmployeeCard :employee="employee" />
      </ion-slide>
    </ion-slides>
    <ion-slides
      pager="true"
      :options="slideOpts"
      class="card__container"
      v-if="employees.length === 0 && employeesRetrieved"
    >
      <h2 class="main__title">No Employees Found.</h2>
    </ion-slides>
    <ion-slides
      pager="true"
      :options="slideOpts"
      class="card__container"
      v-if="!employeesRetrieved"
    >
      <ion-slide>
        <SkeletonCard />
      </ion-slide>
    </ion-slides>
    <ion-popover
      :is-open="isOpenRef"
      css-class="filter_options_popover"
      :event="event"
      :translucent="true"
      @didDismiss="setOpen(false)"
    >
      <FilterOptions
        :noItemsPerPage="true"
        :sortBy="params.sortBy"
        :gender="params.gender"
        :position="params.positionCode"
        :dob="params.dob"
        :positionList="positionList"
        @itemsPerPage="updateItemsPerPage"
        @sortBy="updateSortBy"
        @gender="updateGender"
        @dob="updateDOB"
        @position="updatePosition"
      ></FilterOptions>
    </ion-popover>
  </ion-content>
</template>

<script>
import {
  IonSlides,
  IonSlide,
  IonIcon,
  IonButton,
  IonContent,
  IonPopover,
} from "@ionic/vue";
import EmployeeCard from "@/components/cardView/EmployeeCard";
import { filterCircleOutline } from "ionicons/icons";
import FilterOptions from "@/components/FilterOptions";
import SkeletonCard from "@/components/skeletons/SkeletonCard";
import store from "../../stores";
import { ref } from "vue";

export default {
  name: "CardSlider",
  components: {
    IonSlides,
    IonSlide,
    EmployeeCard,
    IonIcon,
    IonButton,
    IonContent,
    IonPopover,
    FilterOptions,
    SkeletonCard,
  },
  setup() {
    const slideOpts = {
      initialSlide: 0,
      speed: 400,
    };
    const isOpenRef = ref(false);
    const event = ref();
    const setOpen = (state, event) => {
      if (event) event.value = event;
      isOpenRef.value = state;
    };
    return { slideOpts, filterCircleOutline, isOpenRef, setOpen, event };
  },
  data() {
    return {
      params: {
        page: 1,
        itemsPerPage: 0,
        sortBy: "id:asc",
        gender: "",
        dob: "",
        positionCode: "",
      },
      employees: [],
      positions: [],
    };
  },
  computed: {
    employeeList: function() {
      return store.state.employeeList.employees;
    },
    employeesRetrieved: function() {
      return store.state.employeeList.isRetrieved;
    },
    positionList: function() {
      return store.state.positionList.positions;
    },
  },
  mounted() {
    store.dispatch("employeeList/getAllEmployees", this.params, { root: true });
    store.dispatch("positionList/getAllPositions", null, { root: true });
  },
  watch: {
    employeeList: {
      handler(employeeObj) {
        this.totalItems = employeeObj.totalItems;
        this.employees = employeeObj.items;
      },
      deep: true,
    },
    positionList: {
      handler(positionObj) {
        this.positions = positionObj.items;
      },
      deep: true,
    },
    params: {
      handler(params) {
        store.dispatch("employeeList/getAllEmployees", params, {
          root: true,
        });
      },
      deep: true,
    },
    $route() {
      const defaultParams = {
        page: 1,
        itemsPerPage: 0,
        sortBy: "id:asc",
        gender: "",
        dob: "",
        positionCode: "",
      };
      store.dispatch("employeeList/getAllEmployees", defaultParams, {
        root: true,
      });
    },
  },
  methods: {
    updateItemsPerPage(newVal) {
      this.params.itemsPerPage = newVal;
    },
    updateSortBy(newVal) {
      this.params.sortBy = newVal;
    },
    updateGender(newVal) {
      this.params.gender = newVal;
    },
    updatePosition(newVal) {
      this.params.positionCode = newVal;
    },
    updateDOB(newVal) {
      this.params.dob = newVal;
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

.main__title {
  font-weight: 600;
  font-size: 18px;
  color: var(--ion-color-step-200);
  margin: 0 0 8px 0;
}
</style>
