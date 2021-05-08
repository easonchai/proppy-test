import { QueryParams } from "@/models/QueryParams";
import { axios } from "../../utils/axios";
import { Endpoints } from "../endpoints";

const state = () => ({
  isLoading: false,
  isRetrieved: false,
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
  updateRetrieved(state: { isRetrieved: any }, payload: any) {
    state.isRetrieved = payload;
  },
};

const getters = {
  loading(state: { isLoading: any }) {
    return state.isLoading;
  },
  retrieved(state: { isRetrieved: any }) {
    return state.isRetrieved;
  },
  error(state: { error: any }) {
    return state.error;
  },
  employees(state: { employees: any }) {
    return state.employees;
  },
};

const actions = {
  async getAllEmployees({ commit }: any, params: QueryParams) {
    commit("employeeList/updateRetrieved", false, { root: true });
    commit("employeeList/updateLoading", true, { root: true });
    try {
      await axios
        .get(Endpoints.Employees, {
          params,
        })
        .then((response) => {
          commit("employeeList/updateEmployees", response.data, { root: true });
        });
    } catch (error) {
      commit("employeeList/updateError", error, { root: true });
    }
    commit("employeeList/updateLoading", false, { root: true });
    // commit("employeeList/updateRetrieved", true, { root: true });
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
