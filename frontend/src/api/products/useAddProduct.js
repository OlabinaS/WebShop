import { useMutation, useQueryClient } from "@tanstack/react-query";
import { useSendRequest } from "../useSendRequest";
import { useNavigate } from "react-router-dom";
import { toast } from "react-toastify";

export function useAddProduct() {
  const authService = useSendRequest("/seller");
  const navigate = useNavigate();

  return useMutation(
    async ({ name, price, quantity, description }) => {
      const formData = new FormData();
      formData.append("Name", name);
      formData.append("Price", price);
      formData.append("Quantity", quantity);
      formData.append("Description", description);

      await authService.post("/item", formData, {
        headers: {
          "Content-Type": "multipart/form-data", // Set the content type to form data
        },
      });
    },
    {
      onSuccess: () => {
        toast.success("You have successfully posted a product.");
        navigate("/");
      },
      onError: () => {
        toast.error("Something went wrong, please try again later.");
      },
    }
  );
}
