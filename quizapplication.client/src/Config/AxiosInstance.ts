import axios, { AxiosRequestConfig } from "axios";

const baseURL = "http://localhost:5170/";

const axiosConf: AxiosRequestConfig = {
  baseURL,
};

export const AxiosInstance = axios.create(axiosConf);
