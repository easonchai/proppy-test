import { ErrorObject } from "@/models/Error";
import { PositionListStore } from "@/models/Position";
import { axios } from "../../utils/axios";
import { Endpoints } from "../endpoints";

const state = () => ({
  isLoading: false,
  isRetrieved: false,
  error: {},
  positions: [],
});

const mutations = {
  updatePositions(state: PositionListStore, payload: any) {
    state.positions = payload;
  },
  updateError(state: PositionListStore, payload: ErrorObject) {
    state.error = payload;
  },
  updateLoading(state: PositionListStore, payload: boolean) {
    state.isLoading = payload;
  },
  updateRetrieved(state: PositionListStore, payload: boolean) {
    state.isRetrieved = payload;
  },
};

const getters = {
  loading(state: PositionListStore) {
    return state.isLoading;
  },
  retrieved(state: PositionListStore) {
    return state.isRetrieved;
  },
  error(state: PositionListStore) {
    return state.error;
  },
  positions(state: PositionListStore) {
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
