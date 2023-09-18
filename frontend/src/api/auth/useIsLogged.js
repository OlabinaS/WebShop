import { useQuery } from "@tanstack/react-query";
import { useSendRequest } from "../useSendRequest";

const useIsLogged = () => {
  const sendRequest = useSendRequest("/users");

  return useQuery(["session"], async () => {
    try {
      const { data } = await sendRequest.get("/isLoggedIn");

      return data;
    } catch (error) {}
  });
};

export default useIsLogged;
