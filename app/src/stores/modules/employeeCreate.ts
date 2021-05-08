import { EmployeeBody, EmployeeCreateStore } from "@/models/Employee";
import { ErrorObject } from "@/models/Error";
import { axios } from "../../utils/axios";
import { Endpoints } from "../endpoints";

const state = () => ({
  isLoading: false,
  error: null,
  employee: {
    name: "",
    email: "",
    phoneNo: "",
    gender: "",
    dob: "",
    positionCode: "",
    salary: 0,
    photo: "",
    remarks: "",
  },
});

const mutations = {
  updateEmployee(state: EmployeeCreateStore, payload: EmployeeBody) {
    state.employee = payload;
  },
  updateError(state: EmployeeCreateStore, payload: ErrorObject) {
    state.error = payload;
  },
  updateLoading(state: EmployeeCreateStore, payload: boolean) {
    state.isLoading = payload;
  },
};

const getters = {
  loading(state: EmployeeCreateStore) {
    return state.isLoading;
  },
  error(state: EmployeeCreateStore) {
    return state.error;
  },
  employee(state: EmployeeCreateStore) {
    return state.employee;
  },
};

const actions = {
  async createEmployee({ commit }: any, params: any) {
    commit("employeeCreate/updateLoading", true, { root: true });
    try {
      await axios.post(Endpoints.Employees, params).then((response) => {
        commit("employeeCreate/updateEmployee", response.data, {
          root: true,
        });
      });
    } catch (error) {
      // TODO: Add interceptor which returns the body
      const errorBody = {
        status: error.response.status,
        message: error.response.data,
      };
      commit("employeeCreate/updateError", errorBody, { root: true });
    }
    commit("employeeCreate/updateLoading", false, { root: true });
  },
};

const employeeCreate = {
  namespaced: true,
  state,
  getters,
  mutations,
  actions,
};

export default employeeCreate;
