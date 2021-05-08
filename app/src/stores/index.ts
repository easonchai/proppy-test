import { createStore } from "vuex";
import employeeList from "./modules/employeeList";
import employeeDetail from "./modules/employeeDetail";
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
  },
});

export default store;
