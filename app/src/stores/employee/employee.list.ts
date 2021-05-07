import { axios } from "../../utils/axios";
import store from "../index";
import { Endpoints } from "../endpoints";

export const EmployeeList = {
  namespaced: true,
  state: () => ({
    isLoading: false,
    error: {},
    employees: [],
  }),
  mutations: {
    updateEmployees(state: { employees: any }, payload: any) {
      state.employees = payload;
    },
    updateError(state: { error: any }, payload: any) {
      state.error = payload;
    },
    updateLoading(state: { isLoading: any }, payload: any) {
      state.isLoading = payload;
    },
  },
  getters: {
    loading(state: { isLoading: any }) {
      return state.isLoading;
    },
    error(state: { error: any }) {
      return state.error;
    },
    employee(state: { employees: any }) {
      return state.employees;
    },
  },
  actions: {
    async getAllEmployees(context: {
      commit: (arg0: string, arg1: boolean) => void;
    }) {
      context.commit("updateLoadingStatus", true);
      try {
        await axios.get(Endpoints.Positions).then((response) => {
          context.commit("updateEmployees", response.data);
          console.log(response.data);
        });
      } catch (error) {
        context.commit("updateError", error);
      }
      context.commit("updateLoadingStatus", false);
    },
  },
};
