<template>
  <div class="container">
    <ion-list v-if="employees.length > 0 && employeesRetrieved">
      <div class="item__container">
        <div class="column is_left">
          <ion-list-header class="list__header">Employees</ion-list-header>
        </div>
        <div class="column is_right">
          <ion-button @click="setOpen(true, $event)">
            <ion-icon slot="icon-only" :icon="filterCircleOutline"></ion-icon>
          </ion-button>
        </div>
      </div>
      <ion-item
        v-for="employee in employees"
        :key="employee.id"
        class="list__item"
        no-lines
      >
        <div
          :ref="'header-' + employee.id"
          class="accordion__container"
          @click="headerClicked(employee)"
        >
          <div class="item__container">
            <div class="column is_left">
              <h2 class="main__title">
                {{ employee.name }}
              </h2>
              <h3 class="sub__title">
                {{ employee.phone_No }}
              </h3>
              <p>{{ employee.position.description }}</p>
            </div>
            <div class="column is_right">
              <h2 class="main__title">ID: {{ employee.id }}</h2>
              <h3 class="sub__title">
                {{ displayGender(employee.gender) }}
              </h3>
              <ion-text color="primary" class="view_more">
                <p>View More <ion-icon :icon="caretDownOutline"></ion-icon></p>
              </ion-text>
            </div>
          </div>
          <div
            :ref="'body-' + employee.id"
            class="accordion__body"
            style="display:none;"
            v-show="expandElement(employee)"
          >
            <EmployeeDetail :employee="employee"></EmployeeDetail>
          </div>
        </div>
      </ion-item>
    </ion-list>
    <ion-list v-if="employees.length === 0 && employeesRetrieved">
      <div class="item__container">
        <div class="column is_left">
          <ion-list-header class="list__header">Employees</ion-list-header>
        </div>
        <div class="column is_right">
          <ion-button @click="setOpen(true, $event)">
            <ion-icon slot="icon-only" :icon="filterCircleOutline"></ion-icon>
          </ion-button>
        </div>
      </div>
      <ion-item class="list__item">
        <h2 class="main__title">No employees found.</h2>
      </ion-item>
    </ion-list>
    <SkeletonList v-else />
    <pagination
      :page="params.page"
      :itemsPerPage="params.itemsPerPage"
      :totalItems="totalItems"
      @next="goNext"
      @prev="goPrev"
    />
    <ion-popover
      :is-open="isOpenRef"
      css-class="filter_options_popover"
      :event="event"
      :translucent="true"
      @didDismiss="setOpen(false)"
    >
      <FilterOptions
        :itemsPerPage="params.itemsPerPage"
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
  </div>
</template>

<script>
import store from "../stores";
import {
  IonList,
  IonItem,
  IonListHeader,
  IonText,
  IonIcon,
  IonButton,
  IonPopover,
} from "@ionic/vue";
import SkeletonList from "./skeletons/SkeletonList";
import EmployeeDetail from "./EmployeeDetail";
import FilterOptions from "./FilterOptions";
import { caretDownOutline, filterCircleOutline } from "ionicons/icons";
import { ref } from "vue";

export default {
  name: "EmployeeList",
  components: {
    IonItem,
    IonList,
    IonListHeader,
    SkeletonList,
    IonText,
    IonIcon,
    EmployeeDetail,
    IonButton,
    IonPopover,
    FilterOptions,
  },
  setup() {
    const isOpenRef = ref(false);
    const event = ref();
    const setOpen = (state, event) => {
      if (event) event.value = event;
      isOpenRef.value = state;
    };

    return {
      caretDownOutline,
      filterCircleOutline,
      isOpenRef,
      setOpen,
      event,
    };
  },
  data() {
    return {
      params: {
        page: 1,
        itemsPerPage: 10,
        sortBy: "id:asc",
        gender: "",
        dob: "",
        positionCode: "",
      },
      totalItems: 0,
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
    displayGender(character) {
      switch (character) {
        case "M":
          return "Male";
        case "F":
          return "Female";
      }
    },
    expandElement(employee) {
      const curE = this.$refs["body-" + employee.id];
      if (curE === undefined || curE === null) return false;
      if (curE.dataset.isExpanded === "true") {
        return true;
      } else {
        return false;
      }
    },
    headerClicked(employee) {
      this.employees.map(function(e) {
        const curE = this.$refs["body-" + e.id];
        if (e === employee) {
          if (curE.dataset?.isExpanded === "true") {
            curE.setAttribute("data-is-expanded", false);
          } else {
            curE.setAttribute("data-is-expanded", true);
          }
        } else {
          curE.setAttribute("data-is-expanded", false);
        }
      }, this);
      this.employees = [...this.employees];
    },
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
.container {
  padding: 0 2vw;
}

.list__header {
  font-weight: bold;
  font-size: 20px;
  color: var(--ion-color-step-100);
}

.list__item {
  display: flex;
  flex-direction: column;
}

.main__title {
  font-weight: 600;
  font-size: 18px;
  color: var(--ion-color-step-200);
  margin: 0 0 8px 0;
}

.sub__title {
  font-weight: 500;
  font-size: 16px;
  color: var(--ion-color-step-300);
  margin: 0 0 4px 0;
}

.item__container {
  display: flex;
  flex-direction: row;
  justify-content: space-between;
  width: 100%;
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

.accordion__container {
  display: flex;
  flex-direction: column;
  width: 100%;
  margin: 12px 0;
}

.accordion__body {
  height: 100%;
  margin-top: 8px;
}

p {
  display: flex;
  align-items: center;
  justify-content: center;
  margin: 0 0 4px 0;
}
</style>
