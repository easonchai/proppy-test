import { createStore } from "vuex";
import employeeList from "./modules/employeeList";
import employeeDetail from "./modules/employeeDetail";
import employeeCreate from "./modules/employeeCreate";
import positionList from "./modules/positionList";

const store = createStore({
  state: {},
  mutations: {},
  actions: {},
  getters: {},
  modules: {
    employeeList,
    positionList,
    employeeDetail,
    employeeCreate,
  },
});

export default store;
