import { useMutation, useQueryClient } from "@tanstack/react-query";
import { useSendRequest } from "../useSendRequest";
import { useNavigate } from "react-router-dom";
import jwt_decode from "jwt-decode";

export function useLogin() {
  const authService = useSendRequest("/users");
  const queryClient = useQueryClient();
  const navigate = useNavigate();

  return useMutation(
    async ({ email, password }) => {
      const formData = new FormData();
      formData.append("Email", email);
      formData.append("Password", password);

      const { data } = await authService.post("/login", formData, {
        headers: {
          "Content-Type": "multipart/form-data", // Set the content type to form data
        },
      });

      return data;
    },
    {
      onSuccess: (data) => {
        localStorage.setItem('token', data);
        let decoded = jwt_decode(data);
        queryClient.setQueryData(["session"], decoded);
        navigate("/");
      },
    }
  );
}
