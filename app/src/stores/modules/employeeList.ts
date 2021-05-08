import {
  EmployeeResponse,
  EmployeeListStore,
  EmployeeQueryResponse,
} from "@/models/Employee";
import { ErrorObject } from "@/models/Error";
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
  updateEmployees(state: EmployeeListStore, payload: EmployeeQueryResponse) {
    state.employees = payload;
  },
  updateError(state: EmployeeListStore, payload: ErrorObject) {
    state.error = payload;
  },
  updateLoading(state: EmployeeListStore, payload: boolean) {
    state.isLoading = payload;
  },
  updateRetrieved(state: EmployeeListStore, payload: boolean) {
    state.isRetrieved = payload;
  },
};

const getters = {
  loading(state: EmployeeListStore) {
    return state.isLoading;
  },
  retrieved(state: EmployeeListStore) {
    return state.isRetrieved;
  },
  error(state: EmployeeListStore) {
    return state.error;
  },
  employees(state: EmployeeListStore) {
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
          const items = response.data.items.map(
            (employee: EmployeeResponse) => {
              return {
                ...employee,
                phoneNo: employee.phone_No,
              };
            }
          );
          const employeeObj = {
            totalItems: response.data.totalItems,
            items,
          };
          commit("employeeList/updateEmployees", employeeObj, {
            root: true,
          });
        });
    } catch (error) {
      commit("employeeList/updateError", error, { root: true });
    }
    commit("employeeList/updateLoading", false, { root: true });
    commit("employeeList/updateRetrieved", true, { root: true });
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
