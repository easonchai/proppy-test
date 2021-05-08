import { axios } from "../../utils/axios";
import { Endpoints } from "../endpoints";

const state = () => ({
  isLoading: false,
  isRetrieved: false,
  error: {},
  positions: [],
});

const mutations = {
  updatePositions(state: { positions: any }, payload: any) {
    state.positions = payload;
  },
  updateError(state: { error: object }, payload: object) {
    state.error = payload;
  },
  updateLoading(state: { isLoading: boolean }, payload: boolean) {
    state.isLoading = payload;
  },
  updateRetrieved(state: { isRetrieved: boolean }, payload: boolean) {
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
  positions(state: { positions: any }) {
    return state.positions;
  },
};

const actions = {
  async getAllPositions({ commit }: any) {
    commit("positionList/updateRetrieved", false, { root: true });
    commit("positionList/updateLoading", true, { root: true });
    try {
      await axios.get(Endpoints.Positions).then((response) => {
        commit("positionList/updatePositions", response.data, { root: true });
      });
    } catch (error) {
      commit("positionList/updateError", error, { root: true });
    }
    commit("positionList/updateLoading", false, { root: true });
    commit("positionList/updateRetrieved", true, { root: true });
  },
};

const positionList = {
  namespaced: true,
  state,
  getters,
  mutations,
  actions,
};

export default positionList;
