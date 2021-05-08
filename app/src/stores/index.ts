import { createStore } from "vuex";
import employeeList from "./modules/employeeList";
import positionList from "./modules/employeeList";

const store = createStore({
  state: {},
  mutations: {},
  actions: {},
  getters: {},
  modules: {
    employeeList,
    positionList,
  },
});

export default store;
