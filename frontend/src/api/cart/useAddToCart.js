import { useMutation, useQueryClient } from "@tanstack/react-query";
import { toast } from "react-toastify";
import useGetNewToken from "../auth/useGetNewToken";

export function useAddToCart() {
  const queryClient = useQueryClient();

  return useMutation(
    async (product) => {
      return product;
    },
    {
      onSuccess: (data) => {
        const products = queryClient.getQueryData(["cart"]);

        let newCart = [];

        if (products) {
          newCart = [...products];
        }

        newCart.push(data);

        queryClient.setQueryData(["cart"], newCart);
      },
      onError: () => {
        toast.error("Something went wrong, please try again later.");
      },
    }
  );
}
