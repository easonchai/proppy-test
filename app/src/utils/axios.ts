import Axios from "axios";

const instance = Axios.create({
  baseURL: process.env.VUE_APP_BASE_URL || "http://localhost:5000/api",
  timeout: 3000,
});

export const axios = instance;
