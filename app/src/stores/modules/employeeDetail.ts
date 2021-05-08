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
    salary: 0,
    photo: "",
    remarks: "",
  },
});

const mutations = {
  updateEmployee(state: { employee: any }, payload: any) {
    state.employee = payload;

    // Manually modify the phone_No to camel case (Only since this API has this requirement for snake case)
    state.employee.phoneNo = payload.phone_No;
  },
  updateEmployeeId(state: { employee: any }, payload: number) {
    state.employee.id = payload;
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
  updateSuccess(state: { isSuccess: any }, payload: any) {
    state.isSuccess = payload;
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
  employee(state: { employee: any }) {
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
  },
  async updateEmployee({ commit, state }: any, params: any) {
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
};

const employeeDetail = {
  namespaced: true,
  state,
  getters,
  mutations,
  actions,
};

export default employeeDetail;
