import {
  EmployeeDetailStore,
  EmployeeResponse,
  ModifiedEmployeeResponse,
} from "@/models/Employee";
import { ErrorObject } from "@/models/Error";
import { axios } from "../../utils/axios";
import { Endpoints } from "../endpoints";

const state = () => ({
  isLoading: false,
  isRetrieved: false,
  isSuccess: false,
  error: null,
  employee: {
    id: 0,
    name: "",
    email: "",
    phoneNo: "",
    gender: "M",
    position: {
      code: "",
      description: "",
    },
    dob: "",
    salary: 0,
    photo: "",
    remarks: "",
  },
});

const mutations = {
  updateEmployee(state: EmployeeDetailStore, payload: EmployeeResponse) {
    state.employee = payload;

    // Manually modify the phone_No to camel case (Only since this API has this requirement for snake case)
    state.employee.phoneNo = payload.phone_No;
  },
  updateEmployeeId(state: EmployeeDetailStore, payload: number) {
    state.employee.id = payload;
  },
  updateError(state: EmployeeDetailStore, payload: ErrorObject) {
    state.error = payload;
  },
  updateLoading(state: EmployeeDetailStore, payload: boolean) {
    state.isLoading = payload;
  },
  updateRetrieved(state: EmployeeDetailStore, payload: boolean) {
    state.isRetrieved = payload;
  },
  updateSuccess(state: EmployeeDetailStore, payload: boolean) {
    state.isSuccess = payload;
  },
};

const getters = {
  loading(state: EmployeeDetailStore) {
    return state.isLoading;
  },
  retrieved(state: EmployeeDetailStore) {
    return state.isRetrieved;
  },
  error(state: EmployeeDetailStore) {
    return state.error;
  },
  employee(state: EmployeeDetailStore) {
    return state.employee;
  },
};

const actions = {
  async getEmployee({ commit }: any, params: string) {
    commit("employeeDetail/updateRetrieved", false, { root: true });
    commit("employeeDetail/updateLoading", true, { root: true });
    try {
      await axios.get(`${Endpoints.Employees}/${params}`).then((response) => {
        commit("employeeDetail/updateEmployee", response.data, { root: true });
      });
    } catch (error) {
      commit("employeeDetail/updateError", error, { root: true });
    }
    commit("employeeDetail/updateLoading", false, { root: true });
    commit("employeeDetail/updateRetrieved", true, { root: true });
  },
  async deleteEmployee({ commit }: any, params: string) {
    commit("employeeDetail/updateRetrieved", false, { root: true });
    commit("employeeDetail/updateLoading", true, { root: true });
    try {
      await axios
        .delete(`${Endpoints.Employees}/${params}`)
        .then((response) => {
          response.data.deleted = true;
          commit("employeeDetail/updateEmployee", response.data, {
            root: true,
          });
        });
    } catch (error) {
      commit("employeeDetail/updateError", error, { root: true });
    }
    commit("employeeDetail/updateLoading", false, { root: true });
    commit("employeeDetail/updateRetrieved", true, { root: true });
    commit("employeeDetail/updateSuccess", true, { root: true });
  },
  async updateEmployee(
    { commit, state }: any,
    params: ModifiedEmployeeResponse
  ) {
    commit("employeeDetail/updateSuccess", false, { root: true });
    commit("employeeDetail/updateLoading", true, { root: true });
    try {
      await axios
        .put(`${Endpoints.Employees}/${state.employee.id}`, params)
        .then((response) => {
          commit("employeeDetail/updateEmployee", response.data, {
            root: true,
          });
        });
    } catch (error) {
      commit("employeeDetail/updateError", error, { root: true });
    }
    commit("employeeDetail/updateLoading", false, { root: true });
    commit("employeeDetail/updateSuccess", true, { root: true });
  },
  updateSuccess({ commit }: any, params: boolean) {
    commit("employeeDetail/updateSuccess", params, { root: true });
  },
};

const employeeDetail = {
  namespaced: true,
  state,
  getters,
  mutations,
  actions,
};

export default employeeDetail;
