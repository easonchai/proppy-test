import store from "../index";

store.registerModule("employee.create", {
  namespaced: true,
  state: () => ({
    isLoading: false,
    error: false,
    employee: {
      name: "",
      email: "",
      phoneNo: "",
      gender: "M",
      position: "A",
      salary: 0,
      imageUrl: "",
      remarks: "",
    },
  }),
  mutations: {
    updateEmployee(state, payload) {
      state.employee = payload;
    },
    updateError(state, payload) {
      state.error = payload;
    },
    updateLoading(state, payload) {
      state.isLoading = payload;
    },
  },
  getters: {
    loading(state) {
      return state.isLoading;
    },
    error(state) {
      return state.error;
    },
    employee(state) {
      return state.employee;
    },
  },
});
