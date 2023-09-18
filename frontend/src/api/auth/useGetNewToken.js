import { useQuery } from "@tanstack/react-query";
import { useSendRequest } from "../useSendRequest";

const useGetNewToken = () => {
  const sendRequest = useSendRequest("/users");

  return useQuery(["token"], async () => {
    try {
      const { data } = await sendRequest.get("/newToken");

      return data;
    } catch (error) {}
  });
};

export default useGetNewToken;
