import { useQuery } from "@tanstack/react-query";
import { useSendRequest } from "../useSendRequest";

const useGetAllProducts = () => {
  const sendRequest = useSendRequest("/customer");

  return useQuery(["all-products"], async () => {
    try {
      const { data } = await sendRequest.get("/items");

      return data.items;
    } catch (error) {}
  });
};

export default useGetAllProducts;
