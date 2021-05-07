import { createStore } from "vuex";
import employeeList from "./modules/employeeList";

const store = createStore({
  state: {},
  modules: {
    employeeList,
  },
});

export default store;
