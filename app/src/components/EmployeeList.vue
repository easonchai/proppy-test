<template>
  <div class="container">
    <ion-list v-if="employees.length > 0">
      <ion-list-header class="list__header">Employees</ion-list-header>
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
          <transition name="fade">
            <div
              :ref="'body-' + employee.id"
              style="margin-top:8px;display:none; height: 100px;"
              v-show="expandElement(employee)"
            >
              ASDHJAHSDJAHSJD
              <slot :item="employee"></slot>
            </div>
          </transition>
        </div>
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
  </div>
</template>

<script>
import store from "../stores";
import { IonList, IonItem, IonListHeader, IonText, IonIcon } from "@ionic/vue";
import SkeletonList from "./skeletons/SkeletonList";
import { caretDownOutline } from "ionicons/icons";

export default {
  name: "EmployeeList",
  components: {
    IonItem,
    IonList,
    IonListHeader,
    SkeletonList,
    IonText,
    IonIcon,
  },
  setup() {
    return {
      caretDownOutline,
    };
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
    displaySalary(value) {
      const num = value.toFixed(2);
      const parsed = num.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
      return parsed;
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
      if (curE === undefined) return false;
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
          if (curE.dataset.isExpanded === "true") {
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
}

.sub__title {
  font-weight: 500;
  font-size: 16px;
  color: var(--ion-color-step-300);
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
}

p {
  display: flex;
  align-items: center;
  justify-content: center;
}

.fade-enter-active,
.fade-leave-active {
  transition: height 0.2s ease-in-out;
  overflow: hidden;
}
.fade-enter-from,
.fade-leave-to {
  height: 0px !important;
}
</style>
