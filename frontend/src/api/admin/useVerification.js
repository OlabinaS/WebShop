import { useQuery } from "@tanstack/react-query";
import { useSendRequest } from "../useSendRequest";

const useVerification = () => {
  const sendRequest = useSendRequest("/admin");

  return useQuery(["sellers"], async () => {
    try {
      const { data } = await sendRequest.get("/sellers");

      return data.sellers;
    } catch (error) {}
  });
};

export default useVerification;
