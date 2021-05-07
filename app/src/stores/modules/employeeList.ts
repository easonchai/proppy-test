import { axios } from "../../utils/axios";
import { Endpoints } from "../endpoints";

const state = () => ({
  isLoading: false,
  error: {},
  employees: [],
});

const mutations = {
  updateEmployees(state: { employees: any }, payload: any) {
    state.employees = payload;
  },
  updateError(state: { error: any }, payload: any) {
    state.error = payload;
  },
  updateLoading(state: { isLoading: any }, payload: any) {
    state.isLoading = payload;
  },
};

const getters = {
  loading(state: { isLoading: any }) {
    return state.isLoading;
  },
  error(state: { error: any }) {
    return state.error;
  },
  employee(state: { employees: any }) {
    return state.employees;
  },
};

const actions = {
  async getAllEmployees({ commit }: any) {
    commit("employeeList/updateLoading", true, { root: true });
    try {
      await axios.get(Endpoints.Employees).then((response) => {
        commit("employeeList/updateEmployees", response.data, { root: true });
      });
    } catch (error) {
      commit("employeeList/updateError", error, { root: true });
    }
    commit("employeeList/updateLoading", false, { root: true });
  },
};

const employeeList = {
  namespaced: true,
  state,
  getters,
  mutations,
  actions,
};

export default employeeList;
