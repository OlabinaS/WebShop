import axios from "axios";
import { useMemo } from "react";

export const useSendRequest = (service) => {
  const baseURL = `https://localhost:44326/api${service}`;
  const token = localStorage.getItem("token");
  const Authorization = `Bearer ${token}`;

  return useMemo(() => {
    const axiosInstance = axios.create({
      baseURL,
      withCredentials: true,
      headers: {
        Accept: "application/json",
        "Content-Type": "application/json",
        "Access-Contol-Allow-Credentials": true,
        Authorization: Authorization,
      },
    });
    axiosInstance.defaults.headers.common["Set-Cookie"] = "SameSite=None;";
    axios.defaults.withCredentials = true;

    return axiosInstance;
  }, [service]);
};
